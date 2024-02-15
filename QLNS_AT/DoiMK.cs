using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNS_AT
{
    public partial class DoiMK : Form
    {
        Ketnoi data = new Ketnoi();
        string manv = "";
        public DoiMK(string manv)
        {
            InitializeComponent();
            this.manv = manv;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (string.IsNullOrEmpty(txtMKHT.Text))
            {
                MessageBox.Show("Hãy nhập mật khẩu hiện tại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMKHT.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtMKM.Text))
            {
                MessageBox.Show("Hãy nhập mật khẩu mới!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMKM.Focus();
                return;
            }
            dt = data.ExcuteQuery("select * from NhanVien where MaNV = '" + txtTK.Text + "' and MatKhau = '" + txtMKHT.Text + "'");
            if (dt.Rows.Count > 0)
            {
                data.ExecuteNonQuery("update NhanVien set MatKhau = '" + txtMKM.Text + "' where MaNV = " + txtTK.Text);
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sai mật khẩu hiện tại!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DoiMK_Load(object sender, EventArgs e)
        {
            txtTK.Text = manv;
        }
    }
}
