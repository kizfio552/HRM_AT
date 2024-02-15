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
    public partial class FrmTinhThueTNCN : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        int quyen;
        string manv = "";
        public FrmTinhThueTNCN(int quyen, string manv)
        {
            InitializeComponent();
            this.quyen = quyen;
            this.manv = manv;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTinhThueTNCN_Load(object sender, EventArgs e)
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
            string str = "select MaPL as [Mã Phiếu lương], PL.MaHDNV as [Mã Hợp đồng], HoNV as [Họ], TenNV as [Tên], SoNguoiPT as [Người phụ thuộc], " +
                "(PL.Luong - BHXH_Emp - BHYT_Emp - BHTN_Emp) as TNTT, Thue as [Thuế] " +
                "from PhieuLuong PL join HopDongNhanVien HDNV on PL.MaHDNV = HDNV.MaHDNV " +
                "join NhanVien NV on HDNV.MaNV = NV.MaNV join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvTNCN.DataSource = bdsource;
            dgvTNCN.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNCN.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNCN.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNCN.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNCN.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNCN.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNCN.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNCN.Columns[5].DefaultCellStyle.Format = "N2";
            dgvTNCN.Columns[6].DefaultCellStyle.Format = "N2";
        }
        private void loadDataPQ()
        {
            string str = "select MaPL as [Mã Phiếu lương], PL.MaHDNV as [Mã Hợp đồng], HoNV as [Họ], TenNV as [Tên], SoNguoiPT as [Người phụ thuộc], " +
                "(PL.Luong - BHXH_Emp - BHYT_Emp - BHTN_Emp) as TNTT, Thue as [Thuế] " +
                "from PhieuLuong PL join HopDongNhanVien HDNV on PL.MaHDNV = HDNV.MaHDNV " +
                "join NhanVien NV on HDNV.MaNV = NV.MaNV join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV " +
                "where NV.MaNV = " + manv;
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvTNCN.DataSource = bdsource;
            dgvTNCN.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNCN.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNCN.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNCN.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNCN.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNCN.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNCN.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNCN.Columns[5].DefaultCellStyle.Format = "N2";
            dgvTNCN.Columns[6].DefaultCellStyle.Format = "N2";
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
            string str = "select MaPL as [Mã Phiếu lương], PL.MaHDNV as [Mã Hợp đồng], HoNV as [Họ], TenNV as [Tên], SoNguoiPT as [Người phụ thuộc], " +
                "(PL.Luong - BHXH_Emp - BHYT_Emp - BHTN_Emp) as TNTT, Thue as [Thuế] " +
                "from PhieuLuong PL join HopDongNhanVien HDNV on PL.MaHDNV = HDNV.MaHDNV " +
                "join NhanVien NV on HDNV.MaNV = NV.MaNV join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV " +
                "where HoNV + ' ' + TenNV like N'%" + txtTenNV.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvTNCN.DataSource = dt;
            txtTenNV.Text = "";
            txtTenNV.Focus();
            dgvTNCN.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNCN.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNCN.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNCN.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNCN.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNCN.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNCN.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTNCN.Columns[5].DefaultCellStyle.Format = "N2";
            dgvTNCN.Columns[6].DefaultCellStyle.Format = "N2";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvTNCN.CurrentCell.RowIndex;
                string mapl = dgvTNCN.Rows[vitri].Cells[0].Value.ToString();
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
                int vitri = dgvTNCN.CurrentCell.RowIndex;
                string mapl = dgvTNCN.Rows[vitri].Cells[0].Value.ToString();
                int songuoipt = int.Parse(dgvTNCN.Rows[vitri].Cells[4].Value.ToString());
                float tntt = float.Parse(dgvTNCN.Rows[vitri].Cells[5].Value.ToString());
                float thue = 0;
                float tnct = tntt - 11000000 - (songuoipt * 4400000);
                if (tnct > 0)
                {
                    /*if (tntt <= 5000000)
                        thue = 5 / 100 * tntt;
                    else if (tntt > 5000000 && tntt <= 10000000)
                        thue = (float)(10 / 100 * tntt - 0.25 * 1000000);
                    else if (tntt > 10000000 && tntt <= 18000000)
                        thue = (float)(15 / 100 * tntt - 0.75 * 1000000);
                    else if (tntt > 18000000 && tntt <= 32000000)
                        thue = (float)(20 / 100 * tntt - 1.65 * 1000000);
                    else if (tntt > 32000000 && tntt <= 52000000)
                        thue = (float)(25 / 100 * tntt - 3.25 * 1000000);
                    else if (tntt > 52000000 && tntt <= 80000000)
                        thue = (float)(30 / 100 * tntt - 5.85 * 1000000);
                    else if (tntt > 80000000)
                        thue = (float)(35 / 100 * tntt - 9.85 * 1000000);*/
                    if (tntt <= 5000000)
                        thue = 5 / 100 * tntt;
                    else if (tntt > 5000000 && tntt <= 10000000)
                        thue = (float)(0.25 * 1000000 + 10 / 100 * (tntt - 5000000));
                    else if (tntt > 10000000 && tntt <= 18000000)
                        thue = (float)(0.75 * 1000000 + 15 / 100 * (tntt - 10000000));
                    else if (tntt > 18000000 && tntt <= 32000000)
                        thue = (float)(1.95 * 1000000 + 20 / 100 * (tntt - 18000000));
                    else if (tntt > 32000000 && tntt <= 52000000)
                        thue = (float)(4.75 * 1000000 + 25 / 100 * (tntt - 32000000));
                    else if (tntt > 52000000 && tntt <= 80000000)
                        thue = (float)(9.75 * 1000000 + 30 / 100 * (tntt - 52000000));
                    else if (tntt > 80000000)
                        thue = (float)(18.15 * 1000000 + 35 / 100 * (tntt - 80000000));
                }
                else
                    thue = 0;
                data.ExecuteNonQuery("update PhieuLuong set Thue = '" + thue + "' where MaPL= " + mapl);
                MessageBox.Show("Tính thuế thu nhập cá nhân thành công!", "Thông Báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvTNCN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri = dgvTNCN.CurrentCell.RowIndex;
            dgvTNCN.Rows[vitri].Cells[0].ReadOnly = true;
            dgvTNCN.Rows[vitri].Cells[1].ReadOnly = true;
            dgvTNCN.Rows[vitri].Cells[2].ReadOnly = true;
            dgvTNCN.Rows[vitri].Cells[3].ReadOnly = true;
            dgvTNCN.Rows[vitri].Cells[4].ReadOnly = true;
            dgvTNCN.Rows[vitri].Cells[5].ReadOnly = true;
            dgvTNCN.Rows[vitri].Cells[6].ReadOnly = true;
        }
    }
}
