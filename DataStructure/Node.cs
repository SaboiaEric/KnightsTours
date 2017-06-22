using System;
using System.Collections.Generic;

namespace KnightsTours.Telas
{
    /// <summary>
    /// Classe que representa um nó dentro de um grafo.
    /// </summary>
    public class Node
    {

        #region Propriedades

        /// <summary>
        /// O nome do nó dentro do grafo.
        /// </summary>
        public string Nome { get; set; }
        /// <summary>
        /// A informação adicional armazenada no nó.
        /// </summary>
        public object Info { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
        /// <summary>
        /// A lista de arcos associada ao nó.
        /// </summary>
        public List<Edge> Arcos { get; private set; }

        public bool Visited { get; set; }

        #endregion

        #region Construtores

        /// <summary>
        /// Cria um novo nó.
        /// </summary>
        public Node()
        {
            this.Arcos = new List<Edge>();
        }

        /// <summary>
        /// Cria um novo nó.
        /// </summary>
        /// <param name="name">O nome do nó.</param>
        /// <param name="info">A informação armazenada no nó.</param>
        public Node(string name, object info)
            : this()
        {
            this.Nome = name;
            this.Info = info;
        }

        public Node(string name, int x, int y)
            : this()
        {
            this.Nome = name;
            this.X = x;
            this.Y = y;
        }

        #endregion

        #region Métodos

        /// <summary>
        /// Adiciona um arco com nó origem igual ao nó atual, e destino e custo de acordo com os parâmetros.
        /// </summary>
        /// <param name="to">O nó destino.</param>
        public void AddEdge(Node to)
        {
            AddEdge(to, 0);
        }

        /// <summary>
        /// Adiciona um arco com nó origem igual ao nó atual, e destino e custo de acordo com os parâmetros.
        /// </summary>
        /// <param name="to">O nó destino.</param>
        /// <param name="cost">O custo associado ao arco.</param>
        public void AddEdge(Node to, double cost)
        {
            this.Arcos.Add(new Edge(this, to, cost));
        }

        #endregion

        #region Métodos Sobrescritos

        /// <summary>
        /// Apresenta a visualização do objeto em formato texto.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (this.Info != null)
            {
                return String.Format("{0}({1})", this.Nome, this.Info);
            }
            return this.Nome;
        }

        #endregion

    }
}
