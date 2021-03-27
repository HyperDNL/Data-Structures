using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_DS
{
    class Program
    {
        static void Main()
        {
            // Binary Tree

            Console.WriteLine("- - - - - - - - - - - - - - - - - - - - BINARY TREE SECTION - - - - - - - - - - - - - - - - - - - -");
            Tree<int> tree = new Tree<int>();
            Console.WriteLine("\nAntes de crear el Árbol:");
            Console.WriteLine("Is Empty: " + tree.IsEmpty);
            Console.WriteLine("Size: " + tree.Size(tree.RootNode));
            Console.WriteLine("Height: " + tree.HeightTree(tree.RootNode));

            tree.AddRoot(0); // Añadir Raíz

            Node<int> node1 = tree.AddLeftChild(tree.RootNode, 1); // Hijo izquierdo de 0
            Node<int> node2 = tree.AddLeftChild(node1, 2); // Hijo izquierdo de 1
            Node<int> node3 = tree.AddRightChild(node1, 3); // Hijo derecho de 1
            Node<int> node4 = tree.AddLeftChild(node2, 4); // Hijo izquierdo de 2
            Node<int> node5 = tree.AddRightChild(node2, 5); // Hijo derecho de 2
            Node<int> node6 = tree.AddLeftChild(node4, 6); // Hijo izquierdo de 4
            Node<int> node7 = tree.AddRightChild(tree.RootNode, 7); // Hijo derecho de 0
            Node<int> node8 = tree.AddRightChild(node7, 8); // Hijo derecho de 7
            Node<int> node9 = tree.AddLeftChild(node8, 9); // Hijo izquierdo de 8
            Node<int> node10 = tree.AddRightChild(node8, 10); // Hijo derecho de 8
            Node<int> node11 = tree.AddRightChild(node9, 11); // Hijo derecho de 9

            // Recorridos del Tree

            Console.WriteLine("\nDespués de crear Árbol y añadir sus Nodos:");
            Console.WriteLine("Is Empty: " + tree.IsEmpty);
            Console.WriteLine("Size: " + tree.Size(tree.RootNode));
            Console.WriteLine("Height: " + tree.HeightTree(tree.RootNode));
            Console.WriteLine("RootNode: " + tree.RootNode.Data);
            Console.WriteLine("\nRecorrido del Binary Tree:");
            Console.Write("\nRecorrido InOrder: ");
            tree.SelectOrder(1);
            Console.WriteLine(tree);
            Console.Write("Recorrido PreOrder: ");
            tree.SelectOrder(2);
            Console.WriteLine(tree);
            Console.Write("Recorrido PostOrder: ");
            tree.SelectOrder(3);
            Console.WriteLine(tree);

            // Pruebas eliminando Nodos

            Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - - ELIMINANDO NODOS - - - - - - - - - - - - - - - - - - - -");
            tree.DeleteNode(node3, false);
            Console.WriteLine("\nEliminando Nodo 3 - false");
            Console.WriteLine("\nIs Empty: " + tree.IsEmpty);
            Console.WriteLine("Size: " + tree.Size(tree.RootNode));
            Console.WriteLine("Height: " + tree.HeightTree(tree.RootNode));
            Console.WriteLine("RootNode: " + tree.RootNode.Data);
            Console.WriteLine("\nRecorrido del Binary Tree:");
            Console.Write("\nRecorrido InOrder: ");
            tree.SelectOrder(1);
            Console.WriteLine(tree);
            Console.Write("Recorrido PreOrder: ");
            tree.SelectOrder(2);
            Console.WriteLine(tree);
            Console.Write("Recorrido PostOrder: ");
            tree.SelectOrder(3);
            Console.WriteLine(tree);
            tree.DeleteNode(node4, false);
            Console.WriteLine("\nEliminando Nodo 4 - false");
            Console.WriteLine("\nIs Empty: " + tree.IsEmpty);
            Console.WriteLine("Size: " + tree.Size(tree.RootNode));
            Console.WriteLine("Height: " + tree.HeightTree(tree.RootNode));
            Console.WriteLine("RootNode: " + tree.RootNode.Data);
            Console.WriteLine("\nRecorrido del Binary Tree:");
            Console.Write("\nRecorrido InOrder: ");
            tree.SelectOrder(1);
            Console.WriteLine(tree);
            Console.Write("Recorrido PreOrder: ");
            tree.SelectOrder(2);
            Console.WriteLine(tree);
            Console.Write("Recorrido PostOrder: ");
            tree.SelectOrder(3);
            Console.WriteLine(tree);
            tree.DeleteNode(node9, false);
            Console.WriteLine("\nEliminando Nodo 9 - false");
            Console.WriteLine("\nIs Empty: " + tree.IsEmpty);
            Console.WriteLine("Size: " + tree.Size(tree.RootNode));
            Console.WriteLine("Height: " + tree.HeightTree(tree.RootNode));
            Console.WriteLine("RootNode: " + tree.RootNode.Data);
            Console.WriteLine("\nRecorrido del Binary Tree:");
            Console.Write("\nRecorrido InOrder: ");
            tree.SelectOrder(1);
            Console.WriteLine(tree);
            Console.Write("Recorrido PreOrder: ");
            tree.SelectOrder(2);
            Console.WriteLine(tree);
            Console.Write("Recorrido PostOrder: ");
            tree.SelectOrder(3);
            Console.WriteLine(tree);
            tree.DeleteNode(node2, true);
            Console.WriteLine("\nEliminando Nodo 2 - true");
            Console.WriteLine("\nIs Empty: " + tree.IsEmpty);
            Console.WriteLine("Size: " + tree.Size(tree.RootNode));
            Console.WriteLine("Height: " + tree.HeightTree(tree.RootNode));
            Console.WriteLine("RootNode: " + tree.RootNode.Data);
            Console.WriteLine("\nRecorrido del Binary Tree:");
            Console.Write("\nRecorrido InOrder: ");
            tree.SelectOrder(1);
            Console.WriteLine(tree);
            Console.Write("Recorrido PreOrder: ");
            tree.SelectOrder(2);
            Console.WriteLine(tree);
            Console.Write("Recorrido PostOrder: ");
            tree.SelectOrder(3);
            Console.WriteLine(tree);
            tree.DeleteNode(node8, true);
            Console.WriteLine("\nEliminando Nodo 8 - true");
            Console.WriteLine("\nIs Empty: " + tree.IsEmpty);
            Console.WriteLine("Size: " + tree.Size(tree.RootNode));
            Console.WriteLine("Height: " + tree.HeightTree(tree.RootNode));
            Console.WriteLine("RootNode: " + tree.RootNode.Data);
            Console.WriteLine("\nRecorrido del Binary Tree:");
            Console.Write("\nRecorrido InOrder: ");
            tree.SelectOrder(1);
            Console.WriteLine(tree);
            Console.Write("Recorrido PreOrder: ");
            tree.SelectOrder(2);
            Console.WriteLine(tree);
            Console.Write("Recorrido PostOrder: ");
            tree.SelectOrder(3);
            Console.WriteLine(tree);

            // Formas de crear Árboles

            Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - - FORMAS DE CREAR ÁRBOLES - - - - - - - - - - - - - - - - - - - -");
            Tree<string> tree2 = new Tree<string>("Forma 1");
            Console.WriteLine("\nRoot " + tree2.RootNode.Data);
            Console.WriteLine("Is Empty: " + tree2.IsEmpty);
            Console.WriteLine("Size: " + tree2.Size(tree2.RootNode));
            Console.WriteLine("Height: " + tree2.HeightTree(tree2.RootNode));
            Tree<string> tree3 = new Tree<string>();
            tree3.AddRoot("Forma 2");
            Console.WriteLine("\nRoot " + tree3.RootNode.Data);
            Console.WriteLine("Is Empty: " + tree3.IsEmpty);
            Console.WriteLine("Size: " + tree3.Size(tree3.RootNode));
            Console.WriteLine("Height: " + tree3.HeightTree(tree3.RootNode));

            //Tree Sort

            int[] arr = { 27, 48, 13, 50, 39, 77, 82, 91, 65, 19, 70, 66 };

            Tree<int> treeSort = new Tree<int>();

            Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - - TREE SORT SECTION - - - - - - - - - - - - - - - - - - - -");
            Console.WriteLine("\nAntes de crear el Árbol:");
            Console.WriteLine("Is Empty: " + treeSort.IsEmpty);
            Console.WriteLine("Size: " + treeSort.Size(treeSort.RootNode));
            Console.WriteLine("Height: " + treeSort.HeightTree(treeSort.RootNode));
            treeSort.TreeSort(arr);
            Console.Write("\nImprimiendo Tree Sort: ");
            Console.WriteLine(treeSort);
            Console.WriteLine("\nDespués de crear Árbol, añadir sus Nodos y ordenar:");
            Console.WriteLine("Is Empty: " + treeSort.IsEmpty);
            Console.WriteLine("Size: " + treeSort.Size(treeSort.RootNode));
            Console.WriteLine("Height: " + treeSort.HeightTree(treeSort.RootNode));
            Console.WriteLine("RootNode: " + treeSort.RootNode.Data);

            // Método ForEach - Class Tree<T>

            Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - - MÉTODO FOREACH - CLASS TREE<T> - - - - - - - - - - - - - - - - - - - -");
            int restaTree = 0;
            treeSort.ForEach(x => restaTree -= x);
            Console.WriteLine("\nLa resta de los elementos del TreeSort es: " + restaTree);
            int sumaTree = 0;
            treeSort.ForEach(x => sumaTree += x);
            Console.WriteLine("La suma de los elementos del TreeSort es: " + sumaTree);

            int resta = 0;
            tree.ForEach(x => resta -= x);
            Console.WriteLine("\nLa resta de los elementos del Tree es: " + resta);
            int suma = 0;
            tree.ForEach(x => suma += x);
            Console.WriteLine("La suma de los elementos del Tree es: " + suma);

            Console.WriteLine("\n- - - - - - - - - - - - - - - - - - - - MÉTODO FOREACH - EXTERNO - - - - - - - - - - - - - - - - - - - -");
            Console.Write("\nDatos del Array (TreeSort): ");

            foreach (var dato in treeSort)
            {
                Console.Write(dato + " ");
            }

            Console.ReadKey();
        }
    }
}
