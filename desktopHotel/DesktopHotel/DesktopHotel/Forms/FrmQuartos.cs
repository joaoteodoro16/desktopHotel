﻿using DesktopHotel.Model;
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
    public partial class FrmQuartos : Form
    {
        QuartoDAO quartoDAO = new QuartoDAO();
        QuartoModel quartoModel = new QuartoModel();
        bool existe;

        public FrmQuartos()
        {
            InitializeComponent();
        }

        public void atualizaGrid()
        {
            gridQuartos.DataSource = quartoDAO.getAll();
        }

        public void limpaCampos()
        {
            txtNumero.Text = "";
            txtAndar.Text = "";
            txtValorDiaria.Text = "";
            cmbTipo.SelectedItem = null;
            txtDescricao.Text = "";
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            limpaCampos();
        }

        private bool validar()
        {
            if(txtAndar.Text.Length <= 0)
            {
                txtAndar.Focus();
                txtAndar.Text = string.Empty;
                MessageBox.Show("Digite um Andar válido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                Double.Parse(txtValorDiaria.Text);
            }
            catch (Exception)
            {
                txtValorDiaria.Focus();
                txtValorDiaria.Text = string.Empty;
                MessageBox.Show("Digite um Valor válido!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            String tipo = cmbTipo.Text;
            if (tipo == string.Empty)
            {
                MessageBox.Show("Selecione um tipo!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if(txtDescricao.Text.Length < 3)
            {
                txtDescricao.Focus();
                txtDescricao.Text = string.Empty;
                MessageBox.Show("Digite uma Descrição!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            if (!txtNumero.Text.Equals(""))
            {
                quartoModel.numero = int.Parse(txtNumero.Text);
            }

            quartoModel.andar = txtAndar.Text;
            quartoModel.valorDiaria = Double.Parse(txtValorDiaria.Text);
            quartoModel.tipo = cmbTipo.Text;
            quartoModel.descricao = txtDescricao.Text;

            existe = quartoDAO.buscarPorNumero(txtNumero.Text);

            if(!existe && txtNumero.Text == string.Empty)
            {
                existe = quartoDAO.verificaSeExisteQuarto(quartoModel);
                if (existe)
                {
                    MessageBox.Show("Esse quarto já foi cadastrado!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                quartoDAO.cadastrarQuartos(quartoModel);
                
                MessageBox.Show("Cadastro realizado com sucesso!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                quartoDAO.alterarQuarto(quartoModel);
                MessageBox.Show("Alteração realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            
            limpaCampos();
            atualizaGrid();
        }

        private void FrmQuartos_Load(object sender, EventArgs e)
        {
            atualizaGrid();

            gridQuartos.Columns["numero"].HeaderText = "Número";
            gridQuartos.Columns["andar"].HeaderText = "Andar";
            gridQuartos.Columns["valordiaria"].HeaderText = "Valor Diária";
            gridQuartos.Columns["tipo"].HeaderText = "Tipo";
            gridQuartos.Columns["descricao"].HeaderText = "Descrição";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            atualizaGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show("Tem certeza de que deseja excluir o quarto?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
            {
                quartoDAO.excluirQuartos(txtNumero.Text);
            }
            limpaCampos();
            atualizaGrid();
        }

        private void gridQuartos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            quartoModel = gridQuartos.CurrentRow.DataBoundItem as QuartoModel;

            txtNumero.Text = quartoModel.numero.ToString();
            txtAndar.Text = quartoModel.andar.ToString();
            txtValorDiaria.Text = quartoModel.valorDiaria.ToString();
            cmbTipo.Text = quartoModel.tipo.ToString();
            txtDescricao.Text = quartoModel.descricao.ToString();
        }
    }
}