using DesktopHotel.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopHotel.Model.DAO
{
    public class HotelDAO
    {
        BasicContext c = new BasicContext();
        HoteisModel hoteisModel = new HoteisModel();

        public List<HoteisModel> getAll()
        {
            return c.Hotel.ToList();
        }

        public void Salvar(HoteisModel h)
        {
            c.Hotel.AddOrUpdate(h);
            c.SaveChanges();
        }

        public HoteisModel hotelCod(int codigo)
        {
            return c.Hotel.Where(h => h.codigo == codigo).FirstOrDefault();
        }

        public void Excluir(HoteisModel h)
        {
            h = hotelCod(h.codigo);
            c.Hotel.Remove(h);
            c.SaveChanges();
        }

    }
}
