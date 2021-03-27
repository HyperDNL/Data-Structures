using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Node<T>
    {
        // Valor del elemento
        T data;

        // Lista que guarda a los elementos Adyacentes (Vecinos)
        List<Node<T>> adjElements;

        // Constructor
        public Node(T data)
        {
            this.data = data;
            adjElements = new List<Node<T>>();
        }

        // Propiedad del valor del elemento
        public T Data { get => data; }

        public List<Node<T>> AdjElements { get => adjElements; }

        // Añade un elemento nuevo
        public void AddNeighbor(Node<T> element)
        {
            // Comprueba si el elemento que se quiere añadir existe
            if (adjElements.Contains(element))
            {
                throw new Exception("Element already exists."); // Si existe, devuelve una Excepción
            }
            else
            {
                adjElements.Add(element); // En caso contrario, lo añade a la lista
            }
        }

        // Remueve un elemento específico
        public bool RemoveNeighbor(Node<T> element)
        {
            return adjElements.Remove(element); // Si existe, lo remueve
        }

        // Remueve todos los elementos
        public void RemoveAllNeighbors()
        {
            for (int i = adjElements.Count - 1; i >= 0; i++) // Ciclo que recorre los índices de la lista de elementos
            {
                adjElements.RemoveAt(i); // Remueve el elemento en el índice especificado por el Iterador
            }
        }

        // Convierte los elementos en String
        public override string ToString()
        {
            StringBuilder elementString = new StringBuilder();

            elementString.Append("[Data: " + data + " Neighbors: ");
            for (int i = 0; i < adjElements.Count; i++)
            {
                elementString.Append(adjElements[i].data + " ");
            }
            elementString.Append("]");

            return elementString.ToString();
        }
    }
}
