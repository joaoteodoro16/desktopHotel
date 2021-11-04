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
        public BasicContext():base("Data Source=SQL5108.site4now.net;Initial Catalog=db_a79e17_bdhotel;User ID=db_a79e17_bdhotel_admin;Password=admin12345678;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {
        }

        public DbSet<HospedeModel> Hospedes { get; set; }
        public DbSet<HoteisModel> Hotel { get; set; }
        public DbSet<ProdutoModel> Produto { get; set; }
        public DbSet<ReservaModel> Reserva { get; set; }
        public DbSet<VistoriaModel> Vistoria { get; set; }

    }
}
