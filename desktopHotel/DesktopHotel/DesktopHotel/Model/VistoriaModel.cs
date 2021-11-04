using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopHotel.Model
{
    [Table("vistoria")]
    public class VistoriaModel
    {
        [Key()]
        public int codigo { get; set; }

        public String observacao { get; set; }

        public String funcionario { get; set; }

        public DateTime dataInicial { get; set; }

        public int codigoProduto { get; set; }

        public String descricao { get; set; }

        public int codigoQuarto { get; set; }
    }
}
