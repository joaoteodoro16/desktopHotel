using DesktopHotel.Context;
using DesktopHotel.Util;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopHotel.Model.DAO
{
    class HospedeDao
    {
        Conexao conn = new Conexao();
        SqlCommand comando = new SqlCommand();
        ExecutaQuery executaQuery = new ExecutaQuery();
        String query = "";



        public List<HospedeModel> getAll()
        {
            BasicContext con = new BasicContext();
            return con.Hospedes.ToList();
        }


    }
}
