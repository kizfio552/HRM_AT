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
    public partial class FrmPhuCap : Form
    {
        Ketnoi data = new Ketnoi();
        private BindingSource bdsource = new BindingSource();
        public FrmPhuCap()
        {
            InitializeComponent();
        }

        private void FrmPhuCap_Load(object sender, EventArgs e)
        { 
            loadData();
            btnDau.Enabled = false;
            btnTruoc.Enabled = false;
        }
        private void loadData()
        {
            string str = "select MaPC as [Mã Phụ cấp], MaHDNV as [Mã Hợp đồng], TenPC as [Tên Phụ cấp], LoaiPC as [Loại Phụ cấp], SoLuong as [Số lượng], " +
                "DuTieuChuan as [Tiêu chuẩn], YeuCau as [Phê duyệt], ThanhTien as [Thành tiền] " +
                "from PhuCap";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            bdsource.DataSource = dt;
            dgvPhucap.DataSource = bdsource;
            dgvPhucap.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPhucap.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPhucap.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPhucap.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPhucap.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPhucap.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPhucap.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPhucap.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPhucap.Columns[7].DefaultCellStyle.Format = "N2";
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvPhucap.CurrentCell.RowIndex;
                string mapc = dgvPhucap.Rows[vitri].Cells[0].Value.ToString();
                string mahdnv = dgvPhucap.Rows[vitri].Cells[1].Value.ToString();
                string tenpc = dgvPhucap.Rows[vitri].Cells[2].Value.ToString();
                string loaipc = dgvPhucap.Rows[vitri].Cells[3].Value.ToString();
                string soluong = dgvPhucap.Rows[vitri].Cells[4].Value.ToString();
                string dutieuchuan = dgvPhucap.Rows[vitri].Cells[5].Value.ToString();
                string yeucau = dgvPhucap.Rows[vitri].Cells[6].Value.ToString();
                string thanhtien = dgvPhucap.Rows[vitri].Cells[7].Value.ToString();
                DataTable dt = new DataTable();
                dt = data.ExcuteQuery("select * from PhuCap where MaPC = '" + mapc + "'");
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Mã phụ cấp đã tồn tại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadData();
                    return;
                }
                dt = data.ExcuteQuery("select * from HopDongNhanVien where MaHDNV = '" + mahdnv + "'");
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Mã hợp đồng không tồn tại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadData();
                    return;
                }
                data.ExecuteNonQuery("insert into PhuCap values('" + mapc + "','" + mahdnv + "',N'" + tenpc + "',N'" + loaipc + "'," +
                    "'" + soluong + "', N'" + dutieuchuan + "', N'" + yeucau + "', '" + thanhtien + "')");
                MessageBox.Show("Thêm phụ cấp " + tenpc + " thành công!", "Thông Báo",
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
                int vitri = dgvPhucap.CurrentCell.RowIndex;
                string mapc = dgvPhucap.Rows[vitri].Cells[0].Value.ToString();
                string tenpc = dgvPhucap.Rows[vitri].Cells[2].Value.ToString();
                data.ExecuteNonQuery("delete from PhuCap where MaPC ='" + mapc + "'");
                MessageBox.Show("Xóa phụ cấp " + tenpc + " thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa phụ cấp thất bại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                int vitri = dgvPhucap.CurrentCell.RowIndex;
                string mapc = dgvPhucap.Rows[vitri].Cells[0].Value.ToString();
                string mahdnv = dgvPhucap.Rows[vitri].Cells[1].Value.ToString();
                string tenpc = dgvPhucap.Rows[vitri].Cells[2].Value.ToString();
                string loaipc = dgvPhucap.Rows[vitri].Cells[3].Value.ToString();
                string soluong = dgvPhucap.Rows[vitri].Cells[4].Value.ToString();
                string dutieuchuan = dgvPhucap.Rows[vitri].Cells[5].Value.ToString();
                string yeucau = dgvPhucap.Rows[vitri].Cells[6].Value.ToString();
                string thanhtien = dgvPhucap.Rows[vitri].Cells[7].Value.ToString();
                DataTable dt = new DataTable();
                dt = data.ExcuteQuery("select * from HopDongNhanVien where MaHDNV = '" + mahdnv + "'");
                if (dt.Rows.Count <= 0)
                {
                    MessageBox.Show("Mã hợp đồng không tồn tại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    loadData();
                    return;
                }
                data.ExecuteNonQuery("update PhuCap set MaHDNV= '" + mahdnv + "', TenPC= N'"
                    + tenpc + "', LoaiPC= N'" + loaipc + "', SoLuong= '" + soluong + "', DuTieuChuan= N'" + dutieuchuan + "'," +
                    " YeuCau= N'" + yeucau + "', ThanhTien= '" + thanhtien + "' where MaPC= '" + mapc + "'");
                MessageBox.Show("Sửa thông tin phụ cấp " + tenpc + " thành công!", "Thông Báo",
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
            string str = "select MaPC as [Mã Phụ cấp], MaHDNV as [Mã Hợp đồng], TenPC as [Tên Phụ cấp], LoaiPC as [Loại Phụ cấp], SoLuong as [Số lượng], " +
                "DuTieuChuan as [Tiêu chuẩn], YeuCau as [Phê duyệt], ThanhTien as [Thành tiền] " +
                "from PhuCap where TenPC like N'%" + txtTenPC.Text + "%'";
            SqlDataAdapter da = new SqlDataAdapter(str, data.getConnect());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dgvPhucap.DataSource = dt;
            txtTenPC.Text = "";
            txtTenPC.Focus();
            dgvPhucap.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPhucap.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPhucap.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPhucap.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPhucap.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPhucap.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPhucap.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPhucap.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dgvPhucap.Columns[7].DefaultCellStyle.Format = "N2";
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

        private void dgvPhucap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int vitri = dgvPhucap.CurrentCell.RowIndex;
            dgvPhucap.Rows[vitri].Cells[0].ReadOnly = true;
        }
    }
}
