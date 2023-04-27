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
    public partial class Menu : Form
    {
        public Menu()
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

        private void btnLoaiHang_Click(object sender, EventArgs e)
        {
            Form f = findForm("LoaiHangForm");
            if (f == null)
                f = new LoaiHangForm();
            f.Show();
            f.Activate();
        }

        private void btnMatHang_Click(object sender, EventArgs e)
        {
            Form f = findForm("MatHang");
            if (f == null)
                f = new MatHang();
            f.Show();
            f.Activate();
        }

        private void btnHDN_Click(object sender, EventArgs e)
        {
            Form f = findForm("FRMQuanLyHoaDonNhap");
            if (f == null)
                f = new FRMQuanLyHoaDonNhap();
            f.Show();
            f.Activate();
        }

        private void buttonChiTietHDN_Click(object sender, EventArgs e)
        {
            Form f = findForm("FRMQuanLyChiTietHoaDonNhap");
            if (f == null)
                f = new FRMQuanLyChiTietHoaDonNhap(0);
            f.Show();

        }

        private void btnHDBan_Click(object sender, EventArgs e)
        {
            Form f = findForm("FRMHoaDonBan");
            if (f == null)
                f = new FRMHoaDonBan();
            f.Show();
        }

        private void tbnChiTietHoaDonban_Click(object sender, EventArgs e)
        {
            Form f = new FRMChiTietHoaDonBan(0);
            f.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form f = findForm("FormNhanVien");
            if(f==null){
                f = new FormNhanVien();
                f.Show();
            }
        }
    }
}
