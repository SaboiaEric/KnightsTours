using System;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using ProjetoGrafos.DataStructure;
using System.Linq;

namespace EP
{
    public class EightPuzzle : Graph
    {
        readonly static int[,] moves = { {+1,-2},{+2,-1},{+2,+1},{+1,+2},
                                        {-1,+2},{-2,+1},{-2,-1},{-1,-2} };

        public string Solucao(int l, int c, int startx, int starty)
        {
            int Linha = l;
            int Coluna = c;
            string passeio = "";
            int[,] tabuleiro = new int[Linha, Coluna];
            Graph graph = new Graph();
            tabuleiro.Initialize();

            int x, y;

            x = startx;
            y = starty;

            List<Node> list = new List<Node>(Linha * Coluna);
            Node antigo = new Node(x.ToString() + y.ToString(), x, y);
            list.Add(antigo);
            graph.AddNode(antigo.Nome, x, y);
            
            while (list.Count < Linha * Coluna)
            {
                if (MovimentoEPossivel(tabuleiro, x, y, Linha, Coluna))
                {
                    int move = tabuleiro[x, y];
                    tabuleiro[x, y]++;
                    x += moves[move, 0];
                    y += moves[move, 1];
                    Node novo = new Node(x.ToString() + y.ToString(), x, y);
                    graph.AddNode(novo.Nome, x, y);
                    graph.AddEdge(antigo.Nome, novo.Nome, 1);
                    list.Add(novo);
                    antigo = novo;
                }
                else
                {
                    if (tabuleiro[x, y] >= 8)
                    {
                        tabuleiro[x, y] = 0;
                        Node removido = list[list.Count - 1];
                        list.RemoveAt(list.Count - 1);
                        graph.RemoveNode(removido.Nome);
                        try
                        {
                            antigo = graph.Nodes[graph.Nodes.Length - 1];
                            x = graph.Nodes[graph.Nodes.Length - 1].X;
                            y = graph.Nodes[graph.Nodes.Length - 1].Y;
                        }
                        catch (Exception)
                        {
                            return ("Não existe caminho");
                        }

                    }
                    tabuleiro[x, y]++;
                }
            }

            foreach (Node item in graph.Nodes)
            {
                if (item.Arcos.Count > 1)
                {
                    passeio += Convert.ToChar(item.Arcos[item.Arcos.Count - 1].To.X + 65).ToString() + 
                               (item.Arcos[item.Arcos.Count - 1].To.Y + 1).ToString() + ", ";
                    continue;
                }
                foreach (Edge item2 in item.Arcos)
                {
                    if (item2.To != null)
                    {
                        passeio += Convert.ToChar((item2.To.X + 65)).ToString() + (item2.To.Y +1).ToString() + ", ";
                    }
                }
            }
            if(passeio != "")
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
            if (tabuleiro[xatual, yatual] >= 8)
                return false;

            int novox = xatual + moves[tabuleiro[xatual, yatual], 0]; 
            int novoy = yatual + moves[tabuleiro[xatual, yatual], 1];

            if (novox >= 0 && novox < linha && novoy >= 0 && novoy < coluna && tabuleiro[novox, novoy] == 0)
                return true;

            return false;
        }
    }
}

