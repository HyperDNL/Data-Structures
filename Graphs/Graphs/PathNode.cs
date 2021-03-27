using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class PathNode<T>
    {
        // Información sobre un Nodo a lo largo de una ruta de búsqueda

        Node<T> previous; // Nodo auxiliar

        // Crea un Nodo de información con el Nodo anterior dado
        public PathNode(Node<T> previous)
        {
            this.previous = previous;
        }

        public Node<T> Previous { get => previous; } // Propiedad del Nodo auxiliar
    }
}
