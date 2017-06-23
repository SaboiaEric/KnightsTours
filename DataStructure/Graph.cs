using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace KnightsTours.Telas
{
    /// <summary>
    /// Classe que representa um grafo.
    /// </summary>
    [SerializableAttribute]
    public class Graph
    {

        #region Atributos

        /// <summary>
        /// Lista de nós que compõe o grafo.
        /// </summary>
        private List<Node> nos;



        #endregion

        #region Propridades

        /// <summary>
        /// Mostra todos os nós do grafo.
        /// </summary>
        public Node[] Nodes
        {
            get { return this.nos.ToArray(); }
        }

        #endregion

        #region Construtores

        /// <summary>
        /// Cria nova instância do grafo.
        /// </summary>
        public Graph()
        {
            this.nos = new List<Node>();
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Encontra o nó através do seu nome.
        /// </summary>
        /// <param name="name">O nome do nó.</param>
        /// <returns>O nó encontrado ou nulo caso não encontre nada.</returns>
        protected Node Find(string name)
        {
            return this.nos.SingleOrDefault(e => e.Nome == name);
        }

        /// <summary>
        /// Adiciona um nó ao grafo.
        /// </summary>
        /// <param name="name">O nome do nó a ser adicionado.</param>
        /// <param name="info">A informação a ser armazenada no nó.</param>
        public void AddNode(string name, int x, int y)
        {
            if (Find(name) != null)
            {
                throw new Exception("Um nó com o mesmo nome já foi adicionado a este grafo.");
            }
            this.nos.Add(new Node(name, x, y));
        }

        /// <summary>
        /// Remove um nó do grafo.
        /// </summary>
        /// <param name="name">O nome do nó a ser removido.</param>
        public void RemoveNode(string name)
        {
            Node existingNode = Find(name);
            if (existingNode == null)
            {
                throw new Exception("Não foi possível encontrar o nó a ser removido.");
            }
            this.nos.Remove(existingNode);
        }

        /// <summary>
        /// Adiciona o arco entre dois nós associando determinado custo.
        /// </summary>
        /// <param name="from">O nó de origem.</param>
        /// <param name="to">O nó de destino.</param>
        /// <param name="cost">O cust associado.</param>
        public void AddEdge(string from, string to, double cost)
        {
            Node start = Find(from);
            Node end = Find(to);
            // Verifica se os nós existem..
            if (start == null)
            {
                throw new Exception("Não foi possível encontrar o nó origem no grafo.");
            }
            if (end == null)
            {
                throw new Exception("Não foi possível encontrar o nó origem no grafo.");
            }
            start.AddEdge(end, cost);
        }

        /// <summary>
        /// Obtem todos os nós vizinhos de determinado nó.
        /// </summary>
        /// <param name="node">O nó origem.</param>
        /// <returns></returns>
        public Node[] GetNeighbours(string from)
        {
            Node node = Find(from);
            // Verifica se os nós existem..
            if (node == null)
            {
                throw new Exception("Não foi possível encontrar o nó origem no grafo.");
            }
            return node.Arcos.Select(e => e.To).ToArray();
        }

        /// <summary>
        /// Valida um caminho, retornando a lista de nós pelos quais ele passou.
        /// </summary>
        /// <param name="nodes">A lista de nós por onde passou.</param>
        /// <param name="path">O nome de cada nó na ordem que devem ser encontrados.</param>
        /// <returns></returns>
        public bool IsValidPath(ref Node[] nodes, params string[] path)
        {
            return false;
        }


        public bool Hamiltonian()
        {
            foreach (Node n in this.nos)
            {
                bool ret = this.Hamiltonian(n);
                if (ret) return true;
            }
            return false;
        }


        public bool Hamiltonian(Node n)
        {
            return false;
        }


        public List<Node> DepthFirstSearch(string startNode)
        {
            List<Node> path = new List<Node>();
            Stack<Node> stack = new Stack<Node>();
            Node start = Find(startNode);
            stack.Push(start);
            // Percorre enquanto não vazio..
            while (stack.Count > 0)
            {
                Node node = stack.Pop();
                if (!node.Visited)
                {
                    path.Add(node);
                    node.Visited = true;
                    foreach (Edge e in node.Arcos)
                    {
                        if (!e.To.Visited)
                        {
                            stack.Push(e.To);
                        }
                    }
                }
            }
            return path;
        }

        /// <summary>
        /// Executa o caminho em largura buscando o nó alvo.
        /// </summary>
        /// <param name="startNode">O nó inicio.</param>
        /// <returns>A lista de nós visitada.</returns>
        public List<Node> BreadthFirstSearch(string startNode)
        {
            List<Node> path = new List<Node>();
            Queue<Node> queue = new Queue<Node>();
            Node start = Find(startNode);
            queue.Enqueue(start);
            // Percorre enquanto não vazio..
            while (queue.Count > 0)
            {
                Node node = queue.Dequeue();
                if (!node.Visited)
                {
                    path.Add(node);
                    node.Visited = true;
                    foreach (Edge e in node.Arcos)
                    {
                        if (!e.To.Visited)
                        {
                            queue.Enqueue(e.To);
                        }
                    }
                }
            }
            return path;

        }

        public Graph DeepCopy(Graph other)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, other);
                ms.Position = 0;
                return (Graph)formatter.Deserialize(ms);
            }
        }

        #endregion



    }
}
