using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThietBiMayTinh
{
    public partial class menumdi : Form
    {
        public menumdi()
        {
            InitializeComponent();
        }
        private Form findForm(string formName)
        {
            foreach (Form f in Application.OpenForms)
                if (f.Name.Equals(formName))
                    return f;
            return null;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Form f = findForm("LoaiHangForm");
            if (f == null)
                f = new LoaiHangForm();
            f.MdiParent = this;
            f.Show();
            f.Activate();
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {
            Form f = findForm("MatHang");
            if (f == null)
                f = new MatHang();
            f.MdiParent = this;
            f.Show();
            f.Activate();
        }

        private void hóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = findForm("FRMQuanLyHoaDonNhap");
            if (f == null)
                f = new FRMQuanLyHoaDonNhap();
            f.MdiParent = this;
            f.Show();
            f.Activate();
        }

        private void chiTiếtHóaĐơnNhậpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = findForm("FRMQuanLyChiTietHoaDonNhap");
            if (f == null)
                f = new FRMQuanLyChiTietHoaDonNhap(0);
            f.MdiParent = this;
            f.Show();
            f.Activate();
        }

        private void hóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = findForm("FRMHoaDonBan");
            if (f == null)
                f = new FRMHoaDonBan();
            f.MdiParent = this;
            f.Show();
            f.Activate();
        }

        private void chiTiếtHóaĐơnBánToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new FRMChiTietHoaDonBan(0);
            f.MdiParent = this;
            f.Show();
        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {
            Form f = findForm("FormNhanVien");
            if (f == null)
            {
                f = new FormNhanVien();
                f.MdiParent = this;
                f.Show();
                f.Activate();
            }
        }
    }
}
