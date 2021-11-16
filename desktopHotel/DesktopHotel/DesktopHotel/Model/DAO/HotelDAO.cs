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
        HotelModel hoteisModel = new HotelModel();

        public List<HotelModel> getAll()
        {
            return c.Hotel.ToList();
        }

        public void Salvar(HotelModel h)
        {
            c.Hotel.AddOrUpdate(h);
            c.SaveChanges();
        }

        public HotelModel hotelCod(int codigo)
        {
            return c.Hotel.Where(h => h.HT_CODIGO == codigo).FirstOrDefault();
        }

        public void Excluir(HotelModel h)
        {
            h = hotelCod(h.HT_CODIGO);
            c.Hotel.Remove(h);
            c.SaveChanges();
        }

    }
}
