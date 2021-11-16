using DesktopHotel.Model;
using DesktopHotel.Model.DAO;
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
    public partial class FrmReservas : Form
    {
        ReservaDAO reservaDAO = new ReservaDAO();
        public FrmReservas()
        {
            InitializeComponent();
            pesquisar();
            limpaCampos();
        }

        private void FrmReservas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27)) // ESC
            {
                DialogResult = MessageBox.Show("Voltar para o menu principal? " + "\n\nSim = Voltar | Não = Fechar Formulário", this.Text, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (DialogResult == DialogResult.Yes)
                {
                    FrmMenuPrincipal menuPrincipal = new FrmMenuPrincipal();
                    this.Hide();

                    Form f = menuPrincipal;
                    f.Closed += (s, args) => this.Close();
                    f.Show();
                }
                else if (DialogResult == DialogResult.No)
                {
                    Application.Exit();
                }
            }
        }

        public void limpaCampos()
        {
            txtNomeHospede.Text = "";
            txtQuarto.Text = "";
            txtAndar.Text = "";
            txtTipoQuarto.Text = "";
            txtDiaria.Text = "";
            comboPagamento.SelectedItem = null;
            txtTotal.Text = "";
            txtVoucher.Text = "";
            txtParcelado.Text = "";
        }

        private void pesquisar()
        {
            List<ReservaModel> lista = reservaDAO.getAll();
            gridReservas.DataSource = lista;

            if (lista.Count > 0)
            {
                mostra(lista[0]);
            }
        }

        private ReservaModel mostra(ReservaModel r)
        {
            txtCodigo.Text = r.RES_CODIGO.ToString();
            txtNomeHospede.Text = r.RES_NOME_HOSPEDE;
            txtQuarto.Text = r.RES_QUARTO.ToString();
            txtAndar.Text = r.RES_ANDAR.ToString();
            txtTipoQuarto.Text = r.RES_TIPO_QUARTO.ToString();
            txtDiaria.Text = r.RES_DIARIA.ToString();
            txtQtd.Text = r.RES_QTD_DIAS.ToString();
            comboPagamento.Text = r.RES_PAGAMENTO.ToString();
            txtTotal.Text = r.RES_TOTAL.ToString();
            txtVoucher.Text = r.RES_VOUCHER.ToString();
            txtParcelado.Text = r.RES_PARCELADO.ToString();

            return r;
        }

        private ReservaModel getReservaGrid()
        {
            return gridReservas.CurrentRow.DataBoundItem as ReservaModel;
        }

        public ReservaModel montaObjeto()
        {
            ReservaModel r = new ReservaModel();

            r.RES_NOME_HOSPEDE = txtNomeHospede.Text;
            r.RES_QUARTO = txtQuarto.Text;
            r.RES_ANDAR = txtAndar.Text;
            r.RES_TIPO_QUARTO = txtTipoQuarto.Text;
            r.RES_DIARIA = Double.Parse(txtDiaria.Text);
            r.RES_QTD_DIAS = int.Parse(txtQtd.Text);
            r.RES_PAGAMENTO = Double.Parse(comboPagamento.Text);
            r.RES_TOTAL = Double.Parse(txtTotal.Text);
            r.RES_VOUCHER = txtVoucher.Text;
            r.RES_PARCELADO = int.Parse(txtParcelado.Text);

            return r;
        }

        private bool validar()
        {
            if (txtNomeHospede.Text.Length <= 0)
            {
                txtNomeHospede.Focus();
                txtNomeHospede.Text = string.Empty;
                MessageBox.Show("Digite um nome...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtQuarto.Text.Length <= 0)
            {
                txtQuarto.Focus();
                txtQuarto.Text = string.Empty;
                MessageBox.Show("Digite um quarto...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtAndar.Text.Length <= 0)
            {
                txtAndar.Focus();
                txtAndar.Text = string.Empty;
                MessageBox.Show("Digite um andar...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtTipoQuarto.Text.Length <= 0)
            {
                txtTipoQuarto.Focus();
                txtTipoQuarto.Text = string.Empty;
                MessageBox.Show("Digite um tipo de quarto...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtDiaria.Text.Length <= 0)
            {
                txtDiaria.Focus();
                txtDiaria.Text = string.Empty;
                MessageBox.Show("Digite uma diária...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtQtd.Text.Length <= 0)
            {
                txtQtd.Focus();
                txtQtd.Text = string.Empty;
                MessageBox.Show("Digite uma quantidade...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboPagamento.Text == string.Empty)
            {
                MessageBox.Show("Selecione um método de pagamento...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtTotal.Text.Length <= 0)
            {
                txtTotal.Focus();
                txtTotal.Text = string.Empty;
                MessageBox.Show("Digite um total...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtVoucher.Text.Length <= 0)
            {
                txtVoucher.Focus();
                txtVoucher.Text = string.Empty;
                MessageBox.Show("Digite um voucher...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtParcelado.Text.Length <= 0)
            {
                txtParcelado.Focus();
                txtParcelado.Text = string.Empty;
                MessageBox.Show("Digite a quantidade na qual será parcelado...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            if (!validar())
            {
                return;
            }

            String codigo = txtCodigo.Text;
            ReservaModel r = montaObjeto();

            reservaDAO.Salvar(r);
            pesquisar();
            mostra(r);
            limpaCampos();
            txtNomeHospede.Focus();
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Excluir Reserva?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                reservaDAO.Excluir(getReservaGrid());
            }
            pesquisar();
            limpaCampos();
            txtNomeHospede.Focus();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limpaCampos();
            txtNomeHospede.Focus();
        }

        private void recarregar_Click(object sender, EventArgs e)
        {
            pesquisar();
            txtNomeHospede.Focus();
        }

        private void gridReservas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mostra(getReservaGrid());
            txtNomeHospede.Focus();
        }

        private void FrmReservas_Load(object sender, EventArgs e)
        {
            gridReservas.Columns["RES_CODIGO"].HeaderText = "Código";
            gridReservas.Columns["RES_NOME_HOSPEDE"].HeaderText = "Hóspede";
            gridReservas.Columns["RES_QUARTO"].HeaderText = "Quarto";
            gridReservas.Columns["RES_ANDAR"].HeaderText = "Andar";
            gridReservas.Columns["RES_TIPO_QUARTO"].HeaderText = "Tipo Quarto";
            gridReservas.Columns["RES_DIARIA"].HeaderText = "Diária";
            gridReservas.Columns["RES_QTD_DIAS"].HeaderText = "Qtd Dias";
            gridReservas.Columns["RES_PAGAMENTO"].HeaderText = "Pagamento";
            gridReservas.Columns["RES_TOTAL"].HeaderText = "Total";
            gridReservas.Columns["RES_VOUCHER"].HeaderText = "Voucher";
            gridReservas.Columns["RES_PARCELADO"].HeaderText = "Parcelado em";
        }
    }
}
