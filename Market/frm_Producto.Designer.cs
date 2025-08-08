namespace Market
{
    partial class frm_Producto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Producto));
            this.tab_Principal = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dgv_Principal = new System.Windows.Forms.DataGridView();
            this.btn_Buscar = new System.Windows.Forms.Button();
            this.txt_Buscar = new System.Windows.Forms.TextBox();
            this.lbl_Buscar = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.cbox_Unidad = new System.Windows.Forms.ComboBox();
            this.lbl_Unidad = new System.Windows.Forms.Label();
            this.cbox_Marca = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbox_Categoria = new System.Windows.Forms.ComboBox();
            this.lbl_Categoria = new System.Windows.Forms.Label();
            this.txt_Stockmax = new System.Windows.Forms.TextBox();
            this.lbl_Stockmax = new System.Windows.Forms.Label();
            this.txt_Stockmin = new System.Windows.Forms.TextBox();
            this.lbl_Stockmin = new System.Windows.Forms.Label();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.txt_Producto_dc = new System.Windows.Forms.TextBox();
            this.lbl_Producto = new System.Windows.Forms.Label();
            this.btn_Nuevo = new System.Windows.Forms.Button();
            this.btn_Actualizar = new System.Windows.Forms.Button();
            this.btn_Elimiar = new System.Windows.Forms.Button();
            this.btn_Reporte = new System.Windows.Forms.Button();
            this.btn_Salir = new System.Windows.Forms.Button();
            this.txt_CodigoBarra = new System.Windows.Forms.TextBox();
            this.lbl_CodigoBarra = new System.Windows.Forms.Label();
            this.tab_Principal.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Principal)).BeginInit();
            this.tabPage2.SuspendLayout();
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
            this.tab_Principal.Size = new System.Drawing.Size(1140, 350);
            this.tab_Principal.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.dgv_Principal);
            this.tabPage1.Controls.Add(this.btn_Buscar);
            this.tabPage1.Controls.Add(this.txt_Buscar);
            this.tabPage1.Controls.Add(this.lbl_Buscar);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1132, 324);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listado";
            // 
            // dgv_Principal
            // 
            this.dgv_Principal.AllowUserToAddRows = false;
            this.dgv_Principal.AllowUserToDeleteRows = false;
            this.dgv_Principal.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.dgv_Principal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_Principal.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Principal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Principal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Principal.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Principal.EnableHeadersVisualStyles = false;
            this.dgv_Principal.Location = new System.Drawing.Point(6, 53);
            this.dgv_Principal.Name = "dgv_Principal";
            this.dgv_Principal.ReadOnly = true;
            this.dgv_Principal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv_Principal.Size = new System.Drawing.Size(1116, 261);
            this.dgv_Principal.TabIndex = 3;
            this.dgv_Principal.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Principal_CellDoubleClick);
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
            this.tabPage2.Controls.Add(this.lbl_CodigoBarra);
            this.tabPage2.Controls.Add(this.txt_CodigoBarra);
            this.tabPage2.Controls.Add(this.cbox_Unidad);
            this.tabPage2.Controls.Add(this.lbl_Unidad);
            this.tabPage2.Controls.Add(this.cbox_Marca);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.cbox_Categoria);
            this.tabPage2.Controls.Add(this.lbl_Categoria);
            this.tabPage2.Controls.Add(this.txt_Stockmax);
            this.tabPage2.Controls.Add(this.lbl_Stockmax);
            this.tabPage2.Controls.Add(this.txt_Stockmin);
            this.tabPage2.Controls.Add(this.lbl_Stockmin);
            this.tabPage2.Controls.Add(this.btn_Guardar);
            this.tabPage2.Controls.Add(this.btn_Cancelar);
            this.tabPage2.Controls.Add(this.txt_Producto_dc);
            this.tabPage2.Controls.Add(this.lbl_Producto);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1198, 324);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Mantenimiento";
            // 
            // cbox_Unidad
            // 
            this.cbox_Unidad.Enabled = false;
            this.cbox_Unidad.FormattingEnabled = true;
            this.cbox_Unidad.Location = new System.Drawing.Point(137, 126);
            this.cbox_Unidad.Name = "cbox_Unidad";
            this.cbox_Unidad.Size = new System.Drawing.Size(240, 21);
            this.cbox_Unidad.TabIndex = 4;
            // 
            // lbl_Unidad
            // 
            this.lbl_Unidad.AutoSize = true;
            this.lbl_Unidad.Location = new System.Drawing.Point(44, 134);
            this.lbl_Unidad.Name = "lbl_Unidad";
            this.lbl_Unidad.Size = new System.Drawing.Size(73, 13);
            this.lbl_Unidad.TabIndex = 11;
            this.lbl_Unidad.Text = "Medida (*): ";
            // 
            // cbox_Marca
            // 
            this.cbox_Marca.Enabled = false;
            this.cbox_Marca.FormattingEnabled = true;
            this.cbox_Marca.Location = new System.Drawing.Point(137, 87);
            this.cbox_Marca.Name = "cbox_Marca";
            this.cbox_Marca.Size = new System.Drawing.Size(240, 21);
            this.cbox_Marca.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Marca (*): ";
            // 
            // cbox_Categoria
            // 
            this.cbox_Categoria.Enabled = false;
            this.cbox_Categoria.FormattingEnabled = true;
            this.cbox_Categoria.Location = new System.Drawing.Point(137, 52);
            this.cbox_Categoria.Name = "cbox_Categoria";
            this.cbox_Categoria.Size = new System.Drawing.Size(240, 21);
            this.cbox_Categoria.TabIndex = 2;
            // 
            // lbl_Categoria
            // 
            this.lbl_Categoria.AutoSize = true;
            this.lbl_Categoria.Location = new System.Drawing.Point(44, 60);
            this.lbl_Categoria.Name = "lbl_Categoria";
            this.lbl_Categoria.Size = new System.Drawing.Size(86, 13);
            this.lbl_Categoria.TabIndex = 7;
            this.lbl_Categoria.Text = "Categoria (*): ";
            // 
            // txt_Stockmax
            // 
            this.txt_Stockmax.Location = new System.Drawing.Point(223, 183);
            this.txt_Stockmax.MaxLength = 500;
            this.txt_Stockmax.Name = "txt_Stockmax";
            this.txt_Stockmax.ReadOnly = true;
            this.txt_Stockmax.Size = new System.Drawing.Size(152, 20);
            this.txt_Stockmax.TabIndex = 6;
            // 
            // lbl_Stockmax
            // 
            this.lbl_Stockmax.AutoSize = true;
            this.lbl_Stockmax.Location = new System.Drawing.Point(223, 167);
            this.lbl_Stockmax.Name = "lbl_Stockmax";
            this.lbl_Stockmax.Size = new System.Drawing.Size(110, 13);
            this.lbl_Stockmax.TabIndex = 5;
            this.lbl_Stockmax.Text = "Stock maximo (*): ";
            // 
            // txt_Stockmin
            // 
            this.txt_Stockmin.Location = new System.Drawing.Point(47, 183);
            this.txt_Stockmin.MaxLength = 500;
            this.txt_Stockmin.Name = "txt_Stockmin";
            this.txt_Stockmin.ReadOnly = true;
            this.txt_Stockmin.Size = new System.Drawing.Size(152, 20);
            this.txt_Stockmin.TabIndex = 5;
            // 
            // lbl_Stockmin
            // 
            this.lbl_Stockmin.AutoSize = true;
            this.lbl_Stockmin.Location = new System.Drawing.Point(44, 167);
            this.lbl_Stockmin.Name = "lbl_Stockmin";
            this.lbl_Stockmin.Size = new System.Drawing.Size(107, 13);
            this.lbl_Stockmin.TabIndex = 4;
            this.lbl_Stockmin.Text = "Stock minimo (*): ";
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.Black;
            this.btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Guardar.Location = new System.Drawing.Point(223, 267);
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
            this.btn_Cancelar.Location = new System.Drawing.Point(47, 267);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(152, 23);
            this.btn_Cancelar.TabIndex = 7;
            this.btn_Cancelar.Text = "CANCELAR";
            this.btn_Cancelar.UseVisualStyleBackColor = false;
            this.btn_Cancelar.Visible = false;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // txt_Producto_dc
            // 
            this.txt_Producto_dc.Location = new System.Drawing.Point(137, 16);
            this.txt_Producto_dc.MaxLength = 500;
            this.txt_Producto_dc.Name = "txt_Producto_dc";
            this.txt_Producto_dc.ReadOnly = true;
            this.txt_Producto_dc.Size = new System.Drawing.Size(240, 20);
            this.txt_Producto_dc.TabIndex = 1;
            // 
            // lbl_Producto
            // 
            this.lbl_Producto.AutoSize = true;
            this.lbl_Producto.Location = new System.Drawing.Point(44, 23);
            this.lbl_Producto.Name = "lbl_Producto";
            this.lbl_Producto.Size = new System.Drawing.Size(76, 13);
            this.lbl_Producto.TabIndex = 0;
            this.lbl_Producto.Text = "Detalle (*):  ";
            // 
            // btn_Nuevo
            // 
            this.btn_Nuevo.BackColor = System.Drawing.Color.Black;
            this.btn_Nuevo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Nuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Nuevo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Nuevo.Image = ((System.Drawing.Image)(resources.GetObject("btn_Nuevo.Image")));
            this.btn_Nuevo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Nuevo.Location = new System.Drawing.Point(12, 369);
            this.btn_Nuevo.Name = "btn_Nuevo";
            this.btn_Nuevo.Size = new System.Drawing.Size(75, 56);
            this.btn_Nuevo.TabIndex = 1;
            this.btn_Nuevo.Text = "NUEVO";
            this.btn_Nuevo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Nuevo.UseVisualStyleBackColor = false;
            this.btn_Nuevo.Click += new System.EventHandler(this.btn_Nuevo_Click);
            // 
            // btn_Actualizar
            // 
            this.btn_Actualizar.BackColor = System.Drawing.Color.Black;
            this.btn_Actualizar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Actualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Actualizar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Actualizar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Actualizar.Image")));
            this.btn_Actualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Actualizar.Location = new System.Drawing.Point(93, 369);
            this.btn_Actualizar.Name = "btn_Actualizar";
            this.btn_Actualizar.Size = new System.Drawing.Size(96, 56);
            this.btn_Actualizar.TabIndex = 2;
            this.btn_Actualizar.Text = "ACTUALIZAR";
            this.btn_Actualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Actualizar.UseVisualStyleBackColor = false;
            this.btn_Actualizar.Click += new System.EventHandler(this.btn_Actualizar_Click);
            // 
            // btn_Elimiar
            // 
            this.btn_Elimiar.BackColor = System.Drawing.Color.Black;
            this.btn_Elimiar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Elimiar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Elimiar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Elimiar.Image = ((System.Drawing.Image)(resources.GetObject("btn_Elimiar.Image")));
            this.btn_Elimiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Elimiar.Location = new System.Drawing.Point(195, 369);
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
            this.btn_Reporte.Location = new System.Drawing.Point(276, 368);
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
            this.btn_Salir.Location = new System.Drawing.Point(357, 368);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(75, 57);
            this.btn_Salir.TabIndex = 5;
            this.btn_Salir.Text = "SALIR";
            this.btn_Salir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_Salir.UseVisualStyleBackColor = false;
            // 
            // txt_CodigoBarra
            // 
            this.txt_CodigoBarra.Location = new System.Drawing.Point(47, 234);
            this.txt_CodigoBarra.MaxLength = 500;
            this.txt_CodigoBarra.Name = "txt_CodigoBarra";
            this.txt_CodigoBarra.ReadOnly = true;
            this.txt_CodigoBarra.Size = new System.Drawing.Size(330, 20);
            this.txt_CodigoBarra.TabIndex = 12;
            // 
            // lbl_CodigoBarra
            // 
            this.lbl_CodigoBarra.AutoSize = true;
            this.lbl_CodigoBarra.Location = new System.Drawing.Point(44, 218);
            this.lbl_CodigoBarra.Name = "lbl_CodigoBarra";
            this.lbl_CodigoBarra.Size = new System.Drawing.Size(109, 13);
            this.lbl_CodigoBarra.TabIndex = 13;
            this.lbl_CodigoBarra.Text = "Codigo Barra (*):  ";
            // 
            // frm_Producto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(1164, 437);
            this.Controls.Add(this.btn_Salir);
            this.Controls.Add(this.btn_Reporte);
            this.Controls.Add(this.btn_Elimiar);
            this.Controls.Add(this.btn_Actualizar);
            this.Controls.Add(this.btn_Nuevo);
            this.Controls.Add(this.tab_Principal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_Producto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Productos";
            this.Load += new System.EventHandler(this.frm_Producto_Load);
            this.tab_Principal.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Principal)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_Principal;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dgv_Principal;
        private System.Windows.Forms.Button btn_Buscar;
        private System.Windows.Forms.TextBox txt_Buscar;
        private System.Windows.Forms.Label lbl_Buscar;
        private System.Windows.Forms.Button btn_Nuevo;
        private System.Windows.Forms.Button btn_Actualizar;
        private System.Windows.Forms.Button btn_Elimiar;
        private System.Windows.Forms.Button btn_Reporte;
        private System.Windows.Forms.Button btn_Salir;
        private System.Windows.Forms.TextBox txt_Producto_dc;
        private System.Windows.Forms.Label lbl_Producto;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Label lbl_Stockmin;
        private System.Windows.Forms.TextBox txt_Stockmin;
        private System.Windows.Forms.TextBox txt_Stockmax;
        private System.Windows.Forms.Label lbl_Stockmax;
        private System.Windows.Forms.ComboBox cbox_Unidad;
        private System.Windows.Forms.Label lbl_Unidad;
        private System.Windows.Forms.ComboBox cbox_Marca;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbox_Categoria;
        private System.Windows.Forms.Label lbl_Categoria;
        private System.Windows.Forms.Label lbl_CodigoBarra;
        private System.Windows.Forms.TextBox txt_CodigoBarra;
    }
}

