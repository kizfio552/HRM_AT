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
    public partial class FrmTinhTNTT : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        int quyen;
        string manv = "";
        public FrmTinhTNTT(int quyen, string manv)
        {
            InitializeComponent();
            this.quyen = quyen;
            this.manv = manv;
        }

        private void FrmTinhTNTT_Load(object sender, EventArgs e)
        {
            if (quyen == 0)
            {               
                btnXoa.Enabled = false;
                btnTim.Enabled = false;
                btnTinh.Enabled = false;
                loadDataPQ();
            }
            else
            {               
                btnXoa.Enabled = true;
                btnTim.Enabled = true;
                btnTinh.Enabled = true;
                loadData();
            }
            btnDau.Enabled = false;
            btnTruoc.Enabled = false;
        }
        private void loadData()
        {
            string str = "select MaPL as [Mã Phiếu lương], PL.MaHDNV as [Mã Hợp đồng], HoNV as [Họ], TenNV as [Tên], PL.Luong as [Lương], " +
                "BHXH_Emp as [BHXH_NV], BHYT_Emp as [BHYT_NV], BHTN_Emp as [BHTN_NV], (PL.Luong - BHXH_Emp - BHYT_Emp - BHTN_Emp) as TNTT " +
                "from PhieuLuong PL join HopDongNhanVien HDNV on PL.MaHDNV = HDNV.MaHDNV " +
                "join NhanVien NV on HDNV.MaNV = NV.MaNV join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvTNTT.DataSource = bdsource;
            dgvTNTT.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNTT.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNTT.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNTT.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNTT.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNTT.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNTT.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNTT.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNTT.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNTT.Columns[4].DefaultCellStyle.Format = "N2";
            dgvTNTT.Columns[5].DefaultCellStyle.Format = "N2";
            dgvTNTT.Columns[6].DefaultCellStyle.Format = "N2";
            dgvTNTT.Columns[7].DefaultCellStyle.Format = "N2";
            dgvTNTT.Columns[8].DefaultCellStyle.Format = "N2";
        }
        private void loadDataPQ()
        {
            string str = "select MaPL as [Mã Phiếu lương], PL.MaHDNV as [Mã Hợp đồng], HoNV as [Họ], TenNV as [Tên], PL.Luong as [Lương], " +
                "BHXH_Emp as [BHXH_NV], BHYT_Emp as [BHYT_NV], BHTN_Emp as [BHTN_NV], (PL.Luong - BHXH_Emp - BHYT_Emp - BHTN_Emp) as TNTT " +
                 "from PhieuLuong PL join HopDongNhanVien HDNV on PL.MaHDNV = HDNV.MaHDNV " +
                 "join NhanVien NV on HDNV.MaNV = NV.MaNV join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV " +
                 "where NV.MaNV = " + manv;
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvTNTT.DataSource = bdsource;
            dgvTNTT.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNTT.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNTT.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNTT.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNTT.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNTT.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNTT.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNTT.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNTT.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNTT.Columns[4].DefaultCellStyle.Format = "N2";
            dgvTNTT.Columns[5].DefaultCellStyle.Format = "N2";
            dgvTNTT.Columns[6].DefaultCellStyle.Format = "N2";
            dgvTNTT.Columns[7].DefaultCellStyle.Format = "N2";
            dgvTNTT.Columns[8].DefaultCellStyle.Format = "N2";
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

        private void btnTim_Click(object sender, EventArgs e)
        {
            string str = "select MaPL as [Mã Phiếu lương], PL.MaHDNV as [Mã Hợp đồng], HoNV as [Họ], TenNV as [Tên], PL.Luong as [Lương], " +
                "BHXH_Emp as [BHXH_NV], BHYT_Emp as [BHYT_NV], BHTN_Emp as [BHTN_NV], (PL.Luong - BHXH_Emp - BHYT_Emp - BHTN_Emp) as TNTT " +
                 "from PhieuLuong PL join HopDongNhanVien HDNV on PL.MaHDNV = HDNV.MaHDNV " +
                 "join NhanVien NV on HDNV.MaNV = NV.MaNV join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV " +
                 "where HoNV + ' ' + TenNV like N'%" + txtTenNV.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvTNTT.DataSource = dt;
            txtTenNV.Text = "";
            txtTenNV.Focus();
            dgvTNTT.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNTT.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNTT.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNTT.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNTT.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNTT.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNTT.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNTT.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNTT.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNTT.Columns[4].DefaultCellStyle.Format = "N2";
            dgvTNTT.Columns[5].DefaultCellStyle.Format = "N2";
            dgvTNTT.Columns[6].DefaultCellStyle.Format = "N2";
            dgvTNTT.Columns[7].DefaultCellStyle.Format = "N2";
            dgvTNTT.Columns[8].DefaultCellStyle.Format = "N2";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvTNTT.CurrentCell.RowIndex;
                string mapl = dgvTNTT.Rows[vitri].Cells[0].Value.ToString();
                data.ExecuteNonQuery("delete from PhieuLuong where MaPL ='" + mapl + "'");
                MessageBox.Show("Xóa thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thất bại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvTNTT.CurrentCell.RowIndex;
                string mapl = dgvTNTT.Rows[vitri].Cells[0].Value.ToString();                
                float luong = float.Parse(dgvTNTT.Rows[vitri].Cells[4].Value.ToString());
                float bhxh_emp = (float)(luong * 0.08);
                if (bhxh_emp > 2384000)
                    bhxh_emp = 2384000;
                float bhyt_emp = (float)(luong * 0.015);
                if (bhyt_emp > 447000)
                    bhyt_emp = 447000;
                float bhtn_emp = (float)(luong * 0.01);
                if (bhtn_emp > 884000)
                    bhtn_emp = 884000;
                data.ExecuteNonQuery("update PhieuLuong set BHXH_Emp = '" + bhxh_emp + "', BHYT_Emp = '" + bhyt_emp + "', " +
                    "BHTN_Emp = '" + bhtn_emp + "' where MaPL= " + mapl);
                MessageBox.Show("Tính thu nhập trước thuế thành công!", "Thông Báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvTNTT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri = dgvTNTT.CurrentCell.RowIndex;
            dgvTNTT.Rows[vitri].Cells[0].ReadOnly = true;
            dgvTNTT.Rows[vitri].Cells[1].ReadOnly = true;
            dgvTNTT.Rows[vitri].Cells[2].ReadOnly = true;
            dgvTNTT.Rows[vitri].Cells[3].ReadOnly = true;
            dgvTNTT.Rows[vitri].Cells[4].ReadOnly = true;
            dgvTNTT.Rows[vitri].Cells[5].ReadOnly = true;
            dgvTNTT.Rows[vitri].Cells[6].ReadOnly = true;
            dgvTNTT.Rows[vitri].Cells[7].ReadOnly = true;
        }
    }
}
