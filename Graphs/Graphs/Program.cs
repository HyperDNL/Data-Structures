using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creando Grafo
            Graph<int> graph = new Graph<int>();

            Console.WriteLine("Antes de añadir Nodos...");
            Console.WriteLine("Is Empty: " + graph.IsEmpty);
            Console.WriteLine("Size: " + graph.Size);

            // Añadiendo Nodos al Grafo
            graph.AddNode(1);
            graph.AddNode(4);
            graph.AddNode(5);
            graph.AddNode(7);
            graph.AddNode(10);
            graph.AddNode(11);
            graph.AddNode(12);
            graph.AddNode(42);

            // Añadiendo Aristas entre los Nodos previamente añadidos
            graph.AddEdge(1, 5);
            graph.AddEdge(4, 11);
            graph.AddEdge(4, 42);
            graph.AddEdge(5, 11);
            graph.AddEdge(5, 12);
            graph.AddEdge(5, 42);
            graph.AddEdge(7, 10);
            graph.AddEdge(7, 11);
            graph.AddEdge(10, 11);
            graph.AddEdge(11, 42);
            graph.AddEdge(12, 42);

            Console.WriteLine("\nDespués de añadir Nodos...");

            Console.WriteLine(graph);
            Console.WriteLine("\nIs Empty: " + graph.IsEmpty);
            Console.WriteLine("Size: " + graph.Size);

            // Encontrando camino de recorrido
            Console.WriteLine("\nBúsquedas de diferentes casos");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Camino de 4 a 4 => " + graph.SearchPath(4, 4, graph, SearchType.Profundidad));
            Console.WriteLine("Camino de 4 a 0 => " + graph.SearchPath(4, 0, graph, SearchType.Profundidad));
            Console.WriteLine("Camino de 4 a 11 => " + graph.SearchPath(4, 11, graph, SearchType.Profundidad));
            Console.WriteLine("Camino de 4 a 42 => " + graph.SearchPath(4, 42, graph, SearchType.Amplitud));

            // Profundidad
            Console.WriteLine("\nBúsqueda por Profundidad");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Camino de 4 a 1 => " + graph.SearchPath(4, 1, graph, SearchType.Profundidad));

            // Amplitud
            Console.WriteLine("\nBúsqueda por Amplitud");
            Console.WriteLine("--------------------------");
            Console.WriteLine("Camino de 4 a 1 => " + graph.SearchPath(4, 1, graph, SearchType.Amplitud));

            Console.WriteLine("\nEliminando Nodos...");
            graph.RemoveNode(10);
            graph.RemoveNode(42);
            Console.WriteLine(graph);

            Console.WriteLine("\nEliminando Aristas...");
            graph.RemoveEdge(1, 5);
            Console.WriteLine(graph);

            Console.ReadKey();
        }
    }
}
