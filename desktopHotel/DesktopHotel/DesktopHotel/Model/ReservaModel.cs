using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopHotel.Model
{/// <summary>
/// 
/// </summary>
    [Table("reservas")]
    public class ReservaModel
    {
        [Key()]
        public int RES_CODIGO { get; set; }
        public String RES_NOME_HOSPEDE { get; set; }

        public String RES_QUARTO { get; set; }

        public String RES_ANDAR { get; set; }

        public String RES_TIPO_QUARTO { get; set; }

        public Double RES_DIARIA { get; set; }

        public int RES_QTD_DIAS { get; set; }

        public double RES_PAGAMENTO { get; set; }

        public double RES_TOTAL { get; set; }

        public String RES_VOUCHER { get; set; }

        public int RES_PARCELADO { get; set; }

    }
}
