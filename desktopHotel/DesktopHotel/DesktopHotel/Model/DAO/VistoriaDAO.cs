using DesktopHotel.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopHotel.Model.DAO
{
    public class VistoriaDAO
    {

        BasicContext c = new BasicContext();
        VistoriaModel vistoriaModel = new VistoriaModel();

        public List<VistoriaModel> getAll()
        {
            return c.Vistoria.ToList();
        }

        public void Salvar(VistoriaModel v)
        {
            c.Vistoria.AddOrUpdate(v);
            c.SaveChanges();
        }

        public VistoriaModel visCod(int codigo)
        {
            return c.Vistoria.Where(v => v.codigo == codigo).FirstOrDefault();
        }

        public void Excluir(VistoriaModel v)
        {
            v = visCod(v.codigo);
            c.Vistoria.Remove(v);
            c.SaveChanges();
        }
    }
}
