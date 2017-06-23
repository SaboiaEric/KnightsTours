using System;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using KnightsTours.Telas;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

namespace KnightsTours
{
    public class KnightsTours : Graph
    {

        private int[,] obstaculos;
        /// <summary>
        /// Movimentos possíveis
        /// </summary>
        readonly static int[,] moves = { {+1,-2},{+2,-1},{+2,+1},{+1,+2},
                                        {-1,+2},{-2,+1},{-2,-1},{-1,-2} };
        /// <summary>
        /// Solução para o jogo
        /// </summary>
        /// <param name="l"></param>
        /// <param name="c"></param>
        /// <param name="startx"></param>
        /// <param name="starty"></param>
        /// <returns></returns>
        public string Solucao(int l, int c, int startx, int starty, int[,] obstaculo)
        {

            int Linha = l;
            int Coluna = c;
            string passeio = string.Empty;
            int[,] tabuleiro = new int[Linha, Coluna];
            Graph grafoSolucao = new Graph();
            Graph grafoAuxiliar = new Graph();
            int maior = 0;
            bool chooseGraph = false;
            tabuleiro.Initialize();
            int x, y;
            x = startx;
            y = starty;

            this.obstaculos = obstaculo;

            List<Node> tabuleiroLista = new List<Node>(Linha * Coluna);
            Node noAntigo = new Node(x.ToString() + y.ToString(), x, y);
            tabuleiroLista.Add(noAntigo);
            grafoSolucao.AddNode(noAntigo.Nome, x, y);



            while (tabuleiroLista.Count < Linha * Coluna)
            {
                if (MovimentoEPossivel(tabuleiro, x, y, Linha, Coluna))
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
                        if (grafoSolucao.Nodes.Length > maior)
                        {    
                            maior = grafoSolucao.Nodes.Length;
                            grafoAuxiliar = new Graph().DeepCopy(grafoSolucao);                            
                        }
                        tabuleiro[x, y] = 0;
                        Node removido = tabuleiroLista[tabuleiroLista.Count - 1];
                        tabuleiroLista.RemoveAt(tabuleiroLista.Count - 1);
                        grafoSolucao.RemoveNode(removido.Nome);

                        if ((grafoSolucao.Nodes.Length - 1) < 0)
                        {
                            chooseGraph = true;
                            break;
                        }
                        else
                        {
                            noAntigo = grafoSolucao.Nodes[grafoSolucao.Nodes.Length - 1];
                            x = grafoSolucao.Nodes[grafoSolucao.Nodes.Length - 1].X;
                            y = grafoSolucao.Nodes[grafoSolucao.Nodes.Length - 1].Y;
                        }


                    }
                    tabuleiro[x, y]++;
                }
            }

            if (chooseGraph)
                grafoSolucao = grafoAuxiliar;

            foreach (Node item in grafoSolucao.Nodes)
            {
                if (item.Arcos.Count > 1)
                {
                    passeio += Convert.ToChar(item.Arcos[item.Arcos.Count - 1].To.X + 65).ToString() + (item.Arcos[item.Arcos.Count - 1].To.Y + 1).ToString() + ", ";
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

        public bool MovimentoEPossivel(int[,] tabuleiro, int xatual, int yatual, int Linha, int Coluna)
        {
            //Quantidade de tentativas realizadas nesta posição.
            if (tabuleiro[xatual, yatual] >= 8)
                return false;

            int novox = xatual + moves[tabuleiro[xatual, yatual], 0];
            int novoy = yatual + moves[tabuleiro[xatual, yatual], 1];

            if (novox >= 0 && novox < Linha && novoy >= 0 && novoy < Coluna && tabuleiro[novox, novoy] == 0)
                return (obstaculos[novox, novoy] == 1) ? false : true;

            return false;
        }

    }

}