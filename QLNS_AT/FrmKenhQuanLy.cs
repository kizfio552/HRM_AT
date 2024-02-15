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
    public partial class FrmKenhQuanLy : Form
    {
        Ketnoi data = new Ketnoi();
        string manv = "";
        public FrmKenhQuanLy(string manv)
        {
            InitializeComponent();
            this.manv = manv;
        }
        private void loadData()
        {
            string str = "select HoNV + ' ' + TenNV as [Họ tên], TinNhan as [Tin nhắn], ThoiGian as [Thời gian] " +
                "from LoiNhan LN join NhanVien NV on LN.MaNV = NV.MaNV join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV " +
                "where Kenh = N'Quản lý' " +
                "order by ThuTu desc";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvTN.DataSource = dt;
            dgvTN.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTN.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTN.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }
        private void FrmKenhQuanLy_Load(object sender, EventArgs e)
        {
            loadData();
            txtTN.Focus();
        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            try
            {
                string tinnhan = txtTN.Text;
                data.ExecuteNonQuery("insert into LoiNhan values('" + manv + "', N'" + tinnhan + "', Getdate(), N'Quản lý')");
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            txtTN.Text = "";
            txtTN.Focus();
        }
    }
}
