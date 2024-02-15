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
    public partial class FrmDuyetTT : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        string honv = "", tennv = "";
        public FrmDuyetTT(string honv, string tennv)
        {
            InitializeComponent();
            this.honv = honv;
            this.tennv = tennv;
        }
        private void loadData()
        {
            string str = "select XXTT.MaNV as [Mã NV], HoNV + ' ' + TenNV as [Tên nhân viên được tiến cử], TongDuAn as [Tổng dự án hoàn thành], " +
                "TongKyNang as [Số kỹ năng thuần thục], NguoiTienCu as [Người tiến cử], NgayTienCu as [Ngày được tiến cử], TrangThai as [Trạng thái], " +
                "NguoiDuyet as [Người duyệt], NgayDuyet as [Ngày được duyệt] from XemXetThangTien XXTT join NhanVien NV on XXTT.MaNV = NV.MaNV join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvTT.DataSource = bdsource;
            dgvTT.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTT.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTT.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTT.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTT.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTT.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTT.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTT.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTT.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }
        private void FrmDuyetTT_Load(object sender, EventArgs e)
        {
            cbbTim.SelectedIndex = 0;
            loadData();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string str = "";
            if (cbbTim.SelectedIndex == 0)
                str = "select XXTT.MaNV as [Mã NV], HoNV + ' ' + TenNV as [Tên nhân viên được tiến cử], TongDuAn as [Tổng dự án hoàn thành], " +
                    "TongKyNang as [Số kỹ năng thuần thục], NguoiTienCu as [Người tiến cử], NgayTienCu as [Ngày được tiến cử], TrangThai as [Trạng thái], NguoiDuyet as [Người duyệt], " +
                    "NgayDuyet as [Ngày được duyệt] from XemXetThangTien XXTT join NhanVien NV on XXTT.MaNV = NV.MaNV join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV " +
                    "where HoNV + ' ' + TenNV like N'%" + txtTim.Text + "%'";
            else if (cbbTim.SelectedIndex == 1)
                str = "select XXTT.MaNV as [Mã NV], HoNV + ' ' + TenNV as [Tên nhân viên được tiến cử], TongDuAn as [Tổng dự án hoàn thành], " +
                    "TongKyNang as [Số kỹ năng thuần thục], NguoiTienCu as [Người tiến cử], NgayTienCu as [Ngày được tiến cử], TrangThai as [Trạng thái], NguoiDuyet as [Người duyệt], " +
                    "NgayDuyet as [Ngày được duyệt] from XemXetThangTien XXTT join NhanVien NV on XXTT.MaNV = NV.MaNV join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV " +
                    "where NguoiTienCu like N'%" + txtTim.Text + "%'";
            else if (cbbTim.SelectedIndex == 2)
                str = "select XXTT.MaNV as [Mã NV], HoNV + ' ' + TenNV as [Tên nhân viên được tiến cử], TongDuAn as [Tổng dự án hoàn thành], " +
                    "TongKyNang as [Số kỹ năng thuần thục], NguoiTienCu as [Người tiến cử], NgayTienCu as [Ngày được tiến cử], TrangThai as [Trạng thái], NguoiDuyet as [Người duyệt], " +
                    "NgayDuyet as [Ngày được duyệt] from XemXetThangTien XXTT join NhanVien NV on XXTT.MaNV = NV.MaNV join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV " +
                    "where NguoiDuyet like N'%" + txtTim.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvTT.DataSource = dt;
            txtTim.Text = "";
            dgvTT.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTT.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTT.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTT.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTT.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTT.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTT.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTT.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTT.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void btnChapNhan_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvTT.CurrentCell.RowIndex;
                string manv = dgvTT.Rows[vitri].Cells[0].Value.ToString();
                string tennguoiduyet = honv + " " + tennv;
                data.ExecuteNonQuery("update XemXetThangTien set TrangThai= N'Chấp nhận', NguoiDuyet= N'" + tennguoiduyet + "', NgayDuyet= Getdate() where MaNV = " + manv + " and TrangThai = N'Chờ duyệt'");
                MessageBox.Show("Duyệt tiến cử nhân viên thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBaiBo_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvTT.CurrentCell.RowIndex;
                string manv = dgvTT.Rows[vitri].Cells[0].Value.ToString();
                string tennguoiduyet = honv + " " + tennv;
                data.ExecuteNonQuery("update XemXetThangTien set TrangThai= N'Bãi bỏ', NguoiDuyet= N'" + tennguoiduyet + "', NgayDuyet= Getdate() where MaNV = " + manv + " and TrangThai = N'Chờ duyệt'");
                MessageBox.Show("Duyệt tiến cử nhân viên thành công!", "Thông Báo",
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
