using DesktopHotel.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopHotel.Model.DAO
{
    public class FuncionarioDAO
    {

        BasicContext c = new BasicContext();
        FuncionarioModel funcionarioModel = new FuncionarioModel();

        public List<FuncionarioModel> getAll()
        {
            return c.Funcionario.ToList();
        }

        public void Salvar(FuncionarioModel f)
        {
            c.Funcionario.AddOrUpdate(f);
            c.SaveChanges();
        }

        public FuncionarioModel funCod(int codigo)
        {
            return c.Funcionario.Where(f => f.codigo == codigo).FirstOrDefault();
        }

        public void Excluir(FuncionarioModel f)
        {
            f = funCod(f.codigo);
            c.Funcionario.Remove(f);
            c.SaveChanges();
        }
    }
}
