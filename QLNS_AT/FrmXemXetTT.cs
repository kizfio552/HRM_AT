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
    public partial class FrmXemXetTT : Form
    {
        Ketnoi data = new Ketnoi();
        string honv = "", tennv = "", manv = "";
        int quyen;
        private BindingSource bdsource = new BindingSource();
        public FrmXemXetTT(string manv, int quyen, string honv, string tennv)
        {
            InitializeComponent();
            this.manv = manv;
            this.quyen = quyen;
            this.honv = honv;
            this.tennv = tennv;
        }
        private void loadDataDA()
        {
            string str = "select KN.MaNV as [Mã nhân viên], HoNV + ' ' + TenNV as [Họ tên], count(KN.MaNV) as [Tổng dự án hoàn thành] " +
                "from ThongTinNhanVien TTNV join NhanVien NV on TTNV.MaNV = NV.MaNV join KinhNghiem KN on NV.MaNV = KN.MaNV " +
                "where TrangThai = N'Đã hoàn thành' group by KN.MaNV, HoNV + ' ' + TenNV";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvXXTT.DataSource = bdsource;
            dgvXXTT.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvXXTT.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvXXTT.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }
        private void loadDataKN()
        {
            string str = "select KN_NV.MaNV as [Mã nhân viên], HoNV + ' ' + TenNV as [Họ tên], count(KN_NV.MaNV) as [Số kỹ năng thuần thục] " +
                "from ThongTinNhanVien TTNV join NhanVien NV on TTNV.MaNV = NV.MaNV join KN_NV on NV.MaNV = KN_NV.MaNV " +
                "group by KN_NV.MaNV, HoNV + ' ' + TenNV";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvXXTT.DataSource = bdsource;
            dgvXXTT.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvXXTT.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvXXTT.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }
        private void loadDataDAPQ()
        {
            string str = "select KN.MaNV as [Mã nhân viên], HoNV + ' ' + TenNV as [Họ tên], count(KN.MaNV) as [Tổng dự án hoàn thành] " +
                "from ThongTinNhanVien TTNV join NhanVien NV on TTNV.MaNV = NV.MaNV join KinhNghiem KN on NV.MaNV = KN.MaNV " +
                "where TrangThai = N'Đã hoàn thành' and KN.MaNV = " + manv + " group by KN.MaNV, HoNV + ' ' + TenNV";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvXXTT.DataSource = bdsource;
            dgvXXTT.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvXXTT.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvXXTT.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }
        private void loadDataKNPQ()
        {
            string str = "select KN_NV.MaNV as [Mã nhân viên], HoNV + ' ' + TenNV as [Họ tên], count(KN_NV.MaNV) as [Số kỹ năng thuần thục] " +
                "from ThongTinNhanVien TTNV join NhanVien NV on TTNV.MaNV = NV.MaNV join KN_NV on NV.MaNV = KN_NV.MaNV " +
                "where KN_NV.MaNV = " + manv + " group by KN_NV.MaNV, HoNV + ' ' + TenNV";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvXXTT.DataSource = bdsource;
            dgvXXTT.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvXXTT.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvXXTT.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }
        private void FrmXemXetTT_Load(object sender, EventArgs e)
        {
            if (quyen == 0)
            {
                if (rdbDA.Checked == true)
                    loadDataDAPQ();
                else if (rdbKN.Checked == true)
                    loadDataKNPQ();
            }
            else
            {
                if (rdbDA.Checked == true)
                    loadDataDA();
                else if (rdbKN.Checked == true)
                    loadDataKN();
            }
            btnDau.Enabled = false;
            btnTruoc.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDau_Click(object sender, EventArgs e)
        {
            bdsource.Position = 0;
            btnTruoc.Enabled = false;
            btnDau.Enabled = false;
            btnSau.Enabled = true;
            btnCuoi.Enabled = true;
        }

        private void btnTruoc_Click(object sender, EventArgs e)
        {
            bdsource.Position -= 1;
            if (bdsource.Position == 0)
            {
                btnTruoc.Enabled = false;
                btnDau.Enabled = false;
            }
            btnSau.Enabled = true;
            btnCuoi.Enabled = true;
        }

        private void btnSau_Click(object sender, EventArgs e)
        {
            bdsource.Position += 1;
            if (bdsource.Position == bdsource.Count - 1)
            {
                btnSau.Enabled = false;
                btnCuoi.Enabled = false;
            }
            btnTruoc.Enabled = true;
            btnDau.Enabled = true;
        }

        private void btnCuoi_Click(object sender, EventArgs e)
        {
            bdsource.Position = bdsource.Count - 1;
            btnSau.Enabled = false;
            btnCuoi.Enabled = false;
            btnTruoc.Enabled = true;
            btnDau.Enabled = true;
        }

        private void rdbDA_CheckedChanged(object sender, EventArgs e)
        {
            FrmXemXetTT_Load(this, null);
        }

        private void rdbKN_CheckedChanged(object sender, EventArgs e)
        {
            FrmXemXetTT_Load(this, null);
        }

        private void btnTT_Click(object sender, EventArgs e)
        {
            try
            {
                string str = "", tennguoitiencu = honv + " " + tennv;
                int vitri = dgvXXTT.CurrentCell.RowIndex;
                string manv = dgvXXTT.Rows[vitri].Cells[0].Value.ToString();
                if (rdbDA.Checked == true)
                {
                    string tongda = dgvXXTT.Rows[vitri].Cells[2].Value.ToString();
                    str = "insert into XemXetThangTien values('" + manv + "', '" + tongda + "', '', N'" + tennguoitiencu + "', Getdate(), N'Chờ duyệt', N'', '')";
                }
                else if (rdbKN.Checked == true)
                {
                    string tongkn = dgvXXTT.Rows[vitri].Cells[2].Value.ToString();
                    str = "insert into XemXetThangTien values('" + manv + "', '', '" + tongkn + "', N'" + tennguoitiencu + "', Getdate(), N'Chờ duyệt', N'', '')";
                }
                data.ExecuteNonQuery(str);
                data.ExecuteNonQuery("update XemXetThangTien set TongDuAn = (select count(*) from KinhNghiem where MaNV = " + manv + " and TrangThai = N'Đã hoàn thành'), " +
                    "TongKyNang = (select count(*) from KN_NV where MaNV = " + manv + ") where MaNV = " + manv + " and TrangThai = N'Chờ duyệt'");
                MessageBox.Show("Tiến cử nhân viên thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
