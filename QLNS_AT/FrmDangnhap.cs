using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS_AT
{
    public partial class FrmDangnhap : Form
    {
        Ketnoi data = new Ketnoi();
        public FrmDangnhap()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult dg = new DialogResult();
            dg = MessageBox.Show("Bạn có muốn thoát không?", "Thông Báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnDangnhap_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string tk = txtTK.Text;
            string mk = txtMK.Text;
            if (string.IsNullOrEmpty(tk))
            {
                MessageBox.Show("Hãy nhập tài khoản!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTK.Focus();
                return;
            }
            if (string.IsNullOrEmpty(mk))
            {
                MessageBox.Show("Hãy nhập mật khẩu!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMK.Focus();
                return;
            }
            dt = data.ExcuteQuery("select NV.*, HoNV, TenNV, TenVT, TenPB " +
                "from NhanVien NV join ThongTinNhanVien TTNV on NV.MaNV = TTNV.MaNV join ViTri VT on NV.MaVT = VT.MaVT " +
                "join PhongBan PB on VT.MaPB = PB.MaPB " +
                "where NV.MaNV = '" + tk + "' and MatKhau = '" + mk + "'");
            if (dt.Rows.Count > 0)
            {
                FrmMain fr = new FrmMain(Convert.ToInt32(dt.Rows[0][12]), tk, dt.Rows[0][14].ToString(), dt.Rows[0][15].ToString(),
                    dt.Rows[0][16].ToString(), dt.Rows[0][17].ToString());
                this.Hide();
                fr.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sai tài khoản hoặc mật khẩu!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkHienMK_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienMK.Checked)
            {
                txtMK.PasswordChar = (char)0;
            }
            else
            {
                txtMK.PasswordChar = '*';
            }
        }
    }
}
