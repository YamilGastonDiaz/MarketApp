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
            this.lbl_Precio = new System.Windows.Forms.Label();
            this.txt_Producto = new System.Windows.Forms.TextBox();
            this.txt_Stock = new System.Windows.Forms.TextBox();
            this.txt_Precio = new System.Windows.Forms.TextBox();
            this.btn_Guardar = new System.Windows.Forms.Button();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_Producto
            // 
            this.lbl_Producto.AutoSize = true;
            this.lbl_Producto.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_Producto.Location = new System.Drawing.Point(38, 57);
            this.lbl_Producto.Name = "lbl_Producto";
            this.lbl_Producto.Size = new System.Drawing.Size(56, 13);
            this.lbl_Producto.TabIndex = 0;
            this.lbl_Producto.Text = "Producto: ";
            // 
            // lbl_StockActual
            // 
            this.lbl_StockActual.AutoSize = true;
            this.lbl_StockActual.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_StockActual.Location = new System.Drawing.Point(38, 100);
            this.lbl_StockActual.Name = "lbl_StockActual";
            this.lbl_StockActual.Size = new System.Drawing.Size(74, 13);
            this.lbl_StockActual.TabIndex = 1;
            this.lbl_StockActual.Text = "Stock Actual: ";
            // 
            // lbl_Precio
            // 
            this.lbl_Precio.AutoSize = true;
            this.lbl_Precio.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_Precio.Location = new System.Drawing.Point(38, 146);
            this.lbl_Precio.Name = "lbl_Precio";
            this.lbl_Precio.Size = new System.Drawing.Size(82, 13);
            this.lbl_Precio.TabIndex = 2;
            this.lbl_Precio.Text = "Precio Unitario: ";
            // 
            // txt_Producto
            // 
            this.txt_Producto.Location = new System.Drawing.Point(138, 49);
            this.txt_Producto.Name = "txt_Producto";
            this.txt_Producto.ReadOnly = true;
            this.txt_Producto.Size = new System.Drawing.Size(253, 20);
            this.txt_Producto.TabIndex = 3;
            // 
            // txt_Stock
            // 
            this.txt_Stock.Location = new System.Drawing.Point(138, 93);
            this.txt_Stock.Name = "txt_Stock";
            this.txt_Stock.Size = new System.Drawing.Size(253, 20);
            this.txt_Stock.TabIndex = 4;
            // 
            // txt_Precio
            // 
            this.txt_Precio.Location = new System.Drawing.Point(138, 139);
            this.txt_Precio.Name = "txt_Precio";
            this.txt_Precio.Size = new System.Drawing.Size(253, 20);
            this.txt_Precio.TabIndex = 5;
            // 
            // btn_Guardar
            // 
            this.btn_Guardar.BackColor = System.Drawing.Color.Black;
            this.btn_Guardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Guardar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Guardar.Location = new System.Drawing.Point(138, 184);
            this.btn_Guardar.Name = "btn_Guardar";
            this.btn_Guardar.Size = new System.Drawing.Size(113, 23);
            this.btn_Guardar.TabIndex = 6;
            this.btn_Guardar.Text = "Guardar";
            this.btn_Guardar.UseVisualStyleBackColor = false;
            this.btn_Guardar.Click += new System.EventHandler(this.btn_Guardar_Click);
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.BackColor = System.Drawing.Color.Black;
            this.btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Cancelar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Cancelar.Location = new System.Drawing.Point(272, 184);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(113, 23);
            this.btn_Cancelar.TabIndex = 7;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = false;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // frm_StockProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(476, 270);
            this.Controls.Add(this.btn_Cancelar);
            this.Controls.Add(this.btn_Guardar);
            this.Controls.Add(this.txt_Precio);
            this.Controls.Add(this.txt_Stock);
            this.Controls.Add(this.txt_Producto);
            this.Controls.Add(this.lbl_Precio);
            this.Controls.Add(this.lbl_StockActual);
            this.Controls.Add(this.lbl_Producto);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_StockProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock Producto";
            this.Load += new System.EventHandler(this.frm_StockProducto_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Producto;
        private System.Windows.Forms.Label lbl_StockActual;
        private System.Windows.Forms.Label lbl_Precio;
        private System.Windows.Forms.TextBox txt_Producto;
        private System.Windows.Forms.TextBox txt_Stock;
        private System.Windows.Forms.TextBox txt_Precio;
        private System.Windows.Forms.Button btn_Guardar;
        private System.Windows.Forms.Button btn_Cancelar;
    }
}

