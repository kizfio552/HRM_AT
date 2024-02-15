using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS_AT
{
    public partial class FrmChamCong : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        int quyen;
        string manv = "";
        public FrmChamCong(int quyen, string manv)
        {
            InitializeComponent();
            this.quyen = quyen;
            this.manv = manv;
        }

        private void FrmChamCong_Load(object sender, EventArgs e)
        {
            if (quyen == 0)
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                btnTim.Enabled = false;
                btnTinh.Enabled = false;
                loadDataPQ();
            }
            else
            {
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnTim.Enabled = true;
                btnTinh.Enabled = true;
                loadData();
            }
            btnDau.Enabled = false;
            btnTruoc.Enabled = false;
        }
        private void loadData()
        {
            string str = "select MaPL as [Mã Phiếu lương], PL.MaHDNV as [Mã Hợp đồng], HoNV as [Họ], TenNV as [Tên], GioLamViecTieuChuan as [Giờ làm việc tiêu chuẩn], " +
                "GioLamViecThucTe as [Giờ làm việc thực tế], GioTangCa as [Tăng ca], GioPhat as [Phạt], PL.Luong as [Lương], " +
                "NV.TenNganHang as [Ngân hàng], NV.STKNganHang as [STK Ngân hàng], NV.TenTKNganHang as [Tên TK Ngân hàng], HDNV.Luong as [Lương hợp đồng] " +
                "from PhieuLuong PL join HopDongNhanVien HDNV on PL.MaHDNV = HDNV.MaHDNV join NhanVien NV on HDNV.MaNV = NV.MaNV " +
                "join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvChamcong.DataSource = bdsource;
            dgvChamcong.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[8].DefaultCellStyle.Format = "N2";
            dgvChamcong.Columns[12].DefaultCellStyle.Format = "N2";
        }
        private void loadDataPQ()
        {
            string str = "select MaPL as [Mã Phiếu lương], PL.MaHDNV as [Mã Hợp đồng], HoNV as [Họ], TenNV as [Tên], GioLamViecTieuChuan as [Giờ làm việc tiêu chuẩn], " +
                "GioLamViecThucTe as [Giờ làm việc thực tế], GioTangCa as [Tăng ca], GioPhat as [Phạt], PL.Luong as [Lương], " +
                "NV.TenNganHang as [Ngân hàng], NV.STKNganHang as [STK Ngân hàng], NV.TenTKNganHang as [Tên TK Ngân hàng], HDNV.Luong as [Lương hợp đồng] " +
                "from PhieuLuong PL join HopDongNhanVien HDNV on PL.MaHDNV = HDNV.MaHDNV join NhanVien NV on HDNV.MaNV = NV.MaNV " +
                "join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV where NV.MaNV = " + manv;
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvChamcong.DataSource = bdsource;
            dgvChamcong.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[8].DefaultCellStyle.Format = "N2";
            dgvChamcong.Columns[12].DefaultCellStyle.Format = "N2";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string str = "select MaPL as [Mã Phiếu lương], PL.MaHDNV as [Mã Hợp đồng], HoNV as [Họ], TenNV as [Tên], GioLamViecTieuChuan as [Giờ làm việc tiêu chuẩn], " +
                "GioLamViecThucTe as [Giờ làm việc thực tế], GioTangCa as [Tăng ca], GioPhat as [Phạt], PL.Luong as [Lương], " +
                "NV.TenNganHang as [Ngân hàng], NV.STKNganHang as [STK Ngân hàng], NV.TenTKNganHang as [Tên TK Ngân hàng], HDNV.Luong as [Lương hợp đồng] " +
                "from PhieuLuong PL join HopDongNhanVien HDNV on PL.MaHDNV = HDNV.MaHDNV join NhanVien NV on HDNV.MaNV = NV.MaNV " +
                "join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV where HoNV + ' ' + TenNV like N'%" + txtTenNV.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvChamcong.DataSource = dt;
            txtTenNV.Text = "";
            txtTenNV.Focus();
            dgvChamcong.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvChamcong.Columns[8].DefaultCellStyle.Format = "N2";
            dgvChamcong.Columns[12].DefaultCellStyle.Format = "N2";
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

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvChamcong.CurrentCell.RowIndex;
                string mapl = dgvChamcong.Rows[vitri].Cells[0].Value.ToString();
                string mahdnv = dgvChamcong.Rows[vitri].Cells[1].Value.ToString();
                string giolamviecthucte = dgvChamcong.Rows[vitri].Cells[5].Value.ToString();
                string giotangca = dgvChamcong.Rows[vitri].Cells[6].Value.ToString();
                DataTable dt = new DataTable();
                dt = data.ExcuteQuery("select * from PhieuLuong where MaPL = '" + mapl + "'");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Mã phiếu lương đã tồn tại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadData();
                    return;
                }
                dt = data.ExcuteQuery("select * from HopDongNhanVien where MaHDNV = '" + mahdnv + "'");
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Mã hợp đồng không tồn tại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadData();
                    return;
                }
                data.ExecuteNonQuery("insert into PhieuLuong values('" + mapl + "','" + mahdnv + "', 160,'" + giolamviecthucte + "'," +
                    "'" + giotangca + "', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '', '')");
                MessageBox.Show("Thêm chấm công thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvChamcong.CurrentCell.RowIndex;
                string mapl = dgvChamcong.Rows[vitri].Cells[0].Value.ToString();
                data.ExecuteNonQuery("delete from PhieuLuong where MaPL ='" + mapl + "'");
                MessageBox.Show("Xóa chấm công thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvChamcong.CurrentCell.RowIndex;
                string mapl = dgvChamcong.Rows[vitri].Cells[0].Value.ToString();
                string giolamviecthucte = dgvChamcong.Rows[vitri].Cells[5].Value.ToString();
                string giotangca = dgvChamcong.Rows[vitri].Cells[6].Value.ToString();
                data.ExecuteNonQuery("update PhieuLuong set GioTangCa= '" + giotangca + "', GioLamViecThucTe= '" + giolamviecthucte + "'" +
                   " where MaPL = '" + mapl + "'");
                MessageBox.Show("Sửa chấm công thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvChamcong.CurrentCell.RowIndex;
                string mapl = dgvChamcong.Rows[vitri].Cells[0].Value.ToString();
                float giolamviectieuchuan = float.Parse(dgvChamcong.Rows[vitri].Cells[4].Value.ToString());
                float giolamviecthucte = float.Parse(dgvChamcong.Rows[vitri].Cells[5].Value.ToString());
                float giotangca = float.Parse(dgvChamcong.Rows[vitri].Cells[6].Value.ToString());
                float giophat = giolamviectieuchuan - (giolamviecthucte + giotangca);
                if (giophat < 0)
                    giophat = 0;
                float luonghopdong = float.Parse(dgvChamcong.Rows[vitri].Cells[12].Value.ToString());
                float luong = (giolamviecthucte - giotangca) * (luonghopdong / 160) + giotangca * (luonghopdong / 160 * 2) - giophat * (luonghopdong / 160);
                data.ExecuteNonQuery("update PhieuLuong set GioPhat= '" + giophat + "', Luong= '" + luong + "' where MaPL= " + mapl);
                MessageBox.Show("Tính chấm công thành công!", "Thông Báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvChamcong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri = dgvChamcong.CurrentCell.RowIndex;
            dgvChamcong.Rows[vitri].Cells[0].ReadOnly = true;
            dgvChamcong.Rows[vitri].Cells[2].ReadOnly = true;
            dgvChamcong.Rows[vitri].Cells[3].ReadOnly = true;
            dgvChamcong.Rows[vitri].Cells[4].ReadOnly = true;
            dgvChamcong.Rows[vitri].Cells[7].ReadOnly = true;
            dgvChamcong.Rows[vitri].Cells[8].ReadOnly = true;
            dgvChamcong.Rows[vitri].Cells[9].ReadOnly = true;
            dgvChamcong.Rows[vitri].Cells[10].ReadOnly = true;
            dgvChamcong.Rows[vitri].Cells[11].ReadOnly = true;
            dgvChamcong.Rows[vitri].Cells[12].ReadOnly = true;
        }
    }
}
