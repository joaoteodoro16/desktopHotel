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
    public class HoteisModel
    {
        [Key()]
        public int codigo { get; set; }

        public String nome { get; set; }

        public String cnpj { get; set; }

        public String endereco { get; set; }

        public String cidade { get; set; }

        public String estado { get; set; }

        public String telefone { get; set; }
    }
}
