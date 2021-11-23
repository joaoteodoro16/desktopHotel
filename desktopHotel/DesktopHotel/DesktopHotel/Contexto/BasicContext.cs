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
        public BasicContext():base("Data Source=sql5102.site4now.net;Persist Security Info=True;User ID=db_a7ce35_joaoteodoro16_admin;Password=jgct161001")
        {
        }

        public DbSet<HospedeModel> Hospedes { get; set; }
        public DbSet<HotelModel> Hotel { get; set; }
        public DbSet<ProdutoModel> Produto { get; set; }
        public DbSet<ReservaModel> Reserva { get; set; }
        public DbSet<VistoriaModel> Vistoria { get; set; }
        public DbSet<FuncionarioModel> Funcionario { get; set; }

    }
}
