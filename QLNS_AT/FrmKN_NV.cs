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
    public partial class FrmKN_NV : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        public FrmKN_NV()
        {
            InitializeComponent();
        }

        private void FrmKN_NV_Load(object sender, EventArgs e)
        {
            loadData();
            btnDau.Enabled = false;
            btnTruoc.Enabled = false;
        }
        private void loadData()
        {
            string str = "select KN_NV.MaNV as [Mã Nhân viên], KN_NV.MaKN as [Mã Kỹ năng], TenKN as [Kỹ năng], HoNV as [Họ], TenNV as [Tên] " +
                "from KN_NV join KyNang KN on KN_NV.MaKN = KN.MaKN " +
                "join NhanVien NV on KN_NV.MaNV = NV.MaNV join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvKynangNV.DataSource = bdsource;
            dgvKynangNV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKynangNV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKynangNV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKynangNV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKynangNV.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvKynangNV.CurrentCell.RowIndex;
                string manv = dgvKynangNV.Rows[vitri].Cells[0].Value.ToString();
                string makn = dgvKynangNV.Rows[vitri].Cells[1].Value.ToString();
                string tenkn = dgvKynangNV.Rows[vitri].Cells[2].Value.ToString();
                string honv = dgvKynangNV.Rows[vitri].Cells[3].Value.ToString();
                string tennv = dgvKynangNV.Rows[vitri].Cells[4].Value.ToString();
                DataTable dt = new DataTable();
                dt = data.ExcuteQuery("select * from NhanVien where MaNV = '" + manv + "'");
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Mã nhân viên không tồn tại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadData();
                    return;
                }
                dt = data.ExcuteQuery("select * from KyNang where MaKN = '" + makn + "'");
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Mã kỹ năng không tồn tại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadData();
                    return;
                }
                data.ExecuteNonQuery("insert into KN_NV values('" + manv + "','" + makn + "')");
                MessageBox.Show("Thêm kỹ năng " + tenkn + " cho nhân viên " + (honv + " " + tennv) + " thành công!", "Thông Báo",
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
                int vitri = dgvKynangNV.CurrentCell.RowIndex;
                string manv = dgvKynangNV.Rows[vitri].Cells[0].Value.ToString();
                string makn = dgvKynangNV.Rows[vitri].Cells[1].Value.ToString();
                string tenkn = dgvKynangNV.Rows[vitri].Cells[2].Value.ToString();
                string honv = dgvKynangNV.Rows[vitri].Cells[3].Value.ToString();
                string tennv = dgvKynangNV.Rows[vitri].Cells[4].Value.ToString();
                data.ExecuteNonQuery("delete from KN_NV where MaNV ='" + manv + "' and MaKN ='" + makn + "'");
                MessageBox.Show("Xóa kỹ năng " + tenkn + " của nhân viên " + (honv + " " + tennv) + " thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa kỹ năng của nhân viên thất bại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvKynangNV.CurrentCell.RowIndex;
                string manv = dgvKynangNV.Rows[vitri].Cells[0].Value.ToString();
                string makn = dgvKynangNV.Rows[vitri].Cells[1].Value.ToString();
                string tenkn = dgvKynangNV.Rows[vitri].Cells[2].Value.ToString();
                string honv = dgvKynangNV.Rows[vitri].Cells[3].Value.ToString();
                string tennv = dgvKynangNV.Rows[vitri].Cells[4].Value.ToString();
                DataTable dt = new DataTable();
                dt = data.ExcuteQuery("select * from NhanVien where MaNV = '" + manv + "'");
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Mã nhân viên không tồn tại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadData();
                    return;
                }
                dt = data.ExcuteQuery("select * from KyNang where MaKN = '" + makn + "'");
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Mã kỹ năng không tồn tại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadData();
                    return;
                }
                data.ExecuteNonQuery("update KN_NV set MaNV= '" + manv + "', MaKN= '" + makn + "' " +
                    "where MaNV= '" + manv + "' and MaKN= '" + makn + "'");
                MessageBox.Show("Sửa thông tin kỹ năng " + tenkn + " của nhân viên " + (honv + " " + tennv) + " thành công!", "Thông Báo",
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
            string str = "select KN_NV.MaNV as [Mã Nhân viên], KN_NV.MaKN as [Mã Kỹ năng], TenKN as [Kỹ năng], HoNV as [Họ], TenNV as [Tên] " +
                "from KN_NV join KyNang KN on KN_NV.MaKN = KN.MaKN " +
                "join NhanVien NV on KN_NV.MaNV = NV.MaNV join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV " +
                "where TenNV like N'%" + txtTenNV.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvKynangNV.DataSource = dt;
            txtTenNV.Text = "";
            txtTenNV.Focus();
            dgvKynangNV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKynangNV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKynangNV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKynangNV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKynangNV.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
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

        private void dgvKynangNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri = dgvKynangNV.CurrentCell.RowIndex;
            dgvKynangNV.Rows[vitri].Cells[2].ReadOnly = true;
            dgvKynangNV.Rows[vitri].Cells[3].ReadOnly = true;
            dgvKynangNV.Rows[vitri].Cells[4].ReadOnly = true;
        }
    }
}
