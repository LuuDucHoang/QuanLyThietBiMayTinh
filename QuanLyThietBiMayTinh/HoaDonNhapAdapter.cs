using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThietBiMayTinh
{
    class HoaDonNhapAdapter
    {
        private string connectionString;

        public HoaDonNhapAdapter()
        {
            this.connectionString = ConfigurationManager.ConnectionStrings["lienKetSQl"].ConnectionString;
        }
        public DataSet getAll()
        {
            string query = "SELECT * FROM vwHoaDonNhap";
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            connection.Close();
            return ds;
        }

        public int create(int maNV, string tenNCC)
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();
                    using (SqlCommand command = new SqlCommand("prInsertHoaDonNhap", connect))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@tenNCC", tenNCC);
                        command.Parameters.AddWithValue("@iMaNV", maNV);

                        int result = command.ExecuteNonQuery();
                        connect.Close();
                        if (result > 0)
                        {
                            return 0;
                        }
                        else
                        {
                            return -1;
                        }
                    }// command
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }

        public int delete(int maHD)
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();

                    using (SqlCommand command = new SqlCommand("prDeleteHoaDonNhap", connect))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@iMaHD", maHD);

                        int result = command.ExecuteNonQuery();
                        connect.Close();
                        if (result > 0)
                        {
                            return 0;
                        }
                        else
                        {
                            return -1;
                        }
                    }// command
                }
                }catch(Exception ex)
            {
                return -1;
            }
        }

        public int update(string tenNCC, int maHD)
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(connectionString))
                {
                    connect.Open();

                    using (SqlCommand command = new SqlCommand("prUpdateHoaDonNhap", connect))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@iMaHD", maHD);
                        command.Parameters.AddWithValue("@sNCC", tenNCC);

                        int result = command.ExecuteNonQuery();
                        connect.Close();
                        if (result > 0)
                        {
                            return 0;
                        }
                        else
                        {
                            return -1;
                        }
                    }// command
                }
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
