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
    public partial class FrmKinhNghiem : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        public FrmKinhNghiem()
        {
            InitializeComponent();
        }

        private void FrmKinhNghiem_Load(object sender, EventArgs e)
        {
            loadData();
            btnDau.Enabled = false;
            btnTruoc.Enabled = false;
        }
        private void loadData()
        {
            string str = "select MaKN as [Mã Kinh nghiệm], KN.MaNV as [Mã Nhân viên], TenDuAn as [Dự án], KichThuocNhom as [Nhóm], NgayBatDau as [Bắt đầu], " +
                "NgayKetThuc as [Kết thúc], MoTa as [Mô tả], CongNgheSuDung as [Công nghệ], TrangThai as [Trạng thái], HoNV as [Họ], TenNV as [Tên] " +
                "from KinhNghiem KN join NhanVien NV on KN.MaNV = NV.MaNV " +
                "join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvKinhnghiem.DataSource = bdsource;
            dgvKinhnghiem.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKinhnghiem.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKinhnghiem.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKinhnghiem.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKinhnghiem.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKinhnghiem.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKinhnghiem.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKinhnghiem.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKinhnghiem.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKinhnghiem.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKinhnghiem.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvKinhnghiem.CurrentCell.RowIndex;
                string makn = dgvKinhnghiem.Rows[vitri].Cells[0].Value.ToString();
                string manv = dgvKinhnghiem.Rows[vitri].Cells[1].Value.ToString();
                string tenduan = dgvKinhnghiem.Rows[vitri].Cells[2].Value.ToString();
                string ktnhom = dgvKinhnghiem.Rows[vitri].Cells[3].Value.ToString();
                string ngaybatdau = dgvKinhnghiem.Rows[vitri].Cells[4].Value.ToString();
                string ngayketthuc = dgvKinhnghiem.Rows[vitri].Cells[5].Value.ToString();
                string mota = dgvKinhnghiem.Rows[vitri].Cells[6].Value.ToString();
                string congnghesudung = dgvKinhnghiem.Rows[vitri].Cells[7].Value.ToString();
                string trangthai = dgvKinhnghiem.Rows[vitri].Cells[8].Value.ToString();
                DataTable dt = new DataTable();
                dt = data.ExcuteQuery("select * from KinhNghiem where MaKN = '" + makn + "'");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Mã kinh nghiệm đã tồn tại!", "Thông Báo",
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
                data.ExecuteNonQuery("insert into KinhNghiem values('" + makn + "','" + manv + "',N'" + tenduan + "', " +
                    "'" + ktnhom + "', '" + ngaybatdau + "', '" + ngayketthuc + "', N'" + mota + "', '" + congnghesudung + "', " +
                    "'" + trangthai + "')");
                MessageBox.Show("Thêm kinh nghiệm dự án " + tenduan + " thành công!", "Thông Báo",
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
                int vitri = dgvKinhnghiem.CurrentCell.RowIndex;
                string makn = dgvKinhnghiem.Rows[vitri].Cells[0].Value.ToString();
                string tenduan = dgvKinhnghiem.Rows[vitri].Cells[2].Value.ToString();
                data.ExecuteNonQuery("delete from KinhNghiem where MaKN ='" + makn + "'");
                MessageBox.Show("Xóa kinh nghiệm dự án " + tenduan + " thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa kinh nghiệm dự án thất bại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvKinhnghiem.CurrentCell.RowIndex;
                string makn = dgvKinhnghiem.Rows[vitri].Cells[0].Value.ToString();
                string manv = dgvKinhnghiem.Rows[vitri].Cells[1].Value.ToString();
                string tenduan = dgvKinhnghiem.Rows[vitri].Cells[2].Value.ToString();
                string ktnhom = dgvKinhnghiem.Rows[vitri].Cells[3].Value.ToString();
                string ngaybatdau = dgvKinhnghiem.Rows[vitri].Cells[4].Value.ToString();
                string ngayketthuc = dgvKinhnghiem.Rows[vitri].Cells[5].Value.ToString();
                string mota = dgvKinhnghiem.Rows[vitri].Cells[6].Value.ToString();
                string congnghesudung = dgvKinhnghiem.Rows[vitri].Cells[7].Value.ToString();
                string trangthai = dgvKinhnghiem.Rows[vitri].Cells[8].Value.ToString();
                DataTable dt = new DataTable();
                dt = data.ExcuteQuery("select * from NhanVien where MaNV = '" + manv + "'");
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Mã nhân viên không tồn tại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadData();
                    return;
                }
                data.ExecuteNonQuery("update KinhNghiem set MaNV= '" + manv + "', TenDuAn= N'" + tenduan + "', " +
                    "KichThuocNhom= '" + ktnhom + "', NgayBatDau= '" + ngaybatdau + "', NgayKetThuc= '" + ngayketthuc + "', " +
                    "MoTa= N'" + mota + "', CongNgheSuDung= '" + congnghesudung + "', " +
                    "TrangThai= N'" + trangthai + "' where MaKN= '" + makn + "'");
                MessageBox.Show("Sửa thông tin kinh nghiệm dự án " + tenduan + " thành công!", "Thông Báo",
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
            string str = "select MaKN as [Mã Kinh nghiệm], KN.MaNV as [Mã Nhân viên], TenDuAn as [Dự án], KichThuocNhom as [Nhóm], NgayBatDau as [Bắt đầu], " +
                "NgayKetThuc as [Kết thúc], MoTa as [Mô tả], CongNgheSuDung as [Công nghệ], TrangThai as [Trạng thái], HoNV as [Họ], TenNV as [Tên] " +
                "from KinhNghiem KN join NhanVien NV on KN.MaNV = NV.MaNV " +
                "join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV where TenDuAn like N'%" + txtTenDA.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvKinhnghiem.DataSource = dt;
            txtTenDA.Text = "";
            txtTenDA.Focus();
            dgvKinhnghiem.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKinhnghiem.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKinhnghiem.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKinhnghiem.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKinhnghiem.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKinhnghiem.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKinhnghiem.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKinhnghiem.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKinhnghiem.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKinhnghiem.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKinhnghiem.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
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

        private void dgvKinhnghiem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri = dgvKinhnghiem.CurrentCell.RowIndex;
            dgvKinhnghiem.Rows[vitri].Cells[0].ReadOnly = true;
            dgvKinhnghiem.Rows[vitri].Cells[9].ReadOnly = true;
            dgvKinhnghiem.Rows[vitri].Cells[10].ReadOnly = true;
        }
    }
}
