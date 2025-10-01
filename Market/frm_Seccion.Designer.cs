namespace Market
{
    partial class frm_Seccion
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Administrar = new System.Windows.Forms.Button();
            this.btn_Venta = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Administrar
            // 
            this.btn_Administrar.BackColor = System.Drawing.Color.Black;
            this.btn_Administrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Administrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Administrar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Administrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Administrar.Location = new System.Drawing.Point(125, 46);
            this.btn_Administrar.Name = "btn_Administrar";
            this.btn_Administrar.Size = new System.Drawing.Size(344, 80);
            this.btn_Administrar.TabIndex = 0;
            this.btn_Administrar.Text = "GESITION DE PRODUCTOS";
            this.btn_Administrar.UseVisualStyleBackColor = false;
            this.btn_Administrar.Click += new System.EventHandler(this.btn_Administrar_Click);
            // 
            // btn_Venta
            // 
            this.btn_Venta.BackColor = System.Drawing.Color.Black;
            this.btn_Venta.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Venta.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Venta.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Venta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Venta.Location = new System.Drawing.Point(125, 153);
            this.btn_Venta.Name = "btn_Venta";
            this.btn_Venta.Size = new System.Drawing.Size(344, 80);
            this.btn_Venta.TabIndex = 1;
            this.btn_Venta.Text = "GESTION DE VENTAS";
            this.btn_Venta.UseVisualStyleBackColor = false;
            this.btn_Venta.Click += new System.EventHandler(this.btn_Venta_Click);
            // 
            // frm_Seccion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(583, 273);
            this.Controls.Add(this.btn_Venta);
            this.Controls.Add(this.btn_Administrar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Seccion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PANEL ADMIN";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Administrar;
        private System.Windows.Forms.Button btn_Venta;
    }
}