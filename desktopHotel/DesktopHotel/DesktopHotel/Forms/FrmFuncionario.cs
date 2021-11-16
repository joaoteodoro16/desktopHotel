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
    public partial class FrmFuncionario : Form
    {
        FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
        public FrmFuncionario()
        {
            InitializeComponent();
            pesquisar();
            limpaCampos();
        }

        private void FrmFuncionario_KeyDown(object sender, KeyEventArgs e)
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
            txtCPF.Text = "";
            txtRG.Text = "";
            txtEndereco.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            comboEstado.SelectedItem = null;
            txtCEP.Text = "";
            txtCelular.Text = "";
            txtBanco.Text = "";
            txtAgencia.Text = "";
            txtPIS.Text = "";
            comboEstadoCivil.SelectedItem = null;
            txtQtdFilhos.Text = "";
            txtDataAdmissao.CustomFormat = "";
            txtCargo.Text = "";
            txtSalario.Text = "";
            radioEfetivo.Checked = false;
            radioDesligado.Checked = false;
        }

        private void pesquisar()
        {
            List<FuncionarioModel> lista = funcionarioDAO.getAll();
            gridFuncionario.DataSource = lista;

            if (lista.Count > 0)
            {
                mostra(lista[0]);
            }
        }

        private FuncionarioModel mostra(FuncionarioModel f)
        {
            txtCodigo.Text = f.FUN_CODIGO.ToString();
            txtNome.Text = f.FUN_NOME.ToString();
            txtCPF.Text = f.FUN_CPF.ToString();
            txtRG.Text = f.FUN_RG.ToString();
            txtEndereco.Text = f.FUN_ENDERECO.ToString();
            txtBairro.Text = f.FUN_BAIRRO.ToString();
            txtCidade.Text = f.FUN_CIDADE.ToString();
            comboEstado.SelectedItem = f.FUN_ESTADO;
            txtCEP.Text = f.FUN_CEP.ToString();
            txtCelular.Text = f.FUN_CELULAR_TELEFONE.ToString();
            txtBanco.Text = f.FUN_BANCO.ToString();
            txtAgencia.Text = f.FUN_AGENCIA.ToString();
            txtPIS.Text = f.FUN_PIS.ToString();
            comboEstadoCivil.Text = f.FUN_ESTADO_CIVIL;
            txtQtdFilhos.Text = f.FUN_QTD_FILHOS.ToString();
            txtDataAdmissao.Text = f.FUN_ADMISSAO.ToString();
            txtCargo.Text = f.FUN_CARGO.ToString();
            txtSalario.Text = f.FUN_SALARIO.ToString();

            if (radioEfetivo.Checked == true)
            {
                f.FUN_SITUACAO = "Efetivo";
            }
            else if (radioDesligado.Checked == true)
            {
                f.FUN_SITUACAO = "Desligado";
            }

            return f;
        }

        private FuncionarioModel getFuncionarioGrid()
        {
            return gridFuncionario.CurrentRow.DataBoundItem as FuncionarioModel;
        }

        public FuncionarioModel montaObjeto()
        {
            FuncionarioModel f = new FuncionarioModel();

            f.FUN_NOME = txtNome.Text;
            f.FUN_CPF = txtCPF.Text;
            f.FUN_RG = txtRG.Text;
            f.FUN_ENDERECO = txtEndereco.Text;
            f.FUN_BAIRRO = txtBairro.Text;
            f.FUN_CIDADE = txtCidade.Text;
            f.FUN_ESTADO = comboEstado.Text;
            f.FUN_CEP = txtCEP.Text;
            f.FUN_CELULAR_TELEFONE = txtCelular.Text;
            f.FUN_BANCO = txtBanco.Text;
            f.FUN_AGENCIA = txtAgencia.Text;
            f.FUN_PIS = txtPIS.Text;
            f.FUN_ESTADO_CIVIL = comboEstadoCivil.Text;
            f.FUN_QTD_FILHOS = int.Parse(txtQtdFilhos.Text);
            f.FUN_ADMISSAO = txtDataAdmissao.Value;
            f.FUN_CARGO = txtCargo.Text;
            f.FUN_SALARIO = Double.Parse(txtSalario.Text);

            return f;
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

            if (txtCPF.Text.Length <= 0)
            {
                txtCPF.Focus();
                txtCPF.Text = string.Empty;
                MessageBox.Show("Digite um CPF...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtRG.Text.Length <= 0)
            {
                txtRG.Focus();
                txtRG.Text = string.Empty;
                MessageBox.Show("Digite um RG...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtEndereco.Text.Length <= 0)
            {
                txtEndereco.Focus();
                txtEndereco.Text = string.Empty;
                MessageBox.Show("Digite um Endereço...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtBairro.Text.Length <= 0)
            {
                txtBairro.Focus();
                txtBairro.Text = string.Empty;
                MessageBox.Show("Digite um Bairro...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtCidade.Text.Length <= 0)
            {
                txtCidade.Focus();
                txtCidade.Text = string.Empty;
                MessageBox.Show("Digite uma cidade...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboEstado.Text == string.Empty)
            {
                MessageBox.Show("Selecione um Estado...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtCEP.Text.Length <= 0) // Como validar CEP? kkkkk
            {
                txtCEP.Focus();
                txtCEP.Text = string.Empty;
                MessageBox.Show("Digite um CEP...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtCelular.Text.Length <= 0) // Como validar CEP? kkkkk
            {
                txtCelular.Focus();
                txtCelular.Text = string.Empty;
                MessageBox.Show("Digite um número de celular/telefone...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtBanco.Text.Length <= 0) // Como validar CEP? kkkkk
            {
                txtBanco.Focus();
                txtBanco.Text = string.Empty;
                MessageBox.Show("Digite um banco...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtAgencia.Text.Length <= 0) // Como validar CEP? kkkkk
            {
                txtAgencia.Focus();
                txtAgencia.Text = string.Empty;
                MessageBox.Show("Digite uma Agência...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtPIS.Text.Length <= 0) // Como validar CEP? kkkkk
            {
                txtPIS.Focus();
                txtPIS.Text = string.Empty;
                MessageBox.Show("Digite um PIS...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (comboEstadoCivil.Text == string.Empty)
            {
                MessageBox.Show("Selecione um Estado Civil!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtQtdFilhos.Text.Length <= 0) 
            {
                txtQtdFilhos.Focus();
                txtQtdFilhos.Text = string.Empty;
                MessageBox.Show("Digite uma quantidade de filhos...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtDataAdmissao.Value == null) 
            {
                txtDataAdmissao.Focus();
                MessageBox.Show("Digite/Selecione a data de Admissão...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtCargo.Text.Length <= 0) 
            {
                txtCargo.Focus();
                txtCargo.Text = string.Empty;
                MessageBox.Show("Digite um cargo...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                Double.Parse(txtSalario.Text);
            }
            catch (Exception)
            {
                txtSalario.Focus();
                txtSalario.Text = string.Empty;
                MessageBox.Show("Digite um Salário...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (radioEfetivo.Checked == false && radioDesligado.Checked == false)
            {
                radioEfetivo.Focus();
                MessageBox.Show("Selecione qual é a situação atual do funcionário...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            FuncionarioModel f = montaObjeto();

            funcionarioDAO.Salvar(f);
            pesquisar();
            mostra(f);
            limpaCampos();
            txtNome.Focus();
        }

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Excluir Funcionário?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                funcionarioDAO.Excluir(getFuncionarioGrid());
            }
            pesquisar();
            limpaCampos();
            txtNome.Focus();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limpaCampos();
            txtNome.Focus();
        }

        private void recarregar_Click(object sender, EventArgs e)
        {
            pesquisar();
            txtNome.Focus();
        }

        private void gridFuncionario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            mostra(getFuncionarioGrid());
            txtNome.Focus();
        }

        private void FrmFuncionario_Load(object sender, EventArgs e)
        {
            gridFuncionario.Columns["FUN_CODIGO"].HeaderText = "Código";
            gridFuncionario.Columns["FUN_NOME"].HeaderText = "Nome";
            gridFuncionario.Columns["FUN_CPF"].HeaderText = "CPF";
            gridFuncionario.Columns["FUN_RG"].HeaderText = "RG";
            gridFuncionario.Columns["FUN_ENDERECO"].HeaderText = "Endereço";
            gridFuncionario.Columns["FUN_BAIRRO"].HeaderText = "Bairro";
            gridFuncionario.Columns["FUN_CIDADE"].HeaderText = "Cidade";
            gridFuncionario.Columns["FUN_ESTADO"].HeaderText = "Estado";
            gridFuncionario.Columns["FUN_CEP"].HeaderText = "CEP";
            gridFuncionario.Columns["FUN_CELULAR_TELEFONE"].HeaderText = "Celular/Telefone";
            gridFuncionario.Columns["FUN_BANCO"].HeaderText = "Banco";
            gridFuncionario.Columns["FUN_AGENCIA"].HeaderText = "Agência";
            gridFuncionario.Columns["FUN_PIS"].HeaderText = "Cargo";
            gridFuncionario.Columns["FUN_ESTADO_CIVIL"].HeaderText = "Estado Civil";
            gridFuncionario.Columns["FUN_QTD_FILHOS"].HeaderText = "QTD Filhos";
            gridFuncionario.Columns["FUN_ADMISSAO"].HeaderText = "Data de Admissão";
            gridFuncionario.Columns["FUN_CARGO"].HeaderText = "Cargo";
            gridFuncionario.Columns["FUN_SALARIO"].HeaderText = "Salário";
            gridFuncionario.Columns["FUN_SITUACAO"].HeaderText = "Situação";
        }

    }
}
