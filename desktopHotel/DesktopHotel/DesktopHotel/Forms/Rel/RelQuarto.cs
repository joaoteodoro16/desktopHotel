using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopHotel.Forms
{
    public partial class RelQuarto : Form
    {
        public RelQuarto()
        {
            InitializeComponent();
        }

        private void RelQuarto_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'dataSetQuarto.quartos'. Você pode movê-la ou removê-la conforme necessário.
            this.quartosTableAdapter.Fill(this.dataSetQuarto.quartos);

            this.reportViewer1.RefreshReport();
        }
    }
}
