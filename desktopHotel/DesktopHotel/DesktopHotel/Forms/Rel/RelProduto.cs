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
    public partial class RelProduto : Form
    {
        public RelProduto()
        {
            InitializeComponent();
        }

        private void RelProduto_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'dataSetProduto.produtos'. Você pode movê-la ou removê-la conforme necessário.
            this.produtosTableAdapter.Fill(this.dataSetProduto.produtos);

            this.reportViewer1.RefreshReport();
        }
    }
}
