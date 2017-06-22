using System;
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
            Dictionary<string, string> obsPosicao = new Dictionary<string, string>();
            string[] valores;
            for (int i = 0; i < listObs.Items.Count; i++)
            {
                valores = listObs.Items[i].Text.Split(' ');
                obsPosicao.Add(valores.ElementAt(2) + valores.ElementAt(6), 
                    valores.ElementAt(2) + " - " + valores.ElementAt(6));
            }
            

            PainelPrincipal func = new PainelPrincipal(Convert.ToInt32(txtLine.Text), Convert.ToInt32(txtColuna.Text),
                Convert.ToInt32(txtPosx.Text), Convert.ToInt32(txtPosy.Text), obsPosicao);

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
                listObs.Items.Add(new ListViewItem($"X = {txtObsX.Text} - Y = {txtObsY.Text}"));
            }
            else
            {
                MessageBox.Show("Posição inválida", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool validaPosicaoObstaculos()
        {
            int obsX = Convert.ToInt32(txtObsX.Text);
            int obsY = Convert.ToInt32(txtObsY.Text);
            int col = Convert.ToInt32(txtColuna.Text);
            int lin = Convert.ToInt32(txtLine.Text);
            int posx = Convert.ToInt32(txtPosx.Text);
            int posy = Convert.ToInt32(txtPosy.Text);

            if (obsX >= 0 && obsX <= lin - 1 && obsY >= 0 && obsY <= col - 1)
                if (obsX == posx && obsY == posy)
                    return false;
                else
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
