using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopHotel.Model
{
    [Table("hoteis")]
    public class HotelModel
    {
        [Key()]
        public int HT_CODIGO { get; set; }

        public String HT_NOME { get; set; }

        public String HT_CNPJ { get; set; }

        public String HT_ENDERECO { get; set; }

        public String HT_CIDADE { get; set; }

        public String HT_ESTADO { get; set; }

        public String HT_TELEFONE { get; set; }
    }
}
