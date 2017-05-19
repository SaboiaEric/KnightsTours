using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Collections.Generic;
using ProjetoGrafos.DataStructure;
using System.Linq;

namespace EP
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class EP : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Button b00;
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;
        private Button[,] BL;
        private System.Windows.Forms.Button btnSolve;
        private int x, y;
        private Button btnLimpar;
        private TextBox txtSolucao;
        private int Linha;
        private int Coluna;
        private Button button1;
        private Button button2;
        private string a = "";
        private int startx;
        private int starty;
        private int completo = 1;

        public EP(int posx, int posy, int inix, int iniy)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            Linha = posx;
            Coluna = posy;
            startx = inix;
            starty = iniy;
            // Draws the painel
            DrawPanel();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.b00 = new System.Windows.Forms.Button();
            this.btnSolve = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.txtSolucao = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b00
            // 
            this.b00.BackColor = System.Drawing.Color.White;
            this.b00.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.b00.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.b00.Location = new System.Drawing.Point(8, 8);
            this.b00.Margin = new System.Windows.Forms.Padding(8);
            this.b00.Name = "b00";
            this.b00.Size = new System.Drawing.Size(56, 56);
            this.b00.TabIndex = 2;
            this.b00.UseVisualStyleBackColor = false;
            this.b00.Visible = false;
            this.b00.Click += new System.EventHandler(this.b00_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSolve.Location = new System.Drawing.Point(491, 216);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(173, 28);
            this.btnSolve.TabIndex = 3;
            this.btnSolve.Text = "Solução";
            this.btnSolve.Click += new System.EventHandler(this.btnSolve_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(491, 284);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnLimpar.Size = new System.Drawing.Size(173, 28);
            this.btnLimpar.TabIndex = 4;
            this.btnLimpar.Text = "Limpar";
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // txtSolucao
            // 
            this.txtSolucao.Location = new System.Drawing.Point(491, 33);
            this.txtSolucao.Multiline = true;
            this.txtSolucao.Name = "txtSolucao";
            this.txtSolucao.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSolucao.Size = new System.Drawing.Size(173, 177);
            this.txtSolucao.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(491, 250);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(173, 28);
            this.button1.TabIndex = 6;
            this.button1.Text = "Criar";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(491, 318);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button2.Size = new System.Drawing.Size(173, 52);
            this.button2.TabIndex = 7;
            this.button2.Text = "Retornar ao Menu";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EP
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(676, 463);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSolucao);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.b00);
            this.Name = "EP";
            this.Text = "Passeio do Cavalo - Knight\'s Tour";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new Inicio());
        }

        /// <summary>
        /// Draws the game panel
        /// </summary>
        private void DrawPanel()
        {
            int L = Linha;
            int c = Coluna;

            // Creating the labels
            BL = new Button[L, c];
            for (int i = 0; i < L; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    Button B = new Button();

                    B.Parent = b00.Parent;
                    B.Font = b00.Font;
                    B.Size = b00.Size;
                    B.Left = i * 56 + 10;
                    B.Top = j * 56 + 10;
                    if (i % 2 == 0 && j % 2 == 0 || i == j || (j % 2 != 0 && i % 2 != 0))
                        B.BackColor = b00.BackColor;
                    else
                        B.BackColor = Color.LightGray;
                    B.Visible = true;
                    B.Click += new System.EventHandler(this.b00_Click);
                    BL[i, j] = B;
                    BL[i, j].Text = (Convert.ToChar(i + 65).ToString() + (j + 1).ToString());
                }
            }
        }

        /// <summary>
        /// Click template for all buttons 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void b00_Click(object sender, System.EventArgs e)
        {
            Button b = sender as Button;
            Image f = null;

            x = (b.Bounds.X / 56);  // Convertendo posição clique para Matriz.
            y = (b.Bounds.Y / 56);  // Convertendo posição clique para Matriz.

            if (b.BackColor == Color.LightGray)
            {
                
                   f = Image.FromFile("C:\\Users\\erics\\Desktop\\ExQuebraCabeça\\EPEx\\Imagens\\HORSECINZA.png");
            }
            else
            {
                
                 f = Image.FromFile("C:\\Users\\erics\\Desktop\\ExQuebraCabeça\\EPEx\\Imagens\\HORSE.png");
            }
            b.BackgroundImage = f;
            completo++;
            if(completo == Linha * Coluna)
            {
                MessageBox.Show("Passeio Finalizado", "Fim de processo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSolve_Click(object sender, System.EventArgs e)
        {
            EightPuzzle sol = new EightPuzzle();

            a = sol.Solucao(Linha, Coluna, startx, starty);
            Image f = null;
            if (BL[startx, starty].BackColor == Color.LightGray)
            {
                f = Image.FromFile("C:\\Users\\erics\\Desktop\\ExQuebraCabeça\\EPEx\\Imagens\\HORSECINZA.png");
            }
            else
            {
                f = Image.FromFile("C:\\Users\\erics\\Desktop\\ExQuebraCabeça\\EPEx\\Imagens\\HORSE.png");
            }
            BL[startx, starty].BackgroundImage = f;
            BL[startx, starty].Text = "";

            txtSolucao.Text = a;
        }

        //Criar - Processo automático de passeio do cavalo.
        private void button1_Click(object sender, EventArgs e)
        {
            if (a != "" && a[0] != 'N')
            {
                a = RemoverEspacos();
                a = RemoverVirgula();
                List<Char> listachar = new List<Char>();
                List<int> listaint = new List<int>();
                // Cria uma lista de Char onde armazena todos as posicoes do char da solucao
                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] >= 65 && a[i] <= 90)
                        listachar.Add(a[i]);
                }
                //Pega todos as posicoes das linhas da solucao para criar com o char.
                //Precisou fazer isso por causa do tabuleiro 3x10, que na casa A10 ele dava exception.
                for (int i = 0; i < a.Length; i++)
                {
                    if (i == a.Length - 1)
                    {
                        listaint.Add(int.Parse(a[i].ToString()));
                    }
                    else
                    {
                        if (Char.IsDigit(a[i]) && Char.IsDigit(a[i + 1]))
                        {
                            int dezena = int.Parse((a[i] - 48).ToString() + (a[i + 1] - 48).ToString());
                            listaint.Add(dezena);
                        }
                        else
                        {
                            if (Char.IsDigit(a[i]))
                                listaint.Add(int.Parse(a[i].ToString()));
                        }
                    }
                }
                listaint.RemoveAll(z => z == 0);
               
                for (int i = 0; i < listachar.Count; i++)
                {
                    int bx = Convert.ToInt32(listachar[i]) - 65;
                    int by = listaint[i] - 1;

                    Image f = null;
                    if (BL[bx, by].BackColor == Color.LightGray)
                    {
                        f = Image.FromFile("C:\\Users\\erics\\Desktop\\ExQuebraCabeça\\EPEx\\Imagens\\HORSECINZA.png");
                    }
                    else
                    {
                        f = Image.FromFile("C:\\Users\\erics\\Desktop\\ExQuebraCabeça\\EPEx\\Imagens\\HORSE.png");
                    }
                    BL[bx, by].BackgroundImage = f;
                    Thread.Sleep(600);
                    Application.DoEvents();
                }
                Thread.Sleep(1500);
                MessageBox.Show("Passeio Finalizado", "Fim de processo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string RemoverVirgula()
        {
            return new string(a.ToCharArray().Where(x => !(",").Contains(x)).ToArray());
        }

        private string RemoverEspacos()
        {
            return new string(a.ToCharArray().Where(x => !Char.IsWhiteSpace(x)).ToArray());
        }

        // Retornar ao menu principal.
        private void button2_Click(object sender, EventArgs e)
        {
            Inicio i = new Inicio();
            i.Show();
            this.Hide();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Linha; i++)
            {
                for (int j = 0; j < Coluna; j++)
                {
                    BL[i, j].BackgroundImage = null;
                }
            }
            BL[startx, starty].Text = Convert.ToChar(startx + 65) + (starty + 1).ToString();
            txtSolucao.Text = "";
            completo = 0;
        }
    }
}
