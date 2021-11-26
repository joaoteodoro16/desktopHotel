using DesktopHotel.Context;
using DesktopHotel.Model;
using DesktopHotel.Model.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopHotel.Forms
{
    public partial class FrmHospedes : Form
    {
        HospedeDao hospedeDao = new HospedeDao();
        public FrmHospedes()
        {
            InitializeComponent();
            pesquisar();
            limpaCampos();
        }

        private void FrmHospedes_KeyDown(object sender, KeyEventArgs e)
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
            txtCpf.Text = "";
            txtRg.Text = "";
            txtEmail.Text = "";
            txtCelular.Text = "";
            txtDataNascimento.Text = "";
            txtSexo.Text = "";
            txtEndereco.Text = "";
            txtCidade.Text = "";
            txtBairro.Text = "";
            cmbEstado.SelectedItem = null;
        }

        private void pesquisar()
        {
            List<HospedeModel> lista = hospedeDao.getAll();
            gridHospedes.DataSource = lista;

            if (lista.Count > 0)
            {
                mostra(lista[0]);
            }
        }

        private HospedeModel mostra(HospedeModel h)
        {
            txtCodigo.Text = h.hos_cod.ToString();
            txtNome.Text = h.hos_nome;
            txtCpf.Text = h.hos_cpf;
            txtRg.Text = h.hos_rg;
            txtEmail.Text = h.hos_email;
            txtCelular.Text = h.hos_celular;
            txtDataNascimento.Text = h.hos_data_nasc.ToString();
            txtSexo.Text = h.hos_sexo;
            txtEndereco.Text = h.hos_endereco;
            txtCidade.Text = h.hos_cidade;
            txtBairro.Text = h.hos_bairro;


            return h;
        }

        private HospedeModel getHospedeGrid()
        {
            return gridHospedes.CurrentRow.DataBoundItem as HospedeModel;
        }

        private HospedeModel montaObjeto()
        {
            HospedeModel hospede = new HospedeModel();

            hospede.hos_nome = txtNome.Text;
            hospede.hos_bairro = txtBairro.Text;
            hospede.hos_celular = txtCelular.Text;
            hospede.hos_cidade = txtCidade.Text;
            hospede.hos_cpf = txtCpf.Text;
            hospede.hos_data_nasc = Convert.ToDateTime(txtDataNascimento.Text);
            hospede.hos_email = txtEmail.Text;
            hospede.hos_endereco = txtEmail.Text;
            hospede.hos_estado = cmbEstado.Text;
            hospede.hos_rg = txtRg.Text;
            hospede.hos_sexo = txtSexo.Text;

            return hospede;
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

            if (txtCpf.Text.Length <= 0)
            {
                txtCpf.Focus();
                txtCpf.Text = string.Empty;
                MessageBox.Show("Digite um CPF...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtRg.Text.Length <= 0)
            {
                txtRg.Focus();
                txtRg.Text = string.Empty;
                MessageBox.Show("Digite um RG...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtEmail.Text.Length <= 0)
            {
                txtEmail.Focus();
                txtEmail.Text = string.Empty;
                MessageBox.Show("Digite um E-mail...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtCelular.Text.Length <= 0)
            {
                txtCelular.Focus();
                txtCelular.Text = string.Empty;
                MessageBox.Show("Digite um número de celular...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtDataNascimento.Text.Length <= 0)
            {
                txtDataNascimento.Focus();
                txtDataNascimento.Text = string.Empty;
                MessageBox.Show("Digite uma data de nascimento...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtSexo.Text.Length <= 0)
            {
                txtSexo.Focus();
                txtSexo.Text = string.Empty;
                MessageBox.Show("Digite um sexo...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Digite uma cidade...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtBairro.Text.Length <= 0)
            {
                txtBairro.Focus();
                txtBairro.Text = string.Empty;
                MessageBox.Show("Digite um Bairro...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (cmbEstado.Text == string.Empty)
            {
                MessageBox.Show("Selecione um Estado...", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            BasicContext context = new BasicContext();

            String codigo = txtCodigo.Text;
            HospedeModel hospede = montaObjeto();

            //Se for maior que 0 está editando
            if (codigo.Length > 0)
            {
                hospede.hos_cod = Int32.Parse(txtCodigo.Text);
                hospedeDao.Salvar(hospede);
            }
            else
            {
                context.Hospedes.Add(hospede);
                context.SaveChanges();
            }

            pesquisar();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Excluir Hóspede?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {
                hospedeDao.Excluir(getHospedeGrid());
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

        private void gridHospedes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            HospedeModel hospede = gridHospedes.CurrentRow.DataBoundItem as HospedeModel;

            txtBairro.Text = hospede.hos_bairro;
            txtCelular.Text = hospede.hos_celular;
            txtCidade.Text = hospede.hos_cidade;
            txtCodigo.Text = hospede.hos_cod.ToString();
            txtCpf.Text = hospede.hos_cpf;
            txtDataNascimento.Text = hospede.hos_data_nasc.ToString();
            txtEmail.Text = hospede.hos_email;
            txtEndereco.Text = hospede.hos_endereco;
            txtNome.Text = hospede.hos_nome;
            txtRg.Text = hospede.hos_rg;
            txtSexo.Text = hospede.hos_sexo;

        }

        private void FrmHospedes_Load(object sender, EventArgs e)
        {
            gridHospedes.Columns["hos_cod"].HeaderText = "Código";
            gridHospedes.Columns["hos_nome"].HeaderText = "Nome";
            gridHospedes.Columns["hos_cpf"].HeaderText = "CPF";
            gridHospedes.Columns["hos_rg"].HeaderText = "RG";
            gridHospedes.Columns["hos_email"].HeaderText = "E-mail";
            gridHospedes.Columns["hos_celular"].HeaderText = "Celular";
            gridHospedes.Columns["hos_data_nasc"].HeaderText = "Data Nascimento";
            gridHospedes.Columns["hos_sexo"].HeaderText = "Sexo";
            gridHospedes.Columns["hos_cidade"].HeaderText = "Cidade";
            gridHospedes.Columns["hos_bairro"].HeaderText = "Bairro";
            gridHospedes.Columns["hos_estado"].HeaderText = "Estado";
        }
    }
}
