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
    [Table("vistoria")]
    public class VistoriaModel
    {
        [Key()]
        public int VIS_CODIGO { get; set; }

        public String VIS_OBSERVACAO { get; set; }

        public String VIS_FUNCIONARIO { get; set; }

        public DateTime VIS_DATA_INICIAL { get; set; }

        public int VIS_CODIGO_PRODUTO { get; set; }

        public String VIS_DESCRICAO { get; set; }

        public int VIS_CODIGO_QUARTO { get; set; }
    }
}
