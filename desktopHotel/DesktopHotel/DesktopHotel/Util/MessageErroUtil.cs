using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopHotel.Util
{
    class MessageErroUtil
    {

        public static void mensagemErro(String texto, bool finalizaProcesso)
        {

            MessageBox.Show(texto, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);

            if (finalizaProcesso)
            {
                return;
            }

        }


    }
}
