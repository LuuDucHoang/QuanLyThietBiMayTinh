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
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyThietBiMayTinh
{
    public partial class MatHang : Form
    {
        private string connectionString;

        public MatHang()
        {
            connectionString = ConfigurationManager.ConnectionStrings["lienKetSQl"].ConnectionString;
            InitializeComponent();
        }

    /*    private int timTenHH(string a)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["lienKetSQl"].ConnectionString;
            using(SqlConnection cnn = new SqlConnection(connectionString))
            {
                using(SqlCommand cmd = new SqlCommand("select * from tblMatHang where sTenHH ="+a,cnn))
                {
                    cmd.CommandType = CommandType.Text;
                    cnn.Open();
                    using(SqlDataAdapter ad = new SqlDataAdapter(cmd))
                    {
                        DataTable tb = new DataTable();
                        ad.Fill(tb);
                        return tb.Rows.Count;
                    }
                }
            }
        }*/

        private int getTenHang(string v)
        {
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                Cnn.Open();
                SqlCommand Cmd = new SqlCommand("timTenHang", Cnn);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@sTen", v);
                SqlDataAdapter Da = new SqlDataAdapter(Cmd);
                DataTable tbl = new DataTable("tblMatHang");
                Da.Fill(tbl);
                Cnn.Close();
                return tbl.Rows.Count;
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["lienKetSQl"].ConnectionString;
            string procName;
            if (btnThem.Text == "Thêm")
            {
                procName = "prThemMatHang";
            }
            else
            {
                procName = "prSuaMatHang";
            }
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand(procName, Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@tenloaihang", comboBox1.Text);
                    Cmd.Parameters.AddWithValue("@tenHH", txtTenMH.Text);
                    Cmd.Parameters.AddWithValue("@mau", txtMau.Text);
                    Cmd.Parameters.AddWithValue("@kichthuoc", txtKichThuoc.Text);
                    Cmd.Parameters.AddWithValue("@mota", txtMoTa.Text);
                    Cmd.Parameters.AddWithValue("@giaban", txtGia.Text);
                    if (btnThem.Text == "Cập nhật")
                    {
                        DataView dvMatHang = (DataView)dataGridView1.DataSource;
                        DataRowView drvMatHang = dvMatHang[dataGridView1.CurrentRow.Index];
                        string maMatHang = drvMatHang["iMaMH"].ToString();
                        Cmd.Parameters.AddWithValue("@mahang", maMatHang);
                    }

                    Cnn.Open();
                    int n = Cmd.ExecuteNonQuery();
                    Cnn.Close();
                    if (n > 0 && btnThem.Text == "Thêm")
                    {
                        MessageBox.Show("Thêm mặt hàng thành công!!");
                    }
                    if (n > 0 && btnThem.Text == "Cập nhật")
                    {
                        MessageBox.Show("Cập nhật mặt hàng thành công!!");
                    }
                    hienMatHang();
                    hienLoaiHang();
                    txtTenMH.Text = txtMau.Text = txtKichThuoc.Text = txtMoTa.Text = txtGia.Text = string.Empty;
                    btnXoa.Enabled = btnTim.Enabled = btnBaoCao.Enabled = true;
                    btnThem.Text = "Thêm";
                }//cmd
            }//Cnn
        }
        private static bool isNumber(string soluong)
        {
            Regex regex = null;
            try
            {
                regex = new Regex(@"^[-+]?[0-9]*\.?[0-9]+$");
                return regex.IsMatch(soluong);
            }
            catch
            {
                return regex.IsMatch(soluong);
            }
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
                comboBox1.DisplayMember = "sTenHang";
                comboBox1.DataSource = dvLoaiHang;
                
            }
        }


        private DataTable getMatHang()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["lienKetSQl"].ConnectionString;
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                using (SqlCommand Cmd = new SqlCommand("prHienMatHang", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter Da = new SqlDataAdapter(Cmd))
                    {
                        DataTable tbl = new DataTable("tblMatHang");
                        Da.Fill(tbl);
                        return tbl;
                    }
                }
            }
        }
       

        private void hienMatHang(string dk = "")
        {
            using (DataTable tblMatHang = getMatHang())
            {
                DataView dvMatHang = new DataView(tblMatHang);
                if (!string.IsNullOrEmpty(dk))
                    dvMatHang.RowFilter = dk;
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = dvMatHang;
            }
        }

        private void MatHang_Load(object sender, EventArgs e)
        {
            hienMatHang();
            hienLoaiHang();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            DataView dvMatHang = (DataView)dataGridView1.DataSource;
            DataRowView drvMatHang = dvMatHang[dataGridView1.CurrentRow.Index];
            chuyenTrangThaiSua(drvMatHang);
            btnXoa.Enabled =btnTim.Enabled=btnBaoCao.Enabled= false;
           
            btnThem.Text = "Cập nhật";
        }

        private void chuyenTrangThaiSua(DataRowView drvMatHang)
        {
            comboBox1.Text = drvMatHang["sTenHang"].ToString();
            txtTenMH.Text = drvMatHang["sTenHH"].ToString();
            txtMau.Text = drvMatHang["sMauSac"].ToString();
            txtKichThuoc.Text = drvMatHang["sKichThuoc"].ToString();
            txtMoTa.Text = drvMatHang["sMoTaChiTiet"].ToString();
            txtGia.Text = drvMatHang["fGiaBan"].ToString();

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
                DataView dvMatHang = (DataView)dataGridView1.DataSource;
                DataRowView drvMatHang = dvMatHang[dataGridView1.CurrentRow.Index];

                string connectionString = ConfigurationManager.ConnectionStrings["lienKetSQl"].ConnectionString;
                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    using (SqlCommand Cmd = new SqlCommand("prXoaMatHang", Cnn))
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.Parameters.AddWithValue("@maMH", drvMatHang["iMaMH"]);
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
                    MessageBox.Show("Mặt hàng này có dữ liệu liên quan, không xóa được", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Đã có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            hienMatHang();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string filter = "iMaMH>0";
            if (!string.IsNullOrEmpty(comboBox1.Text.Trim()))
                filter += string.Format(" AND sTenHang like '%{0}%'", comboBox1.Text);
            if (!string.IsNullOrEmpty(txtTenMH.Text.Trim()))
                filter += string.Format(" AND sTenHH like '%{0}%'", txtTenMH.Text);
            if (!string.IsNullOrEmpty(txtMoTa.Text.Trim()))
                filter += string.Format(" AND sMoTaChiTiet like '%{0}%'", txtMoTa.Text);
            if (!string.IsNullOrEmpty(txtMau.Text.Trim()))
                filter += string.Format(" AND sMauSac like '%{0}%'", txtMau.Text);
            if (!string.IsNullOrEmpty(txtKichThuoc.Text.Trim()))
                filter += string.Format(" AND sKichThuoc like '%{0}%'", txtKichThuoc.Text);
            string a = Convert.ToString(txtGia.Text);
            string[] arr = a.Split('-');
            if (!string.IsNullOrEmpty(txtGia.Text.Trim()))
            {
                if (arr.Length > 1)
                {
                    filter += string.Format(" AND fGiaBan >= {0} and fGiaBan <= {1}", arr[0], arr[1]);
                }
                else
                {
                    filter += string.Format(" AND fGiaBan = {0}", arr[0]);
                }
            }
            //btnBaoCao.Enabled = false;
            hienMatHang(filter);
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            if(btnThem.Text=="Cập nhật")
            {
                DialogResult re = MessageBox.Show("Bạn có chắc chắn muốn thoát không, tất cả thông tin bạn vừa sửa sẽ không được lưu", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (re == DialogResult.No)
                {
                    return;
                }
            }
            txtTenMH.Text=txtMoTa.Text=txtMau.Text=txtKichThuoc.Text=txtGia.Text = string.Empty;
            btnThem.Text = "Thêm";
            btnXoa.Enabled =btnTim.Enabled=btnBaoCao.Enabled= true;
            hienMatHang();
        }

        private void txtTenMH_TextChanged(object sender, EventArgs e)
        {
            btnThem.Enabled = txtTenMH.Text.Trim().Length > 0;
        }

        private Form findForm(string formName)
        {
            foreach (Form f in Application.OpenForms)
                if (f.Name.Equals(formName))
                    return f;
            return null;
        }

        private void btnBaoCao_Click(object sender, EventArgs e)
        {
            string filter = "{tblMatHang.iMaMH}>0";
            if (!string.IsNullOrEmpty(comboBox1.Text.Trim()))
                filter += string.Format(" AND {1} like '*{0}*'", comboBox1.Text, "{tblLoaiHang.sTenHang}");
            if (!string.IsNullOrEmpty(txtTenMH.Text.Trim()))
                filter += string.Format(" AND {1} like '*{0}*'", txtTenMH.Text, "{tblMatHang.sTenHH}");
            if (!string.IsNullOrEmpty(txtMoTa.Text.Trim()))
                filter += string.Format(" AND {1} like '*{0}*'", txtMoTa.Text, "{tblMatHang.sMoTaChiTiet}");
            if (!string.IsNullOrEmpty(txtMau.Text.Trim()))
                filter += string.Format(" AND {1} like '*{0}*'", txtMau.Text, "{tblMatHang.sMauSac}");
            if (!string.IsNullOrEmpty(txtKichThuoc.Text.Trim()))
                filter += string.Format(" AND {1} like '*{0}*'", txtKichThuoc.Text, "{tblMatHang.sKichThuoc}");
            //if (!string.IsNullOrEmpty(txtGia.Text.Trim()))
            //    filter += string.Format(" AND {1} = {0}", txtGia.Text, "{tblMatHang.fGiaBan}");

            string a = Convert.ToString(txtGia.Text);
            string[] arr = a.Split('-');
            if (!string.IsNullOrEmpty(txtGia.Text.Trim()))
            {
                if (arr.Length > 1)
                {
                    filter += string.Format(" AND {2} >= {0} and {2} <= {1}", arr[0], arr[1], "{tblMatHang.fGiaBan}");
                }
                else
                {
                    filter += string.Format(" AND {1} = {0}", arr[0], "{tblMatHang.fGiaBan}");
                }
            }

            ReportForm f = findForm("MatHangReport") as ReportForm;
            if (f == null)
                f = new ReportForm();
            f.Show();
            f.showReport("MatHangReport.rpt", filter, "Danh sách mặt hàng");
            f.Activate();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGia_Validating(object sender, CancelEventArgs e)
        {
            if (txtGia.Text == "")
            {
                errorProvider1.SetError(txtGia, "Ban phai nhap don gia!");
            }else
            {
                try
                {
                    int getDonGia = 0;

                    if (isNumber(txtGia.Text) != true)
                    {
                        errorProvider2.SetError(txtGia, "Don gia phai la so");
                    }
                    else
                    {
                        getDonGia = int.Parse(txtGia.Text);
                        errorProvider2.SetError(txtGia, "");
                    }

                    if (txtGia.Text == "")
                    {
                        errorProvider1.SetError(txtGia, "Ban phai nhap don gia!");
                    }
                    
                    else
                    {
                        if (getDonGia < 0)
                        {
                            errorProvider1.SetError(txtGia, "Don gia phai lon hon khong");

                        }
                        else
                        {
                            errorProvider1.SetError(txtGia, "");
                        }
                    }
                }
                catch
                {
                    errorProvider3.SetError(txtGia, "Nhap gia khong hop le");
                }
            }

        }

        private void txtGia_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtGia_Validating_1(object sender, CancelEventArgs e)
        {
            if (txtGia.Text == "")
            {
                errorProvider1.SetError(txtGia, "Ban phai nhap don gia!");
            }
            else
            {
                try
                {
                    int getDonGia = 0;

                    if (isNumber(txtGia.Text) != true)
                    {
                        errorProvider2.SetError(txtGia, "Don gia phai la so");
                    }
                    else
                    {
                        getDonGia = int.Parse(txtGia.Text);
                        errorProvider2.SetError(txtGia, "");
                    }

                    if (txtGia.Text == "")
                    {
                        errorProvider1.SetError(txtGia, "Ban phai nhap don gia!");
                    }
                    else
                    {
                        if (getDonGia < 0)
                        {
                            errorProvider1.SetError(txtGia, "Don gia phai lon hon khong");

                        }
                        else
                        {
                            errorProvider1.SetError(txtGia, "");
                        }
                    }
                }
                catch
                {
                    errorProvider3.SetError(txtGia, "Nhap gia khong hop le");
                }
            }
        }

        private void txtTenMH_Validating(object sender, CancelEventArgs e)
        {
         if(txtTenMH.Text == "" )
            {
                errorProvider1.SetError(txtTenMH, "Ban phai nhap ten mat hang!");

            }
         else
            {
                try
                {
                    if(getTenHang(txtTenMH.Text) > 0)
                    {
                        errorProvider1.SetError(txtTenMH, "Ten mat hang da ton tai!");

                    }
                }
                catch
                {
                    errorProvider3.SetError(txtTenMH    , "Nhap gia khong hop le");
                }
            }
       
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
   
        }


    }
}
