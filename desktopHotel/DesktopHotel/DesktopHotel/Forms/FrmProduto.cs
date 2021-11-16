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
    public partial class FrmProduto : Form
    {
        ProdutoDAO produtoDAO = new ProdutoDAO();
        public FrmProduto()
        {
            InitializeComponent();
            pesquisar();
            limpaCampos();
        }

        private void FrmProduto_KeyDown(object sender, KeyEventArgs e)
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
            comboTipo.SelectedItem = null;
            txtDataCadastro.CustomFormat = "";
            txtFornecedor.Text = "";
            txtFabricante.Text = "";
            txtQuantidadeEstoque.Text = "";
            comboUnidade.SelectedItem = null;
            txtPrecoCusto.Text = "";
            txtPrecoVenda.Text = "";
            txtCodigoDeBarras.Text = "";
            txtDataFabricacao.CustomFormat = "";
            txtDataValidade.CustomFormat = "";
            txtDescricao.Text = "";
        }

        private void pesquisar()
        {
            List<ProdutoModel> lista = produtoDAO.getAll();
            gridProduto.DataSource = lista;

            if (lista.Count > 0)
            {
                mostra(lista[0]);
            }
        }

        private ProdutoModel mostra(ProdutoModel p)
        {
            txtCodigo.Text = p.PRO_CODIGO.ToString();
            comboTipo.SelectedItem = p.PRO_TIPO;
            txtDataCadastro.Text = p.PRO_DATA_CADASTRO.ToString();
            txtFornecedor.Text = p.PRO_FORNECEDOR.ToString();
            txtFabricante.Text = p.PRO_FABRICANTE.ToString();
            txtQuantidadeEstoque.Text = p.PRO_QTD_ESTOQUE.ToString();
            comboUnidade.SelectedItem = p.PRO_UNIDADE;
            txtPrecoCusto.Text = p.PRO_PRECO_CUSTO.ToString();
            txtPrecoVenda.Text = p.PRO_PRECO_VENDA.ToString();
            txtCodigoDeBarras.Text = p.PRO_COD_BARRAS.ToString();
            txtDataFabricacao.Text = p.PRO_DATA_FABRICACAO.ToString();
            txtDataValidade.Text = p.PRO_DATA_VALIDADE.ToString();
            txtDescricao.Text = p.PRO_DESCRICAO.ToString();

            return p;
        }

        private ProdutoModel getProdutoGrid()
        {
            return gridProduto.CurrentRow.DataBoundItem as ProdutoModel;
        }

        public ProdutoModel montaObjeto()
        {
            ProdutoModel p = new ProdutoModel();

            p.PRO_TIPO = comboTipo.Text;
            p.PRO_DATA_CADASTRO = txtDataCadastro.Value;
            p.PRO_FORNECEDOR = txtFornecedor.Text;
            p.PRO_FABRICANTE = txtFabricante.Text;
            p.PRO_QTD_ESTOQUE = int.Parse(txtQuantidadeEstoque.Text);
            p.PRO_UNIDADE = comboUnidade.Text;
            p.PRO_PRECO_CUSTO = Double.Parse(txtPrecoCusto.Text);
            p.PRO_PRECO_VENDA = Double.Parse(txtPrecoVenda.Text);
            p.PRO_COD_BARRAS = txtCodigoDeBarras.Text;
            p.PRO_DATA_FABRICACAO = txtDataFabricacao.Value;
            p.PRO_DATA_VALIDADE = txtDataValidade.Value;
            p.PRO_DESCRICAO = txtDescricao.Text;

            return p;
        }

        private bool validar()
        {
            if (comboTipo.Text == string.Empty)
            {
                MessageBox.Show("Selecione um Tipo...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtDataCadastro.Text.Length <= 0)
            {
                txtDataCadastro.Focus();
                txtDataCadastro.Text = string.Empty;
                MessageBox.Show("Digite/Selecione uma data de cadastro...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtFornecedor.Text.Length <= 0)
            {
                txtFornecedor.Focus();
                txtFornecedor.Text = string.Empty;
                MessageBox.Show("Digite um fornecedor...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtFabricante.Text.Length <= 0)
            {
                txtFabricante.Focus();
                txtFabricante.Text = string.Empty;
                MessageBox.Show("Digite um fabricante...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtQuantidadeEstoque.Text.Length <= 0)
            {
                txtQuantidadeEstoque.Focus();
                txtQuantidadeEstoque.Text = string.Empty;
                MessageBox.Show("Digite uma quantidade...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboUnidade.Text == string.Empty)
            {
                MessageBox.Show("Selecione uma unidade...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtPrecoCusto.Text.Length <= 0)
            {
                txtPrecoCusto.Focus();
                txtPrecoCusto.Text = string.Empty;
                MessageBox.Show("Digite um preço de custo...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtPrecoVenda.Text.Length <= 0)
            {
                txtPrecoVenda.Focus();
                txtPrecoVenda.Text = string.Empty;
                MessageBox.Show("Digite um preço de venda...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtCodigoDeBarras.Text.Length <= 0)
            {
                txtCodigoDeBarras.Focus();
                txtCodigoDeBarras.Text = string.Empty;
                MessageBox.Show("Digite um código de barras...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtDataFabricacao.Text.Length <= 0)
            {
                txtDataFabricacao.Focus();
                txtDataFabricacao.Text = string.Empty;
                MessageBox.Show("Selecione/Digite uma data de fabricação...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtDataValidade.Text.Length <= 0)
            {
                txtDataValidade.Focus();
                txtDataValidade.Text = string.Empty;
                MessageBox.Show("Selecione/Digite uma data de validade...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtDescricao.Text.Length <= 0)
            {
                txtDescricao.Focus();
                txtDescricao.Text = string.Empty;
                MessageBox.Show("Digite uma descrição...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ProdutoModel p = montaObjeto();

            produtoDAO.Salvar(p);
            pesquisar();
            mostra(p);
            limpaCampos();
            comboTipo.Focus();
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Excluir Produto?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                produtoDAO.Excluir(getProdutoGrid());
            }
            pesquisar();
            limpaCampos();
            comboTipo.Focus();
        }

        private void gridProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mostra(getProdutoGrid());
            comboTipo.Focus();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limpaCampos();
            comboTipo.Focus();
        }

        private void recarregar_Click(object sender, EventArgs e)
        {
            pesquisar();
            comboTipo.Focus();
        }

        private void FrmProduto_Load(object sender, EventArgs e)
        {
            gridProduto.Columns["PRO_CODIGO"].HeaderText = "Código";
            gridProduto.Columns["PRO_TIPO"].HeaderText = "Tipo";
            gridProduto.Columns["PRO_DESCRICAO"].HeaderText = "Descrição";
            gridProduto.Columns["PRO_DATA_CADASTRO"].HeaderText = "Data Cadastro";
            gridProduto.Columns["PRO_FORNECEDOR"].HeaderText = "Fornecedor";
            gridProduto.Columns["PRO_FABRICANTE"].HeaderText = "Fabricante";
            gridProduto.Columns["PRO_QTD_ESTOQUE"].HeaderText = "Qtd Estoque";
            gridProduto.Columns["PRO_UNIDADE"].HeaderText = "Unidade";
            gridProduto.Columns["PRO_PRECO_CUSTO"].HeaderText = "Preço custo";
            gridProduto.Columns["PRO_PRECO_VENDA"].HeaderText = "Preço venda";
            gridProduto.Columns["PRO_COD_BARRAS"].HeaderText = "Código barras";
            gridProduto.Columns["PRO_DATA_FABRICACAO"].HeaderText = "Data Fabricação";
            gridProduto.Columns["PRO_DATA_VALIDADE"].HeaderText = "Data Validade";
        }
    }
}
