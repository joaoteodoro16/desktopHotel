using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopHotel.Model
{
    [Table("hospedes")]
    class HospedeModel
    {
        [Key()]
        public int hos_cod { get; set; }
        public String hos_nome { get; set; }
        public String hos_cpf { get; set; }
        public String hos_rg { get; set; }
        public String hos_email { get; set; }
        public String hos_celular { get; set; }
        public DateTime hos_data_nasc { get; set; }
        public String hos_sexo { get; set; }
        public String hos_endereco { get; set; }
        public String hos_cidade { get; set; }
        public String hos_bairro { get; set; }
        public String hos_estado { get; set; }
        public String hos_voucher { get; set; }
        public String hos_usuario { get; set; }
        public String hos_senha { get; set; }
    }
}
