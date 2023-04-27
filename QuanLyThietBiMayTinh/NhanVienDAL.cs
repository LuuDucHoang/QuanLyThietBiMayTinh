using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThietBiMayTinh
{
    class NhanVienDAL
    {
        DataConnection connect;
        SqlDataAdapter da;
        SqlCommand cmd;

        public NhanVienDAL()
        {
            connect = new DataConnection();
        }

        public DataTable getAllNhanVien()
        {
            string sql = "select*from tblNhanVien";
            SqlConnection con = connect.getConnect();
            da = new SqlDataAdapter(sql, con);
            con.Open();
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public bool insertNhanVien(tblNhanVien nv)
        {
            string sql = "insert into tblNhanVien(sTen,sSDT, sDiachi, fPhucap, fLuong, dNgaysinh) values(@sTen,@sSDT,@sDiachi,@fPhucap,@fLuong,@dNgaysinh)";
            SqlConnection con = connect.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@sTen", SqlDbType.NVarChar).Value = nv.sTen;
                cmd.Parameters.Add("@sSDT", SqlDbType.VarChar).Value = nv.sSDT;
                cmd.Parameters.Add("@sDiachi", SqlDbType.NVarChar).Value = nv.sDiaChi;
                cmd.Parameters.Add("@fPhucap", SqlDbType.Float).Value = nv.fPhucap;
                cmd.Parameters.Add("@fLuong", SqlDbType.Float).Value = nv.fLuong;
                cmd.Parameters.Add("@dNgaysinh", SqlDbType.Date).Value = nv.dNgaysinh;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool updateNhanVien(tblNhanVien nv)
        {
            string sql = "update tblNhanVien set sTen=@sTen,sSDT=@sSDT,sDiachi=@sDiachi,fPhucap=@fPhucap,fLuong=@fLuong,dNgaysinh=@dNgaysinh where iMaNV=@iMaNV";
            SqlConnection con = connect.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@iMaNV", SqlDbType.Int).Value = nv.iMaNV;
                cmd.Parameters.Add("@sTen", SqlDbType.NVarChar).Value = nv.sTen;
                cmd.Parameters.Add("@sSDT", SqlDbType.VarChar).Value = nv.sSDT;
                cmd.Parameters.Add("@sDiachi", SqlDbType.NVarChar).Value = nv.sDiaChi;
                cmd.Parameters.Add("@fPhucap", SqlDbType.Float).Value = nv.fPhucap;
                cmd.Parameters.Add("@fLuong", SqlDbType.Float).Value = nv.fLuong;
                cmd.Parameters.Add("@dNgaysinh", SqlDbType.DateTime).Value = nv.dNgaysinh;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public bool deleteNhanVien(tblNhanVien nv)
        {
            string sql = "delete tblNhanVien where iMaNV=@iMaNV";
            SqlConnection con = connect.getConnect();
            try
            {
                cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.Parameters.Add("@iMaNV", SqlDbType.Int).Value = nv.iMaNV;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
