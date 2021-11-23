using DesktopHotel.Context;
using DesktopHotel.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopHotel.Model.DAO
{
    class HospedeDao
    {
        Conexao conn = new Conexao();
        MySqlCommand comando = new MySqlCommand();

        ExecutaQuery executaQuery = new ExecutaQuery();
      
        public List<HospedeModel> getAll()
        {
            BasicContext con = new BasicContext();
            return con.Hospedes.ToList();
        }


    }
}
