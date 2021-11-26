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
    public partial class RelHospede : Form
    {
        public RelHospede()
        {
            InitializeComponent();
        }

        private void RelHospede_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'dataSetHospede.hospedes'. Você pode movê-la ou removê-la conforme necessário.
            this.hospedesTableAdapter.Fill(this.dataSetHospede.hospedes);

            this.reportViewer1.RefreshReport();
        }
    }
}
