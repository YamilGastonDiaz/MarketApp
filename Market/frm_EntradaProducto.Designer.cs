namespace Market
{
    partial class frm_EntradaProducto
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_EntradaProducto));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tab_Principal = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.txt_Buscar = new System.Windows.Forms.TextBox();
            this.lbl_Buscar = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.pnl_ListaProducto = new System.Windows.Forms.Panel();
            this.btn_RetornarPR = new System.Windows.Forms.Button();
            this.btn_BuscarPR = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgv_Producto = new System.Windows.Forms.DataGridView();
            this.txt_Total = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnl_ListadoProveedor = new System.Windows.Forms.Panel();
            this.btn_RetornarP = new System.Windows.Forms.Button();
            this.btn_BuscarP1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv_Proveedor = new System.Windows.Forms.DataGridView();
            this.btn_LupaProveedor = new System.Windows.Forms.Button();
            this.dtp_Fecha = new System.Windows.Forms.DateTimePicker();
            this.btn_Quitar = new System.Windows.Forms.Button();
            this.btn_Agregar = new System.Windows.Forms.Button();
            this.pnl_ProductoEntrada = new System.Windows.Forms.Panel();
            this.dgv_ListaDetalle = new System.Windows.Forms.DataGridView();
            this.lbl_Categoria = new System.Windows.Forms.Label();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.txt_Proveedor = new System.Windows.Forms.TextBox();
            this.lbl_Producto = new System.Windows.Forms.Label();
            this.btn_Nuevo = new System.Windows.Forms.Button();
            this.btn_Elimiar = new System.Windows.Forms.Button();
            this.btn_Reporte = new System.Windows.Forms.Button();
            this.btn_Salir = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dgv_Principal = new System.Windows.Forms.DataGridView();
            this.tab_Principal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.pnl_ListaProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Producto)).BeginInit();
            this.pnl_ListadoProveedor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Proveedor)).BeginInit();
            this.pnl_ProductoEntrada.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListaDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Principal)).BeginInit();
            this.SuspendLayout();
            // 
            // tab_Principal
            // 
            this.tab_Principal.Controls.Add(this.tabPage1);
            this.tab_Principal.Controls.Add(this.tabPage2);
            this.tab_Principal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tab_Principal.Location = new System.Drawing.Point(12, 12);
            this.tab_Principal.Name = "tab_Principal";
            this.tab_Principal.SelectedIndex = 0;
            this.tab_Principal.Size = new System.Drawing.Size(1014, 414);
            this.tab_Principal.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.dgv_Principal);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.btn_Buscar);
            this.tabPage1.Controls.Add(this.txt_Buscar);
            this.tabPage1.Controls.Add(this.lbl_Buscar);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1006, 388);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado";
            // 
            // btn_Buscar
            // 
            this.btn_Buscar.BackColor = System.Drawing.Color.Black;
            this.btn_Buscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Buscar.Location = new System.Drawing.Point(455, 20);
            this.btn_Buscar.Name = "btn_Buscar";
            this.btn_Buscar.Size = new System.Drawing.Size(75, 23);
            this.btn_Buscar.TabIndex = 2;
            this.btn_Buscar.Text = "BUSCAR";
            this.btn_Buscar.UseVisualStyleBackColor = false;
            // 
            // txt_Buscar
            // 
            this.txt_Buscar.Location = new System.Drawing.Point(81, 22);
            this.txt_Buscar.Name = "txt_Buscar";
            this.txt_Buscar.Size = new System.Drawing.Size(368, 20);
            this.txt_Buscar.TabIndex = 1;
            // 
            // lbl_Buscar
            // 
            this.lbl_Buscar.AutoSize = true;
            this.lbl_Buscar.Location = new System.Drawing.Point(6, 29);
            this.lbl_Buscar.Name = "lbl_Buscar";
            this.lbl_Buscar.Size = new System.Drawing.Size(69, 13);
            this.lbl_Buscar.TabIndex = 0;
            this.lbl_Buscar.Text = "BUSCAR:  ";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage2.Controls.Add(this.pnl_ListaProducto);
            this.tabPage2.Controls.Add(this.txt_Total);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.pnl_ListadoProveedor);
            this.tabPage2.Controls.Add(this.btn_LupaProveedor);
            this.tabPage2.Controls.Add(this.dtp_Fecha);
            this.tabPage2.Controls.Add(this.btn_Quitar);
            this.tabPage2.Controls.Add(this.btn_Agregar);
            this.tabPage2.Controls.Add(this.pnl_ProductoEntrada);
            this.tabPage2.Controls.Add(this.lbl_Categoria);
            this.tabPage2.Controls.Add(this.btn_Guardar);
            this.tabPage2.Controls.Add(this.btn_Cancelar);
            this.tabPage2.Controls.Add(this.txt_Proveedor);
            this.tabPage2.Controls.Add(this.lbl_Producto);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1006, 388);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            // 
            // pnl_ListaProducto
            // 
            this.pnl_ListaProducto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_ListaProducto.Controls.Add(this.btn_RetornarPR);
            this.pnl_ListaProducto.Controls.Add(this.btn_BuscarPR);
            this.pnl_ListaProducto.Controls.Add(this.textBox2);
            this.pnl_ListaProducto.Controls.Add(this.label5);
            this.pnl_ListaProducto.Controls.Add(this.label4);
            this.pnl_ListaProducto.Controls.Add(this.dgv_Producto);
            this.pnl_ListaProducto.Location = new System.Drawing.Point(893, 20);
            this.pnl_ListaProducto.Name = "pnl_ListaProducto";
            this.pnl_ListaProducto.Size = new System.Drawing.Size(777, 239);
            this.pnl_ListaProducto.TabIndex = 17;
            this.pnl_ListaProducto.Visible = false;
            // 
            // btn_RetornarPR
            // 
            this.btn_RetornarPR.Location = new System.Drawing.Point(735, 3);
            this.btn_RetornarPR.Name = "btn_RetornarPR";
            this.btn_RetornarPR.Size = new System.Drawing.Size(35, 23);
            this.btn_RetornarPR.TabIndex = 5;
            this.btn_RetornarPR.Text = ":::";
            this.btn_RetornarPR.UseVisualStyleBackColor = true;
            this.btn_RetornarPR.Click += new System.EventHandler(this.btn_RetornarPR_Click);
            // 
            // btn_BuscarPR
            // 
            this.btn_BuscarPR.Location = new System.Drawing.Point(349, 27);
            this.btn_BuscarPR.Name = "btn_BuscarPR";
            this.btn_BuscarPR.Size = new System.Drawing.Size(35, 23);
            this.btn_BuscarPR.TabIndex = 4;
            this.btn_BuscarPR.Text = ":::";
            this.btn_BuscarPR.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(79, 29);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(264, 20);
            this.textBox2.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Busacar: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(346, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "LISTADO PRODUCTO";
            // 
            // dgv_Producto
            // 
            this.dgv_Producto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Producto.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgv_Producto.Location = new System.Drawing.Point(3, 56);
            this.dgv_Producto.Name = "dgv_Producto";
            this.dgv_Producto.Size = new System.Drawing.Size(767, 176);
            this.dgv_Producto.TabIndex = 0;
            this.dgv_Producto.DoubleClick += new System.EventHandler(this.dgv_Producto_DoubleClick);
            // 
            // txt_Total
            // 
            this.txt_Total.Location = new System.Drawing.Point(841, 358);
            this.txt_Total.Name = "txt_Total";
            this.txt_Total.Size = new System.Drawing.Size(155, 20);
            this.txt_Total.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(780, 365);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "TOTAL: ";
            // 
            // pnl_ListadoProveedor
            // 
            this.pnl_ListadoProveedor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_ListadoProveedor.Controls.Add(this.btn_RetornarP);
            this.pnl_ListadoProveedor.Controls.Add(this.btn_BuscarP1);
            this.pnl_ListadoProveedor.Controls.Add(this.textBox1);
            this.pnl_ListadoProveedor.Controls.Add(this.label2);
            this.pnl_ListadoProveedor.Controls.Add(this.label1);
            this.pnl_ListadoProveedor.Controls.Add(this.dgv_Proveedor);
            this.pnl_ListadoProveedor.Location = new System.Drawing.Point(947, 6);
            this.pnl_ListadoProveedor.Name = "pnl_ListadoProveedor";
            this.pnl_ListadoProveedor.Size = new System.Drawing.Size(452, 244);
            this.pnl_ListadoProveedor.TabIndex = 14;
            this.pnl_ListadoProveedor.Visible = false;
            // 
            // btn_RetornarP
            // 
            this.btn_RetornarP.Location = new System.Drawing.Point(410, 2);
            this.btn_RetornarP.Name = "btn_RetornarP";
            this.btn_RetornarP.Size = new System.Drawing.Size(35, 23);
            this.btn_RetornarP.TabIndex = 5;
            this.btn_RetornarP.Text = ":::";
            this.btn_RetornarP.UseVisualStyleBackColor = true;
            this.btn_RetornarP.Click += new System.EventHandler(this.btn_RetornarP_Click);
            // 
            // btn_BuscarP1
            // 
            this.btn_BuscarP1.Location = new System.Drawing.Point(410, 49);
            this.btn_BuscarP1.Name = "btn_BuscarP1";
            this.btn_BuscarP1.Size = new System.Drawing.Size(35, 23);
            this.btn_BuscarP1.TabIndex = 4;
            this.btn_BuscarP1.Text = ":::";
            this.btn_BuscarP1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(65, 51);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(339, 20);
            this.textBox1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Buscar: ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(158, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "LISTADO PROVEEDORES";
            // 
            // dgv_Proveedor
            // 
            this.dgv_Proveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Proveedor.DefaultCellStyle = dataGridViewCellStyle9;
            this.dgv_Proveedor.Location = new System.Drawing.Point(4, 80);
            this.dgv_Proveedor.Name = "dgv_Proveedor";
            this.dgv_Proveedor.Size = new System.Drawing.Size(441, 153);
            this.dgv_Proveedor.TabIndex = 0;
            this.dgv_Proveedor.DoubleClick += new System.EventHandler(this.dgv_Proveedor_DoubleClick);
            // 
            // btn_LupaProveedor
            // 
            this.btn_LupaProveedor.Location = new System.Drawing.Point(352, 10);
            this.btn_LupaProveedor.Name = "btn_LupaProveedor";
            this.btn_LupaProveedor.Size = new System.Drawing.Size(41, 23);
            this.btn_LupaProveedor.TabIndex = 13;
            this.btn_LupaProveedor.Text = ":::";
            this.btn_LupaProveedor.UseVisualStyleBackColor = true;
            this.btn_LupaProveedor.Visible = false;
            this.btn_LupaProveedor.Click += new System.EventHandler(this.btn_LupaProveedor_Click);
            // 
            // dtp_Fecha
            // 
            this.dtp_Fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_Fecha.Location = new System.Drawing.Point(106, 44);
            this.dtp_Fecha.Name = "dtp_Fecha";
            this.dtp_Fecha.Size = new System.Drawing.Size(240, 20);
            this.dtp_Fecha.TabIndex = 12;
            // 
            // btn_Quitar
            // 
            this.btn_Quitar.BackColor = System.Drawing.Color.DarkRed;
            this.btn_Quitar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Quitar.Location = new System.Drawing.Point(87, 74);
            this.btn_Quitar.Name = "btn_Quitar";
            this.btn_Quitar.Size = new System.Drawing.Size(75, 32);
            this.btn_Quitar.TabIndex = 11;
            this.btn_Quitar.Text = "QUITAR";
            this.btn_Quitar.UseVisualStyleBackColor = false;
            this.btn_Quitar.Visible = false;
            this.btn_Quitar.Click += new System.EventHandler(this.btn_Quitar_Click);
            // 
            // btn_Agregar
            // 
            this.btn_Agregar.BackColor = System.Drawing.Color.DarkGreen;
            this.btn_Agregar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Agregar.Location = new System.Drawing.Point(6, 74);
            this.btn_Agregar.Name = "btn_Agregar";
            this.btn_Agregar.Size = new System.Drawing.Size(75, 32);
            this.btn_Agregar.TabIndex = 10;
            this.btn_Agregar.Text = "AGREGAR";
            this.btn_Agregar.UseVisualStyleBackColor = false;
            this.btn_Agregar.Visible = false;
            this.btn_Agregar.Click += new System.EventHandler(this.btn_Agregar_Click);
            // 
            // pnl_ProductoEntrada
            // 
            this.pnl_ProductoEntrada.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnl_ProductoEntrada.Controls.Add(this.dgv_ListaDetalle);
            this.pnl_ProductoEntrada.Location = new System.Drawing.Point(6, 112);
            this.pnl_ProductoEntrada.Name = "pnl_ProductoEntrada";
            this.pnl_ProductoEntrada.Size = new System.Drawing.Size(990, 237);
            this.pnl_ProductoEntrada.TabIndex = 9;
            // 
            // dgv_ListaDetalle
            // 
            this.dgv_ListaDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_ListaDetalle.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgv_ListaDetalle.Location = new System.Drawing.Point(4, 4);
            this.dgv_ListaDetalle.Name = "dgv_ListaDetalle";
            this.dgv_ListaDetalle.Size = new System.Drawing.Size(979, 226);
            this.dgv_ListaDetalle.TabIndex = 0;
            this.dgv_ListaDetalle.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_ListaDetalle_CellEndEdit);
            // 
            // lbl_Categoria
            // 
            this.lbl_Categoria.AutoSize = true;
            this.lbl_Categoria.Location = new System.Drawing.Point(6, 52);
            this.lbl_Categoria.Name = "lbl_Categoria";
            this.lbl_Categoria.Size = new System.Drawing.Size(67, 13);
            this.lbl_Categoria.TabIndex = 7;
            this.lbl_Categoria.Text = "Fecha (*): ";
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.Black;
            this.btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Guardar.Location = new System.Drawing.Point(164, 355);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(152, 23);
            this.btn_Guardar.TabIndex = 8;
            this.btn_Guardar.Text = "GUARDAR";
            this.btn_Guardar.UseVisualStyleBackColor = false;
            this.btn_Guardar.Visible = false;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.BackColor = System.Drawing.Color.Black;
            this.btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Cancelar.Location = new System.Drawing.Point(6, 355);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(152, 23);
            this.btn_Cancelar.TabIndex = 7;
            this.btn_Cancelar.Text = "CANCELAR";
            this.btn_Cancelar.UseVisualStyleBackColor = false;
            this.btn_Cancelar.Visible = false;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // txt_Proveedor
            // 
            this.txt_Proveedor.Location = new System.Drawing.Point(106, 12);
            this.txt_Proveedor.MaxLength = 500;
            this.txt_Proveedor.Name = "txt_Proveedor";
            this.txt_Proveedor.ReadOnly = true;
            this.txt_Proveedor.Size = new System.Drawing.Size(240, 20);
            this.txt_Proveedor.TabIndex = 1;
            // 
            // lbl_Producto
            // 
            this.lbl_Producto.AutoSize = true;
            this.lbl_Producto.Location = new System.Drawing.Point(6, 19);
            this.lbl_Producto.Name = "lbl_Producto";
            this.lbl_Producto.Size = new System.Drawing.Size(94, 13);
            this.lbl_Producto.TabIndex = 0;
            this.lbl_Producto.Text = "Proveedor (*):  ";
            // 
            // btn_Nuevo
            // 
            this.btn_Nuevo.BackColor = System.Drawing.Color.Black;
            this.btn_Nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Nuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Nuevo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Nuevo.Image = ((System.Drawing.Image)(resources.GetObject("btn_Nuevo.Image")));
            this.btn_Nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Nuevo.Location = new System.Drawing.Point(12, 432);
            this.btn_Nuevo.Name = "btn_Nuevo";
            this.btn_Nuevo.Size = new System.Drawing.Size(75, 56);
            this.btn_Nuevo.TabIndex = 1;
            this.btn_Nuevo.Text = "NUEVO";
            this.btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Nuevo.UseVisualStyleBackColor = false;
            this.btn_Nuevo.Click += new System.EventHandler(this.btn_Nuevo_Click);
            // 
            // btn_Elimiar
            // 
            this.btn_Elimiar.BackColor = System.Drawing.Color.Black;
            this.btn_Elimiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Elimiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Elimiar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Elimiar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Elimiar.Image")));
            this.btn_Elimiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Elimiar.Location = new System.Drawing.Point(93, 432);
            this.btn_Elimiar.Name = "btn_Elimiar";
            this.btn_Elimiar.Size = new System.Drawing.Size(75, 56);
            this.btn_Elimiar.TabIndex = 3;
            this.btn_Elimiar.Text = "ELIMINAR";
            this.btn_Elimiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Elimiar.UseVisualStyleBackColor = false;
            this.btn_Elimiar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // btn_Reporte
            // 
            this.btn_Reporte.BackColor = System.Drawing.Color.Black;
            this.btn_Reporte.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Reporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reporte.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Reporte.Image = ((System.Drawing.Image)(resources.GetObject("btn_Reporte.Image")));
            this.btn_Reporte.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Reporte.Location = new System.Drawing.Point(174, 432);
            this.btn_Reporte.Name = "btn_Reporte";
            this.btn_Reporte.Size = new System.Drawing.Size(75, 57);
            this.btn_Reporte.TabIndex = 4;
            this.btn_Reporte.Text = "REPORTE";
            this.btn_Reporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Reporte.UseVisualStyleBackColor = false;
            // 
            // btn_Salir
            // 
            this.btn_Salir.BackColor = System.Drawing.Color.Black;
            this.btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Salir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_Salir.Image")));
            this.btn_Salir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Salir.Location = new System.Drawing.Point(255, 432);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(75, 57);
            this.btn_Salir.TabIndex = 5;
            this.btn_Salir.Text = "SALIR";
            this.btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Salir.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(147, 361);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(563, 16);
            this.label6.TabIndex = 4;
            this.label6.Text = "* HACER DOBLE CLICK EN LA CELDA DE LA COMPRA PARA VER SU DETALLE.";
            // 
            // dgv_Principal
            // 
            this.dgv_Principal.AllowUserToAddRows = false;
            this.dgv_Principal.AllowUserToDeleteRows = false;
            this.dgv_Principal.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.dgv_Principal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_Principal.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Principal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_Principal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Principal.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_Principal.EnableHeadersVisualStyles = false;
            this.dgv_Principal.Location = new System.Drawing.Point(144, 61);
            this.dgv_Principal.Name = "dgv_Principal";
            this.dgv_Principal.ReadOnly = true;
            this.dgv_Principal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_Principal.Size = new System.Drawing.Size(723, 289);
            this.dgv_Principal.TabIndex = 3;
            this.dgv_Principal.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Principal_CellDoubleClick);
            // 
            // frm_EntradaProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(1038, 500);
            this.Controls.Add(this.btn_Salir);
            this.Controls.Add(this.btn_Reporte);
            this.Controls.Add(this.btn_Elimiar);
            this.Controls.Add(this.btn_Nuevo);
            this.Controls.Add(this.tab_Principal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_EntradaProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Entrada Productos";
            this.Load += new System.EventHandler(this.frm_EntradaProducto_Load);
            this.tab_Principal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.pnl_ListaProducto.ResumeLayout(false);
            this.pnl_ListaProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Producto)).EndInit();
            this.pnl_ListadoProveedor.ResumeLayout(false);
            this.pnl_ListadoProveedor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Proveedor)).EndInit();
            this.pnl_ProductoEntrada.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_ListaDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Principal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_Principal;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.TextBox txt_Buscar;
        private System.Windows.Forms.Label lbl_Buscar;
        private System.Windows.Forms.Button btn_Nuevo;
        private System.Windows.Forms.Button btn_Elimiar;
        private System.Windows.Forms.Button btn_Reporte;
        private System.Windows.Forms.Button btn_Salir;
        private System.Windows.Forms.TextBox txt_Proveedor;
        private System.Windows.Forms.Label lbl_Producto;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Label lbl_Categoria;
        private System.Windows.Forms.Panel pnl_ProductoEntrada;
        private System.Windows.Forms.Button btn_Quitar;
        private System.Windows.Forms.Button btn_Agregar;
        private System.Windows.Forms.Button btn_LupaProveedor;
        private System.Windows.Forms.DateTimePicker dtp_Fecha;
        private System.Windows.Forms.Panel pnl_ListadoProveedor;
        private System.Windows.Forms.DataGridView dgv_Proveedor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_BuscarP1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btn_RetornarP;
        private System.Windows.Forms.Panel pnl_ListaProducto;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgv_Producto;
        private System.Windows.Forms.TextBox txt_Total;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_RetornarPR;
        private System.Windows.Forms.Button btn_BuscarPR;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_ListaDetalle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgv_Principal;
    }
}

