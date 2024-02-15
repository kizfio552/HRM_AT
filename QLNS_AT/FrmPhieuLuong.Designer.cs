namespace QLNS_AT
{
    partial class FrmPhieuLuong
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPhieuLuong));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.qLNS_ATDataSet1 = new QLNS_ATDataSet();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportTableAdapter1 = new QLNS_ATDataSetTableAdapters.ReportTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLNS_ATDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "Report";
            this.bindingSource1.DataSource = this.qLNS_ATDataSet1;
            // 
            // qLNS_ATDataSet1
            // 
            this.qLNS_ATDataSet1.DataSetName = "QLNS_ATDataSet";
            this.qLNS_ATDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer2
            // 
            this.reportViewer2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("reportViewer2.BackgroundImage")));
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.bindingSource1;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "QLNS_AT.ReportPL.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.ServerReport.BearerToken = null;
            this.reportViewer2.Size = new System.Drawing.Size(1262, 673);
            this.reportViewer2.TabIndex = 0;
            // 
            // reportTableAdapter1
            // 
            this.reportTableAdapter1.ClearBeforeFill = true;
            // 
            // FrmPhieuLuong
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.reportViewer2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmPhieuLuong";
            this.Text = "Phiếu lương Amazing Tech";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPhieuLuong_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qLNS_ATDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource ReportBindingSource;
        private QLNS_ATDataSet QLNS_ATDataSet;
        private QLNS_ATDataSetTableAdapters.ReportTableAdapter ReportTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private QLNS_ATDataSet qLNS_ATDataSet1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private QLNS_ATDataSetTableAdapters.ReportTableAdapter reportTableAdapter1;
    }
}