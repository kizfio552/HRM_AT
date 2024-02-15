using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS_AT
{
    public partial class FrmTTNV : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        string manv = "";
        int quyen;
        public FrmTTNV(int quyen, string manv)
        {
            InitializeComponent();
            this.quyen = quyen;
            this.manv = manv;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmTTNV_Load(object sender, EventArgs e)
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
            cbbTim.SelectedIndex = 0;
        }
        private void loadData()
        {
            string str = "select MaTTNV as [Mã Thông tin], MaNV as [Mã Nhân viên], HoNV as [Họ], TenNV as [Tên], SDT as [SĐT], QueQuan as [Quê quán], " +
                "GioiTinh as [Giới tính], SoNguoiPT as [Người phụ thuộc] " +
                "from ThongTinNhanVien";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvTTNV.DataSource = bdsource;
            dgvTTNV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTTNV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTTNV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTTNV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTTNV.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTTNV.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTTNV.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTTNV.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }
        private void loadDataPQ()
        {
            string str = "select MaTTNV as [Mã Thông tin], MaNV as [Mã Nhân viên], HoNV as [Họ], TenNV as [Tên], SDT as [SĐT], QueQuan as [Quê quán], " +
                "GioiTinh as [Giới tính], SoNguoiPT as [Người phụ thuộc] " +
                "from ThongTinNhanVien where MaNV = " + manv;
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvTTNV.DataSource = bdsource;
            dgvTTNV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTTNV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTTNV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTTNV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTTNV.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTTNV.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTTNV.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTTNV.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
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

        private void dgvTTNV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri = dgvTTNV.CurrentCell.RowIndex;
            dgvTTNV.Rows[vitri].Cells[0].ReadOnly = true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvTTNV.CurrentCell.RowIndex;
                string mattnv = dgvTTNV.Rows[vitri].Cells[0].Value.ToString();
                string manv = dgvTTNV.Rows[vitri].Cells[1].Value.ToString();
                string honv = dgvTTNV.Rows[vitri].Cells[2].Value.ToString();
                string tennv = dgvTTNV.Rows[vitri].Cells[3].Value.ToString();
                string sdt = dgvTTNV.Rows[vitri].Cells[4].Value.ToString();
                string quequan = dgvTTNV.Rows[vitri].Cells[5].Value.ToString();
                string gioitinh = dgvTTNV.Rows[vitri].Cells[6].Value.ToString();
                string songuoipt = dgvTTNV.Rows[vitri].Cells[7].Value.ToString();
                DataTable dt = new DataTable();
                dt = data.ExcuteQuery("select * from ThongTinNhanVien where MaTTNV = '" + mattnv + "'");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Mã thông tin nhân viên đã tồn tại!", "Thông Báo",
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
                data.ExecuteNonQuery("insert into ThongTinNhanVien values('" + mattnv + "','" + manv + "',N'" + honv + "',N'" + tennv + "'," +
                    "'" + sdt + "', N'" + quequan + "', '" + gioitinh + "', '" + songuoipt + "')");
                MessageBox.Show("Thêm thông tin nhân viên thành công!", "Thông Báo",
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
                int vitri = dgvTTNV.CurrentCell.RowIndex;
                string mattnv = dgvTTNV.Rows[vitri].Cells[0].Value.ToString();
                data.ExecuteNonQuery("delete from ThongTinNhanVien where MaTTNV ='" + mattnv + "'");
                MessageBox.Show("Xóa thông tin nhân viên thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa thông tin nhân viên thất bại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvTTNV.CurrentCell.RowIndex;
                string mattnv = dgvTTNV.Rows[vitri].Cells[0].Value.ToString();
                string manv = dgvTTNV.Rows[vitri].Cells[1].Value.ToString();
                string honv = dgvTTNV.Rows[vitri].Cells[2].Value.ToString();
                string tennv = dgvTTNV.Rows[vitri].Cells[3].Value.ToString();
                string sdt = dgvTTNV.Rows[vitri].Cells[4].Value.ToString();
                string quequan = dgvTTNV.Rows[vitri].Cells[5].Value.ToString();
                string gioitinh = dgvTTNV.Rows[vitri].Cells[6].Value.ToString();
                string songuoipt = dgvTTNV.Rows[vitri].Cells[7].Value.ToString();
                DataTable dt = new DataTable();
                dt = data.ExcuteQuery("select * from NhanVien where MaNV = '" + manv + "'");
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Mã nhân viên không tồn tại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadData();
                    return;
                }
                data.ExecuteNonQuery("update ThongTinNhanVien set MaNV= '" + manv + "', HoNV= N'" + honv + "', " +
                    "TenNV= N'" + tennv + "', SDT= '" + sdt + "', QueQuan= N'" + quequan + "', GioiTinh = '" + gioitinh + "', " +
                    "SoNguoiPT = '" + songuoipt + "' where MaTTNV= '" + mattnv + "'");
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
            string str = "";
            if (cbbTim.SelectedIndex == 0)
                str = "select MaTTNV as [Mã Thông tin], MaNV as [Mã Nhân viên], HoNV as [Họ], TenNV as [Tên], SDT as [SĐT], QueQuan as [Quê quán], " +
                    "GioiTinh as [Giới tính], SoNguoiPT as [Người phụ thuộc] " +
                    "from ThongTinNhanVien where HoNV + ' ' + TenNV like N'%" + txtTim.Text + "%'";
            else if (cbbTim.SelectedIndex == 1)
                str = "select MaTTNV as [Mã Thông tin], MaNV as [Mã Nhân viên], HoNV as [Họ], TenNV as [Tên], SDT as [SĐT], QueQuan as [Quê quán], " +
                    "GioiTinh as [Giới tính], SoNguoiPT as [Người phụ thuộc] " +
                    "from ThongTinNhanVien where QueQuan like N'%" + txtTim.Text + "%'";           
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvTTNV.DataSource = dt;
            txtTim.Text = "";
            txtTim.Focus();
            dgvTTNV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTTNV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTTNV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTTNV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTTNV.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTTNV.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTTNV.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvTTNV.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void cbbTim_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTim.SelectedIndex == 0)
            {
                lblTim.Text = "Tên NV:";
                txtTim.Text = "";
                txtTim.Focus();
            }
            else if (cbbTim.SelectedIndex == 1)
            {
                lblTim.Text = "Quê quán:";
                txtTim.Text = "";
                txtTim.Focus();
            }
        }
    }
}
