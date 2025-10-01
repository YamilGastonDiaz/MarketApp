namespace Market
{
    partial class frm_StockProducto
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
            this.lbl_Producto = new System.Windows.Forms.Label();
            this.lbl_StockActual = new System.Windows.Forms.Label();
            this.lbl_PrecioD = new System.Windows.Forms.Label();
            this.txt_Producto = new System.Windows.Forms.TextBox();
            this.txt_Stock = new System.Windows.Forms.TextBox();
            this.txt_PrecioD = new System.Windows.Forms.TextBox();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.lbl_PrecioN = new System.Windows.Forms.Label();
            this.txt_PrecioN = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Producto
            // 
            this.lbl_Producto.AutoSize = true;
            this.lbl_Producto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Producto.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_Producto.Location = new System.Drawing.Point(41, 71);
            this.lbl_Producto.Name = "lbl_Producto";
            this.lbl_Producto.Size = new System.Drawing.Size(77, 16);
            this.lbl_Producto.TabIndex = 0;
            this.lbl_Producto.Text = "Producto: ";
            // 
            // lbl_StockActual
            // 
            this.lbl_StockActual.AutoSize = true;
            this.lbl_StockActual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_StockActual.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_StockActual.Location = new System.Drawing.Point(41, 111);
            this.lbl_StockActual.Name = "lbl_StockActual";
            this.lbl_StockActual.Size = new System.Drawing.Size(101, 16);
            this.lbl_StockActual.TabIndex = 1;
            this.lbl_StockActual.Text = "Stock Actual: ";
            // 
            // lbl_PrecioD
            // 
            this.lbl_PrecioD.AutoSize = true;
            this.lbl_PrecioD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PrecioD.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_PrecioD.Location = new System.Drawing.Point(41, 152);
            this.lbl_PrecioD.Name = "lbl_PrecioD";
            this.lbl_PrecioD.Size = new System.Drawing.Size(84, 16);
            this.lbl_PrecioD.TabIndex = 2;
            this.lbl_PrecioD.Text = "Precio Dia:";
            // 
            // txt_Producto
            // 
            this.txt_Producto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Producto.Location = new System.Drawing.Point(152, 61);
            this.txt_Producto.Name = "txt_Producto";
            this.txt_Producto.ReadOnly = true;
            this.txt_Producto.Size = new System.Drawing.Size(253, 26);
            this.txt_Producto.TabIndex = 3;
            // 
            // txt_Stock
            // 
            this.txt_Stock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Stock.Location = new System.Drawing.Point(152, 101);
            this.txt_Stock.Name = "txt_Stock";
            this.txt_Stock.ReadOnly = true;
            this.txt_Stock.Size = new System.Drawing.Size(253, 26);
            this.txt_Stock.TabIndex = 4;
            // 
            // txt_PrecioD
            // 
            this.txt_PrecioD.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PrecioD.Location = new System.Drawing.Point(152, 142);
            this.txt_PrecioD.Name = "txt_PrecioD";
            this.txt_PrecioD.Size = new System.Drawing.Size(253, 26);
            this.txt_PrecioD.TabIndex = 5;
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.Black;
            this.btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Guardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Guardar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Guardar.Location = new System.Drawing.Point(152, 233);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(113, 35);
            this.btn_Guardar.TabIndex = 6;
            this.btn_Guardar.Text = "GUARDAR";
            this.btn_Guardar.UseVisualStyleBackColor = false;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.BackColor = System.Drawing.Color.Black;
            this.btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Cancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Cancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Cancelar.Location = new System.Drawing.Point(292, 233);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(113, 35);
            this.btn_Cancelar.TabIndex = 7;
            this.btn_Cancelar.Text = "CANCELAR";
            this.btn_Cancelar.UseVisualStyleBackColor = false;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // lbl_PrecioN
            // 
            this.lbl_PrecioN.AutoSize = true;
            this.lbl_PrecioN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_PrecioN.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_PrecioN.Location = new System.Drawing.Point(41, 193);
            this.lbl_PrecioN.Name = "lbl_PrecioN";
            this.lbl_PrecioN.Size = new System.Drawing.Size(105, 16);
            this.lbl_PrecioN.TabIndex = 8;
            this.lbl_PrecioN.Text = "Precio Noche:";
            // 
            // txt_PrecioN
            // 
            this.txt_PrecioN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_PrecioN.Location = new System.Drawing.Point(152, 183);
            this.txt_PrecioN.Name = "txt_PrecioN";
            this.txt_PrecioN.Size = new System.Drawing.Size(253, 26);
            this.txt_PrecioN.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 40);
            this.panel1.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "STOCK ACTUAL Y PRECIOS";
            // 
            // frm_StockProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(476, 280);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txt_PrecioN);
            this.Controls.Add(this.lbl_PrecioN);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.txt_PrecioD);
            this.Controls.Add(this.txt_Stock);
            this.Controls.Add(this.txt_Producto);
            this.Controls.Add(this.lbl_PrecioD);
            this.Controls.Add(this.lbl_StockActual);
            this.Controls.Add(this.lbl_Producto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_StockProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "STOCK PRODUCTO";
            this.Load += new System.EventHandler(this.frm_StockProducto_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Producto;
        private System.Windows.Forms.Label lbl_StockActual;
        private System.Windows.Forms.Label lbl_PrecioD;
        private System.Windows.Forms.TextBox txt_Producto;
        private System.Windows.Forms.TextBox txt_Stock;
        private System.Windows.Forms.TextBox txt_PrecioD;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Label lbl_PrecioN;
        private System.Windows.Forms.TextBox txt_PrecioN;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}

