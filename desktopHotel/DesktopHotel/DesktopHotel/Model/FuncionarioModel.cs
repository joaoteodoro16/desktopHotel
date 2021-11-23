using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopHotel.Model
{
    [Table("funcionarios")]
    public class FuncionarioModel
    {
        [Key()]
        public int FUN_CODIGO { get; set; }

        public String FUN_NOME { get; set; }

        public String FUN_CPF { get; set; }

        public String FUN_RG { get; set; }

        public String FUN_ENDERECO { get; set; }

        public String FUN_BAIRRO { get; set; }

        public String FUN_CIDADE { get; set; }

        public String FUN_ESTADO { get; set; }
    
        public String FUN_CEP { get; set; }

        public String FUN_CELULAR_TELEFONE { get; set; }

        public String FUN_BANCO { get; set; }

        public String FUN_AGENCIA { get; set; }

        public String FUN_PIS { get; set; }

        public String FUN_ESTADO_CIVIL { get; set; }

        public int FUN_QTD_FILHOS { get; set; }

        public DateTime FUN_ADMISSAO { get; set; }

        public String FUN_CARGO { get; set; }

        public double FUN_SALARIO { get; set; }

        public String FUN_SITUACAO { get; set; }
    }
}
