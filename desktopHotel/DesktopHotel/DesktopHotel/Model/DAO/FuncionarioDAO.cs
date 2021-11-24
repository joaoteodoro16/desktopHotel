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
            return c.Funcionario.Where(f => f.FUN_CODIGO == codigo).FirstOrDefault();
        }

        public void Excluir(FuncionarioModel f)
        {
            f = funCod(f.FUN_CODIGO);
            c.Funcionario.Remove(f);
            c.SaveChanges();
        }


        public FuncionarioModel buscaPorCpf(string cpf)
        {
            return c.Funcionario.Where(f => f.FUN_CPF == cpf).FirstOrDefault();
        }



    }
}
