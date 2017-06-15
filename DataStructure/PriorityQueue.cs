using System.Collections.Generic;

namespace KnightsTours.Telas
{
    public class PriorityQueue : LinkedList<Node>
    {
        public void Insert()
        {
            LinkedListNode<Node> listaNo = this.First;

            while(listaNo != null)
            {
                Node n = listaNo.Value;
                
            }
        }

        public Node Remove()
        {
            Node f = this.First.Value;
            this.RemoveFirst();
            return f;
        }

    }
}
