using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Graph<T>
    {
        // Lista que almacena los Nodos o Vértices
        List<Node<T>> nodes;

        // Constructor de la clase Graph<T>
        public Graph()
        {
            nodes = new List<Node<T>>();
        }

        // Devuelve el número de Nodos
        public int Size { get => nodes.Count(); }

        // Propiedad de los Nodos
        public List<Node<T>> Nodes { get => nodes; }

        // Devuelve True si el Grafo está vacío. False si no lo está
        public bool IsEmpty => Size == 0;

        // Limpia el Grafo, eliminando tanto Aristas como Nodos
        public void Clear()
        {
            // Elimina las Aristas del Grafo
            foreach (Node<T> node in nodes)
            {
                node.RemoveAllNeighbors();
            }

            // Elimina los Nodos del Grafo
            for (int i = nodes.Count() - 1; i >= 0; i++)
            {
                nodes.RemoveAt(i);
            }
        }

        // Añade un nuevo Nodo
        public void AddNode(T data)
        {
            if (Find(data) != null) // Comprueba si el Nodo existe...
            {
                throw new Exception("Node already exists."); // Si existe, devuelve una Excepción
            }
            else
            {
                nodes.Add(new Node<T>(data)); // En caso contrario, lo añade
            }
        }

        // Crea Aristas
        public void AddEdge(T data1, T data2)
        {
            // Asignación de Nodos
            Node<T> node1 = Find(data1);
            Node<T> node2 = Find(data2);

            if (node1 == null || node2 == null) // Comprueba si alguno de los dos Nodos es Nulo
            {
                throw new Exception("An Edge cannot be added."); // Si es así, devuelve una Excepción
            }
            else if (node1.AdjElements.Contains(node2)) // Comprueba si ya existe alguna Arista formada por esos Nodos
            {
                throw new Exception("Edge already exists."); // Si es así, devuelve una Excepción
            }
            else // En caso contrario... Crea la arista con esos Nodos
            {
                node1.AddNeighbor(node2); // El Nodo 1 es Adyacente al Nodo 2
                node2.AddNeighbor(node1); // El Nodo 2 es Adyacente al Nodo 1
            }
        }

        // Remueve algún nodo específico del Grafo
        public void RemoveNode(T data)
        {
            Node<T> toRemove = Find(data); // Nodo a remover

            if (toRemove == null) // Comprueba si el Nodo a remover es Nulo...
            {
                throw new Exception("Node does not exist."); // Si es así, devuelve una Excepción
            }
            else
            {
                // Eliminar como Nodo Adyacente para todos sus Nodos Vecinos
                nodes.Remove(toRemove);

                foreach (Node<T> node in nodes) // Recorre la lista de Nodos
                {
                    node.RemoveNeighbor(toRemove); // Se elimina el Nodo para cada Nodo que lo tenga como Vecino Adyacente
                }
            }
        }

        // Elimia la Arista con los elementos especificados
        public void RemoveEdge(T data1, T data2)
        {
            // Asignación de Nodos
            Node<T> node1 = Find(data1);
            Node<T> node2 = Find(data2);

            if (node1 == null || node2 == null) // Comprueba si alguno de los dos Nodos es Nulo
            {
                throw new Exception("Edge does not exist."); // Si es así, devuelve una Excepción
            }
            else if (!node1.AdjElements.Contains(node2)) // Comprueba si existe alguna Arista formada por estos Nodos
            {
                throw new Exception("Edge does not exist."); // Si no es así, devuelve una Excepción
            }
            else
            {
                // La Arista ya no existe para ninguno de los Nodos
                node1.RemoveNeighbor(node2);
                node2.RemoveNeighbor(node1);
            }
        }

        // Busca el valor del Nodo en la colección de Nodos
        public Node<T> Find(T data)
        {
            foreach (Node<T> node in nodes) // Recorre la lista de Nodos
            {
                if (node.Data.Equals(data)) // Si el valor del Nodo en cuestión existe en la lista de Nodos
                {
                    return node; // Retorna ese mismo Nodo
                }
            }

            return null; // En caso contrario, retorna null
        }

        // Convertir en String
        public override string ToString()
        {
            StringBuilder graphString = new StringBuilder();

            for (int i = 0; i < Size; i++)
            {
                graphString.Append(nodes[i].ToString());

                if (i < Size - 1)
                {
                    graphString.Append(", ");
                }
            }

            return graphString.ToString();
        }

        // Busca un camino de principio a fin
        public string SearchPath(T start, T finish, Graph<T> graph, SearchType type)
        {
            LinkedList<Node<T>> searchList = new LinkedList<Node<T>>();

            // Si ambos Nodos son el mismo
            if (Comparer<T>.Default.Compare(start, finish) == 0)
            {
                return start.ToString();
            }
            else if (graph.Find(start) == null || graph.Find(finish) == null) // En caso de que alguno de los Nodos sea Nulo
            {
                return "";
            }
            else
            {
                // Agregar Nodo de inicio al diccionario y lista de búsqueda
                Node<T> startNode = graph.Find(start);

                Dictionary<Node<T>, PathNode<T>> pathNodes = new Dictionary<Node<T>, PathNode<T>>();

                pathNodes.Add(startNode, new PathNode<T>(null));
                searchList.AddFirst(startNode);

                // Ciclo que se ejecuta hasta agotar todos los caminos posibles
                while (searchList.Count > 0)
                {
                    // Extrae el frente de la lista de búsqueda
                    Node<T> currentNode = searchList.First.Value;
                    searchList.RemoveFirst();

                    // Explora cada vecino Adyacente de este Nodo
                    foreach (Node<T> neighbor in currentNode.AdjElements)
                    {
                        // Verifica si el Nodo en la lista de Adyacentes es igual al Final
                        if (Comparer<T>.Default.Compare(neighbor.Data, finish) == 0)
                        {
                            pathNodes.Add(neighbor, new PathNode<T>(currentNode));
                            return ConvertPathToString(neighbor, pathNodes);
                        }
                        else if (pathNodes.ContainsKey(neighbor)) // Si el nodo ya ha sido visitado...
                        {
                            // Encontró un ciclo, así que salta este vecino
                            continue;
                        }
                        else
                        {
                            // Vincular vecino al Nodo actual en la ruta
                            pathNodes.Add(neighbor, new PathNode<T>(currentNode));

                            // Agregar vecino al frente o al final de la lista de búsqueda
                            if (type == SearchType.Profundidad)
                            {
                                searchList.AddFirst(neighbor);
                            }
                            else
                            {
                                searchList.AddLast(neighbor);
                            }
                        }
                    }
                }

                // No se encontró ningún camino
                return "";
            }
        }

        // Convierte la información del Nodo final y del nodo de ruta especificados a una ruta desde el Nodo de inicio hasta el Nodo final
        public String ConvertPathToString(Node<T> endNode, Dictionary<Node<T>, PathNode<T>> pathNodes)
        {
            // Construye una lista vinculada para la ruta en el orden correcto
            LinkedList<Node<T>> path = new LinkedList<Node<T>>();
            path.AddFirst(endNode);
            Node<T> previous = pathNodes[endNode].Previous;

            while (previous != null)
            {
                path.AddFirst(previous);
                previous = pathNodes[previous].Previous;
            }

            // Construye y retorna un String
            StringBuilder pathString = new StringBuilder();

            LinkedListNode<Node<T>> currentNode = path.First;
            int nodeCount = 0;
            pathString.Append("Recorrido: [ ");
            while (currentNode != null)
            {
                nodeCount++;
                pathString.Append(currentNode.Value.Data);

                if (nodeCount < path.Count)
                {
                    pathString.Append(" ");
                }
                currentNode = currentNode.Next;
            }
            pathString.Append(" ]");
            pathString.Append(" Distancia: " + nodeCount);

            return pathString.ToString();
        }
    }
}
