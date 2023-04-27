using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThietBiMayTinh
{
    public partial class LoaiHangForm : Form
    {
        public LoaiHangForm()
        {
            InitializeComponent();
        }




        private void btnThem_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["lienKetSQl"].ConnectionString;
            string procName;
            if (btnThem.Text == "Thêm")
            {
                procName = "prThemLoaiHang";
            }
            else
            {
                procName = "prSuaLoaiHang";
                
            }
            using(SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using(SqlCommand Cmd = new SqlCommand(procName, Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@tenhang", txtTenLoaiHang.Text);
                    if(btnThem.Text=="Cập nhật")
                    {
                        DataView dvLoaiHang = (DataView)dataGridView1.DataSource;
                        DataRowView drvLoaiHang = dvLoaiHang[dataGridView1.CurrentRow.Index];
                        string maloaiHang = drvLoaiHang["iMaLH"].ToString();
                        Cmd.Parameters.AddWithValue("@maLh",maloaiHang );
                    }
                    Cnn.Open();
                    int n = Cmd.ExecuteNonQuery();
                    Cnn.Close();
                    if (n > 0 && btnThem.Text == "Thêm")
                    {
                        MessageBox.Show("Thêm loại hàng thành công!!");
                    }
                    if (n > 0 && btnThem.Text == "Cập nhật")
                    {
                        MessageBox.Show("Cập nhật loại hàng thành công!!");
                    }
                    hienLoaiHang();
                    txtTenLoaiHang.Text = string.Empty;
                    btnXoa.Enabled = true;
                    btnThem.Text = "Thêm";
                }//cmd
            }//Cnn
        }

        

        private DataTable getLoaiHang()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["lienKetSQl"].ConnectionString;
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("prLayLoaiHang", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter Da = new SqlDataAdapter(Cmd))
                    {
                        DataTable tbl = new DataTable("tblLoaiHang");
                        Da.Fill(tbl);
                        return tbl;
                    }
                }
            }
        }

        private void hienLoaiHang()
        {
            using (DataTable tblLoaiHang = getLoaiHang())
            {
                DataView dvLoaiHang = new DataView(tblLoaiHang);
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dvLoaiHang;
            }
        }

        private void LoaiHangForm_Load(object sender, EventArgs e)
        {
            hienLoaiHang();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataView dvLoaiHang = (DataView)dataGridView1.DataSource;
            DataRowView drvLoaiHang = dvLoaiHang[dataGridView1.CurrentRow.Index];
            chuyenTrangThaiSua(drvLoaiHang);
            btnXoa.Enabled = false;
            btnThem.Text = "Cập nhật";
        }

        private void chuyenTrangThaiSua(DataRowView drvLoaiHang)
        {

            txtTenLoaiHang.Text = drvLoaiHang["sTenHang"].ToString();
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("Bạn có chắc chắn muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (re == DialogResult.No)
            {
                return;
            }
            try
            {
                DataView dvLoaiHang = (DataView)dataGridView1.DataSource;
                DataRowView drvLoaiHang = dvLoaiHang[dataGridView1.CurrentRow.Index];

                string connectionString = ConfigurationManager.ConnectionStrings["lienKetSQl"].ConnectionString;
                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand Cmd = new SqlCommand("prXoaLoaiHang", Cnn))
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.Parameters.AddWithValue("@maLh", drvLoaiHang["iMaLH"]);
                        Cnn.Open();
                        int n = Cmd.ExecuteNonQuery();
                        Cnn.Close();
                        if (n > 0)
                        {
                            MessageBox.Show("Xóa thành công!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        hienLoaiHang();
                    }//Cmd
                }//Cnn
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("REFERENCE"))
                {
                    MessageBox.Show("Loại hàng này có dữ liệu liên quan, không xóa được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Đã có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            hienLoaiHang();

        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            txtTenLoaiHang.Text = string.Empty;
            btnThem.Text = "Thêm";
            btnXoa.Enabled = true;
        }

        private void txtTenLoaiHang_TextChanged(object sender, EventArgs e)
        {
            btnThem.Enabled = txtTenLoaiHang.Text.Trim().Length > 0;
        }
    }
}
