using DesktopHotel.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopHotel.Model.DAO
{
    public class ReservaDAO
    {
        BasicContext c = new BasicContext();
        ReservaModel reservaModel = new ReservaModel();

        public List<ReservaModel> getAll()
        {
            return c.Reserva.ToList();
        }

        public void Salvar(ReservaModel r)
        {
            c.Reserva.AddOrUpdate(r);
            c.SaveChanges();
        }

        public ReservaModel reservaCod(int codigo)
        {
            return c.Reserva.Where(r => r.RES_CODIGO == codigo).FirstOrDefault();
        }

        public void Excluir(ReservaModel r)
        {
            r = reservaCod(r.RES_CODIGO);
            c.Reserva.Remove(r);
            c.SaveChanges();
        }
    }
}
