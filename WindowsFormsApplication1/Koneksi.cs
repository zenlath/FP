using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    class Koneksi
    {
        public SqlConnection GetConn()
        {
            SqlConnection Conn = new SqlConnection(@"Data Source=JAEN\SQLEXPRESS;Initial Catalog=DB_Final;Integrated Security=True");
    
            return Conn;
        }
    }
}
