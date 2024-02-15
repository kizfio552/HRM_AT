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
    public partial class FrmNhanVien : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        string manv = "";
        int quyen;
        public FrmNhanVien(int quyen, string manv)
        {
            InitializeComponent();
            this.quyen = quyen;
            this.manv = manv;
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            if (quyen == 0)
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnTim.Enabled = false;
                loadDataPQ();
            }
            else
            {
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnTim.Enabled = true;
                loadData();
            }
            btnDau.Enabled = false;
            btnTruoc.Enabled = false;
        }
        private void loadData()
        {
            string str = "select MaNV as [Mã Nhân viên], MaVT as [Mã Vị trí], CCCD, NgayLapCCCD as [Ngày lập CCCD], NoiLapCCCD as [Nơi lập CCCD], " +
                "TenNganHang as [Ngân hàng], STKNganHang as [STK Ngân hàng], TenTKNganHang as [Tên TK Ngân hàng], DuongDanCV as [Đường dẫn CV], " +
                "DiaChi as [Địa chỉ], Quan_Huyen as [Quận - Huyện], Tinh_Thanh as [Tỉnh - Thành], PhanQuyen as [Quyền] " +
                "from NhanVien";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvNhanvien.DataSource = bdsource;
            dgvNhanvien.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }
        private void loadDataPQ()
        {
            string str = "select MaNV as [Mã Nhân viên], MaVT as [Mã Vị trí], CCCD, NgayLapCCCD as [Ngày lập CCCD], NoiLapCCCD as [Nơi lập CCCD], " +
                 "TenNganHang as [Ngân hàng], STKNganHang as [STK Ngân hàng], TenTKNganHang as [Tên TK Ngân hàng], DuongDanCV as [Đường dẫn CV], " +
                 "DiaChi as [Địa chỉ], Quan_Huyen as [Quận - Huyện], Tinh_Thanh as [Tỉnh - Thành], PhanQuyen as [Quyền] " +
                 "from NhanVien " +
                "where MaNV = " + manv;
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvNhanvien.DataSource = bdsource;
            dgvNhanvien.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvNhanvien.CurrentCell.RowIndex;
                string manv = dgvNhanvien.Rows[vitri].Cells[0].Value.ToString();
                string mavt = dgvNhanvien.Rows[vitri].Cells[1].Value.ToString();
                string cccd = dgvNhanvien.Rows[vitri].Cells[2].Value.ToString();
                string ngaylapcccd = dgvNhanvien.Rows[vitri].Cells[3].Value.ToString();
                string noilapcccd = dgvNhanvien.Rows[vitri].Cells[4].Value.ToString();
                string tennh = dgvNhanvien.Rows[vitri].Cells[5].Value.ToString();
                string stknh = dgvNhanvien.Rows[vitri].Cells[6].Value.ToString();
                string tentknh = dgvNhanvien.Rows[vitri].Cells[7].Value.ToString();
                string cv = dgvNhanvien.Rows[vitri].Cells[8].Value.ToString();
                string diachi = dgvNhanvien.Rows[vitri].Cells[9].Value.ToString();
                string quanhuyen = dgvNhanvien.Rows[vitri].Cells[10].Value.ToString();
                string tinhthanh = dgvNhanvien.Rows[vitri].Cells[11].Value.ToString();
                string phanquyen = dgvNhanvien.Rows[vitri].Cells[12].Value.ToString();
                DataTable dt = new DataTable();
                dt = data.ExcuteQuery("select * from NhanVien where MaNV = '" + manv + "'");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadData();
                    return;
                }
                dt = data.ExcuteQuery("select * from ViTri where MaVT = '" + mavt + "'");
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Mã vị trí không tồn tại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadData();
                    return;
                }
                data.ExecuteNonQuery("insert into NhanVien values('" + manv + "','" + mavt + "','" + cccd + "','"+ ngaylapcccd +"'," +
                    "N'"+ noilapcccd +"', '"+ tennh +"', '"+ stknh +"', '"+ tentknh +"', '"+ cv +"', N'"+ diachi +"'," +
                    "N'"+ quanhuyen +"', N'"+ tinhthanh +"', '"+ phanquyen +"', 1)");
                MessageBox.Show("Thêm nhân viên thành công!", "Thông Báo",
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
                int vitri = dgvNhanvien.CurrentCell.RowIndex;
                string manv = dgvNhanvien.Rows[vitri].Cells[0].Value.ToString();               
                data.ExecuteNonQuery("delete from NhanVien where MaNV ='" + manv + "'");
                MessageBox.Show("Xóa nhân viên thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa nhân viên thất bại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvNhanvien.CurrentCell.RowIndex;
                string manv = dgvNhanvien.Rows[vitri].Cells[0].Value.ToString();
                string mavt = dgvNhanvien.Rows[vitri].Cells[1].Value.ToString();
                string cccd = dgvNhanvien.Rows[vitri].Cells[2].Value.ToString();
                string ngaylapcccd = dgvNhanvien.Rows[vitri].Cells[3].Value.ToString();
                string noilapcccd = dgvNhanvien.Rows[vitri].Cells[4].Value.ToString();
                string tennh = dgvNhanvien.Rows[vitri].Cells[5].Value.ToString();
                string stknh = dgvNhanvien.Rows[vitri].Cells[6].Value.ToString();
                string tentknh = dgvNhanvien.Rows[vitri].Cells[7].Value.ToString();
                string cv = dgvNhanvien.Rows[vitri].Cells[8].Value.ToString();
                string diachi = dgvNhanvien.Rows[vitri].Cells[9].Value.ToString();
                string quanhuyen = dgvNhanvien.Rows[vitri].Cells[10].Value.ToString();
                string tinhthanh = dgvNhanvien.Rows[vitri].Cells[11].Value.ToString();
                string phanquyen = dgvNhanvien.Rows[vitri].Cells[12].Value.ToString();
                DataTable dt = new DataTable();
                dt = data.ExcuteQuery("select * from ViTri where MaVT = '" + mavt + "'");
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Mã vị trí không tồn tại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadData();
                    return;
                }
                data.ExecuteNonQuery("update NhanVien set MaVT= '" + mavt + "', CCCD= '" + cccd + "', NgayLapCCCD= '" + ngaylapcccd + "', " +
                    "NoiLapCCCD= N'" + noilapcccd + "', TenNganHang= '" + tennh + "', STKNganHang= '" + stknh + "', " +
                    "TenTKNganHang= '" + tentknh + "', DuongDanCV= '" + cv + "', DiaChi= N'" + diachi + "', " +
                    "Quan_Huyen= '" + quanhuyen + "', Tinh_Thanh= '" + tinhthanh + "', PhanQuyen= '" + phanquyen + "', " +
                    "MatKhau= 1 where MaNV= '" + manv + "'");
                MessageBox.Show("Sửa thông tin nhân viên thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string str = "select MaNV as [Mã Nhân viên], MaVT as [Mã Vị trí], CCCD, NgayLapCCCD as [Ngày lập CCCD], NoiLapCCCD as [Nơi lập CCCD], " +
                "TenNganHang as [Ngân hàng], STKNganHang as [STK Ngân hàng], TenTKNganHang as [Tên TK Ngân hàng], DuongDanCV as [Đường dẫn CV], " +
                "DiaChi as [Địa chỉ], Quan_Huyen as [Quận - Huyện], Tinh_Thanh as [Tỉnh - Thành], PhanQuyen as [Quyền] " +
                "from NhanVien " +
                "where MaNV like '%" + txtMaNV.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvNhanvien.DataSource = dt;
            txtMaNV.Text = "";
            txtMaNV.Focus();
            dgvNhanvien.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvNhanvien.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
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

        private void dgvNhanvien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri = dgvNhanvien.CurrentCell.RowIndex;
            dgvNhanvien.Rows[vitri].Cells[0].ReadOnly = true;
        }
    }
}
