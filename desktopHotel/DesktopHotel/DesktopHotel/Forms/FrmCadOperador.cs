using DesktopHotel.Model;
using DesktopHotel.Model.DAO;
using DesktopHotel.Util;
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
    public partial class FrmCadOperador : Form
    {
        bool existe;
        public FrmCadOperador()
        {
            InitializeComponent();
        }

        public void atualizaGrid()
        {
            LoginDao logindao = new LoginDao();
            gridOperadores.DataSource = logindao.getAll();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            LoginDao logindao = new LoginDao();
            LoginModel login = new LoginModel();

            if (!txtSenha.Text.Equals(txtSenha2.Text) && !txtSenha2.Text.Equals(txtSenha.Text))
            {
                MessageBox.Show("Senhas não conferem", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (mskCpf.Text.Equals(""))
            {
                MessageBox.Show("Por favor informe o CPF do funcionário", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (!txtCodigo.Text.Equals(""))
            {
                login.codigo = Convert.ToInt32(txtCodigo.Text);
            }

           
          
            login.user = txtUsuario.Text;
            login.senha = txtSenha.Text;
            login.nivel = cmbNivel.Text;
            login.cpf = mskCpf.Text;

            if (!txtNomeFunc.Text.Equals(""))
            {
                login.username = txtNomeFunc.Text;
            }

            if (cmbStatus.Text.Equals("ATIVO"))
            {
                login.status = "A";
            }
            else{
                login.status = "I";
            }

            if (login.username == null || login.user.Equals("") || login.senha.Equals("")
                || txtSenha2.Text.Equals("") || login.nivel.Equals("") || login.status.Equals("") || login.cpf.Equals(""))
            {
                MessageBox.Show("Preencha todos os campos!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
          
            existe = logindao.buscaPorCodigo(txtCodigo.Text);

            if(!existe && txtCodigo.Text == "")
            {

                existe = logindao.verificaSeExisteUser(login);
                if (existe)
                {
                    MessageBox.Show("Esse usuário já foi cadastrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                login.username = txtNomeFunc.Text;

                if (login.username != null)
                {
                    bool verificaCpf = logindao.verificaCPFCadastrado(login);

                    if (verificaCpf != true)
                    {
                        logindao.cadastraOperador(login);
                    }
                    else
                    {
                        MessageBox.Show("Esse CPF já foi cadastrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                }
            }
            else
            {
                login.username = txtNomeFunc.Text;
                logindao.alterarOperador(login);
            }
            

            limpaCampos();
            atualizaGrid();

        }

        private void cmbNivel_KeyDown(object sender, KeyEventArgs e)
        {
            cmbNivel.Text = "";
        }

        private void cmbNivel_KeyUp(object sender, KeyEventArgs e)
        {
            cmbNivel.Text = "";
        }

        private void FrmCadOperador_Load(object sender, EventArgs e)
        {

            atualizaGrid();

            gridOperadores.Columns["codigo"].HeaderText = "Código";
            gridOperadores.Columns["user"].HeaderText = "Usuário";
            gridOperadores.Columns["username"].HeaderText = "Funcionário";
            gridOperadores.Columns["senha"].HeaderText = "Senha";
            gridOperadores.Columns["nivel"].HeaderText = "Nível";
            gridOperadores.Columns["status"].HeaderText = "Status";
            gridOperadores.Columns["cpf"].HeaderText = "CPF";
            
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                LoginDao loginDao = new LoginDao();
                LoginModel login = new LoginModel();

                login = loginDao.getLoginUser(txtUsuario.Text);

                if (login == null)
                {
                    MessageBox.Show("Nenhum registro encontrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    txtCodigo.Text = login.codigo.ToString();
                    txtSenha.Text = login.senha;
                    txtSenha2.Text = login.senha;
                    txtNomeFunc.Text = login.username;
                    cmbNivel.Text = login.nivel;
                    cmbStatus.Text = login.status;
                    mskCpf.Text = login.cpf;

                    }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            atualizaGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            limpaCampos();
        }

        public void limpaCampos()
        {
            txtCodigo.Text = "";
            txtNomeFunc.Text = "";
            txtSenha.Text = "";
            txtUsuario.Text = "";
            txtSenha2.Text = "";
            cmbNivel.Text = "";
            cmbStatus.Text = "";
            mskCpf.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LoginDao loginDao = new LoginDao();

            if (txtCodigo.Text != "")
            {
                loginDao.excluirLogin(txtCodigo.Text);
                limpaCampos();
                atualizaGrid();
            }
        }

        private void gridOperadores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            LoginModel login = gridOperadores.CurrentRow.DataBoundItem as LoginModel;

            txtCodigo.Text = login.codigo.ToString();
            txtUsuario.Text = login.user;
            txtSenha.Text = login.senha;
            txtSenha2.Text = login.senha;
            txtNomeFunc.Text = login.username;
            cmbNivel.Text = login.nivel;
            mskCpf.Text = login.cpf;

            if (login.status.Equals("A"))
            {
                cmbStatus.Text = "ATIVO";
            }
            else
            {
                cmbStatus.Text = "INATIVO";
            }
            
        }

        private void cmbStatus_KeyUp(object sender, KeyEventArgs e)
        {
            cmbStatus.Text = "";
        }

        private void mskCpf_Leave(object sender, EventArgs e)
        {
            buscaNomeFuncionario();
        }

        public void buscaNomeFuncionario()
        {
            FuncionarioDAO funcionarioDAO = new FuncionarioDAO();
            FuncionarioModel func = funcionarioDAO.buscaPorCpf(mskCpf.Text);

            
            if(func != null)
            {
                txtNomeFunc.Text = func.FUN_NOME;
            }
            else
            {
                MessageErroUtil.mensagemErro("Esse CPF já foi utilizado",true);
            }

        }

        private void mskCpf_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13))
            {
                buscaNomeFuncionario();
            }
        }
    }
}
