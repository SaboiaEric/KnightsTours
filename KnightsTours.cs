using System;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using KnightsTours.Telas;

namespace KnightsTours
{
    public class KnightsTours : Graph
    {

        private int[,] obstaculos;
        /// <summary>
        /// Movimentos possíveis
        /// </summary>
        readonly static int[,] moves = {
            {+1,-2},
            {+1,+2},
            {+2,-1},
            {+2,+1},
            {-2,+1},
            {-2,-1},
            {-1,+2},
            {-1,-2}
        };

        /// <summary>
        /// Solução para o jogo
        /// </summary>
        /// <param name="l"></param>
        /// <param name="c"></param>
        /// <param name="startx"></param>
        /// <param name="starty"></param>
        /// <returns></returns>
        public string Solucao(int linha, int coluna, int startx, int starty, int[,] obstaculo)
        {
            int x, y;
            x = startx;
            y = starty;
            string passeio = string.Empty;
            //Matriz que representa o tabuleiro de xadrez;
            int[,] tabuleiro = new int[linha, coluna];
            this.obstaculos = obstaculo;
            Graph grafoSolucao = new Graph();

            //Lista que representa a capacidade do tabuleiro de xadrez;
            List<Node> tabuleiroLista = new List<Node>(linha * coluna);
            //Cria e coleta o primeiro nó
            Node noAntigo = new Node(x.ToString() + y.ToString(), x, y);
            //Adiciona o primeiro nó na lista dos nós existentes no tabuleiro
            tabuleiroLista.Add(noAntigo);
            //Adiciona este nó no grafo de solução pois a solução terá como partida este nó.
            grafoSolucao.AddNode(noAntigo.Nome, x, y);

            while (tabuleiroLista.Count < linha * coluna)
            {
                //Verifica se há movimentos possiveis para o cavalo andar
                if (MovimentoEPossivel(tabuleiro, x, y, linha, coluna))
                {
                    int move = tabuleiro[x, y];
                    tabuleiro[x, y]++;
                    x += moves[move, 0];
                    y += moves[move, 1];
                    Node novo = new Node(x.ToString() + y.ToString(), x, y);
                    grafoSolucao.AddNode(novo.Nome, x, y);
                    grafoSolucao.AddEdge(noAntigo.Nome, novo.Nome, 1);
                    tabuleiroLista.Add(novo);
                    noAntigo = novo;
                }
                else
                {
                    if (tabuleiro[x, y] >= 8)
                    {
                        tabuleiro[x, y] = 0;
                        Node removido = tabuleiroLista[tabuleiroLista.Count - 1];
                        tabuleiroLista.RemoveAt(tabuleiroLista.Count - 1);
                        grafoSolucao.RemoveNode(removido.Nome);

                        if ((grafoSolucao.Nodes.Length - 1) < 0)
                            return ("Não existe caminho");

                        noAntigo = grafoSolucao.Nodes[grafoSolucao.Nodes.Length - 1];
                        x = grafoSolucao.Nodes[grafoSolucao.Nodes.Length - 1].X;
                        y = grafoSolucao.Nodes[grafoSolucao.Nodes.Length - 1].Y;


                    }
                    tabuleiro[x, y]++;
                }
            }

            foreach (Node item in grafoSolucao.Nodes)
            {
                if (item.Arcos.Count > 1)
                {
                    passeio += Convert.ToChar(item.Arcos[item.Arcos.Count - 1].To.X + 65).ToString() +
                        (item.Arcos[item.Arcos.Count - 1].To.Y + 1).ToString() + ", ";
                    continue;
                }
                foreach (Edge item2 in item.Arcos)
                    if (item2.To != null)
                        passeio += Convert.ToChar((item2.To.X + 65)).ToString() + (item2.To.Y + 1).ToString() + ", ";
            }
            if (passeio != string.Empty)
                passeio = passeio.Remove(passeio.Length - 2);
            return passeio;
        }

        public string FormataPasseio(string pas)
        {
            string b = new string(pas.ToCharArray().Where(x => !Char.IsWhiteSpace(x)).ToArray());
            string a = new string(b.ToCharArray().Where(x => !(",").Contains(x)).ToArray());
            string f = "";
            char[] bx = a.ToCharArray();
            for (int i = 0; i < bx.Length; i += 2)
            {
                if (i == bx.Length - 2)
                {
                    f += Convert.ToChar(bx[i] + 17) + (bx[i + 1] - 47).ToString();
                }
                else
                {
                    f += Convert.ToChar(bx[i] + 17) + (bx[i + 1] - 47).ToString() + ",";
                }
            }

            return f;
        }


        public bool MovimentoEPossivel(int[,] tabuleiro, int xatual, int yatual, int linha, int coluna)
        {
            //Quantidade de tentativas realizadas nesta posição.
            if (tabuleiro[xatual, yatual] >= 8)
                return false;

            int novox = xatual + moves[tabuleiro[xatual, yatual], 0];
            int novoy = yatual + moves[tabuleiro[xatual, yatual], 1];

            if (novox >= 0 && novox < linha && novoy >= 0 && novoy < coluna && tabuleiro[novox, novoy] == 0)
                return (obstaculos[novox, novoy] == 1) ? false : true;

            return false;
        }
    }
}

