﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace KnightsTours.Telas
{
    public partial class Inicio : Form
    {
        
        public Inicio()
        {          
            InitializeComponent();
            SetaValores();
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            
            PainelPrincipal func = new PainelPrincipal(Convert.ToInt32(txtLine.Text), Convert.ToInt32(txtColuna.Text),
                Convert.ToInt32(txtPosx.Text), Convert.ToInt32(txtPosy.Text));

            func.Show();
            this.Hide();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            SetaValores();
        }
        
        public void SetaValores()
        {
            this.txtColuna.Text = InsereValorMinimo();
            this.txtLine.Text = InsereValorMinimo();
            this.txtPosx.Text = InsereValorMinimo();
            this.txtPosy.Text = InsereValorMinimo();
            this.txtObsX.Text = InsereValorMinimo();
            this.txtObsY.Text = InsereValorMinimo();
            this.btnIniciar.Enabled = false;
            controleGrupoObstaculos(false);
            controleGrupoTabuleiro(true);
        }
        

        public string InsereValorMinimo()
        {
            return "0";
        }

        private void txtObsX_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddTabuleiro_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtColuna.Text) <= 0 || Convert.ToInt32(txtLine.Text) <= 0)
            {
                MessageBox.Show("Linha ou Coluna devem obrigatoriamente serem preenchidas com valores maiores que zero. ",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //if (Convert.ToInt32(txtColuna.Text) > 8 || Convert.ToInt32(txtLine.Text) > 8)
            //{
            //    MessageBox.Show("Não é possivel gerar tabuleiro maior que 8x8", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}

            if (Convert.ToInt32(txtPosx.Text) >= Convert.ToInt32(txtLine.Text) || Convert.ToInt32(txtPosy.Text) >= Convert.ToInt32(txtColuna.Text))
            {
                MessageBox.Show("Posição não existente no tabuleiro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.btnIniciar.Enabled = true;
            controleGrupoObstaculos(true);
            controleGrupoTabuleiro(false);
        }

        
        private void btnAddObs_Click(object sender, EventArgs e)
        {
            if (validaPosicaoObstaculos())
            {                
                listObs.Items.Add(new ListViewItem($"X = {txtObsX.Text}, Y = {txtObsY.Text}"));
            }
            else
            {
                MessageBox.Show("Posição fora do tabuleiro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool validaPosicaoObstaculos()
        {
            int obsX = Convert.ToInt32(txtObsX.Text);
            int obsY = Convert.ToInt32(txtObsY.Text);
            int col = Convert.ToInt32(txtColuna.Text);
            int lin = Convert.ToInt32(txtLine.Text);
            if (obsX >= 0 && obsX <= col && obsY >= 0 && obsY <= lin)
                return true;
            return false;
        }

        private void controleGrupoObstaculos(bool valor)
        {
            this.btnAddObs.Enabled = valor;
            this.txtObsX.Enabled = valor;
            this.txtObsY.Enabled = valor;
            this.listObs.Enabled = valor;
            this.listObs.Clear();
        }

        private void controleGrupoTabuleiro(bool valor)
        {
            txtColuna.Enabled = valor;
            txtLine.Enabled = valor;
            txtPosx.Enabled = valor;
            txtPosy.Enabled = valor;
        }
    }
}
