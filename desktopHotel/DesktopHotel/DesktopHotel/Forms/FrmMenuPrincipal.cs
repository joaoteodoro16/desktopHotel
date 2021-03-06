using DesktopHotel.Forms.Rel;
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
    public partial class FrmMenuPrincipal : Form
    {

        public static String nomeOperador { get; set; }
        public static String cargoOperador { get; set; }

        public FrmMenuPrincipal()
        {
            InitializeComponent();
            
     
        }

        private void FrmMenuPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27)) //ESC
            {
                DialogResult result = MessageBox.Show("Sair do sistema", "Deseja realmente sair do sistema?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if(result == DialogResult.Yes)
                {
                    Application.Exit();
                }
                
            }
        }

        private void quartosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmQuartos frmQuartos = new FrmQuartos();
            frmQuartos.ShowDialog(); // ShowDialog faz com que o frm seja um modal, ou seja, não cons
        }

        private void hóspedesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmHospedes frmHospedes = new FrmHospedes();
            frmHospedes.ShowDialog(); 
        }

        private void funcionáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFuncionario frmFuncionario = new FrmFuncionario();
            frmFuncionario.ShowDialog(); 
        }

        private void hotéisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHoteis frmHoteis = new FrmHoteis();
            frmHoteis.ShowDialog();
        }

        private void produtosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmProduto frmProduto = new FrmProduto();
            frmProduto.ShowDialog();
        }

        private void quartosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmQuartos frmQuartos = new FrmQuartos();
            frmQuartos.ShowDialog();
        }

        private void reservasToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmReservas frmReservas = new FrmReservas();
            frmReservas.ShowDialog();
        }

        private void vistoriaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVistoria frmVistoria = new frmVistoria();
            frmVistoria.ShowDialog();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            FrmReservas frmReservas = new FrmReservas();
            frmReservas.ShowDialog();
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {
            txtNomeFunc.Text = nomeOperador;
            lblCargo.Text = cargoOperador;
        }

        private void quartoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelQuarto relQuarto = new RelQuarto();
            relQuarto.ShowDialog();
        }

        private void hóspedesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelHospede relHospede = new RelHospede();
            relHospede.ShowDialog();
        }

        private void funcionáriosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RelFuncionario relFuncionario = new RelFuncionario();
            relFuncionario.ShowDialog();
        }

        private void hotéisToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RelHotel relHotel = new RelHotel();
            relHotel.ShowDialog();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelProduto relProduto = new RelProduto();
            relProduto.ShowDialog();
        }

        private void reservasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelReserva relReserva = new RelReserva();
            relReserva.ShowDialog();
        }

        private void vistoriaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RelVistoria relVistoria = new RelVistoria();
            relVistoria.ShowDialog();
        }
    }
}
