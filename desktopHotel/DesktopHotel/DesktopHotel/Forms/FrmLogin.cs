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
    public partial class FrmLogin : Form
    {
        

        public FrmLogin()
        {
            InitializeComponent();

        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
  
            txtUsuario.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool valido = false;

            LoginModel login = new LoginModel();
            LoginDao loginDao = new LoginDao();
            
            login.senha = txtSenha.Text;
            login.user = txtUsuario.Text;
     
            valido = loginDao.validaLogin(login);

            if (valido)
            {
              
                FrmMenuPrincipal frmMenuPrincipal = new FrmMenuPrincipal();
                login = loginDao.getLoginUser(login.user);

                FrmMenuPrincipal.nomeOperador = login.username;
                frmMenuPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login incorreto","Atenção",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }



        }

       

        private void FrmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(27)) //ESC
            {
                this.Close();
            }
        }



        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13)) //Enter
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }
        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue.Equals(13)) //Enter
            {
                SendKeys.Send("{TAB}");
                e.SuppressKeyPress = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            FrmCadOperador frmCadOperador = new FrmCadOperador();
            frmCadOperador.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmCadOperador frmCadOperador = new FrmCadOperador();
            frmCadOperador.Show();
        }

        private void operadorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoginDao loginDao = new LoginDao();

            if (loginDao.verificaNivel(txtUsuario.Text, txtSenha.Text))
            {
                FrmCadOperador frmCadOperador = new FrmCadOperador();
                frmCadOperador.Show();
            }
            else
            {
                MessageBox.Show("Acesso negado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 
        }
    }
}
