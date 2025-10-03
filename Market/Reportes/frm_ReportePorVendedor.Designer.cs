namespace Market.Reportes
{
    partial class frm_ReportePorVendedor
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
            this.reporteVentasPorVendedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reporteVentasPorVendedorTableAdapter = new Market.Reportes.DataSetMarketTableAdapters.ReporteVentasPorVendedorTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetMarket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteVentasPorVendedorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.reporteVentasPorVendedorBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Market.Reportes.ReporteVentaVendedor.rdlc";
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
            // reporteVentasPorVendedorBindingSource
            // 
            this.reporteVentasPorVendedorBindingSource.DataMember = "ReporteVentasPorVendedor";
            this.reporteVentasPorVendedorBindingSource.DataSource = this.dataSetMarket;
            // 
            // reporteVentasPorVendedorTableAdapter
            // 
            this.reporteVentasPorVendedorTableAdapter.ClearBeforeFill = true;
            // 
            // frm_ReportePorVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(712, 342);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_ReportePorVendedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "REPORTE POR VENTA VENDEDOR";
            this.Load += new System.EventHandler(this.frm_ReportePorVendedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataSetMarket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteVentasPorVendedorBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource reporteVentasPorVendedorBindingSource;
        private DataSetMarket dataSetMarket;
        private DataSetMarketTableAdapters.ReporteVentasPorVendedorTableAdapter reporteVentasPorVendedorTableAdapter;
    }
}