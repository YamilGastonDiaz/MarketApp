namespace Market.Reportes
{
    partial class frm_HistorialCompra
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
            this.reporteHistorialPreciosCompraBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSetMarket = new Market.Reportes.DataSetMarket();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reporteHistorialPreciosCompraTableAdapter = new Market.Reportes.DataSetMarketTableAdapters.ReporteHistorialPreciosCompraTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.reporteHistorialPreciosCompraBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetMarket)).BeginInit();
            this.SuspendLayout();
            // 
            // reporteHistorialPreciosCompraBindingSource
            // 
            this.reporteHistorialPreciosCompraBindingSource.DataMember = "ReporteHistorialPreciosCompra";
            this.reporteHistorialPreciosCompraBindingSource.DataSource = this.dataSetMarket;
            // 
            // dataSetMarket
            // 
            this.dataSetMarket.DataSetName = "DataSetMarket";
            this.dataSetMarket.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.reporteHistorialPreciosCompraBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Market.Reportes.ReporteHistorialCompra.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(712, 342);
            this.reportViewer1.TabIndex = 0;
            // 
            // reporteHistorialPreciosCompraTableAdapter
            // 
            this.reporteHistorialPreciosCompraTableAdapter.ClearBeforeFill = true;
            // 
            // frm_HistorialCompra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(62)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(712, 342);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_HistorialCompra";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HISTORIAL PRECIO COMPRA";
            this.Load += new System.EventHandler(this.frm_HistorialCompra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reporteHistorialPreciosCompraBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSetMarket)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource reporteHistorialPreciosCompraBindingSource;
        private DataSetMarket dataSetMarket;
        private DataSetMarketTableAdapters.ReporteHistorialPreciosCompraTableAdapter reporteHistorialPreciosCompraTableAdapter;
    }
}