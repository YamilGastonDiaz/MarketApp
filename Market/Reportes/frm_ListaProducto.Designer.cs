namespace Market.Reportes
{
    partial class frm_ListaProducto
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataSetMarket = new Market.Reportes.DataSetMarket();
            this.listarProductosActivosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.listarProductosActivosTableAdapter = new Market.Reportes.DataSetMarketTableAdapters.ListarProductosActivosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetMarket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.listarProductosActivosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.listarProductosActivosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Market.Reportes.ReporteListaProducto.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(712, 342);
            this.reportViewer1.TabIndex = 0;
            // 
            // dataSetMarket
            // 
            this.dataSetMarket.DataSetName = "DataSetMarket";
            this.dataSetMarket.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // listarProductosActivosBindingSource
            // 
            this.listarProductosActivosBindingSource.DataMember = "ListarProductosActivos";
            this.listarProductosActivosBindingSource.DataSource = this.dataSetMarket;
            // 
            // listarProductosActivosTableAdapter
            // 
            this.listarProductosActivosTableAdapter.ClearBeforeFill = true;
            // 
            // frm_ListaProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(712, 342);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frm_ListaProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LISTADO DE PRODUCTOS";
            this.Load += new System.EventHandler(this.frm_ListaProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetMarket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.listarProductosActivosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private DataSetMarket dataSetMarket;
        private System.Windows.Forms.BindingSource listarProductosActivosBindingSource;
        private DataSetMarketTableAdapters.ListarProductosActivosTableAdapter listarProductosActivosTableAdapter;
    }
}