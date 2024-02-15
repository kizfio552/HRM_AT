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
    public partial class FrmMain : Form
    {
        Ketnoi data = new Ketnoi();
        string manv = "", honv = "", tennv = "", tenvt = "", tenpb = "";
        int quyen;
        public FrmMain(int quyen, string manv, string honv, string tennv, string tenvt, string tenpb)
        {
            InitializeComponent();
            this.quyen = quyen;
            this.manv = manv;
            this.honv = honv;
            this.tennv = tennv;
            this.tenvt = tenvt;
            this.tenpb = tenpb;
        }

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dg = new DialogResult();
            dg = MessageBox.Show("Bạn có muốn thoát không?", "Thông Báo",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dangXuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmDangnhap fr = new FrmDangnhap();
            fr.Show();
        }

        private void kyNangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKyNang fr = new FrmKyNang(quyen);
            fr.Show();
        }

        private void hopDongNVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHDNV fr = new FrmHDNV(quyen, manv);
            fr.Show();
        }

        private void phuCapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPhuCap fr = new FrmPhuCap();
            fr.Show();
        }

        private void phongBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPhongBan fr = new FrmPhongBan();
            fr.Show();
        }

        private void viTriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmViTri fr = new FrmViTri();
            fr.Show();
        }

        private void capBacToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCapBac fr = new FrmCapBac();
            fr.Show();
        }

        private void nhanVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNhanVien fr = new FrmNhanVien(quyen, manv);
            fr.Show();
        }

        private void bangCapNVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBangCap fr = new FrmBangCap();
            fr.Show();
        }

        private void doiMKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMK fr = new DoiMK(manv);
            fr.Show();
        }

        private void kinhNghiemNVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKinhNghiem fr = new FrmKinhNghiem();
            fr.Show();
        }

        private void phieuLuongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPhieuLuong fr = new FrmPhieuLuong();
            fr.Show();
        }

        private void thongTinNVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTTNV fr = new FrmTTNV(quyen, manv);
            fr.Show();
        }

        private void chamCongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChamCong fr = new FrmChamCong(quyen, manv);
            fr.Show();
        }

        private void TNTTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTinhTNTT fr = new FrmTinhTNTT(quyen, manv);
            fr.Show();
        }

        private void thueTNCNToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTinhThueTNCN fr = new FrmTinhThueTNCN(quyen, manv);
            fr.Show();
        }

        private void chungToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKenhChung fr = new FrmKenhChung(manv);
            fr.Show();
        }

        private void kyThuatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKenhKyThuat fr = new FrmKenhKyThuat(manv);
            fr.Show();
        }

        private void kinhDoanhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKenhKinhDoanh fr = new FrmKenhKinhDoanh(manv);
            fr.Show();
        }

        private void quanLyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKenhQuanLy fr = new FrmKenhQuanLy(manv);
            fr.Show();
        }

        private void hTKTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKenhHTKT fr = new FrmKenhHTKT(manv);
            fr.Show();
        }

        private void keToanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKenhKeToan fr = new FrmKenhKeToan(manv);
            fr.Show();
        }

        private void nhanSuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKenhNhanSu fr = new FrmKenhNhanSu(manv);
            fr.Show();
        }

        private void xemXetTTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmXemXetTT fr = new FrmXemXetTT(manv, quyen, honv, tennv);
            fr.Show();
        }

        private void duyetTTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmDuyetTT fr = new FrmDuyetTT(honv, tennv);
            fr.Show();
        }

        private void bhCongTyTraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBHCongTyTra fr = new FrmBHCongTyTra(quyen, manv);
            fr.Show();
        }

        private void luongCuoiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLuongCuoi fr = new FrmLuongCuoi(quyen, manv);
            fr.Show();
        }

        private void kyNangNVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmKN_NV fr = new FrmKN_NV();
            fr.Show();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            if (quyen == 1)
            {
                bophanMenu.Enabled = true;
                quanlyMenu.Enabled = true;
                nhansuMenu.Enabled = true;
                luongMenu.Enabled = true;
                phuCapToolStripMenuItem.Enabled = true;
                phieuLuongToolStripMenuItem.Enabled = true;
                duyetTTToolStripMenuItem.Enabled = true;
            }
            else
            {
                quanlyMenu.Enabled = true;
                nhansuMenu.Enabled = true;
                luongMenu.Enabled = true;
                phuCapToolStripMenuItem.Enabled = false;
            }
            switch (tenpb)
            {
                case "Phòng Kỹ thuật": kyThuatToolStripMenuItem.Enabled = true; break;
                case "Phòng Kinh doanh": kinhDoanhToolStripMenuItem.Enabled = true; break;
                case "Phòng Quản lý": quanLyToolStripMenuItem.Enabled = true; break;
                case "Phòng Hỗ trợ kỹ thuật": hTKTToolStripMenuItem.Enabled = true; break;
                case "Phòng Kế toán": keToanToolStripMenuItem.Enabled = true; break;
                case "Phòng Nhân sự": nhanSuToolStripMenuItem.Enabled = true; break;
                default: break;
            }
            toolStripStatusLabel.Text = honv + " " + tennv + " - " + tenvt + " - " + tenpb;
        }
    }
}
