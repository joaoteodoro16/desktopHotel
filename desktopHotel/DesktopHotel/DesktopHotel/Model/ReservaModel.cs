using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopHotel.Model
{
    [Table("reservas")]
    public class ReservaModel
    {
        [Key()]
        public int codigo { get; set; }
        public String nomeHospede { get; set; }

        public QuartoModel Quarto { get; set; }

        public String andar { get; set; }

        public String tipoQuarto { get; set; }

        public String diaria { get; set; }

        public DateTime dataCheckIn { get; set; }

        public DateTime dataCheckOut { get; set; }

        public int qtdDias { get; set; }

        public double pagamento { get; set; }

        public String total { get; set; }

        public String voucher { get; set; }

        public String parceladoEm { get; set; }
    }
}
