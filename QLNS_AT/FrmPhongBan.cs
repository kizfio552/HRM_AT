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
    public partial class FrmPhongBan : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        public FrmPhongBan()
        {
            InitializeComponent();
        }

        private void FrmPhongBan_Load(object sender, EventArgs e)
        {
            loadData();
            btnDau.Enabled = false;
            btnTruoc.Enabled = false;
        }

        private void loadData()
        {
            string str = "select MaPB as [Mã Phòng ban], TenPB as [Tên Phòng ban], MoTa as [Mô tả] from PhongBan";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvPhongban.DataSource = bdsource;
            dgvPhongban.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPhongban.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPhongban.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvPhongban.CurrentCell.RowIndex;
                string mapb = dgvPhongban.Rows[vitri].Cells[0].Value.ToString();
                string tenpb = dgvPhongban.Rows[vitri].Cells[1].Value.ToString();
                string mota = dgvPhongban.Rows[vitri].Cells[2].Value.ToString();
                DataTable dt = new DataTable();
                dt = data.ExcuteQuery("select * from PhongBan where MaPB = '" + mapb + "'");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Mã phòng ban đã tồn tại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadData();
                    return;
                }
                data.ExecuteNonQuery("insert into PhongBan values('" + mapb + "',N'" + tenpb + "',N'" + mota + "')");
                MessageBox.Show("Thêm phòng ban " + tenpb + " thành công!", "Thông Báo",
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
                int vitri = dgvPhongban.CurrentCell.RowIndex;
                string mapb = dgvPhongban.Rows[vitri].Cells[0].Value.ToString();
                string tenpb = dgvPhongban.Rows[vitri].Cells[1].Value.ToString();
                data.ExecuteNonQuery("delete from PhongBan where MaPB ='" + mapb + "'");
                MessageBox.Show("Xóa phòng ban " + tenpb + " thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa phòng ban thất bại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvPhongban.CurrentCell.RowIndex;
                //dgvPhongban.Rows[vitri].Cells[0].ReadOnly = true;
                string mapb = dgvPhongban.Rows[vitri].Cells[0].Value.ToString();
                string tenpb = dgvPhongban.Rows[vitri].Cells[1].Value.ToString();
                string mota = dgvPhongban.Rows[vitri].Cells[2].Value.ToString();
                data.ExecuteNonQuery("update PhongBan set TenPB= N'"
                    + tenpb + "', MoTa= N'" + mota + "' where MaPB= '" + mapb + "'");
                MessageBox.Show("Sửa thông tin phòng ban " + tenpb + " thành công!", "Thông Báo",
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
            string str = "select MaPB as [Mã Phòng ban], TenPB as [Tên Phòng ban], MoTa as [Mô tả] from PhongBan where TenPB like N'%" + txtTenPB.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvPhongban.DataSource = dt;
            txtTenPB.Text = "";
            txtTenPB.Focus();
            dgvPhongban.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPhongban.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPhongban.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
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

        private void dgvPhongban_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri = dgvPhongban.CurrentCell.RowIndex;
            dgvPhongban.Rows[vitri].Cells[0].ReadOnly = true;
        }
    }
}
