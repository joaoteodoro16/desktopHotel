using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopHotel.Model
{
    [Table("quartos")]
    public class QuartoModel
    {
        [Key()]
        public int QT_NUMERO { get; set; }
        public String QT_ANDAR { get; set; }
        public Double QT_VALOR { get; set; }
        public String QT_TIPO { get; set; }
        public String QT_DESC { get; set; }
    }
}
