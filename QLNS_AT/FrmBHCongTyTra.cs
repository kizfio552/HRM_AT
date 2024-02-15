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
    public partial class FrmBHCongTyTra : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        int quyen;
        string manv = "";
        public FrmBHCongTyTra(int quyen, string manv)
        {
            InitializeComponent();
            this.quyen = quyen;
            this.manv = manv;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string str = "select MaPL as [Mã Phiếu lương], PL.MaHDNV as [Mã Hợp đồng], HoNV as [Họ], TenNV as [Tên], PL.Luong as [Lương], " +
                "BHXH_Comp as [BHXH_CTy], BHYT_Comp as [BHYT_CTy], BHTN_Comp as [BHTN_CTy], CongTyTra as [Công ty trả] " +
               "from PhieuLuong PL join HopDongNhanVien HDNV on PL.MaHDNV = HDNV.MaHDNV " +
               "join NhanVien NV on HDNV.MaNV = NV.MaNV join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV " +
               "where HoNV + ' ' + TenNV like N'%" + txtTenNV.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvBHCTT.DataSource = dt;
            txtTenNV.Text = "";
            txtTenNV.Focus();
            dgvBHCTT.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBHCTT.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBHCTT.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBHCTT.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBHCTT.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBHCTT.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBHCTT.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBHCTT.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBHCTT.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBHCTT.Columns[4].DefaultCellStyle.Format = "N2";
            dgvBHCTT.Columns[5].DefaultCellStyle.Format = "N2";
            dgvBHCTT.Columns[6].DefaultCellStyle.Format = "N2";
            dgvBHCTT.Columns[7].DefaultCellStyle.Format = "N2";
            dgvBHCTT.Columns[8].DefaultCellStyle.Format = "N2";
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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvBHCTT.CurrentCell.RowIndex;
                string mapl = dgvBHCTT.Rows[vitri].Cells[0].Value.ToString();
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
                int vitri = dgvBHCTT.CurrentCell.RowIndex;
                string mapl = dgvBHCTT.Rows[vitri].Cells[0].Value.ToString();
                float luong = float.Parse(dgvBHCTT.Rows[vitri].Cells[4].Value.ToString());
                float bhxh_comp = (float)(luong * 0.175);
                if (bhxh_comp > 5215000)
                    bhxh_comp = 5215000;
                float bhyt_comp = (float)(luong * 0.03);
                if (bhyt_comp > 894000)
                    bhyt_comp = 894000;
                float bhtn_comp = (float)(luong * 0.01);
                if (bhtn_comp > 884000)
                    bhtn_comp = 884000;
                float tiencongtytra = luong + bhxh_comp + bhyt_comp + bhtn_comp;
                data.ExecuteNonQuery("update PhieuLuong set BHXH_Comp = '" + bhxh_comp + "', BHYT_Comp = '" + bhyt_comp + "', " +
                    "BHTN_Comp = '" + bhtn_comp + "', CongTyTra = '" + tiencongtytra + "' where MaPL= " + mapl);
                MessageBox.Show("Tính bảo hiểm công ty phải trả thành công!", "Thông Báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvBHCTT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri = dgvBHCTT.CurrentCell.RowIndex;
            dgvBHCTT.Rows[vitri].Cells[0].ReadOnly = true;
            dgvBHCTT.Rows[vitri].Cells[1].ReadOnly = true;
            dgvBHCTT.Rows[vitri].Cells[2].ReadOnly = true;
            dgvBHCTT.Rows[vitri].Cells[3].ReadOnly = true;
            dgvBHCTT.Rows[vitri].Cells[4].ReadOnly = true;
            dgvBHCTT.Rows[vitri].Cells[5].ReadOnly = true;
            dgvBHCTT.Rows[vitri].Cells[6].ReadOnly = true;
            dgvBHCTT.Rows[vitri].Cells[7].ReadOnly = true;
            dgvBHCTT.Rows[vitri].Cells[8].ReadOnly = true;
        }

        private void FrmBHCongTyTra_Load(object sender, EventArgs e)
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
                "BHXH_Comp as [BHXH_CTy], BHYT_Comp as [BHYT_CTy], BHTN_Comp as [BHTN_CTy], CongTyTra as [Công ty trả] " +
                "from PhieuLuong PL join HopDongNhanVien HDNV on PL.MaHDNV = HDNV.MaHDNV " +
                "join NhanVien NV on HDNV.MaNV = NV.MaNV join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvBHCTT.DataSource = bdsource;
            dgvBHCTT.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBHCTT.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBHCTT.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBHCTT.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBHCTT.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBHCTT.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBHCTT.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBHCTT.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBHCTT.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBHCTT.Columns[4].DefaultCellStyle.Format = "N2";
            dgvBHCTT.Columns[5].DefaultCellStyle.Format = "N2";
            dgvBHCTT.Columns[6].DefaultCellStyle.Format = "N2";
            dgvBHCTT.Columns[7].DefaultCellStyle.Format = "N2";
            dgvBHCTT.Columns[8].DefaultCellStyle.Format = "N2";
        }
        private void loadDataPQ()
        {
            string str = "select MaPL as [Mã Phiếu lương], PL.MaHDNV as [Mã Hợp đồng], HoNV as [Họ], TenNV as [Tên], PL.Luong as [Lương], " +
                "BHXH_Comp as [BHXH_CTy], BHYT_Comp as [BHYT_CTy], BHTN_Comp as [BHTN_CTy], CongTyTra as [Công ty trả] " +
               "from PhieuLuong PL join HopDongNhanVien HDNV on PL.MaHDNV = HDNV.MaHDNV " +
               "join NhanVien NV on HDNV.MaNV = NV.MaNV join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV " +
               "where NV.MaNV = " + manv;
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvBHCTT.DataSource = bdsource;
            dgvBHCTT.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBHCTT.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBHCTT.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBHCTT.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBHCTT.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBHCTT.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBHCTT.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBHCTT.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBHCTT.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvBHCTT.Columns[4].DefaultCellStyle.Format = "N2";
            dgvBHCTT.Columns[5].DefaultCellStyle.Format = "N2";
            dgvBHCTT.Columns[6].DefaultCellStyle.Format = "N2";
            dgvBHCTT.Columns[7].DefaultCellStyle.Format = "N2";
            dgvBHCTT.Columns[8].DefaultCellStyle.Format = "N2";
        }
    }
}
