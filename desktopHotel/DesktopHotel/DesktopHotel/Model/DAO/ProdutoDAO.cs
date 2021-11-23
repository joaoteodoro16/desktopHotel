using DesktopHotel.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopHotel.Model.DAO
{
    public class ProdutoDAO
    {
        BasicContext c = new BasicContext();
        ProdutoModel produtoModel = new ProdutoModel();
        
        public List<ProdutoModel> getAll()
        {
            return c.Produto.ToList();
        }

        public void Salvar(ProdutoModel p)
        {
            c.Produto.AddOrUpdate(p);
            c.SaveChanges();
        }

        public ProdutoModel proCod(int codigo)
        {
            return c.Produto.Where(p => p.PRO_CODIGO == codigo).FirstOrDefault();
        }

        public void Excluir(ProdutoModel p)
        {
            p = proCod(p.PRO_CODIGO);
            c.Produto.Remove(p);
            c.SaveChanges();
        }
    }
}
