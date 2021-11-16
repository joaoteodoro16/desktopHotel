using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopHotel.Model
{
    [Table("produtos")]
    public class ProdutoModel
    {
        [Key()]
        public int PRO_CODIGO { get; set; }

        public String PRO_TIPO { get; set; }

        public String PRO_DESCRICAO { get; set; }

        public DateTime PRO_DATA_CADASTRO { get; set; }

        public String PRO_FORNECEDOR { get; set; }

        public String PRO_FABRICANTE { get; set; }

        public int PRO_QTD_ESTOQUE { get; set; }

        public String PRO_UNIDADE { get; set; }

        public double PRO_PRECO_CUSTO { get; set; }

        public double PRO_PRECO_VENDA { get; set; }

        public String PRO_COD_BARRAS { get; set; }

        public DateTime PRO_DATA_FABRICACAO { get; set; }

        public DateTime PRO_DATA_VALIDADE { get; set; }
    }
}
