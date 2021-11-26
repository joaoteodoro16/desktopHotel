using DesktopHotel.Context;
using DesktopHotel.Util;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopHotel.Model.DAO
{
    class HospedeDao
    {
        BasicContext c = new BasicContext();
        HospedeModel hospedeModel = new HospedeModel();

        public List<HospedeModel> getAll()
        {
            return c.Hospedes.ToList();
        }

        public void Salvar(HospedeModel h)
        {
            c.Hospedes.AddOrUpdate(h);
            c.SaveChanges();
        }

        public HospedeModel hosCod(int codigo)
        {
            return c.Hospedes.Where(h => h.hos_cod == codigo).FirstOrDefault();
        }

        public void Excluir(HospedeModel h)
        {
            h = hosCod(h.hos_cod);
            c.Hospedes.Remove(h);
            c.SaveChanges();
        }
    }
}
