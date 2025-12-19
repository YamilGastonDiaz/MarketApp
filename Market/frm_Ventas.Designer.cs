namespace Market
{
    partial class frm_Ventas
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Ventas));
            this.lbl_Total = new System.Windows.Forms.Label();
            this.lbl_Vuelto = new System.Windows.Forms.Label();
            this.lbl_Efectivo = new System.Windows.Forms.Label();
            this.txt_Total = new System.Windows.Forms.TextBox();
            this.txt_Vuelto = new System.Windows.Forms.TextBox();
            this.txt_Efectivo = new System.Windows.Forms.TextBox();
            this.dgv_Principal = new System.Windows.Forms.DataGridView();
            this.txt_CodBarra = new System.Windows.Forms.TextBox();
            this.btn_PagoEfectivo = new System.Windows.Forms.Button();
            this.btn_PagoQr = new System.Windows.Forms.Button();
            this.rdb_PrecioNoche = new System.Windows.Forms.RadioButton();
            this.rdb_PrecioDia = new System.Windows.Forms.RadioButton();
            this.btn_Quitar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lbl_Hora = new System.Windows.Forms.Label();
            this.lbl_Fecha = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_TipoUser = new System.Windows.Forms.Label();
            this.lbl_Bienvenida = new System.Windows.Forms.Label();
            this.btn_Salir = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer_Venta = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Principal)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Total
            // 
            this.lbl_Total.AutoSize = true;
            this.lbl_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Total.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_Total.Location = new System.Drawing.Point(540, 382);
            this.lbl_Total.Name = "lbl_Total";
            this.lbl_Total.Size = new System.Drawing.Size(43, 12);
            this.lbl_Total.TabIndex = 6;
            this.lbl_Total.Text = "TOTAL:";
            // 
            // lbl_Vuelto
            // 
            this.lbl_Vuelto.AutoSize = true;
            this.lbl_Vuelto.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Vuelto.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_Vuelto.Location = new System.Drawing.Point(275, 382);
            this.lbl_Vuelto.Name = "lbl_Vuelto";
            this.lbl_Vuelto.Size = new System.Drawing.Size(52, 12);
            this.lbl_Vuelto.TabIndex = 5;
            this.lbl_Vuelto.Text = "VUELTO:";
            // 
            // lbl_Efectivo
            // 
            this.lbl_Efectivo.AutoSize = true;
            this.lbl_Efectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Efectivo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_Efectivo.Location = new System.Drawing.Point(10, 382);
            this.lbl_Efectivo.Name = "lbl_Efectivo";
            this.lbl_Efectivo.Size = new System.Drawing.Size(64, 12);
            this.lbl_Efectivo.TabIndex = 4;
            this.lbl_Efectivo.Text = "EFECTIVO:";
            // 
            // txt_Total
            // 
            this.txt_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Total.Location = new System.Drawing.Point(542, 397);
            this.txt_Total.Name = "txt_Total";
            this.txt_Total.ReadOnly = true;
            this.txt_Total.Size = new System.Drawing.Size(250, 29);
            this.txt_Total.TabIndex = 3;
            // 
            // txt_Vuelto
            // 
            this.txt_Vuelto.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Vuelto.Location = new System.Drawing.Point(277, 397);
            this.txt_Vuelto.Name = "txt_Vuelto";
            this.txt_Vuelto.Size = new System.Drawing.Size(250, 29);
            this.txt_Vuelto.TabIndex = 2;
            // 
            // txt_Efectivo
            // 
            this.txt_Efectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Efectivo.Location = new System.Drawing.Point(10, 397);
            this.txt_Efectivo.Name = "txt_Efectivo";
            this.txt_Efectivo.Size = new System.Drawing.Size(250, 29);
            this.txt_Efectivo.TabIndex = 1;
            this.txt_Efectivo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_Efectivo_KeyPress);
            // 
            // dgv_Principal
            // 
            this.dgv_Principal.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Principal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Principal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Principal.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Principal.Location = new System.Drawing.Point(7, 9);
            this.dgv_Principal.Name = "dgv_Principal";
            this.dgv_Principal.Size = new System.Drawing.Size(783, 360);
            this.dgv_Principal.TabIndex = 0;
            this.dgv_Principal.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Principal_CellEndEdit);
            this.dgv_Principal.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgv_Principal_EditingControlShowing);
            // 
            // txt_CodBarra
            // 
            this.txt_CodBarra.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_CodBarra.Location = new System.Drawing.Point(10, 19);
            this.txt_CodBarra.Name = "txt_CodBarra";
            this.txt_CodBarra.Size = new System.Drawing.Size(100, 15);
            this.txt_CodBarra.TabIndex = 10;
            this.txt_CodBarra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_CodBarra_KeyPress);
            // 
            // btn_PagoEfectivo
            // 
            this.btn_PagoEfectivo.BackColor = System.Drawing.Color.DarkGreen;
            this.btn_PagoEfectivo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_PagoEfectivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PagoEfectivo.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_PagoEfectivo.Image = ((System.Drawing.Image)(resources.GetObject("btn_PagoEfectivo.Image")));
            this.btn_PagoEfectivo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_PagoEfectivo.Location = new System.Drawing.Point(421, 14);
            this.btn_PagoEfectivo.Name = "btn_PagoEfectivo";
            this.btn_PagoEfectivo.Size = new System.Drawing.Size(345, 75);
            this.btn_PagoEfectivo.TabIndex = 1;
            this.btn_PagoEfectivo.Text = "EFECTIVO";
            this.btn_PagoEfectivo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_PagoEfectivo.UseVisualStyleBackColor = false;
            this.btn_PagoEfectivo.Click += new System.EventHandler(this.btn_PagoEfectivo_Click);
            // 
            // btn_PagoQr
            // 
            this.btn_PagoQr.BackColor = System.Drawing.Color.Teal;
            this.btn_PagoQr.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_PagoQr.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PagoQr.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_PagoQr.Image = ((System.Drawing.Image)(resources.GetObject("btn_PagoQr.Image")));
            this.btn_PagoQr.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_PagoQr.Location = new System.Drawing.Point(31, 14);
            this.btn_PagoQr.Name = "btn_PagoQr";
            this.btn_PagoQr.Size = new System.Drawing.Size(345, 75);
            this.btn_PagoQr.TabIndex = 0;
            this.btn_PagoQr.Text = "QR";
            this.btn_PagoQr.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btn_PagoQr.UseVisualStyleBackColor = false;
            this.btn_PagoQr.Click += new System.EventHandler(this.btn_PagoQr_Click);
            // 
            // rdb_PrecioNoche
            // 
            this.rdb_PrecioNoche.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_PrecioNoche.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rdb_PrecioNoche.Location = new System.Drawing.Point(121, 11);
            this.rdb_PrecioNoche.Name = "rdb_PrecioNoche";
            this.rdb_PrecioNoche.Size = new System.Drawing.Size(102, 40);
            this.rdb_PrecioNoche.TabIndex = 1;
            this.rdb_PrecioNoche.TabStop = true;
            this.rdb_PrecioNoche.Text = "NOCHE";
            this.rdb_PrecioNoche.UseVisualStyleBackColor = true;
            this.rdb_PrecioNoche.CheckedChanged += new System.EventHandler(this.rdb_PrecioNoche_CheckedChanged);
            // 
            // rdb_PrecioDia
            // 
            this.rdb_PrecioDia.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdb_PrecioDia.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.rdb_PrecioDia.Location = new System.Drawing.Point(25, 11);
            this.rdb_PrecioDia.Name = "rdb_PrecioDia";
            this.rdb_PrecioDia.Size = new System.Drawing.Size(78, 40);
            this.rdb_PrecioDia.TabIndex = 0;
            this.rdb_PrecioDia.TabStop = true;
            this.rdb_PrecioDia.Text = "DIA";
            this.rdb_PrecioDia.UseVisualStyleBackColor = true;
            this.rdb_PrecioDia.CheckedChanged += new System.EventHandler(this.rdb_PrecioDia_CheckedChanged);
            // 
            // btn_Quitar
            // 
            this.btn_Quitar.BackColor = System.Drawing.Color.DarkRed;
            this.btn_Quitar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Quitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Quitar.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Quitar.Location = new System.Drawing.Point(729, 530);
            this.btn_Quitar.Name = "btn_Quitar";
            this.btn_Quitar.Size = new System.Drawing.Size(86, 32);
            this.btn_Quitar.TabIndex = 6;
            this.btn_Quitar.Text = "QUITAR";
            this.btn_Quitar.UseVisualStyleBackColor = false;
            this.btn_Quitar.Click += new System.EventHandler(this.btn_Quitar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel5);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1081, 65);
            this.panel2.TabIndex = 7;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lbl_Hora);
            this.panel5.Controls.Add(this.lbl_Fecha);
            this.panel5.Location = new System.Drawing.Point(808, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(270, 59);
            this.panel5.TabIndex = 3;
            // 
            // lbl_Hora
            // 
            this.lbl_Hora.AutoSize = true;
            this.lbl_Hora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Hora.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_Hora.Location = new System.Drawing.Point(18, 33);
            this.lbl_Hora.Name = "lbl_Hora";
            this.lbl_Hora.Size = new System.Drawing.Size(60, 20);
            this.lbl_Hora.TabIndex = 1;
            this.lbl_Hora.Text = "HORA";
            // 
            // lbl_Fecha
            // 
            this.lbl_Fecha.AutoSize = true;
            this.lbl_Fecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Fecha.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_Fecha.Location = new System.Drawing.Point(19, 6);
            this.lbl_Fecha.Name = "lbl_Fecha";
            this.lbl_Fecha.Size = new System.Drawing.Size(47, 13);
            this.lbl_Fecha.TabIndex = 0;
            this.lbl_Fecha.Text = "FECHA";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbl_TipoUser);
            this.panel3.Controls.Add(this.lbl_Bienvenida);
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(270, 59);
            this.panel3.TabIndex = 2;
            // 
            // lbl_TipoUser
            // 
            this.lbl_TipoUser.AutoSize = true;
            this.lbl_TipoUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_TipoUser.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_TipoUser.Location = new System.Drawing.Point(9, 33);
            this.lbl_TipoUser.Name = "lbl_TipoUser";
            this.lbl_TipoUser.Size = new System.Drawing.Size(88, 16);
            this.lbl_TipoUser.TabIndex = 1;
            this.lbl_TipoUser.Text = "TIPO USER";
            this.lbl_TipoUser.Visible = false;
            // 
            // lbl_Bienvenida
            // 
            this.lbl_Bienvenida.AutoSize = true;
            this.lbl_Bienvenida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Bienvenida.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbl_Bienvenida.Location = new System.Drawing.Point(9, 6);
            this.lbl_Bienvenida.Name = "lbl_Bienvenida";
            this.lbl_Bienvenida.Size = new System.Drawing.Size(50, 16);
            this.lbl_Bienvenida.TabIndex = 0;
            this.lbl_Bienvenida.Text = "NAME";
            this.lbl_Bienvenida.Visible = false;
            // 
            // btn_Salir
            // 
            this.btn_Salir.BackColor = System.Drawing.Color.Black;
            this.btn_Salir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Salir.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Salir.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btn_Salir.Image = ((System.Drawing.Image)(resources.GetObject("btn_Salir.Image")));
            this.btn_Salir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_Salir.Location = new System.Drawing.Point(827, 636);
            this.btn_Salir.Name = "btn_Salir";
            this.btn_Salir.Size = new System.Drawing.Size(240, 46);
            this.btn_Salir.TabIndex = 8;
            this.btn_Salir.Text = "SALIR";
            this.btn_Salir.UseVisualStyleBackColor = false;
            this.btn_Salir.Click += new System.EventHandler(this.btn_Salir_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Black;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.pictureBox1);
            this.panel4.Location = new System.Drawing.Point(827, 172);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(241, 352);
            this.panel4.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(84, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "- SIN NOMBRE -";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(47, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "MINIMARKET";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(3, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(231, 252);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // timer_Venta
            // 
            this.timer_Venta.Enabled = true;
            this.timer_Venta.Tick += new System.EventHandler(this.timer_Venta_Tick);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.dgv_Principal);
            this.panel1.Controls.Add(this.lbl_Total);
            this.panel1.Controls.Add(this.txt_CodBarra);
            this.panel1.Controls.Add(this.txt_Vuelto);
            this.panel1.Controls.Add(this.lbl_Efectivo);
            this.panel1.Controls.Add(this.txt_Total);
            this.panel1.Controls.Add(this.txt_Efectivo);
            this.panel1.Controls.Add(this.lbl_Vuelto);
            this.panel1.Location = new System.Drawing.Point(13, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 434);
            this.panel1.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(13, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 12);
            this.label1.TabIndex = 13;
            this.label1.Text = "PRODUCTO";
            // 
            // panel6
            // 
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel6.Controls.Add(this.rdb_PrecioNoche);
            this.panel6.Controls.Add(this.rdb_PrecioDia);
            this.panel6.Location = new System.Drawing.Point(830, 90);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(237, 63);
            this.panel6.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(828, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 12);
            this.label4.TabIndex = 15;
            this.label4.Text = "TURNO";
            // 
            // panel7
            // 
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel7.Controls.Add(this.btn_PagoEfectivo);
            this.panel7.Controls.Add(this.btn_PagoQr);
            this.panel7.Location = new System.Drawing.Point(15, 582);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(800, 100);
            this.panel7.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(13, 567);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 12);
            this.label5.TabIndex = 17;
            this.label5.Text = "FORMA DE PAGO";
            // 
            // frm_Ventas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(1081, 701);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btn_Salir);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btn_Quitar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_Ventas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VENTAS";
            this.Load += new System.EventHandler(this.frm_Ventas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Principal)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_PagoEfectivo;
        private System.Windows.Forms.Button btn_PagoQr;
        private System.Windows.Forms.RadioButton rdb_PrecioNoche;
        private System.Windows.Forms.RadioButton rdb_PrecioDia;
        private System.Windows.Forms.TextBox txt_Total;
        private System.Windows.Forms.TextBox txt_Vuelto;
        private System.Windows.Forms.TextBox txt_Efectivo;
        private System.Windows.Forms.Label lbl_Total;
        private System.Windows.Forms.Label lbl_Vuelto;
        private System.Windows.Forms.Label lbl_Efectivo;
        private System.Windows.Forms.Button btn_Quitar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_Bienvenida;
        private System.Windows.Forms.Button btn_Salir;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbl_TipoUser;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label lbl_Hora;
        private System.Windows.Forms.Label lbl_Fecha;
        private System.Windows.Forms.Timer timer_Venta;
        private System.Windows.Forms.TextBox txt_CodBarra;
        private System.Windows.Forms.DataGridView dgv_Principal;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label5;
    }
}