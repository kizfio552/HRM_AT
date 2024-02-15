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
    public partial class FrmLuongCuoi : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        int quyen;
        string manv = "";
        public FrmLuongCuoi(int quyen, string manv)
        {
            InitializeComponent();
            this.quyen = quyen;
            this.manv = manv;
        }

        private void FrmLuongCuoi_Load(object sender, EventArgs e)
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
            string str = "select MaPL as [Mã Phiếu lương], PL.MaHDNV as [Mã Hợp đồng], HoNV as [Họ], TenNV as [Tên], " +
                "(PL.Luong - BHXH_Emp - BHYT_Emp - BHTN_Emp) as TNTT, Thue as [Thuế], " +
                "Thuong as [Thưởng], KhauTru as [Khấu trừ], TongPhuCap as [Tổng phụ cấp], LuongThucNhan as [Lương thực nhận], NgayTra as [Ngày trả], GhiChu as [Ghi chú] " +
                "from PhieuLuong PL join HopDongNhanVien HDNV on PL.MaHDNV = HDNV.MaHDNV join NhanVien NV on HDNV.MaNV = NV.MaNV " +
                "join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvLCC.DataSource = bdsource;
            dgvLCC.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[4].DefaultCellStyle.Format = "N2";
            dgvLCC.Columns[5].DefaultCellStyle.Format = "N2";
            dgvLCC.Columns[6].DefaultCellStyle.Format = "N2";
            dgvLCC.Columns[7].DefaultCellStyle.Format = "N2";
            dgvLCC.Columns[8].DefaultCellStyle.Format = "N2";
            dgvLCC.Columns[9].DefaultCellStyle.Format = "N2";
        }
        private void loadDataPQ()
        {
            string str = "select MaPL as [Mã Phiếu lương], PL.MaHDNV as [Mã Hợp đồng], HoNV as [Họ], TenNV as [Tên], " +
                 "(PL.Luong - BHXH_Emp - BHYT_Emp - BHTN_Emp) as TNTT, Thue as [Thuế], " +
                 "Thuong as [Thưởng], KhauTru as [Khấu trừ], TongPhuCap as [Tổng phụ cấp], LuongThucNhan as [Lương thực nhận], NgayTra as [Ngày trả], GhiChu as [Ghi chú] " +
                 "from PhieuLuong PL join HopDongNhanVien HDNV on PL.MaHDNV = HDNV.MaHDNV join NhanVien NV on HDNV.MaNV = NV.MaNV " +
                "join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV where NV.MaNV = " + manv;
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvLCC.DataSource = bdsource;
            dgvLCC.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[4].DefaultCellStyle.Format = "N2";
            dgvLCC.Columns[5].DefaultCellStyle.Format = "N2";
            dgvLCC.Columns[6].DefaultCellStyle.Format = "N2";
            dgvLCC.Columns[7].DefaultCellStyle.Format = "N2";
            dgvLCC.Columns[8].DefaultCellStyle.Format = "N2";
            dgvLCC.Columns[9].DefaultCellStyle.Format = "N2";
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string str = "select MaPL as [Mã Phiếu lương], PL.MaHDNV as [Mã Hợp đồng], HoNV as [Họ], TenNV as [Tên], " +
                "(PL.Luong - BHXH_Emp - BHYT_Emp - BHTN_Emp) as TNTT, Thue as [Thuế], " +
                "Thuong as [Thưởng], KhauTru as [Khấu trừ], TongPhuCap as [Tổng phụ cấp], LuongThucNhan as [Lương thực nhận], NgayTra as [Ngày trả], GhiChu as [Ghi chú] " +
                "from PhieuLuong PL join HopDongNhanVien HDNV on PL.MaHDNV = HDNV.MaHDNV join NhanVien NV on HDNV.MaNV = NV.MaNV " +
                "join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV where HoNV + ' ' + TenNV like N'%" + txtTenNV.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvLCC.DataSource = dt;
            txtTenNV.Text = "";
            txtTenNV.Focus();
            dgvLCC.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvLCC.Columns[4].DefaultCellStyle.Format = "N2";
            dgvLCC.Columns[5].DefaultCellStyle.Format = "N2";
            dgvLCC.Columns[6].DefaultCellStyle.Format = "N2";
            dgvLCC.Columns[7].DefaultCellStyle.Format = "N2";
            dgvLCC.Columns[8].DefaultCellStyle.Format = "N2";
            dgvLCC.Columns[9].DefaultCellStyle.Format = "N2";
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

        private void dgvLCC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri = dgvLCC.CurrentCell.RowIndex;
            dgvLCC.Rows[vitri].Cells[0].ReadOnly = true;
            dgvLCC.Rows[vitri].Cells[1].ReadOnly = true;
            dgvLCC.Rows[vitri].Cells[2].ReadOnly = true;
            dgvLCC.Rows[vitri].Cells[3].ReadOnly = true;
            dgvLCC.Rows[vitri].Cells[4].ReadOnly = true;
            dgvLCC.Rows[vitri].Cells[5].ReadOnly = true;
            dgvLCC.Rows[vitri].Cells[8].ReadOnly = true;
            dgvLCC.Rows[vitri].Cells[9].ReadOnly = true;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvLCC.CurrentCell.RowIndex;
                string mapl = dgvLCC.Rows[vitri].Cells[0].Value.ToString();
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
        private void TinhTongPC()
        {
            try
            {
                int vitri = dgvLCC.CurrentCell.RowIndex;
                string mapl = dgvLCC.Rows[vitri].Cells[0].Value.ToString();
                data.ExecuteNonQuery("update PhieuLuong set TongPhuCap= (select sum(ThanhTien) from " +
                    "PhieuLuong PL join HopDongNhanVien HDNV on PL.MaHDNV = HDNV.MaHDNV join PhuCap PC on PC.MaHDNV = HDNV.MaHDNV" +
                    " where MaPL= " + mapl + " and YeuCau= N'Chấp nhận')" +
                    " where MaPL= " + mapl);
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.ToString(), "Thông Báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnTinh_Click(object sender, EventArgs e)
        {
            TinhTongPC();
            try
            {
                int vitri = dgvLCC.CurrentCell.RowIndex;
                string mapl = dgvLCC.Rows[vitri].Cells[0].Value.ToString();
                float tntt = float.Parse(dgvLCC.Rows[vitri].Cells[4].Value.ToString());
                float thue = float.Parse(dgvLCC.Rows[vitri].Cells[5].Value.ToString());
                float thuong = float.Parse(dgvLCC.Rows[vitri].Cells[6].Value.ToString());
                float khautru = float.Parse(dgvLCC.Rows[vitri].Cells[7].Value.ToString());
                float phucap = float.Parse(dgvLCC.Rows[vitri].Cells[8].Value.ToString());
                float luongthucnhan = tntt - thue + thuong + phucap - khautru;
                data.ExecuteNonQuery("update PhieuLuong set LuongThucNhan = '" + luongthucnhan + "' where MaPL= " + mapl);
                MessageBox.Show("Tính lương cuối cùng của nhân viên thành công!", "Thông Báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvLCC.CurrentCell.RowIndex;
                string mapl = dgvLCC.Rows[vitri].Cells[0].Value.ToString();
                float thuong = float.Parse(dgvLCC.Rows[vitri].Cells[6].Value.ToString());
                float khautru = float.Parse(dgvLCC.Rows[vitri].Cells[7].Value.ToString());
                string ngaytra = dgvLCC.Rows[vitri].Cells[10].Value.ToString();
                string ghichu = dgvLCC.Rows[vitri].Cells[11].Value.ToString();
                data.ExecuteNonQuery("update PhieuLuong set Thuong = '" + thuong + "', KhauTru = '" + khautru + "', " +
                    "NgayTra = '" + ngaytra + "', GhiChu = N'" + ghichu + "' where MaPL= " + mapl);
                MessageBox.Show("Cập nhật lương nhân viên thành công!", "Thông Báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
