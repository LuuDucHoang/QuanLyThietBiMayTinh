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
    public partial class FormNhanVien : Form
    {
        NhanVienBLL bllnv;
        public FormNhanVien()
        {
            InitializeComponent();
            bllnv = new NhanVienBLL();
        }

        public void showAllNhanVien()
        {
            DataTable dt = bllnv.getAllNhanVien();
            dataGridView1.DataSource = dt;
        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            showAllNhanVien();
        }



        public bool checkData()
        {
            if (string.IsNullOrEmpty(tbTen.Text))
            {
                MessageBox.Show("Ban chua nhan ten!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbTen.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(tbSDT.Text))
            {
                MessageBox.Show("Ban chua nhan SDT!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbSDT.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tbDiachi.Text))
            {
                MessageBox.Show("Ban chua nhan dia chi!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbDiachi.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tbPhucap.Text))
            {
                MessageBox.Show("Ban chua nhan Phu cap!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbPhucap.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(tbLuong.Text))
            {
                MessageBox.Show("Ban chua nhan luong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                tbLuong.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(dateTimePicker1.Text))
            {
                MessageBox.Show("Ban chua nhan ngay sinh!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dateTimePicker1.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (checkData())
            {
                tblNhanVien nv = new tblNhanVien();
                nv.sTen = tbTen.Text;
                nv.sSDT = tbSDT.Text;
                nv.sDiaChi = tbDiachi.Text;
                nv.fPhucap = float.Parse(tbPhucap.Text);
                nv.fLuong = float.Parse(tbLuong.Text);
                nv.dNgaysinh = DateTime.Parse(dateTimePicker1.Text);

                if (bllnv.insertNhanVien(nv))
                {
                    showAllNhanVien();
                }
                else
                {
                    MessageBox.Show("Co loi xay ra!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                tbTen.Text = "";
                tbSDT.Text = "";
                tbDiachi.Text = "";
                tbLuong.Text = "";
                tbPhucap.Text = "";
                dateTimePicker1.Text = "";
                MessageBox.Show("Them thanh cong.", "Thong bao",MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
          
        }

        int ID;
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (checkData())
            {
                tblNhanVien nv = new tblNhanVien();
                nv.iMaNV = ID;
                nv.sTen = tbTen.Text;
                nv.sSDT = tbSDT.Text;
                nv.sDiaChi = tbDiachi.Text;
                nv.fPhucap = float.Parse(tbPhucap.Text);
                nv.fLuong = float.Parse(tbLuong.Text);
                nv.dNgaysinh = DateTime.Parse(dateTimePicker1.Text);

                if (bllnv.updateNhanVien(nv))
                {
                    showAllNhanVien();
                }
                else
                {
                    MessageBox.Show("Co loi xay ra!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                tbTen.Text = "";
                tbSDT.Text = "";
                tbDiachi.Text = "";
                tbLuong.Text = "";
                tbPhucap.Text = "";
                dateTimePicker1.Text = "";
                MessageBox.Show("Sua thanh cong.", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ban co muon xoa?", "Thong bao", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (checkData())
                {
                    tblNhanVien nv = new tblNhanVien();
                    nv.iMaNV = ID;

                    if (bllnv.deleteNhanVien(nv))
                    {
                        showAllNhanVien();
                    }
                    else
                    {
                        MessageBox.Show("Co loi xay ra!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    }
                    tbTen.Text = "";
                    tbSDT.Text = "";
                    tbDiachi.Text = "";
                    tbLuong.Text = "";
                    tbPhucap.Text = "";
                    dateTimePicker1.Text = "";
                    MessageBox.Show("Xoa thang cong.","Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
              
            }
          
        }

        private void btnBoqua_Click(object sender, EventArgs e)
        {
            tbTen.Text = "";
            tbSDT.Text = "";
            tbDiachi.Text = "";
            tbLuong.Text = "";
            tbPhucap.Text = "";
            dateTimePicker1.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            if (index >= 0)
            {
                ID = Int32.Parse(dataGridView1.Rows[index].Cells["iMaNV"].Value.ToString());
                tbTen.Text = dataGridView1.Rows[index].Cells["sTen"].Value.ToString();
                tbSDT.Text = dataGridView1.Rows[index].Cells["sSDT"].Value.ToString();
                tbPhucap.Text = dataGridView1.Rows[index].Cells["fPhucap"].Value.ToString();
                tbLuong.Text = dataGridView1.Rows[index].Cells["fLuong"].Value.ToString();
                tbDiachi.Text = dataGridView1.Rows[index].Cells["sDiachi"].Value.ToString();
                dateTimePicker1.Text = dataGridView1.Rows[index].Cells["dNgaysinh"].Value.ToString();

            }
        }



      

    }
}
