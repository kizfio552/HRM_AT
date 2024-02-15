using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS_AT
{
    public partial class FrmPhieuLuong : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        public FrmPhieuLuong()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmPhieuLuong_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'QLNS_ATDataSet.Report' table. You can move, or remove it, as needed.
            this.ReportTableAdapter.Fill(this.QLNS_ATDataSet.Report);

            this.reportViewer1.RefreshReport();
        }

        private void FrmPhieuLuong_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qLNS_ATDataSet1.Report' table. You can move, or remove it, as needed.
            this.reportTableAdapter1.Fill(this.qLNS_ATDataSet1.Report);

            this.reportViewer2.RefreshReport();
        }
    }
}
