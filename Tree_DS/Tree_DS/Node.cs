using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_DS
{
    public class Node<T>
    {
        public T data;
        public Node<T> parent;
        public Node<T> leftchild;
        public Node<T> rightchild;
        public Tree<T> tree;
        public int height;

        // Constructor de la clase Node con instanciación de variables
        public Node(T data, Tree<T> tree, Node<T> parentNode)
        {
            this.data = data;
            this.parent = parentNode;
            this.tree = tree;
            leftchild = null;
            rightchild = null;

            if (parentNode == null)
            {
                Height = 0;
            }
            else
            {
                Height = Parent.Height + 1;
            }
        }

        public T Data { get => data; set => data = value; }
        public Node<T> Parent { get => parent; set => parent = value; }
        public Node<T> LeftChild { get => leftchild; set => leftchild = value; }
        public Node<T> RightChild { get => rightchild; set => rightchild = value; }
        public Tree<T> Tree { get => tree; set => tree = value; }
        public int Height { get; }


        // Devuelve True si no tiene Hijos (Nodo Hoja), devuelve False si tiene Hijos (Nodo Padre)
        public bool IsLeaf
        {
            get
            {
                return rightchild == null && leftchild == null;
            }
        }

        // Retorna True si tiene al menos un hijo (Derecho o izquierdo)
        public bool HasChildren
        {
            get
            {
                return rightchild != null || leftchild != null;
            }
        }

        // Retorna el Nodo hermano, si no tiene, devuelve Null
        public Node<T> GetSibling()
        {
            Node<T> rightChild = Parent.RightChild;
            Node<T> leftChild = Parent.LeftChild;
            if (parent == null)
            {
                throw new InvalidOperationException("Has no parent.");
            }
            if (rightChild == this)
            {
                return rightChild;
            }
            else
            {
                return leftChild;
            }
        }
    }
}
