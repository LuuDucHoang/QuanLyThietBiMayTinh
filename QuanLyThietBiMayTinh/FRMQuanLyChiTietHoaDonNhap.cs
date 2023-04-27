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
    public partial class FRMQuanLyChiTietHoaDonNhap : Form
    {
        private string connectionString;
        private int iMaHD = 0;
        public FRMQuanLyChiTietHoaDonNhap(int iMaHD)
        {
            connectionString = ConfigurationManager.ConnectionStrings["lienKetSQl"].ConnectionString;
            this.iMaHD = iMaHD;
            InitializeComponent();
        }

        private void FRMQuanLyChiTietHoaDonNhap_Load(object sender, EventArgs e)
        {
            if (iMaHD == 0)
            {
                labelHD.Text = "Bạn chưa chọn hóa đơn";
            }
            else
            {
                labelHD.Text = "Thêm mặt hàng vào hóa đơn " + iMaHD;
            }
            hienLoaiHang();
            getChiTietHDNHap(this.iMaHD);
        }

        private void hienLoaiHang()
        {
            DataTable tblLoaiHang = new DataTable();
            tblLoaiHang = getLoaiHang();
            DataView dvLoaiHang = new DataView(tblLoaiHang);
            cbloaihang.DisplayMember = "sTenHang";
            cbloaihang.ValueMember = "iMaLH";
            cbloaihang.DataSource = dvLoaiHang;   
            
        }

        private DataTable getLoaiHang()
        {
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                Cnn.Open();
                using (SqlCommand Cmd = new SqlCommand("prViewLoaiHang", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter Da = new SqlDataAdapter(Cmd))
                    {
                        DataTable tbl = new DataTable("tblLoaiHang");
                        Da.Fill(tbl);
                        Cnn.Close();
                        return tbl;
                    }
                }
            }
        }


        private void hienMatHang(string sMaLH)
        {
            using (DataTable tblMatHang = getMatHang(sMaLH))
            {
                DataView dvMatHang = new DataView(tblMatHang);
                cbmathang.DisplayMember = "sTenHH";
                cbmathang.ValueMember = "iMaMH";
                cbmathang.DataSource = dvMatHang;
            }
        }

        private DataTable getMatHang(string sMaLH)
        {
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                Cnn.Open();
                using (SqlCommand Cmd = new SqlCommand("prViewMatHang", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@iMaLH", sMaLH);
                    using (SqlDataAdapter Da = new SqlDataAdapter(Cmd))
                    {
                        DataTable tbl = new DataTable("tblMatHang");
                        Da.Fill(tbl);
                        Cnn.Close();
                        return tbl;
                    }
                }
            }
        }

        private void getChiTietHDNHap(int iMaHD)
        {
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                Cnn.Open();
                using (SqlCommand Cmd = new SqlCommand("prViewdeltailHDNhap", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@iMaHD", iMaHD);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(Cmd))
                    {
                        DataSet tbl = new DataSet();
                        adapter.Fill(tbl);
                        dataGRVdetailHDNhap.DataSource = tbl.Tables[0];
                        Cnn.Close();
                    }
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.iMaHD == 0)
                {
                    MessageBox.Show("Bạn lòng chọn hóa đơn muốn thêm!");
                    return;
                }
                string strMaMH = cbmathang.SelectedValue.ToString(),
                       strSoLuong = soluong.Text.ToString(),
                        sGiaNhap = textGiaNhap.Text.ToString();
                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    Cnn.Open();
                    using (SqlCommand Cmd = new SqlCommand("prInsertChiTietHoaDonNhap", Cnn))
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.Parameters.AddWithValue("@iMaMH", strMaMH);
                        Cmd.Parameters.AddWithValue("@iSoLuong", strSoLuong);
                        Cmd.Parameters.AddWithValue("@iMaHD", iMaHD);
                        Cmd.Parameters.AddWithValue("@fGiaNhap", sGiaNhap);

                        int result = Cmd.ExecuteNonQuery();
                        if(result > 0)
                        {
                            MessageBox.Show("Bạn đã thêm 1 bản ghi mới!");
                            getChiTietHDNHap(iMaHD);
                            clear();
                        }
                        else
                        {
                            MessageBox.Show("Quá trình thực hiện xảy ra lỗi vui lòng thử lại");
                        }
                        Cnn.Close();
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Quá trình thực hiện xảy ra lỗi vui lòng thử lại" + ex.ToString());
            }

        }

        private void cbloaihang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sMaLH = cbloaihang.SelectedValue.ToString();
            hienMatHang(sMaLH);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string txtSoLuong = soluong.Text;
            int iMaMH = int.Parse(dataGRVdetailHDNhap.Rows[dataGRVdetailHDNhap.CurrentRow.Index].Cells[1].Value.ToString());
            string txtGiaNhap = textGiaNhap.Text;
            int iSoLuong = int.Parse(dataGRVdetailHDNhap.Rows[dataGRVdetailHDNhap.CurrentRow.Index].Cells[6].Value.ToString());
            float fDonGia = int.Parse(dataGRVdetailHDNhap.Rows[dataGRVdetailHDNhap.CurrentRow.Index].Cells[7].Value.ToString());
            if (txtSoLuong != "")
            {
                iSoLuong = int.Parse(txtSoLuong);
            }
            if (txtGiaNhap != "")
            {
                fDonGia = float.Parse(txtGiaNhap);
            }
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                Cnn.Open();
                using (SqlCommand Cmd = new SqlCommand("prUpdateChiTietHDNhap", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@iMaMH", iMaMH);
                    Cmd.Parameters.AddWithValue("@iMaHD", iMaHD);
                    Cmd.Parameters.AddWithValue("@iSoLuong", iSoLuong);
                    Cmd.Parameters.AddWithValue("@fDonGia", fDonGia);

                    int result = Cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật thành công");
                        getChiTietHDNHap(this.iMaHD);
                        clear();
                    }
                    else
                    {
                        MessageBox.Show("Quá trình thực hiện xảy ra lỗi vui lòng thử lại");
                    }
                    Cnn.Close();
                }
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int iMaMH = int.Parse(dataGRVdetailHDNhap.Rows[dataGRVdetailHDNhap.CurrentRow.Index].Cells[1].Value.ToString());
            DialogResult re = MessageBox.Show("Bạn có chắc chắn muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (re == DialogResult.No)
            {
                return;
            }
            try
            {
                using (SqlConnection Cnn = new SqlConnection(connectionString))
                {
                    Cnn.Open();
                    using (SqlCommand Cmd = new SqlCommand("prDeleteRowChiTietHDNhap", Cnn))
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.Parameters.AddWithValue("@iMaMH", iMaMH);
                        Cmd.Parameters.AddWithValue("@iMaHD", iMaHD);
   
                        int result = Cmd.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Xóa thành công");
                            getChiTietHDNHap(this.iMaHD);
                        }
                        else
                        {
                            MessageBox.Show("Quá trình thực hiện xảy ra lỗi vui lòng thử lại");
                        }
                        Cnn.Close();
                    }
                }
            }catch(Exception ex){

                MessageBox.Show("Quá trình thực hiện xảy ra lỗi vui lòng thử lại");
            }
        }

        private void clear()
        {
            soluong.Text = textGiaNhap.Text = "";
        }

        private void cbmathang_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                Cnn.Open();
                SqlCommand Cmd = new SqlCommand("prSoLuong", Cnn);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@iMaMH", cbmathang.SelectedValue.ToString());
                var reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtTonKho.Text = reader["iSoLuong"].ToString();
                }
            }
        }

        private void labelHD_Click(object sender, EventArgs e)
        {

        }
    }
}
