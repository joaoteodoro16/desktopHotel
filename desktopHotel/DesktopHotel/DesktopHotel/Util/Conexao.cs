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
            conn.ConnectionString = "Data Source=sql5102.site4now.net;Persist Security Info=True;User ID=db_a7ce35_joaoteodoro16_admin;Password=jgct161001";
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
