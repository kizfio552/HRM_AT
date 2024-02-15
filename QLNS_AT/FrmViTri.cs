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
    public partial class FrmViTri : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        public FrmViTri()
        {
            InitializeComponent();
        }

        private void FrmViTri_Load(object sender, EventArgs e)
        {
            loadData();
            btnDau.Enabled = false;
            btnTruoc.Enabled = false;
        }
        private void loadData()
        {
            string str = "select MaVT as [Mã Vị trí], MaPB as [Mã Phòng ban], TenVT as [Tên Vị trí] from ViTri";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvVitri.DataSource = bdsource;
            dgvVitri.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvVitri.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvVitri.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvVitri.CurrentCell.RowIndex;
                string mavt = dgvVitri.Rows[vitri].Cells[0].Value.ToString();
                string mapb = dgvVitri.Rows[vitri].Cells[1].Value.ToString();
                string tenvt = dgvVitri.Rows[vitri].Cells[2].Value.ToString();
                DataTable dt = new DataTable();
                dt = data.ExcuteQuery("select * from ViTri where MaVT = '" + mavt + "'");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Mã vị trí đã tồn tại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadData();
                    return;
                }
                dt = data.ExcuteQuery("select * from PhongBan where MaPB = '" + mapb + "'");
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Mã phòng ban không tồn tại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadData();
                    return;
                }
                data.ExecuteNonQuery("insert into ViTri values('" + mavt + "','" + mapb + "',N'" + tenvt + "')");
                MessageBox.Show("Thêm vị trí " + tenvt + " thành công!", "Thông Báo",
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
                int vitri = dgvVitri.CurrentCell.RowIndex;
                string mavt = dgvVitri.Rows[vitri].Cells[0].Value.ToString();
                string tenvt = dgvVitri.Rows[vitri].Cells[2].Value.ToString();
                data.ExecuteNonQuery("delete from ViTri where MaVT ='" + mavt + "'");
                MessageBox.Show("Xóa vị trí " + tenvt + " thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa vị trí thất bại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvVitri.CurrentCell.RowIndex;
                //dgvVitri.Rows[vitri].Cells[0].ReadOnly = true;
                string mavt = dgvVitri.Rows[vitri].Cells[0].Value.ToString();
                string mapb = dgvVitri.Rows[vitri].Cells[1].Value.ToString();
                string tenvt = dgvVitri.Rows[vitri].Cells[2].Value.ToString();
                DataTable dt = new DataTable();
                dt = data.ExcuteQuery("select * from PhongBan where MaPB = '" + mapb + "'");
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Mã phòng ban không tồn tại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadData();
                    return;
                }
                data.ExecuteNonQuery("update ViTri set MaPB= '"
                    + mapb + "', TenVT= N'" + tenvt + "' where MaVT= '" + mavt + "'");
                MessageBox.Show("Sửa thông tin vị trí " + tenvt + " thành công!", "Thông Báo",
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
            string str = "select MaVT as [Mã Vị trí], MaPB as [Mã Phòng ban], TenVT as [Tên Vị trí] from ViTri where TenVT like N'%" + txtVT.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvVitri.DataSource = dt;
            txtVT.Text = "";
            txtVT.Focus();
            dgvVitri.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvVitri.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvVitri.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
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

        private void dgvVitri_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri = dgvVitri.CurrentCell.RowIndex;
            dgvVitri.Rows[vitri].Cells[0].ReadOnly = true;
        }
    }
}
