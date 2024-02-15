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
    public partial class FrmHDNV : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        string manv = "";
        int quyen;
        public FrmHDNV(int quyen, string manv)
        {
            InitializeComponent();
            this.quyen = quyen;
            this.manv = manv;
        }

        private void FrmHDNV_Load(object sender, EventArgs e)
        {
            if (quyen == 0)
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                btnNV.Enabled = false;
                loadDataPQ();
            }
            else
            {
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnNV.Enabled = true;
                loadData();
            }
            btnDau.Enabled = false;
            btnTruoc.Enabled = false;
            cbbTim.SelectedIndex = 0;
            rdbAll.Checked = true;
        }
        private void loadData()
        {
            string str = "select HDNV.MaHDNV as [Mã Hợp đồng], HDNV.MaNV as [Mã Nhân viên], NgayBatDau as [Bắt đầu], NgayKetThuc as [Kết thúc], " +
                "CongViec as [Công việc], Luong as [Lương], TrangThai as [Trạng thái], HoNV as [Họ], TenNV as [Tên] from HopDongNhanVien HDNV " +
                "join NhanVien NV on HDNV.MaNV = NV.MaNV join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvHDNV.DataSource = bdsource;
            dgvHDNV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[5].DefaultCellStyle.Format = "N2";
        }
        private void loadDataCH()
        {
            string str = "select HDNV.MaHDNV as [Mã Hợp đồng], HDNV.MaNV as [Mã Nhân viên], NgayBatDau as [Bắt đầu], NgayKetThuc as [Kết thúc], " +
                "CongViec as [Công việc], Luong as [Lương], TrangThai as [Trạng thái], HoNV as [Họ], TenNV as [Tên] from HopDongNhanVien HDNV " +
                "join NhanVien NV on HDNV.MaNV = NV.MaNV join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV " +
                "where TrangThai = N'Còn hạn'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvHDNV.DataSource = bdsource;
            dgvHDNV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[5].DefaultCellStyle.Format = "N2";
        }
        private void loadDataHH()
        {
            string str = "select HDNV.MaHDNV as [Mã Hợp đồng], HDNV.MaNV as [Mã Nhân viên], NgayBatDau as [Bắt đầu], NgayKetThuc as [Kết thúc], " +
                "CongViec as [Công việc], Luong as [Lương], TrangThai as [Trạng thái], HoNV as [Họ], TenNV as [Tên] from HopDongNhanVien HDNV " +
                "join NhanVien NV on HDNV.MaNV = NV.MaNV join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV " +
                "where TrangThai = N'Hết hạn'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvHDNV.DataSource = bdsource;
            dgvHDNV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[5].DefaultCellStyle.Format = "N2";
        }
        private void loadDataPQ()
        {
            string str = "select HDNV.MaHDNV as [Mã Hợp đồng], HDNV.MaNV as [Mã Nhân viên], NgayBatDau as [Bắt đầu], NgayKetThuc as [Kết thúc], " +
                "CongViec as [Công việc], Luong as [Lương], TrangThai as [Trạng thái], HoNV as [Họ], TenNV as [Tên] from HopDongNhanVien HDNV " +
                "join NhanVien NV on HDNV.MaNV = NV.MaNV join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV where HDNV.MaNV = " + manv;
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvHDNV.DataSource = bdsource;
            dgvHDNV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[5].DefaultCellStyle.Format = "N2";
        }
        private void loadDataPQCH()
        {
            string str = "select HDNV.MaHDNV as [Mã Hợp đồng], HDNV.MaNV as [Mã Nhân viên], NgayBatDau as [Bắt đầu], NgayKetThuc as [Kết thúc], " +
                "CongViec as [Công việc], Luong as [Lương], TrangThai as [Trạng thái], HoNV as [Họ], TenNV as [Tên] from HopDongNhanVien HDNV " +
                "join NhanVien NV on HDNV.MaNV = NV.MaNV join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV where HDNV.MaNV = " + manv + " and TrangThai = N'Còn hạn'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvHDNV.DataSource = bdsource;
            dgvHDNV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[5].DefaultCellStyle.Format = "N2";
        }
        private void loadDataPQHH()
        {
            string str = "select HDNV.MaHDNV as [Mã Hợp đồng], HDNV.MaNV as [Mã Nhân viên], NgayBatDau as [Bắt đầu], NgayKetThuc as [Kết thúc], " +
                "CongViec as [Công việc], Luong as [Lương], TrangThai as [Trạng thái], HoNV as [Họ], TenNV as [Tên] from HopDongNhanVien HDNV " +
                "join NhanVien NV on HDNV.MaNV = NV.MaNV join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV where HDNV.MaNV = " + manv + " and TrangThai = N'Hết hạn'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvHDNV.DataSource = bdsource;
            dgvHDNV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[5].DefaultCellStyle.Format = "N2";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvHDNV.CurrentCell.RowIndex;
                string mahdnv = dgvHDNV.Rows[vitri].Cells[0].Value.ToString();
                string manv = dgvHDNV.Rows[vitri].Cells[1].Value.ToString();
                string ngaybatdau = dgvHDNV.Rows[vitri].Cells[2].Value.ToString();
                string ngayketthuc = dgvHDNV.Rows[vitri].Cells[3].Value.ToString();
                string congviec = dgvHDNV.Rows[vitri].Cells[4].Value.ToString();
                string luong = dgvHDNV.Rows[vitri].Cells[5].Value.ToString();
                string trangthai = dgvHDNV.Rows[vitri].Cells[6].Value.ToString();
                string honv = dgvHDNV.Rows[vitri].Cells[7].Value.ToString();
                string tennv = dgvHDNV.Rows[vitri].Cells[8].Value.ToString();
                DataTable dt = new DataTable();
                dt = data.ExcuteQuery("select * from HopDongNhanVien where MaHDNV = '" + mahdnv + "'");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Mã hợp đồng đã tồn tại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadData();
                    return;
                }
                dt = data.ExcuteQuery("select * from NhanVien where MaNV = '" + manv + "'");
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Mã nhân viên không tồn tại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadData();
                    return;
                }
                data.ExecuteNonQuery("insert into HopDongNhanVien values('" + mahdnv + "','" + manv + "', " +
                    "'" + ngaybatdau + "', '" + ngayketthuc + "', N'" + congviec + "', '" + luong + "', " +
                    "N'" + trangthai + "')");
                MessageBox.Show("Thêm hợp đồng của nhân viên " + (honv + " " + tennv) + " thành công!", "Thông Báo",
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
                int vitri = dgvHDNV.CurrentCell.RowIndex;
                string mahdnv = dgvHDNV.Rows[vitri].Cells[0].Value.ToString();
                string honv = dgvHDNV.Rows[vitri].Cells[7].Value.ToString();
                string tennv = dgvHDNV.Rows[vitri].Cells[8].Value.ToString();
                data.ExecuteNonQuery("delete from HopDongNhanVien where MaHDNV ='" + mahdnv + "'");
                MessageBox.Show("Xóa hợp đồng của nhân viên " + (honv + " " + tennv) + " thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa hợp đồng của nhân viên thất bại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvHDNV.CurrentCell.RowIndex;
                string mahdnv = dgvHDNV.Rows[vitri].Cells[0].Value.ToString();
                string manv = dgvHDNV.Rows[vitri].Cells[1].Value.ToString();               
                string ngaybatdau = dgvHDNV.Rows[vitri].Cells[2].Value.ToString();
                string ngayketthuc = dgvHDNV.Rows[vitri].Cells[3].Value.ToString();
                string congviec = dgvHDNV.Rows[vitri].Cells[4].Value.ToString();
                string luong = dgvHDNV.Rows[vitri].Cells[5].Value.ToString();                
                string trangthai = dgvHDNV.Rows[vitri].Cells[6].Value.ToString();
                string honv = dgvHDNV.Rows[vitri].Cells[7].Value.ToString();
                string tennv = dgvHDNV.Rows[vitri].Cells[8].Value.ToString();
                DataTable dt = new DataTable();
                dt = data.ExcuteQuery("select * from NhanVien where MaNV = '" + manv + "'");
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Mã nhân viên không tồn tại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadData();
                    return;
                }
                data.ExecuteNonQuery("update HopDongNhanVien set MaNV= '" + manv + "', " +
                    "NgayBatDau= '" + ngaybatdau + "', NgayKetThuc= '" + ngayketthuc + "', CongViec= N'" + congviec + "', " +
                    "Luong= '" + luong + "', " +
                    "TrangThai= N'" + trangthai + "' where MaHDNV= '" + mahdnv + "'");
                MessageBox.Show("Sửa hợp đồng của nhân viên " + (honv + " " + tennv) + " thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnNV_Click(object sender, EventArgs e)
        {
            string str = "";
            if (cbbTim.SelectedIndex == 0)
                str = "select HDNV.MaHDNV as [Mã Hợp đồng], HDNV.MaNV as [Mã Nhân viên], NgayBatDau as [Bắt đầu], NgayKetThuc as [Kết thúc], " +
                    "CongViec as [Công việc], Luong as [Lương], TrangThai as [Trạng thái], HoNV as [Họ], TenNV as [Tên] from HopDongNhanVien HDNV " +
                    "join NhanVien NV on HDNV.MaNV = NV.MaNV join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV " +
                    "where HoNV + ' ' + TenNV like N'%" + txtTim.Text + "%'";
            else if (cbbTim.SelectedIndex == 1)
                str = "select HDNV.MaHDNV as [Mã Hợp đồng], HDNV.MaNV as [Mã Nhân viên], NgayBatDau as [Bắt đầu], NgayKetThuc as [Kết thúc], " +
                    "CongViec as [Công việc], Luong as [Lương], TrangThai as [Trạng thái], HoNV as [Họ], TenNV as [Tên] from HopDongNhanVien HDNV " +
                    "join NhanVien NV on HDNV.MaNV = NV.MaNV join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV " +
                    "where NgayKetThuc < Getdate()";
            else if (cbbTim.SelectedIndex == 2)
            {
                string sqlFormat = "MM-dd-yyyy";
                str = "select HDNV.MaHDNV as [Mã Hợp đồng], HDNV.MaNV as [Mã Nhân viên], NgayBatDau as [Bắt đầu], NgayKetThuc as [Kết thúc], " +
                    "CongViec as [Công việc], Luong as [Lương], TrangThai as [Trạng thái], HoNV as [Họ], TenNV as [Tên] from HopDongNhanVien HDNV " +
                    "join NhanVien NV on HDNV.MaNV = NV.MaNV join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV " +
                    "where NgayBatDau >= '" + dtpTuNgay.Value.ToString(sqlFormat) + "' and NgayKetThuc <= '" + dtpDenNgay.Value.ToString(sqlFormat) + "'";
            }
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvHDNV.DataSource = dt;
            txtTim.Text = "";
            if (cbbTim.SelectedIndex == 0)
                txtTim.Focus();
            dgvHDNV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvHDNV.Columns[5].DefaultCellStyle.Format = "N2";
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

        private void dgvHDNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri = dgvHDNV.CurrentCell.RowIndex;
            dgvHDNV.Rows[vitri].Cells[0].ReadOnly = true;
            dgvHDNV.Rows[vitri].Cells[7].ReadOnly = true;
            dgvHDNV.Rows[vitri].Cells[8].ReadOnly = true;
        }

        private void cbbTim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTim.SelectedIndex == 0)
            {
                lblTim.Text = "Tên NV:";
                txtTim.Text = "";
                txtTim.Focus();
                lblTim.Visible = true;
                txtTim.Visible = true;
                lblTim2.Visible = false;
                dtpTuNgay.Visible = false;
                dtpDenNgay.Visible = false;
            }
            else if (cbbTim.SelectedIndex == 1)
            {
                lblTim.Visible = false;
                txtTim.Visible = false;
                lblTim2.Visible = false;
                dtpTuNgay.Visible = false;
                dtpDenNgay.Visible = false;
            }
            else if (cbbTim.SelectedIndex == 2)
            {
                lblTim.Text = "Từ ngày:";
                lblTim.Visible = true;
                lblTim2.Visible = true;
                dtpTuNgay.Visible = true;
                dtpDenNgay.Visible = true;
                txtTim.Visible = false;
            }
        }

        private void btnCNTT_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvHDNV.CurrentCell.RowIndex;
                string mahdnv = dgvHDNV.Rows[vitri].Cells[0].Value.ToString();
                string ngaybatdau = dgvHDNV.Rows[vitri].Cells[2].Value.ToString();
                string ngayketthuc = dgvHDNV.Rows[vitri].Cells[3].Value.ToString();
                string trangthai = dgvHDNV.Rows[vitri].Cells[6].Value.ToString();
                data.ExecuteNonQuery("update HopDongNhanVien set TrangThai = case when NgayKetThuc < Getdate() then N'Hết hạn' " +
                    "when NgayKetThuc >= Getdate() then N'Còn hạn' else TrangThai end");
                MessageBox.Show("Cập nhật trạng thái hợp đồng thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void rdbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (quyen == 0)
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                btnNV.Enabled = false;
                loadDataPQ();
            }
            else
            {
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnNV.Enabled = true;
                loadData();
            }
        }

        private void rdbConHan_CheckedChanged(object sender, EventArgs e)
        {
            if (quyen == 0)
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                btnNV.Enabled = false;
                loadDataPQCH();
            }
            else
            {
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnNV.Enabled = true;
                loadDataCH();
            }
        }

        private void rdbHetHan_CheckedChanged(object sender, EventArgs e)
        {
            if (quyen == 0)
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
                btnNV.Enabled = false;
                loadDataPQHH();
            }
            else
            {
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                btnNV.Enabled = true;
                loadDataHH();
            }
        }
    }
}
