using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;
using System.Collections.Generic;
using System.Linq;

namespace KnightsTours.Telas
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public class PainelPrincipal : Form
    {
        private System.Windows.Forms.Button botaoInicial;
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
        private Button btnCriar;
        private Button btnRetornarMenu;
        private string a = "";
        private int startx;
        private int starty;
        private Button btnAnimar;
        private int completo = 1;
        private int TempoProcessamentoEmMinisegundos; 

        public PainelPrincipal(int posx, int posy, int inix, int iniy)
        {
            // Required for Windows Form Designer support
            InitializeComponent();
            Linha = posx;
            Coluna = posy;
            startx = inix;
            starty = iniy;
            // Draws the painel
            DrawPanel();
            PosicaoInicial();
            btnAnimar.Enabled = false;
            btnCriar.Visible = false;
            TempoProcessamentoEmMinisegundos = 300;
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
            this.botaoInicial = new System.Windows.Forms.Button();
            this.btnSolve = new System.Windows.Forms.Button();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.txtSolucao = new System.Windows.Forms.TextBox();
            this.btnCriar = new System.Windows.Forms.Button();
            this.btnRetornarMenu = new System.Windows.Forms.Button();
            this.btnAnimar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // botaoInicial
            // 
            this.botaoInicial.BackColor = System.Drawing.Color.White;
            this.botaoInicial.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.botaoInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botaoInicial.Location = new System.Drawing.Point(8, 8);
            this.botaoInicial.Margin = new System.Windows.Forms.Padding(8);
            this.botaoInicial.Name = "botaoInicial";
            this.botaoInicial.Size = new System.Drawing.Size(56, 56);
            this.botaoInicial.TabIndex = 2;
            this.botaoInicial.UseVisualStyleBackColor = false;
            this.botaoInicial.Visible = false;
            this.botaoInicial.Click += new System.EventHandler(this.botaoInicial_Click);
            // 
            // btnSolve
            // 
            this.btnSolve.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSolve.Location = new System.Drawing.Point(491, 249);
            this.btnSolve.Name = "btnSolve";
            this.btnSolve.Size = new System.Drawing.Size(173, 28);
            this.btnSolve.TabIndex = 3;
            this.btnSolve.Text = "Solução";
            this.btnSolve.Click += new System.EventHandler(this.btnSolucao_Click);
            // 
            // btnLimpar
            // 
            this.btnLimpar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpar.Location = new System.Drawing.Point(491, 317);
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
            // btnCriar
            // 
            this.btnCriar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCriar.Location = new System.Drawing.Point(491, 216);
            this.btnCriar.Name = "btnCriar";
            this.btnCriar.Size = new System.Drawing.Size(173, 28);
            this.btnCriar.TabIndex = 6;
            this.btnCriar.Text = "Criar";
            this.btnCriar.Click += new System.EventHandler(this.btnCriar_Click);
            // 
            // btnRetornarMenu
            // 
            this.btnRetornarMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetornarMenu.Location = new System.Drawing.Point(491, 351);
            this.btnRetornarMenu.Name = "btnRetornarMenu";
            this.btnRetornarMenu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnRetornarMenu.Size = new System.Drawing.Size(173, 52);
            this.btnRetornarMenu.TabIndex = 7;
            this.btnRetornarMenu.Text = "Retornar ao Menu";
            this.btnRetornarMenu.Click += new System.EventHandler(this.btnRetornarMenu_Click);
            // 
            // btnAnimar
            // 
            this.btnAnimar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAnimar.Location = new System.Drawing.Point(491, 283);
            this.btnAnimar.Name = "btnAnimar";
            this.btnAnimar.Size = new System.Drawing.Size(173, 28);
            this.btnAnimar.TabIndex = 8;
            this.btnAnimar.Text = "Animar";
            this.btnAnimar.Click += new System.EventHandler(this.btnAnimar_Click);
            // 
            // PainelPrincipal
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(676, 463);
            this.Controls.Add(this.btnAnimar);
            this.Controls.Add(this.btnRetornarMenu);
            this.Controls.Add(this.btnCriar);
            this.Controls.Add(this.txtSolucao);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.btnSolve);
            this.Controls.Add(this.botaoInicial);
            this.Name = "PainelPrincipal";
            this.Text = "Passeio do Cavalo - Knight\'s Tour";
            this.Load += new System.EventHandler(this.EP_Load);
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

                    B.Parent = botaoInicial.Parent;
                    B.Font = botaoInicial.Font;
                    B.Size = botaoInicial.Size;
                    B.Left = i * 56 + 10;
                    B.Top = j * 56 + 10;
                    if (i % 2 == 0 && j % 2 == 0 || i == j || (j % 2 != 0 && i % 2 != 0))
                        B.BackColor = botaoInicial.BackColor;
                    else
                        B.BackColor = Color.LightGray;
                    B.Visible = true;
                    B.Click += new System.EventHandler(this.botaoInicial_Click);
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
        private void botaoInicial_Click(object sender, System.EventArgs e)
        {
            Button b = sender as Button;
            Image f = null;

            x = (b.Bounds.X / 56);  // Convertendo posição clique para Matriz.
            y = (b.Bounds.Y / 56);  // Convertendo posição clique para Matriz.

            if (b.BackColor == Color.LightGray)
            {
                
                   f = Image.FromFile("C:\\Projetos\\KnightsTours\\Imagens\\HORSECINZA.png");
            }
            else
            {
                 f = Image.FromFile("C:\\Projetos\\KnightsTours\\Imagens\\HORSE.png");
            }
            b.BackgroundImage = f;
            completo++;
            if(completo == Linha * Coluna)
            {
                MessageBox.Show("Passeio Finalizado", "Fim de processo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSolucao_Click(object sender, System.EventArgs e)
        {
            KnightsTours game = new KnightsTours();

            a = game.Solucao(Linha, Coluna, startx, starty);
            txtSolucao.Text = a;
            if (a.Equals("Não existe caminho"))
                return;

            txtSolucao.Text = a;
            btnAnimar.Enabled = true;
            btnCriar.Enabled = false;

        }

        //Criar - Processo automático de passeio do cavalo.
        private void btnCriar_Click(object sender, EventArgs e)
        {
            PosicaoInicial();
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
        private void btnRetornarMenu_Click(object sender, EventArgs e)
        {
            Inicio i = new Inicio();
            i.Show();
            this.Hide();
            PosicaoInicial();
            btnAnimar.Enabled = false;
        }

        private void btnAnimar_Click(object sender, EventArgs e)
        {
            PosicionaCavalo();
            if (a != "" && a[0] != 'N')
            {
                a = RemoverEspacos();
                a = RemoverVirgula();
                List<Char> listachar = new List<Char>();
                List<int> listaint = new List<int>();
                // Cria uma lista de Char onde armazena todos as posicoes do char da solucao
                for (int i = 0; i < a.Length; i++)
                    if (a[i] >= 65 && a[i] <= 90)
                        listachar.Add(a[i]);

                //Pega todos as posicoes das linhas da solucao para criar com o char.
                //Precisou fazer isso por causa do tabuleiro 3x10, que na casa A10 ele dava exception.
                for (int i = 0; i < a.Length; i++)
                {
                    if (i == a.Length - 1)
                        listaint.Add(int.Parse(a[i].ToString()));
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
                        f = Image.FromFile("C:\\Projetos\\KnightsTours\\Imagens\\HORSECINZA.png");
                    else
                        f = Image.FromFile("C:\\Projetos\\KnightsTours\\Imagens\\HORSE.png");
                    
                    BL[bx, by].BackgroundImage = f;
                    Thread.Sleep(TempoProcessamentoEmMinisegundos/3);
                    Application.DoEvents();
                }
                Thread.Sleep(TempoProcessamentoEmMinisegundos);
                MessageBox.Show("Passeio Finalizado", "Fim de processo", MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void EP_Load(object sender, EventArgs e)
        {

        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Linha; i++)
            {
                for (int j = 0; j < Coluna; j++)
                {
                    if (BL[i, j] == BL[startx, starty])
                        continue;
                    BL[i, j].BackgroundImage = null;
                }
            }
            BL[startx, starty].Text = Convert.ToChar(startx + 65) + (starty + 1).ToString();
            txtSolucao.Text = "";
            completo = 0;
            btnAnimar.Enabled = false;
        
        }

        public void PosicaoInicial()
        {
            PosicionaCavalo();
            txtSolucao.Text = string.Empty;
            a = string.Empty;
        }

        public void PosicionaCavalo()
        {
            Image f = null;
            if (BL[startx, starty].BackColor == Color.LightGray)
            {
                f = Image.FromFile("C:\\Projetos\\KnightsTours\\Imagens\\HORSECINZA.png");
            }
            else
            {
                f = Image.FromFile("C:\\Projetos\\KnightsTours\\Imagens\\HORSE.png");
            }
            BL[startx, starty].BackgroundImage = f;
            BL[startx, starty].Text = "";
        }
    }
}
