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
            if (Convert.ToInt32(txtColuna.Text) <= 0 || Convert.ToInt32(txtLine.Text) <= 0)
            {
                MessageBox.Show("Linha ou Coluna devem obrigatoriamente serem preenchidas com valores maiores que zero. ",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if(Convert.ToInt32(txtColuna.Text ) > 8 || Convert.ToInt32(txtLine.Text) > 8)
            //{
            //    MessageBox.Show("Não é possivel gerar tabuleiro maior que 8x8","Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return;
            //}
            if (Convert.ToInt32(txtPosx.Text) >= Convert.ToInt32(txtLine.Text) ||
                Convert.ToInt32(txtPosy.Text) >= Convert.ToInt32(txtColuna.Text))
            {
                MessageBox.Show("Posição não existente no tabuleiro", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
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
        }

        private string SetaValor()
        {
            throw new NotImplementedException();
        }

        public string InsereValorMinimo()
        {
            return "0";
        }

    }
}
