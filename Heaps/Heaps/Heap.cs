using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps
{
    class Heap<T>
    {
        List<T> dataContainer;

        // Devuelve el número de elementos de Heap
        public int Size => dataContainer.Count();

        // Devuelve true si el Heap está vacío, false si tiene elementos
        public bool IsEmpty => Size == 0;

        // Retorna la altura del Heap
        public double Height()
        {
            if (IsEmpty)
            {
                return 0;
            }
            return Math.Floor(Math.Truncate(Math.Log(Size, 2)) + 1);
        }

        // Constructor manual del Heap
        public Heap()
        {
            dataContainer = new List<T>();
        }

        // Constructor del Heap que recibe una colección de datos desordenada y el HeapSort la ordena
        public Heap(List<T> elements)
        {
            dataContainer = HeapSort(elements);
        }

        // Devuelve el valor mínimo del Heap sin eliminarlo
        public T Min()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Heap is empty.");
            }
            else
            {
                return dataContainer[0];
            }
        }

        // Añade elementos al Heap y reordena
        public void Insert(T data)
        {
            dataContainer.Add(data);
            UpHeapBubbling(GetLast());
        }

        // Devuelve y remueve el valor mínimo del Heap y reordena
        public T RemoveMin()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Heap is empty.");
            }

            T toRemove = Min();
            dataContainer[0] = dataContainer[GetLast()];
            dataContainer.RemoveAt(GetLast());
            DownHeapBubbling(0);

            return toRemove;
        }

        // Imprime el Heap
        public override string ToString()
        {
            return string.Join(", ", dataContainer.ToArray());
        }

        // SECCIÓN DE MÉTODOS PRIVADOS

        // Construye el Heap al recibir una colección de datos
        private static void Heapify(List<T> newList, int index)
        {
            int leftIndex = 2 * index + 1;
            int rightIndex = 2 * index + 2;
            int min = index;

            if (leftIndex < newList.Count && Comparer<T>.Default.Compare(newList[leftIndex], newList[min]) == -1)
            {
                min = leftIndex;
            }

            if (rightIndex < newList.Count && Comparer<T>.Default.Compare(newList[rightIndex], newList[min]) == -1)
            {
                min = rightIndex;
            }

            if (min != index)
            {
                T temp = newList[min];
                newList[min] = newList[index];
                newList[index] = temp;
                Heapify(newList, min);
            }
        }

        // Ordena el Heap al recibir una colección de datos desordenada
        private static List<T> HeapSort(List<T> newList)
        {
            for (int i = newList.Count - 1; i >= 0; i--)
            {
                Heapify(newList, i);
            }

            return newList;
        }

        // Reordena el Heap cuando el nuevo hijo insertado sea menor que su padre
        private void UpHeapBubbling(int index)
        {
            int current = index;
            int parent = GetParentIndex(current);

            while (current > 0 && (Comparer<T>.Default.Compare(dataContainer[current], dataContainer[parent]) == -1))
            {
                ReAsign(current, parent);
                current = parent;
                parent = GetParentIndex(current);
            }
        }

        // Reordena el Heap cuando se remueve el nodo más pequeño
        private void DownHeapBubbling(int index)
        {
            int small = index;
            int right = GetRightChildIndex(index);
            int left = GetLeftChildIndex(index);

            if (left < Size && (Comparer<T>.Default.Compare(dataContainer[left], dataContainer[small]) == -1))
            {
                small = left;
            }

            if (right < Size && (Comparer<T>.Default.Compare(dataContainer[right], dataContainer[small]) == -1))
            {
                small = right;
            }

            if (small != index)
            {
                ReAsign(index, small);
                DownHeapBubbling(small);
            }
        }

        // Obtiene el último Nodo
        private int GetLast()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Heap is empty.");
            }
            else
            {
                return dataContainer.Count - 1;
            }
        }

        // Intercambia los nodos
        private void ReAsign(int index1, int index2)
        {
            T temp = dataContainer[index1];
            dataContainer[index1] = dataContainer[index2];
            dataContainer[index2] = temp;
        }

        // Obtiene el Padre del Nodo Hijo
        private int GetParentIndex(int childIndex)
        {
            return ((childIndex - 1) / 2);
        }

        // Obtiene el Hijo Izquierdo del Padre
        private int GetLeftChildIndex(int parentIndex)
        {
            return (2 * parentIndex + 1);
        }

        // Obtiene el Hijo Derecho del Padre
        private int GetRightChildIndex(int parentIndex)
        {
            return (2 * parentIndex + 2);
        }
    }
}
