using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyThietBiMayTinh
{
    class DataConnection
    {
        String constr;
        public DataConnection()
        {
            constr = @"Data Source=DESKTOP-G13BOMB\SQLEXPRESS;Initial Catalog=db_QuanLyHangHoa;Integrated Security=True";
        }

        public SqlConnection getConnect()
        {
            return new SqlConnection(constr);
        }
    }
}
