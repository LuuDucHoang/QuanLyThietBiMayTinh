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
    public partial class FRMChiTietHoaDonBan : Form
    {
        private int MaHD = 0;
        private string connectionString;

        public FRMChiTietHoaDonBan(int iMaHD)
        {
            connectionString = ConfigurationManager.ConnectionStrings["lienKetSQl"].ConnectionString;
            this.MaHD = iMaHD;
            InitializeComponent();
        }

        private void FRMChiTietHoaDonBan_Load(object sender, EventArgs e)
        {
            loadForm();
        }
        private void loadForm()
        {
            if (MaHD == 0)
            {
                labelHD.Text = "Bạn chưa chọn hóa đơn";
            }
            else
            {
                labelHD.Text = "Thêm mặt hàng vào hóa đơn " + MaHD;
            }
            hienChiTietHDBan(this.MaHD);
            hienLoaiHang();
        }

        private void hienChiTietHDBan(int iMaHD)
        {
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                Cnn.Open();
                using (SqlCommand Cmd = new SqlCommand("prFindAllDetailsHDBan", Cnn))
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.Parameters.AddWithValue("@iMaHD", iMaHD);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(Cmd))
                    {
                        DataSet tbl = new DataSet();
                        adapter.Fill(tbl);
                        grvChiTietHDBan.DataSource = tbl.Tables[0];
                        Cnn.Close();
                    }
                }
            }
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
                SqlCommand Cmd = new SqlCommand("prViewLoaiHang", Cnn);
                Cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter Da = new SqlDataAdapter(Cmd);
                DataTable tbl = new DataTable("tblLoaiHang");
                Da.Fill(tbl);
                Cnn.Close();
                return tbl;
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
            SqlConnection Cnn = new SqlConnection(connectionString);
            Cnn.Open();
            SqlCommand Cmd = new SqlCommand("prViewMatHang", Cnn);

            Cmd.CommandType = CommandType.StoredProcedure;
            Cmd.Parameters.AddWithValue("@iMaLH", sMaLH);

            SqlDataAdapter Da = new SqlDataAdapter(Cmd);
            DataTable tbl = new DataTable("tblMatHang");
            Da.Fill(tbl);
            Cnn.Close();
            return tbl;  
        }

        private void cbloaihang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sMaLH = cbloaihang.SelectedValue.ToString();
            hienMatHang(sMaLH);
        }

        private string convertBaoHanh()
        {
            string strBaoHanh = txtBaoHanh.Text;
           
            string[] baoHanhs = strBaoHanh.Split('/');
            return baoHanhs[0];
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if(this.MaHD == 0)
                {
                    MessageBox.Show("Vui lòng chọn hóa đơn");
                    return;
                }
                int iMaMH = int.Parse(cbmathang.SelectedValue.ToString());
                int iSoLuong = int.Parse(soluong.Text);
                int iTonKho = int.Parse(txtTonKho.Text);
                if(iSoLuong > iTonKho)
                {
                    MessageBox.Show("Sản phẩm trong kho hiện không đủ");
                    return;
                }
                string sBaoHanh = convertBaoHanh();
                string sGhiChu = txtGhiChu.Text;

                SqlConnection connetion = new SqlConnection(connectionString);
                connetion.Open();
                SqlCommand command = new SqlCommand("prInsertDetailsHDBan", connetion);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@iMaMH", iMaMH);
                command.Parameters.AddWithValue("@iMaHD", MaHD);
                command.Parameters.AddWithValue("@iSoLuong", iSoLuong);
                command.Parameters.AddWithValue("@iBaoHanh", sBaoHanh);
                command.Parameters.AddWithValue("@sGhiChu", sGhiChu);
                int result = command.ExecuteNonQuery();
                if(result > 0)
                {
                    MessageBox.Show("Bạn đã thêm mới 1 bản ghi");
                    loadForm();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra vui lòng thực hiện lại");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xảy ra lỗi: " + ex.ToString());
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int iSoLuong = int.Parse(soluong.Text);
            int iBaoHanh  = int.Parse(convertBaoHanh());
            string sGhiChu = txtGhiChu.Text;
            int iFirstSoLuong = int.Parse(grvChiTietHDBan.Rows[grvChiTietHDBan.CurrentRow.Index].Cells["iSoLuong"].Value.ToString());
            int iTonKho = int.Parse(txtTonKho.Text);
            string stenMH = grvChiTietHDBan.Rows[grvChiTietHDBan.CurrentRow.Index].Cells["sTenHH"].Value.ToString();
            if (iSoLuong > iTonKho + iFirstSoLuong)
            {
                MessageBox.Show("Số lượng trong kho không đủ");
                return;
            }
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                Cnn.Open();
                SqlCommand Cmd = new SqlCommand("prUpdateDetailHdBan", Cnn);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@iMaHD", this.MaHD);
                Cmd.Parameters.AddWithValue("@iMaMH", cbmathang.SelectedValue.ToString());
                Cmd.Parameters.AddWithValue("@iSoluong", iSoLuong);
                Cmd.Parameters.AddWithValue("@iBaohanh", iBaoHanh);
                Cmd.Parameters.AddWithValue("@sGhichu", sGhiChu);
                Cmd.Parameters.AddWithValue("@sTenMH", stenMH);
                int result = Cmd.ExecuteNonQuery();
                if(result > 0)
                {
                    MessageBox.Show("Bạn đã cập nhật bản ghi mới");
                    loadForm();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra vui lòng thử lại sau!");
                }
            }

        }

        private void cbmathang_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                Cnn.Open();
                SqlCommand Cmd = new SqlCommand("prSoLuong", Cnn);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@iMaMH",cbmathang.SelectedValue.ToString());
                var reader = Cmd.ExecuteReader();
                while (reader.Read())
                {
                    txtTonKho.Text =  reader["iSoLuong"].ToString();
                }
            }
        }

        private void loadCellgridView()
        {
            try
            {
                int index = grvChiTietHDBan.CurrentRow.Index;
                string strSoLuong = grvChiTietHDBan.Rows[index].Cells["iSoLuong"].Value.ToString();
                string strGhiChu = grvChiTietHDBan.Rows[index].Cells["sGhiChu"].Value.ToString();
                string strBaoHanh = grvChiTietHDBan.Rows[index].Cells["iBaoHanh"].Value.ToString();
                soluong.Text = strSoLuong;
                txtBaoHanh.Text = strBaoHanh;
                txtGhiChu.Text = strGhiChu;
            }catch(Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra");
            }
        }

        private void grvChiTietHDBan_SelectionChanged(object sender, EventArgs e)
        {
            //loadCellgridView();
            try
            {
                int index = 0;
                if (grvChiTietHDBan.CurrentRow != null)
                {
                    index = grvChiTietHDBan.CurrentRow.Index;
                }
                else return;
                string strSoLuong = grvChiTietHDBan.Rows[index].Cells["iSoLuong"].Value.ToString();
                string strGhiChu = grvChiTietHDBan.Rows[index].Cells["sGhiChu"].Value.ToString();
                string strBaoHanh = grvChiTietHDBan.Rows[index].Cells["iBaoHanh"].Value.ToString();
                soluong.Text = strSoLuong;
                txtBaoHanh.Text = strBaoHanh;
                txtGhiChu.Text = strGhiChu;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult re = MessageBox.Show("Bạn có chắc chắn muốn xóa không", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (re == DialogResult.No)
            {
                return;
            }
            string strTenMH = grvChiTietHDBan.Rows[grvChiTietHDBan.CurrentRow.Index].Cells["sTenHH"].Value.ToString();
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                Cnn.Open();
                SqlCommand Cmd = new SqlCommand("prDeleteChitietHD", Cnn);
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.Parameters.AddWithValue("@iMaHD", MaHD);
                Cmd.Parameters.AddWithValue("@sTenMH", strTenMH);
                int result = Cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Bạn đã xóa 1 bản ghi");
                    loadForm();
                }
                else
                {
                    MessageBox.Show("Có lỗi xảy ra vui lòng thử lại sau!");
                }
            }
        }

        private void txtGhiChu_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelHD_Click(object sender, EventArgs e)
        {

        }
    }
}
