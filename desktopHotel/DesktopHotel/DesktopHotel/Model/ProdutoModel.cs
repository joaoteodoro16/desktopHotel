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
        public int codigo { get; set; }

        public String tipo { get; set; }

        public String descricao { get; set; }

        public DateTime dataCadastro { get; set; }

        public String fornecedor { get; set; }

        public String fabricante { get; set; }

        public int qtdEstoque { get; set; }

        public String unidade { get; set; }

        public double precoCusto { get; set; }

        public double precoVenda { get; set; }

        public String codBarras { get; set; }

        public DateTime dataFabricacao { get; set; }

        public DateTime dataValidade { get; set; }
    }
}
