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
        public FrmHospedes()
        {
            InitializeComponent();
        }

        
        private void FrmHospedes_Load(object sender, EventArgs e)
        {
            HospedeDao hospedeDao = new HospedeDao();
            gridHospedes.DataSource = hospedeDao.getAll();
        }

       
        private void btnSalva_Click(object sender, EventArgs e)
        {
            BasicContext context = new BasicContext();

            String codigo = txtCodigo.Text;
            HospedeModel hospede = montaObjeto();

            //Se for maior que 0 está editando
            if(codigo.Length > 0)
            {
                hospede.hos_cod = Int32.Parse(txtCodigo.Text);
                context.Hospedes.AddOrUpdate(hospede);
            }
            else
            {
                context.Hospedes.Add(hospede);
                context.SaveChanges();
            }
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
    }
}
