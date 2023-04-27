using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThietBiMayTinh
{
    class NhanVienAdapter
    {
        string connectionString; 
        public NhanVienAdapter()
        {
            connectionString = ConfigurationManager.ConnectionStrings["lienKetSQl"].ConnectionString;
        }
        public List<NhanVienDTO> getAll()
        {
            List<NhanVienDTO> nhanViens = new List<NhanVienDTO>();
            string connectionString = ConfigurationManager.ConnectionStrings["lienKetSQl"].ConnectionString;
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                Cnn.Open();
                string query = "SELECT * FROM tblNhanVien";
                using (SqlCommand Cmd = new SqlCommand(query, Cnn))
                {
                    var reader = Cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        nhanViens.Add(new NhanVienDTO((int)reader["iMaNV"],(string)reader["sTen"],(string)reader["sSDT"]));
                    }
                    Cnn.Close();
                }
            }
            return nhanViens; 
        }

        public DataTable findAllNV()
        {
            using (SqlConnection Cnn = new SqlConnection(connectionString))
            {
                Cnn.Open();
                string query = "SELECT * FROM tblNhanVien";
                using (SqlCommand Cmd = new SqlCommand(query, Cnn))
                {
                   // Cmd.CommandType = CommandType.StoredProcedure;
                    using (SqlDataAdapter Da = new SqlDataAdapter(Cmd))
                    {
                        DataTable tbl = new DataTable("tblNhanVien");
                        Da.Fill(tbl);
                        Cnn.Close();
                        return tbl;
                    }
                }
            }
        }

        public void create()
        {

        }

        public void search()
        {

        }
        
    }
}
