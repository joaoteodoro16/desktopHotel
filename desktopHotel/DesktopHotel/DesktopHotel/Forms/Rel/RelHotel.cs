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
    public partial class RelHotel : Form
    {
        public RelHotel()
        {
            InitializeComponent();
        }

        private void RelHotel_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'dataSetHoteis.hotel'. Você pode movê-la ou removê-la conforme necessário.
            this.hotelTableAdapter.Fill(this.dataSetHoteis.hotel);

            this.reportViewer1.RefreshReport();
        }
    }
}
