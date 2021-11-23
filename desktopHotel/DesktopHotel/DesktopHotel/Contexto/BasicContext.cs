using DesktopHotel.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopHotel.Context
{
     class BasicContext: DbContext
    {
        //Passa a conexão
        public BasicContext():base("Server=servidorpim.cvhukkdl0e2n.sa-east-1.rds.amazonaws.com;Database=bd_hotelaria;Uid=root;Pwd=root12345;")
        {
        }

        public DbSet<HospedeModel> Hospedes { get; set; }
        public DbSet<HoteisModel> Hotel { get; set; }
        public DbSet<ProdutoModel> Produto { get; set; }
        public DbSet<ReservaModel> Reserva { get; set; }
        public DbSet<VistoriaModel> Vistoria { get; set; }
        public DbSet<FuncionarioModel> Funcionario { get; set; }

    }
}
