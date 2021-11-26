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
    public partial class FrmHoteis : Form
    {
        HotelDAO hotelDAO = new HotelDAO();
        public FrmHoteis()
        {
            InitializeComponent();
            pesquisar();
            limpaCampos();
        }

        private void FrmHoteis_KeyDown(object sender, KeyEventArgs e)
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
            txtCodigo.Text = "";
            txtNome.Text = "";
            txtCNPJ.Text = "";
            txtEndereco.Text = "";
            txtCidade.Text = "";
            cmbEstado.SelectedItem = null;
            txtTelefone.Text = "";
        }

        private void pesquisar()
        {
            List<HotelModel> lista = hotelDAO.getAll();
            gridHoteis.DataSource = lista;

            if (lista.Count > 0)
            {
                mostra(lista[0]);
            }
        }

        private HotelModel mostra(HotelModel h)
        {
            txtCodigo.Text = h.HT_CODIGO.ToString();
            txtNome.Text = h.HT_NOME;
            txtCNPJ.Text = h.HT_CNPJ;
            txtEndereco.Text = h.HT_ENDERECO;
            txtCidade.Text = h.HT_CIDADE;
            cmbEstado.SelectedItem = h.HT_ESTADO;
            txtTelefone.Text = h.HT_TELEFONE;

            return h;
        }

        private HotelModel getHotelGrid()
        {
            return gridHoteis.CurrentRow.DataBoundItem as HotelModel;
        }

        public HotelModel montaObjeto()
        {
            HotelModel h = new HotelModel();

            h.HT_NOME = txtNome.Text;
            h.HT_CNPJ = txtCNPJ.Text;
            h.HT_ENDERECO = txtEndereco.Text;
            h.HT_CIDADE = txtCidade.Text;
            h.HT_ESTADO = cmbEstado.Text;
            h.HT_TELEFONE = txtTelefone.Text;

            return h;
        }

        private bool validar()
        {
            if (txtNome.Text.Length <= 0)
            {
                txtNome.Focus();
                txtNome.Text = string.Empty;
                MessageBox.Show("Digite um Nome...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtCNPJ.Text.Length <= 0)
            {
                txtCNPJ.Focus();
                txtCNPJ.Text = string.Empty;
                MessageBox.Show("Digite um CNPJ...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtEndereco.Text.Length <= 0)
            {
                txtEndereco.Focus();
                txtEndereco.Text = string.Empty;
                MessageBox.Show("Digite um Endereço...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtCidade.Text.Length <= 0)
            {
                txtCidade.Focus();
                txtCidade.Text = string.Empty;
                MessageBox.Show("Digite uma Cidade...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbEstado.Text == string.Empty)
            {
                MessageBox.Show("Selecione um Estado...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtTelefone.Text.Length <= 0)
            {
                txtTelefone.Focus();
                txtTelefone.Text = string.Empty;
                MessageBox.Show("Digite um número de telefone...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!validar())
            {
                return;
            }

            String codigo = txtCodigo.Text;
            HotelModel h = montaObjeto();

            hotelDAO.Salvar(h);
            pesquisar();
            mostra(h);
            limpaCampos();
            txtNome.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Excluir Hotel?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                hotelDAO.Excluir(getHotelGrid());
            }
            pesquisar();
            limpaCampos();
            txtNome.Focus();
        }

        private void btnNovo_Click_1(object sender, EventArgs e)
        {
            limpaCampos();
            txtNome.Focus();
        }

        private void gridHoteis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mostra(getHotelGrid());
            txtNome.Focus();
        }

        private void FrmHoteis_Load(object sender, EventArgs e)
        {
            gridHoteis.Columns["HT_CODIGO"].HeaderText = "Código";
            gridHoteis.Columns["HT_NOME"].HeaderText = "Nome";
            gridHoteis.Columns["HT_CNPJ"].HeaderText = "CNPJ";
            gridHoteis.Columns["HT_ENDERECO"].HeaderText = "Endereço";
            gridHoteis.Columns["HT_CIDADE"].HeaderText = "Cidade";
            gridHoteis.Columns["HT_ESTADO"].HeaderText = "Estado";
            gridHoteis.Columns["HT_TELEFONE"].HeaderText = "Telefone";
        }
        
    }
}
