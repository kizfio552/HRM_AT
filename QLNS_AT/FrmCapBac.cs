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
    public partial class FrmCapBac : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        public FrmCapBac()
        {
            InitializeComponent();
        }

        private void FrmCapBac_Load(object sender, EventArgs e)
        {
            loadData();
            btnDau.Enabled = false;
            btnTruoc.Enabled = false;
        }
        private void loadData()
        {
            string str = "select MaCB as [Mã Cấp bậc], MaVT as [Mã Vị trí], TenCB as [Tên Cấp bậc] from CapBac";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvCapbac.DataSource = bdsource;
            dgvCapbac.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCapbac.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCapbac.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvCapbac.CurrentCell.RowIndex;
                string macb = dgvCapbac.Rows[vitri].Cells[0].Value.ToString();
                string mavt = dgvCapbac.Rows[vitri].Cells[1].Value.ToString();
                string tencb = dgvCapbac.Rows[vitri].Cells[2].Value.ToString();
                string mota = dgvCapbac.Rows[vitri].Cells[3].Value.ToString();
                DataTable dt = new DataTable();
                dt = data.ExcuteQuery("select * from CapBac where MaCB = '" + macb + "'");
                if (dt.Rows.Count > 0 )
                {
                    MessageBox.Show("Mã cấp bậc đã tồn tại!", "Thông Báo",
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
                data.ExecuteNonQuery("insert into CapBac values('" + macb + "','" + mavt + "',N'" + tencb + "',N'" + mota + "')");
                MessageBox.Show("Thêm cấp bậc " + tencb + " thành công!", "Thông Báo",
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
                int vitri = dgvCapbac.CurrentCell.RowIndex;
                string macb = dgvCapbac.Rows[vitri].Cells[0].Value.ToString();
                string tencb = dgvCapbac.Rows[vitri].Cells[2].Value.ToString();
                data.ExecuteNonQuery("delete from CapBac where MaCB ='" + macb + "'");
                MessageBox.Show("Xóa cấp bậc " + tencb + " thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa cấp bậc thất bại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvCapbac.CurrentCell.RowIndex;
                string macb = dgvCapbac.Rows[vitri].Cells[0].Value.ToString();
                string mavt = dgvCapbac.Rows[vitri].Cells[1].Value.ToString();
                string tencb = dgvCapbac.Rows[vitri].Cells[2].Value.ToString();
                string mota = dgvCapbac.Rows[vitri].Cells[3].Value.ToString();
                DataTable dt = new DataTable();
                dt = data.ExcuteQuery("select * from ViTri where MaVT = '" + mavt + "'");
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Mã vị trí không tồn tại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadData();
                    return;
                }
                data.ExecuteNonQuery("update CapBac set MaVT= '"
                    + mavt + "', TenCB= N'" + tencb + "', MoTa= N'" + mota + "' where MaCB= '" + macb + "'");
                MessageBox.Show("Sửa thông tin cấp bậc " + tencb + " thành công!", "Thông Báo",
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
            string str = "select MaCB as [Mã Cấp bậc], MaVT as [Mã Vị trí], TenCB as [Tên Cấp bậc] " +
                "from CapBac where TenCB like N'%" + txtTenCB.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvCapbac.DataSource = dt;
            txtTenCB.Text = "";
            txtTenCB.Focus();
            dgvCapbac.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCapbac.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvCapbac.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
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

        private void dgvCapbac_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri = dgvCapbac.CurrentCell.RowIndex;
            dgvCapbac.Rows[vitri].Cells[0].ReadOnly = true;
        }
    }
}
