CREATE DATABASE DB_MiniMarket

USE DB_MiniMarket;

CREATE TABLE Categorias(
    Categoria_id INT NOT NULL IDENTITY(1, 1),
    Descripcion VARCHAR(100) NOT NULL,
    Estado BIT NOT NULL DEFAULT 1,

    PRIMARY KEY(Categoria_id)
)

CREATE TABLE Marcas(
    Marca_id INT NOT NULL IDENTITY(1, 1),
    Descripcion VARCHAR(100) NOT NULL,
    Estado BIT NOT NULL DEFAULT 1,

    PRIMARY KEY(Marca_id)
)

CREATE TABLE TiposEmpaques(
    Empaque_id INT NOT NULL IDENTITY(1, 1),
    Descripcion VARCHAR(50) NOT NULL, 
    CantidadUnidad DECIMAL(10, 2) NOT NULL, 
    Estado BIT NOT NULL DEFAULT 1,

    PRIMARY KEY(Empaque_id)
)

CREATE TABLE Usuarios(
    Usuario_id INT NOT NULL IDENTITY(1, 1),
    Nombre VARCHAR(100) NOT NULL,
    Usuario VARCHAR(50) UNIQUE NOT NULL,
    Contrasenia VARCHAR(255) NOT NULL,
    Rol INT NOT NULL, 
    Estado BIT NOT NULL DEFAULT 1,
    PRIMARY KEY(Usuario_id)
)

CREATE TABLE Proveedores(
    Proveedor_id INT NOT NULL IDENTITY(1, 1),
    Nombre VARCHAR(100) NOT NULL,
    CUIT VARCHAR(20),
    Direccion VARCHAR(200),
    Telefono VARCHAR(20),
    Email VARCHAR(100),
    Empresa VARCHAR(100),
    Estado BIT NOT NULL DEFAULT 1,
    
    PRIMARY KEY(Proveedor_id)
)

CREATE TABLE Productos(
    Producto_id INT NOT NULL IDENTITY(1, 1),
    CodigoBarras VARCHAR(20) UNIQUE NOT NULL,
    id_Categoria INT NOT NULL,
    id_Marca INT NOT NULL,
    id_Empaque INT NOT NULL,
    Descripcion VARCHAR(500) NOT NULL,
    Stock_min DECIMAL(10, 2) DEFAULT 0,
    Estado BIT NOT NULL DEFAULT 1,

    PRIMARY KEY(Producto_id),
    FOREIGN KEY(id_Categoria) REFERENCES Categorias(Categoria_id),
    FOREIGN KEY(id_Marca) REFERENCES Marcas(Marca_id),
    FOREIGN KEY(id_Empaque) REFERENCES TiposEmpaques(Empaque_id)
)

CREATE TABLE StockProductos(
    Stock_id INT NOT NULL IDENTITY(1, 1),
    id_Producto INT NOT NULL,
    Stock_actual DECIMAL(10, 2) DEFAULT 0,
    PrecioDia DECIMAL(10, 2) DEFAULT 0,
    PrecioNoche DECIMAL(10, 2) DEFAULT 0,

    PRIMARY KEY(Stock_id),
    FOREIGN KEY(id_Producto) REFERENCES Productos(Producto_id)
)

CREATE TABLE Compras(
    Compra_id INT NOT NULL IDENTITY(1, 1),
    id_Proveedor INT NOT NULL,
    Fecha DATETIME NOT NULL,
    Total_importe DECIMAL(10, 2) NOT NULL,
    Estado BIT NOT NULL DEFAULT 1,

    PRIMARY KEY(Compra_id),
    FOREIGN KEY(id_Proveedor) REFERENCES Proveedores(Proveedor_id)
)

CREATE TABLE DetalleCompras(
    Detalle_id INT NOT NULL IDENTITY(1, 1),
    id_Compra INT NOT NULL,
    id_Producto INT NOT NULL,
    id_Marca INT NOT NULL,
    Cantidad DECIMAL(10, 2) NOT NULL,
    PrecioCompra DECIMAL(10, 2) NOT NULL,
    Subtotal DECIMAL(10, 2) NOT NULL,
    Estado BIT NOT NULL DEFAULT 1,

    PRIMARY KEY(Detalle_id),
    FOREIGN KEY(id_Compra) REFERENCES Compras(Compra_id),
    FOREIGN KEY(id_Producto) REFERENCES Productos(Producto_id),
    FOREIGN KEY(id_Marca) REFERENCES Marcas(Marca_id)
)

CREATE TABLE TurnosCajero (
    Turno_id INT NOT NULL IDENTITY(1,1),
    id_Usuario INT NOT NULL,
    FechaInicio DATETIME NOT NULL,
    FechaFin DATETIME NULL,
    MontoRecaudado DECIMAL(10,2) NULL,
    Estado BIT NOT NULL DEFAULT 1, 

    PRIMARY KEY(Turno_id),
    FOREIGN KEY (id_Usuario) REFERENCES Usuarios(Usuario_id)
);

CREATE TABLE Ventas(
    Venta_id INT NOT NULL IDENTITY(1, 1),
    id_Usuario INT NOT NULL,
    id_Turno INT NOT NULL,
    Fecha DATETIME NOT NULL,
    Total_importe DECIMAL(10, 2) NOT NULL,
    Estado BIT NOT NULL DEFAULT 1,

    PRIMARY KEY(Venta_id),
    FOREIGN KEY(id_Usuario) REFERENCES Usuarios(Usuario_id),
    FOREIGN KEY (id_Turno) REFERENCES TurnosCajero(Turno_id)
)

CREATE TABLE DetalleVentas(
    DetalleVenta_id INT NOT NULL IDENTITY(1, 1),
    id_Venta INT NOT NULL,
    id_Producto INT NOT NULL,
    id_Marca INT NOT NULL,
    Cantidad DECIMAL(10, 2) NOT NULL,
    PrecioUnitario DECIMAL(10, 2) NOT NULL,
    Subtotal DECIMAL(10, 2) NOT NULL,
    Estado BIT NOT NULL DEFAULT 1,

    PRIMARY KEY(DetalleVenta_id),
    FOREIGN KEY(id_Venta) REFERENCES Ventas(Venta_id),
    FOREIGN KEY(id_Producto) REFERENCES Productos(Producto_id),
    FOREIGN KEY(id_Marca) REFERENCES Marcas(Marca_id)
)

GO

CREATE PROCEDURE SP_INSERTAR_USER
(
    @nombre VARCHAR(25),
    @usuario VARCHAR(25),   
    @pass VARCHAR(255)
)
AS
BEGIN
    INSERT INTO Usuarios(Nombre, Usuario, Contrasenia, Rol)
    OUTPUT inserted.Usuario_Id VALUES (@nombre, @usuario, @pass, 2)
END

GO

CREATE PROCEDURE AgregarProducto
    @CodigoBarras VARCHAR(50),
    @id_Categoria INT,
    @id_Marca INT,
    @id_Empaque INT,
    @Descripcion NVARCHAR(100),
    @Stock_min INT
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Productos (CodigoBarras, id_Categoria, id_Marca, id_Empaque, Descripcion, Stock_min)
    VALUES (@CodigoBarras, @id_Categoria, @id_Marca, @id_Empaque, @Descripcion, @Stock_min);

    SELECT SCOPE_IDENTITY(); 
END


GO

CREATE TYPE dbo.DetalleCompraType AS TABLE
(
    id_Producto INT,
    id_Marca INT,
    Cantidad DECIMAL(10,2),
    StockCalculado DECIMAL(10,2),
    PrecioCompra DECIMAL(10,2),
    Subtotal DECIMAL(10,2)
)

GO

CREATE TYPE dbo.DetalleVentaType AS TABLE
(
    id_Producto INT,
    id_Marca INT,
    Cantidad DECIMAL(10,2),
    PrecioUnitario DECIMAL(10,2),
    Subtotal DECIMAL(10,2)
)

GO

CREATE PROCEDURE AgregarCompraConDetalles
    @idProveedor INT,
    @Fecha DATETIME,
    @Total DECIMAL(10,2),
    @Detalles dbo.DetalleCompraType READONLY
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- 1. Insertar compra y obtener ID
        DECLARE @idCompra INT;

        INSERT INTO Compras (id_Proveedor, Fecha, Total_importe)
        VALUES (@idProveedor, @Fecha, @Total);

        SET @idCompra = SCOPE_IDENTITY();

        -- 2. Insertar detalles
        INSERT INTO DetalleCompras (id_Compra, id_Producto, id_Marca, Cantidad, PrecioCompra, Subtotal)
        SELECT @idCompra, id_Producto, id_Marca, Cantidad, PrecioCompra, Subtotal
        FROM @Detalles;

        -- 3. Actualizar stock
        UPDATE s
        SET s.Stock_actual = s.Stock_actual + d.StockCalculado
        FROM StockProductos s
        INNER JOIN @Detalles d ON s.id_Producto = d.id_Producto;

        COMMIT TRANSACTION;
        SELECT @idCompra;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END

GO

CREATE PROCEDURE AgregarVentaConDetalles
    @idUsuario INT,
    @idTurno INT,
    @Fecha DATETIME,
    @Total DECIMAL(10,2),
    @Detalles dbo.DetalleVentaType READONLY
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- 1. Insertar venta y obtener ID
        DECLARE @idVenta INT;

        INSERT INTO Ventas (id_Usuario, id_Turno, Fecha, Total_importe)
        VALUES (@idUsuario, @idTurno, @Fecha, @Total);

        SET @idVenta = SCOPE_IDENTITY();

        -- 2. Validar stock suficiente
        IF EXISTS (
            SELECT 1
            FROM StockProductos s
            INNER JOIN @Detalles d ON s.id_Producto = d.id_Producto
            WHERE s.Stock_actual < d.Cantidad
        )
        BEGIN
            RAISERROR('Stock insuficiente para uno o más productos.', 16, 1);
            ROLLBACK TRANSACTION;
            RETURN;
        END

        -- 3. Insertar detalles
        INSERT INTO DetalleVentas (id_Venta, id_Producto, id_Marca, Cantidad, PrecioUnitario, Subtotal)
        SELECT @idVenta, id_Producto, id_Marca, Cantidad, PrecioUnitario, Subtotal
        FROM @Detalles;

        -- 4. Actualizar stock
        UPDATE s
        SET s.Stock_actual = s.Stock_actual - d.Cantidad
        FROM StockProductos s
        INNER JOIN @Detalles d ON s.id_Producto = d.id_Producto;

        COMMIT TRANSACTION;
        SELECT @idVenta;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END

GO

CREATE PROCEDURE EliminarCompra
    @idCompra INT
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        -- 1. Revertir el stock de los productos
        UPDATE s
        SET s.Stock_actual = s.Stock_actual - d.Cantidad
        FROM StockProductos s
        INNER JOIN DetalleCompras d ON s.id_Producto = d.id_Producto
        WHERE d.id_Compra = @idCompra;

        -- 2. Eliminar los detalles de la compra
        UPDATE DetalleCompras SET Estado = 0 WHERE id_Compra = @idCompra;

        -- 3. Eliminar la compra
        UPDATE Compras SET Estado = 0 WHERE Compra_id = @idCompra;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END

GO

CREATE PROCEDURE AbrirTurnoCajero
    @idUsuario INT,
    @FechaInicio DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO TurnosCajero (id_Usuario, FechaInicio, Estado)
    VALUES (@idUsuario, @FechaInicio, 1);

    SELECT SCOPE_IDENTITY() AS Turno_id;
END

GO

CREATE PROCEDURE CerrarTurnoCajero
    @idTurno INT,
    @FechaFin DATETIME
AS
BEGIN
    BEGIN TRY
        BEGIN TRANSACTION;

        DECLARE 
            @FechaInicio DATETIME,
            @idUsuario INT,
            @MontoTotal DECIMAL(10, 2);

        -- Obtener datos del turno
        SELECT @FechaInicio = FechaInicio,
               @idUsuario = id_Usuario
        FROM TurnosCajero
        WHERE Turno_id = @idTurno AND Estado = 1;

        IF @FechaInicio IS NULL
        BEGIN
            RAISERROR('El turno no existe o ya está cerrado.', 16, 1);
            ROLLBACK;
            RETURN;
        END

        -- Calcular la recaudación de ventas asociadas al turno
        SELECT @MontoTotal = ISNULL(SUM(Total_importe), 0)
        FROM Ventas
        WHERE id_Turno = @idTurno AND Estado = 1;

        -- Actualizar el turno
        UPDATE TurnosCajero
        SET FechaFin = @FechaFin,
            MontoRecaudado = @MontoTotal,
            Estado = 0
        WHERE Turno_id = @idTurno;

        COMMIT;

        SELECT 
            @idTurno AS Turno_id,
            @idUsuario AS Usuario_id,
            @FechaInicio AS FechaInicio,
            @FechaFin AS FechaFin,
            @MontoTotal AS MontoRecaudado;

    END TRY
    BEGIN CATCH
        ROLLBACK;
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        RAISERROR(@ErrorMessage, 16, 1);
    END CATCH
END

GO

--REPORTES
--0. Productos Activos de la Tienda
CREATE PROCEDURE ListarProductosActivos
AS
BEGIN
    SELECT 
        p.Producto_id, 
        p.Descripcion, 
        c.Descripcion AS Categoria, 
        m.Descripcion AS Marca, 
        te.Descripcion AS Empaque
    FROM Productos AS p
    INNER JOIN Categorias AS c ON p.id_Categoria = c.Categoria_id
    INNER JOIN Marcas AS m ON p.id_Marca = m.Marca_id
    INNER JOIN TiposEmpaques AS te ON p.id_Empaque = te.Empaque_id
    WHERE p.Estado = 1
    ORDER BY p.Descripcion;
END

GO

--1. Reporte de Ventas por Rango de Fecha (diario, semanal, mensual)

CREATE PROCEDURE ReporteVentasPorRango
    @FechaDesde DATE,
    @FechaHasta DATE
AS
BEGIN
    SELECT 
        v.Venta_id,
        v.Fecha,
        u.Nombre AS Vendedor,
        v.Total_importe
    FROM Ventas v
    INNER JOIN Usuarios u ON v.id_Usuario = u.Usuario_id
    WHERE CAST(v.Fecha AS DATE) BETWEEN @FechaDesde AND @FechaHasta
      AND v.Estado = 1
    ORDER BY v.Fecha ASC;
END

GO

--2. Reporte de Productos con Stock Actual vs Stock Mínimo
CREATE PROCEDURE ReporteStockVsMinimo
AS
BEGIN
    SELECT 
        p.Producto_id,
        p.Descripcion,
        s.Stock_actual,
        p.Stock_min,
        CASE 
            WHEN s.Stock_actual < p.Stock_min THEN 'Bajo Stock'
            ELSE 'OK'
        END AS EstadoStock
    FROM Productos p
    INNER JOIN StockProductos s ON p.Producto_id = s.id_Producto
    WHERE p.Estado = 1
    ORDER BY s.Stock_actual ASC;
END

GO

--3. Historial de Precios de Compra
CREATE PROCEDURE ReporteHistorialPreciosCompra
    @idProducto INT
AS
BEGIN
    SELECT 
        c.Compra_id,
        CAST(c.Fecha AS DATE) AS Fecha,
        pr.Nombre AS Proveedor,
        d.PrecioCompra,
        d.Cantidad,
        d.Subtotal
    FROM DetalleCompras d
    INNER JOIN Compras c ON d.id_Compra = c.Compra_id
    INNER JOIN Proveedores pr ON c.id_Proveedor = pr.Proveedor_id
    WHERE d.id_Producto = @idProducto
      AND c.Estado = 1
    ORDER BY c.Fecha DESC;
END

GO

--4. Reporte de Ventas por Vendedor (Día / Turno)
CREATE PROCEDURE ReporteVentasPorVendedor
    @idUsuario INT,
    @FechaDesde DATE,
    @FechaHasta DATE
AS
BEGIN
    SELECT 
        u.Nombre AS Vendedor,
        t.FechaInicio AS FechaInicio,
        t.FechaFin AS FechaFin,
        COUNT(v.Venta_id) AS CantidadVentas,
        SUM(v.Total_importe) AS TotalVendido
    FROM Ventas v
    INNER JOIN Usuarios u ON v.id_Usuario = u.Usuario_id
    INNER JOIN TurnosCajero t ON v.id_Turno = t.Turno_id
    WHERE CAST(v.Fecha AS DATE) BETWEEN @FechaDesde AND @FechaHasta
      AND v.Estado = 1
      AND u.Usuario_id = @idUsuario
    GROUP BY u.Nombre, t.Turno_id, t.FechaInicio, t.FechaFin
    ORDER BY t.FechaInicio;
END

GO

--Insert Usuarios (pass12345)
INSERT INTO Usuarios (Nombre, Usuario, Contrasenia, Rol)
VALUES
('ADMIN', 'ADMIN', 'AQAAAAEAACcQAAAAEC2hOEN9kLTZjr2GGnz2XhpbSsQckezzTywNdzHXrTMe6APaSYbio+6QUVRjeBH3wA==', 1)