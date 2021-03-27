using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_DS
{
    public class Tree<T> : IEnumerable
    {
        // Propiedades de la clase Árbol

        public int HeightTree(Node<T> root) // Devuelve la altura del Árbol (Raíz)
        {
            if (root == null) // Si el arbol está vacío...
            {
                return 0; //Retorna 0
            }

            if (root.IsLeaf) // Si el arbol es Hoja...
            {
                return 1; // Retorna 1
            }

            int left = 0;
            int right = 0;

            if (root.LeftChild != null) // Inicia recursividad por cada rama del hijo izquierdo
            {
                left = HeightTree(root.LeftChild);
            }

            if (root.RightChild != null) // Inicia recursividad por cada rama del hijo derecho
            {
                right = HeightTree(root.RightChild);
            }

            if (left > right) // Devuelve la altura de cada rama (Izquierda/Derecha)
            {
                return left + 1;
            }
            else
            {
                return right + 1;
            }
        }

        public int Size(Node<T> root) // Devuelve el total de Nodos en el Árbol
        {
            if (root == null) // Si el Árbol está vacío...
            {
                return 0; //Devuelve 0
            }
            else // En caso contrario...
            {
                return 1 + Size(root.RightChild) + Size(root.LeftChild); // Se llama a sí misma para cada hijo (Acumula su valor)...
            }
        }

        public Node<T> RootNode { get; set; }

        // Constructor de la clase Árbol con sus respectivas instanciaciones (Sin raíz)
        public Tree()
        {
            RootNode = null;
        }

        // Constructor de la clase Árbol con sus respectivas instanciaciones (Con raíz)
        public Tree(T root)
        {
            RootNode = new Node<T>(root, this, null);
        }

        // Comprueba si el Árbol está vacío
        public bool IsEmpty
        {
            get
            {
                return this.RootNode == null;
            }
        }

        //Método para crear el Nodo Raíz del Árbol
        public void AddRoot(T value)
        {
            if (IsEmpty) // Comprueba si la Raíz está vacía
            {
                RootNode = new Node<T>(value, this, null); // Si está vacía, crea la Raíz con el valor asignado
            }
            else
            {
                throw new InvalidOperationException("Root exists."); // Si la Raíz existe y se quiere poner otra, devuelve excepción
            }
        }

        // Añade un hijo derecho al Nodo especificado
        public Node<T> AddRightChild(Node<T> node, T value)
        {
            if (node.Tree != this) // Comprueba que el Nodo sea parte del Árbol...
            {
                throw new InvalidOperationException("Invalid action."); // De no serlo, devuelve excepción
            }

            if (IsEmpty) // Comprueba si la raíz está vacía
            {
                AddRoot(value); // Si está vacía, crea la Raíz con el valor asignado
                return RootNode; // Retorna la Raíz creada
            }
            else // En caso contrario...
            {
                if (node.RightChild == null) // Comprueba si el hijo derecho del Nodo está vacío
                {
                    node.RightChild = new Node<T>(value, this, node); // Si está vacío, crea el Nodo con el valor especificado
                    return node.RightChild; // Retorna el Nodo
                }
                else
                {
                    throw new InvalidOperationException("Right child exists."); // Si el hijo derecho existe, devuelve excepción
                }
            }
        }

        // Añade un hijo izquierdo al Nodo especificado
        public Node<T> AddLeftChild(Node<T> node, T value)
        {
            if (node.Tree != this) // Comprueba que el Nodo sea parte del Árbol...
            {
                throw new InvalidOperationException("Invalid action."); // De no serlo, devuelve excepción
            }

            if (IsEmpty) // Comprueba si la raíz está vacía
            {
                AddRoot(value); // Si está vacía, crea la Raíz con el valor asignado
                return RootNode; // Retorna la Raíz creada
            }
            else // En caso contrario...
            {
                if (node.LeftChild == null) // Comprueba si el hijo izquierdo del Nodo está vacío
                {
                    node.LeftChild = new Node<T>(value, this, node); // Si está vacío, crea el Nodo con el valor especificado
                    return node.LeftChild; // Retorna el Nodo
                }
                else
                {
                    throw new InvalidOperationException("Left child exists."); // Si el hijo izquierdo existe, devuelve excepción
                }
            }
        }

        // Elimina el Nodo especificado según la condición
        public void DeleteNode(Node<T> node, bool decision)
        {
            if (node.Tree != this) // Comprueba que el Nodo sea parte del Árbol...
            {
                throw new InvalidOperationException("Invalid action."); // De no serlo, devuelve excepción
            }

            if (decision) // Si condición es true...
            {
                if (RootNode == node) // Comprueba si el Nodo es la Raíz...
                {
                    RootNode = null; // De ser así, elimina el Árbol
                }
                else // En caso contrario...
                {
                    Node<T> temp = node.Parent; // Auxiliar que toma el valor del Nodo Padre del Nodo a eliminar...
                    if (temp.LeftChild == node) // Si el hijo izquierdo del Padre es igual al Nodo a eliminar...
                    {
                        temp.LeftChild = null; // El hijo izquierdo es Null (Tanto el Nodo como sus hijos son eliminados)
                    }

                    if (temp.RightChild == node) // Si el hijo derecho del Padre es igual al Nodo a eliminar...
                    {
                        temp.RightChild = null; // El hijo derecho es Null (Tanto el Nodo como sus hijos son eliminados)
                    }
                }
            }
            else // Si condición es false...
            {
                if (node.IsLeaf || node.HasChildren) // Comprueba que el Nodo a eliminar sea un Nodo hoja o que tenga por lo menos un hijo...
                {
                    if (RootNode == node) // Comprueba si el Nodo es la Raíz...
                    {
                        RootNode = null; // De ser así, elimina el Árbol
                    }
                    else // En caso contrario...
                    {
                        Node<T> temp = node.Parent; // Auxiliar que toma el valor del Nodo Padre del Nodo a eliminar...
                        if (temp.LeftChild == node) // Si el hijo izquierdo del Padre es igual al Nodo a eliminar...
                        {
                            temp.LeftChild = null; // El hijo izquierdo es Null (Tanto el Nodo como sus hijos son eliminados (Si tiene alguno))
                        }

                        if (temp.RightChild == node) // Si el hijo derecho del Padre es igual al Nodo a eliminar...
                        {
                            temp.RightChild = null; // El hijo derecho es Null (Tanto el Nodo como sus hijos son eliminados (Si tiene alguno))
                        }
                    }
                }
                else
                {
                    throw new InvalidOperationException("Invalid action."); // En caso contrario, devuelve excepción
                }
            }
        }

        // Recorrido del Árbol

        private List<T> dataContainer = new List<T>();

        public void InOrder(Node<T> node, Action<T> action = null) // LCH-P-RCH
        {
            if (node == null) // Si el Nodo está vacío...
            {
                throw new InvalidOperationException("Is empty."); // Devuelve excepción
            }

            if (node.LeftChild != null) // Si el hijo izquierdo existe...
            {
                InOrder(node.LeftChild, action); // Llamada recursiva aplicada a ese Nodo
            }

            if (action != null) // Si la acción es diferente de null...
            {
                action(node.Data); // Toma el valor del Nodo
            }

            dataContainer.Add(node.Data); // Añadir los elementos a la lista...

            if (node.RightChild != null) // Si el hijo derecho existe...
            {
                InOrder(node.RightChild, action); // Llamada recursiva aplicada a ese Nodo
            }

            return;
        }

        public void PreOrder(Node<T> node, Action<T> action = null) // P-LCH-RCH
        {
            if (node == null) // Si el Nodo está vacío...
            {
                throw new InvalidOperationException("Is empty."); // Devuelve excepción
            }

            if (action != null) // Si la acción es diferente de null...
            {
                action(node.Data); // Toma el valor del Nodo
            }

            dataContainer.Add(node.data); // Añadir los elementos a la lista...

            if (node.LeftChild != null) // Si el hijo izquierdo existe...
            {
                PreOrder(node.LeftChild, action); // Llamada recursiva aplicada a ese Nodo
            }

            if (node.RightChild != null) // Si el hijo derecho existe...
            {
                PreOrder(node.RightChild, action); // Llamada recursiva aplicada a ese Nodo
            }

            return;
        }

        public void PostOrder(Node<T> node, Action<T> action = null) // LCH-RCH-P
        {
            if (node == null) // Si el Nodo está vacío...
            {
                throw new InvalidOperationException("Is empty."); // Devuelve excepción
            }

            if(node.LeftChild != null) // Si el hijo izquierdo existe...
            {
                PostOrder(node.LeftChild, action); // Llamada recursiva aplicada a ese Nodo
            }

            if(node.RightChild != null) // Si el hijo derecho existe...
            {
                PostOrder(node.RightChild, action); // Llamada recursiva aplicada a ese Nodo
            }

            if (action != null) // Si la acción es diferente de null...
            {
                action(node.Data); // Toma el valor del Nodo
            }

            dataContainer.Add(node.Data); // Añadir los elementos a la lista...

            return;
        }

        // Enumerador de selección de recorrido
        public enum ProcessOrder
        {
            InOrder = 0,
            PreOrder = 1,
            PostOrder = 2
        }

        ProcessOrder order;

        public int SelectOrder(int elec) // Método para elegir el tipo de recorrido del árbol
        {
            switch(elec)
            {
                case 1:
                    order = ProcessOrder.InOrder;
                    return 1;
                case 2:
                    order = ProcessOrder.PreOrder;
                    return 2;
                case 3:
                    order = ProcessOrder.PostOrder;
                    return 3;
                default: // Default = InOrder
                    order = ProcessOrder.InOrder;
                    return default;
            }
            
            throw new InvalidOperationException("Invalid selection."); // Devuelve excepción en caso de elegir incorrectamente
        }

        public void ForEach(Action<T> action) // Recibe acción a ejecutar sobre cada nodo del Árbol. Recorre el Árbol con respecto al orden de la propiedad ProcessOrder...
        {
            if (order == ProcessOrder.InOrder)
            {
                InOrder(RootNode, action);
            }

            if (order == ProcessOrder.PreOrder)
            {
                PreOrder(RootNode, action);
            }

            if (order == ProcessOrder.PostOrder)
            {
                PostOrder(RootNode, action);
            }
        }

        public override string ToString() // Método de impresión y recorrido del Árbol con respecto al orden de la propiedad ProcessOrder...
        {
            if (order == ProcessOrder.InOrder)
            {
                dataContainer.Clear();
                InOrder(RootNode);
                return string.Join(", ", dataContainer.ToArray());
            }

            if (order == ProcessOrder.PreOrder)
            {
                dataContainer.Clear();
                PreOrder(RootNode);
                return string.Join(", ", dataContainer.ToArray());
            }

            if (order == ProcessOrder.PostOrder)
            {
                dataContainer.Clear();
                PostOrder(RootNode);
                return string.Join(", ", dataContainer.ToArray());
            }

            throw new InvalidOperationException("Invalid operation.");
        }


        // Tree Sort Section

        public void Add(Node<T> node, T value)
        {
            // Si el valor a añadir es mayor al valor del Nodo padre...
            if(Comparer<T>.Default.Compare(node.Data, value) == -1)
            {
                if (node.RightChild != null) // Verifica si el hijo derecho existe...
                {
                    Add(node.RightChild, value); // Se llama la misma función aplicándose al hijo derecho existente
                }
                else // De no existir el hijo derecho...
                {
                    node.RightChild = new Node<T>(value, this, node); // Se crea un Nodo nuevo tomando como valor el dato
                }
            }
            else // En caso contrario, si el valor del dato es menor al valor del Nodo padre...
            {
                if (node.LeftChild != null) // Verifica si el hijo izquierdo existe...
                {
                    Add(node.LeftChild, value); // Se llama la misma función aplicándose al hijo izquierdo existente
                }
                else // De no existir el hijo izquierdo...
                {
                    node.LeftChild = new Node<T>(value,this, node); // Se crea un Nodo nuevo tomando como valor el dato
                }
            }
        }

        public string TreeSort(T[] array)
        {
            if (RootNode == null) // Comprueba si el Árbol está vacío...
            {
                this.AddRoot(array[0]); // En caso de que no exista, la Raíz será el índice cero del Arreglo

                for (int i = 1; i < array.Length; i++) // Para cada índice mientras i sea menor que el tamaño del Arreglo
                {
                    Add(RootNode, array[i]); // Se llama la función para añadir Nodos, pasándole como parámetro la Raíz, y el Arreglo donde i corresponde a cada índice...
                }

                dataContainer.Clear(); // Se limpia la lista donde se van a acumular los datos...
                InOrder(RootNode); // Se llama el método InOrder, y se pasa como parámetro el Árbol
                return string.Join(", ", dataContainer.ToArray()); // Se retornan los datos de la lista convirtiéndose a Array...
            }
            else
            {
                throw new InvalidOperationException("Invalid action."); // Si la condición principal no se cumple, genera excepción
            }
        }

        // Iterator Section

        private class Enumerator : IEnumerator
        {
            private int currentIndex;
            private List<T> iterList = new List<T>();

            public Enumerator(Tree<T> tree)
            {
                tree.ForEach(x => iterList.Add(x));
                currentIndex = -1;
            }

            public object Current => iterList[currentIndex];

            public bool MoveNext()
            {
                if (currentIndex + 1 == iterList.Count)
                {
                    return false;
                }

                currentIndex++;
                return true;
            }

            public void Reset() => currentIndex = -1;
        }

        public IEnumerator GetEnumerator()
        {
            return new Enumerator(this);
        }
    }
}
