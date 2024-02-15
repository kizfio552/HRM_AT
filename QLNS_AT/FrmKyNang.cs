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
    public partial class FrmKyNang : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        int quyen;
        public FrmKyNang(int quyen)
        {
            InitializeComponent();
            this.quyen = quyen;
        }

        private void FrmKyNang_Load(object sender, EventArgs e)
        {
            if (quyen == 0)
            {
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                btnSua.Enabled = false;
            }
            else
            {
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
            }
            loadData();
            btnDau.Enabled = false;
            btnTruoc.Enabled = false;
        }
        private void loadData()
        {
            string str = "select MaKN as [Mã Kỹ năng], TenKN as [Kỹ năng], MoTaKN as [Mô tả] from KyNang";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvKynang.DataSource = bdsource;
            dgvKynang.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKynang.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKynang.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvKynang.CurrentCell.RowIndex;
                string makn = dgvKynang.Rows[vitri].Cells[0].Value.ToString();
                string tenkn = dgvKynang.Rows[vitri].Cells[1].Value.ToString();
                string mota = dgvKynang.Rows[vitri].Cells[2].Value.ToString();
                DataTable dt = new DataTable();
                dt = data.ExcuteQuery("select * from KyNang where MaKN = '" + makn + "'");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Mã kỹ năng đã tồn tại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadData();
                    return;
                }
                data.ExecuteNonQuery("insert into KyNang values('" + makn + "',N'" + tenkn + "',N'" + mota + "')");
                MessageBox.Show("Thêm kỹ năng " + tenkn + " thành công!", "Thông Báo",
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
                int vitri = dgvKynang.CurrentCell.RowIndex;
                string makn = dgvKynang.Rows[vitri].Cells[0].Value.ToString();
                string tenkn = dgvKynang.Rows[vitri].Cells[1].Value.ToString();
                data.ExecuteNonQuery("delete from KyNang where MaKN ='" + makn + "'");
                MessageBox.Show("Xóa kỹ năng " + tenkn + " thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa kỹ năng thất bại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvKynang.CurrentCell.RowIndex;
                string makn = dgvKynang.Rows[vitri].Cells[0].Value.ToString();
                string tenkn = dgvKynang.Rows[vitri].Cells[1].Value.ToString();
                string mota = dgvKynang.Rows[vitri].Cells[2].Value.ToString();
                data.ExecuteNonQuery("update KyNang set TenKN= N'"
                    + tenkn + "', MoTaKN= N'" + mota + "' where MaKN= '" + makn + "'");
                MessageBox.Show("Sửa thông tin kỹ năng " + tenkn + " thành công!", "Thông Báo",
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
            string str = "select MaKN as [Mã Kỹ năng], TenKN as [Kỹ năng], MoTaKN as [Mô tả] from KyNang where TenKN like N'%" + txtTenKN.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvKynang.DataSource = dt;
            txtTenKN.Text = "";
            txtTenKN.Focus();
            dgvKynang.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKynang.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvKynang.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
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

        private void dgvKynang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri = dgvKynang.CurrentCell.RowIndex;
            dgvKynang.Rows[vitri].Cells[0].ReadOnly = true;
        }
    }
}
