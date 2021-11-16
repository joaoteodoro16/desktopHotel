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
    public partial class frmVistoria : Form
    {
        VistoriaDAO vistoriaDAO = new VistoriaDAO();
        public frmVistoria()
        {
            InitializeComponent();
            pesquisar();
            limpaCampos();
        }

        private void frmVistoria_KeyDown(object sender, KeyEventArgs e)
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
            txtObservacao.Text = "";
            txtFuncionario.Text = "";
            txtDataInicial.Text = "";
            txtCodigoProduto.Text = "";
            txtDescricao.Text = "";
            txtCodigoQuarto.Text = "";
        }

        private void pesquisar()
        {
            List<VistoriaModel> lista = vistoriaDAO.getAll();
            gridVistoria.DataSource = lista;

            if (lista.Count > 0)
            {
                mostra(lista[0]);
            }
        }

        private VistoriaModel mostra(VistoriaModel v)
        {
            txtCodigo.Text = v.VIS_CODIGO.ToString();
            txtObservacao.Text = v.VIS_OBSERVACAO;
            txtFuncionario.Text = v.VIS_FUNCIONARIO.ToString();
            txtDataInicial.Text = v.VIS_DATA_INICIAL.ToString();
            txtCodigoProduto.Text = v.VIS_CODIGO_PRODUTO.ToString();
            txtDescricao.Text = v.VIS_DESCRICAO;
            txtCodigoQuarto.Text = v.VIS_CODIGO_QUARTO.ToString();

            return v;
        }

        private VistoriaModel getVistoriaGrid()
        {
            return gridVistoria.CurrentRow.DataBoundItem as VistoriaModel;
        }

        public VistoriaModel montaObjeto()
        {
            VistoriaModel v = new VistoriaModel();

            v.VIS_OBSERVACAO = txtObservacao.Text;
            v.VIS_FUNCIONARIO = txtFuncionario.Text;
            v.VIS_DATA_INICIAL = txtDataInicial.Value;
            v.VIS_CODIGO_PRODUTO = int.Parse(txtCodigoProduto.Text);
            v.VIS_DESCRICAO = txtDescricao.Text;
            v.VIS_CODIGO_QUARTO = int.Parse(txtCodigoQuarto.Text);

            return v;
        }

        private bool validar()
        {
            if (txtObservacao.Text.Length <= 0)
            {
                txtObservacao.Focus();
                txtObservacao.Text = string.Empty;
                MessageBox.Show("Digite uma observação...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtFuncionario.Text.Length <= 0)
            {
                txtFuncionario.Focus();
                txtFuncionario.Text = string.Empty;
                MessageBox.Show("Digite um Funcionário...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtDataInicial.Text.Length <= 0)
            {
                txtDataInicial.Focus();
                txtDataInicial.Text = string.Empty;
                MessageBox.Show("Digite/Selecione uma Data inicial...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtCodigoProduto.Text.Length <= 0)
            {
                txtCodigoProduto.Focus();
                txtCodigoProduto.Text = string.Empty;
                MessageBox.Show("Digite um código de produto...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtDescricao.Text.Length <= 0)
            {
                txtDescricao.Focus();
                txtDescricao.Text = string.Empty;
                MessageBox.Show("Digite uma descrição...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtCodigoQuarto.Text.Length <= 0)
            {
                txtCodigoQuarto.Focus();
                txtCodigoQuarto.Text = string.Empty;
                MessageBox.Show("Digite um código de quarto...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            VistoriaModel v = montaObjeto();

            vistoriaDAO.Salvar(v);
            pesquisar();
            mostra(v);
            limpaCampos();
            txtObservacao.Focus();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Excluir Vistoria?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                vistoriaDAO.Excluir(getVistoriaGrid());
            }
            pesquisar();
            limpaCampos();
            txtObservacao.Focus();
        }

        private void btnNovo_Click_1(object sender, EventArgs e)
        {
            limpaCampos();
            txtObservacao.Focus();
        }

        private void recarregar_Click_1(object sender, EventArgs e)
        {
            pesquisar();
            txtObservacao.Focus();
        }

        private void gridVistoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mostra(getVistoriaGrid());
            txtObservacao.Focus();
        }

        private void frmVistoria_Load(object sender, EventArgs e)
        {
            gridVistoria.Columns["VIS_CODIGO"].HeaderText = "Código";
            gridVistoria.Columns["VIS_OBSERVACAO"].HeaderText = "Observação";
            gridVistoria.Columns["VIS_FUNCIONARIO"].HeaderText = "Funcionário";
            gridVistoria.Columns["VIS_DATA_INICIAL"].HeaderText = "Data Inicial";
            gridVistoria.Columns["VIS_CODIGO_PRODUTO"].HeaderText = "Código Produto";
            gridVistoria.Columns["VIS_DESCRICAO"].HeaderText = "Descrição";
            gridVistoria.Columns["VIS_CODIGO_QUARTO"].HeaderText = "Código Quarto";
        }
    }
}
