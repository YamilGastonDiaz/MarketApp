USE DB_MiniMarket;

--CATEGORIA
INSERT INTO Categorias (Descripcion) VALUES
('Bebidas'),
('Galletitas'),
('Limpieza'),
('Fiambres');

--MARCA
INSERT INTO Marcas (Descripcion) VALUES
('Coca-Cola'),
('Pepsi'),
('Oreo'),
('Ala'),
('La Serenísima');

--TIPOS EMPAQUES
INSERT INTO TiposEmpaques (Descripcion, CantidadUnidad) VALUES
('Unidad', 1),
('Pack 6', 6),
('Caja', 12);

--PROVEEDORES
INSERT INTO Proveedores (Nombre, CUIT, Direccion, Telefono, Email, Empresa) VALUES
('Distribuidora Sur', '20-12345678-9', 'Av. Siempre Viva 123', '1122334455', 'ventas@sur.com', 'Dist. Sur'),
('Mayorista Norte', '30-98765432-1', 'Calle Falsa 222', '1199887766', 'info@norte.com', 'Mayorista Norte');

--PRODUCTOS
INSERT INTO Productos (CodigoBarras, id_Categoria, id_Marca, id_Empaque, Descripcion, Stock_min)
VALUES
('779000100001', 1, 1, 1, 'Coca-Cola 2L', 10),
('779000100002', 1, 2, 1, 'Pepsi 2L', 10),
('779000200001', 2, 3, 1, 'Oreo Clásica', 15),
('779000300001', 3, 4, 1, 'Detergente Ala 1L', 8),
('779000400001', 4, 5, 1, 'Queso Cremoso', 5);

--STOCK
INSERT INTO StockProductos (id_Producto, Stock_actual, PrecioDia, PrecioNoche) VALUES
(1, 50, 1200, 1300),
(2, 40, 1100, 1200),
(3, 100, 500, 550),
(4, 30, 900, 950),
(5, 20, 2500, 2600);

-- Compra 1
INSERT INTO Compras (id_Proveedor, Fecha, Total_importe) VALUES
(1, '2025-01-05', 150000);

INSERT INTO DetalleCompras (id_Compra, id_Producto, id_Marca, Cantidad, PrecioCompra, Subtotal) VALUES
(1, 1, 1, 30, 800, 24000),
(1, 3, 3, 50, 350, 17500);

-- Compra 2
INSERT INTO Compras (id_Proveedor, Fecha, Total_importe) VALUES
(2, '2025-01-10', 180000);

INSERT INTO DetalleCompras (id_Compra, id_Producto, id_Marca, Cantidad, PrecioCompra, Subtotal) VALUES
(2, 2, 2, 40, 750, 30000),
(2, 4, 4, 20, 700, 14000),
(2, 5, 5, 15, 1800, 27000);

--USUARIOS
INSERT INTO Usuarios (Nombre, Usuario, Contrasenia, Rol)
VALUES
('Juan Pérez', 'juanp', '123', 2),
('María López', 'marial', '123', 2);

--TURNO CAJERO
INSERT INTO TurnosCajero (id_Usuario, FechaInicio, FechaFin, MontoRecaudado, Estado) VALUES
(2, '2025-01-12 08:00:00', '2025-01-12 16:00:00', 45000, 0),
(3, '2025-01-12 16:00:00', '2025-01-12 23:00:00', 52000, 0);

-- Venta 1
INSERT INTO Ventas (id_Usuario, id_Turno, Fecha, Total_importe) VALUES
(2, 1, '2025-01-12 10:30:00', 3500);

INSERT INTO DetalleVentas (id_Venta, id_Producto, id_Marca, Cantidad, PrecioUnitario, Subtotal) VALUES
(1, 1, 1, 2, 1200, 2400),
(1, 3, 3, 2, 500, 1000);

-- Venta 2
INSERT INTO Ventas (id_Usuario, id_Turno, Fecha, Total_importe) VALUES
(3, 2, '2025-01-12 19:20:00', 4300);

INSERT INTO DetalleVentas (id_Venta, id_Producto, id_Marca, Cantidad, PrecioUnitario, Subtotal) VALUES
(2, 2, 2, 2, 1100, 2200),
(2, 5, 5, 1, 2500, 2500);