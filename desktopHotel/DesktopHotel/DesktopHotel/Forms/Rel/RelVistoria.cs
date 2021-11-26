using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopHotel.Forms.Rel
{
    public partial class RelVistoria : Form
    {
        public RelVistoria()
        {
            InitializeComponent();
        }

        private void RelVistoria_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'dataSetVistoria.vistoria'. Você pode movê-la ou removê-la conforme necessário.
            this.vistoriaTableAdapter.Fill(this.dataSetVistoria.vistoria);

            this.reportViewer1.RefreshReport();
        }
    }
}
