using System.Windows.Forms;

namespace KnightsTours.Telas
{
    partial class Inicio: Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLine = new System.Windows.Forms.TextBox();
            this.txtColuna = new System.Windows.Forms.TextBox();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.txtPosx = new System.Windows.Forms.TextBox();
            this.txtPosy = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnLimpar = new System.Windows.Forms.Button();
            this.txtObsX = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtObsY = new System.Windows.Forms.TextBox();
            this.btnAddObs = new System.Windows.Forms.Button();
            this.listObs = new System.Windows.Forms.ListView();
            this.btnAddTabuleiro = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tab. linhas:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tab. colunas:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Passeio do Cavalo";
            // 
            // txtLine
            // 
            this.txtLine.Location = new System.Drawing.Point(92, 42);
            this.txtLine.Name = "txtLine";
            this.txtLine.Size = new System.Drawing.Size(51, 20);
            this.txtLine.TabIndex = 19;
            // 
            // txtColuna
            // 
            this.txtColuna.Location = new System.Drawing.Point(92, 67);
            this.txtColuna.Name = "txtColuna";
            this.txtColuna.Size = new System.Drawing.Size(51, 20);
            this.txtColuna.TabIndex = 2;
            // 
            // btnIniciar
            // 
            this.btnIniciar.Location = new System.Drawing.Point(60, 266);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 45);
            this.btnIniciar.TabIndex = 5;
            this.btnIniciar.Text = "INICIAR";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // txtPosx
            // 
            this.txtPosx.Location = new System.Drawing.Point(252, 45);
            this.txtPosx.Name = "txtPosx";
            this.txtPosx.Size = new System.Drawing.Size(51, 20);
            this.txtPosx.TabIndex = 3;
            // 
            // txtPosy
            // 
            this.txtPosy.Location = new System.Drawing.Point(252, 68);
            this.txtPosy.Name = "txtPosy";
            this.txtPosy.Size = new System.Drawing.Size(51, 20);
            this.txtPosy.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(166, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Pos. Cavalo X:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(166, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Pos. Cavalo Y:";
            // 
            // btnLimpar
            // 
            this.btnLimpar.Location = new System.Drawing.Point(220, 266);
            this.btnLimpar.Name = "btnLimpar";
            this.btnLimpar.Size = new System.Drawing.Size(75, 45);
            this.btnLimpar.TabIndex = 10;
            this.btnLimpar.Text = "LIMPAR";
            this.btnLimpar.UseVisualStyleBackColor = true;
            this.btnLimpar.Click += new System.EventHandler(this.btnLimpar_Click);
            // 
            // txtObsX
            // 
            this.txtObsX.Location = new System.Drawing.Point(84, 141);
            this.txtObsX.Name = "txtObsX";
            this.txtObsX.Size = new System.Drawing.Size(51, 20);
            this.txtObsX.TabIndex = 12;
            this.txtObsX.TextChanged += new System.EventHandler(this.txtObsX_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Pos. Obs. X:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 172);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(66, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Pos. Obs. Y:";
            // 
            // txtObsY
            // 
            this.txtObsY.Location = new System.Drawing.Point(84, 167);
            this.txtObsY.Name = "txtObsY";
            this.txtObsY.Size = new System.Drawing.Size(51, 20);
            this.txtObsY.TabIndex = 14;
            // 
            // btnAddObs
            // 
            this.btnAddObs.Location = new System.Drawing.Point(15, 202);
            this.btnAddObs.Name = "btnAddObs";
            this.btnAddObs.Size = new System.Drawing.Size(120, 27);
            this.btnAddObs.TabIndex = 16;
            this.btnAddObs.Text = "ADD OBSTÁCULO";
            this.btnAddObs.UseVisualStyleBackColor = true;
            this.btnAddObs.Click += new System.EventHandler(this.btnAddObs_Click);
            // 
            // listObs
            // 
            this.listObs.Location = new System.Drawing.Point(154, 141);
            this.listObs.Margin = new System.Windows.Forms.Padding(1);
            this.listObs.Name = "listObs";
            this.listObs.Size = new System.Drawing.Size(149, 88);
            this.listObs.TabIndex = 17;
            this.listObs.UseCompatibleStateImageBehavior = false;
            this.listObs.View = System.Windows.Forms.View.List;
            // 
            // btnAddTabuleiro
            // 
            this.btnAddTabuleiro.Location = new System.Drawing.Point(114, 103);
            this.btnAddTabuleiro.Name = "btnAddTabuleiro";
            this.btnAddTabuleiro.Size = new System.Drawing.Size(120, 27);
            this.btnAddTabuleiro.TabIndex = 20;
            this.btnAddTabuleiro.Text = "ADD TABULEIRO";
            this.btnAddTabuleiro.UseVisualStyleBackColor = true;
            this.btnAddTabuleiro.Click += new System.EventHandler(this.btnAddTabuleiro_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(375, 330);
            this.Controls.Add(this.btnAddTabuleiro);
            this.Controls.Add(this.listObs);
            this.Controls.Add(this.btnAddObs);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtObsY);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtObsX);
            this.Controls.Add(this.btnLimpar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPosy);
            this.Controls.Add(this.txtPosx);
            this.Controls.Add(this.btnIniciar);
            this.Controls.Add(this.txtColuna);
            this.Controls.Add(this.txtLine);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLine;
        private System.Windows.Forms.TextBox txtColuna;
        private System.Windows.Forms.Button btnIniciar;
        private System.Windows.Forms.TextBox txtPosx;
        private System.Windows.Forms.TextBox txtPosy;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnLimpar;
        private TextBox txtObsX;
        private Label label7;
        private Label label8;
        private TextBox txtObsY;
        private Button btnAddObs;
        private ListView listObs;
        private Button btnAddTabuleiro;
    }
}