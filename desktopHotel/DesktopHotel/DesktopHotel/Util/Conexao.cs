using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DesktopHotel.Util
{
    class Conexao
    { 
        SqlConnection conn = new SqlConnection();
        public Conexao()
        {
            conn.ConnectionString = "Data Source=SQL5108.site4now.net;Initial Catalog=db_a79e17_bdhotel;User ID=db_a79e17_bdhotel_admin;Password=admin12345678;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }

        public SqlConnection conectar()
        {
            if(conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }

            return conn;
        }

        public void desconectar()
        {
            if(conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
