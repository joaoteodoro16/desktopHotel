using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace DesktopHotel.Util
{
    class Conexao
    { 
        MySqlConnection conn = new MySqlConnection();
        public Conexao()
        {
            conn.ConnectionString = "Server=servidorpim.cvhukkdl0e2n.sa-east-1.rds.amazonaws.com;Database=bd_hotelaria;Uid=root;Pwd=root12345;";
        }

        public MySqlConnection conectar()
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
