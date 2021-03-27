using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("- - - - - - - - - - - - - - - - - - HEAP MANUAL - - - - - - - - - - - - - - - - - -");
            Heap<int> test1 = new Heap<int>();

            Console.WriteLine("\nAntes de añadir elementos...");
            Console.WriteLine("Is Empty: " + test1.IsEmpty);
            Console.Write("Size: " + test1.Size);
            Console.WriteLine("\nHeight: " + test1.Height());

            test1.Insert(77);
            test1.Insert(33);
            test1.Insert(10);
            test1.Insert(45);
            test1.Insert(7);
            test1.Insert(51);
            test1.Insert(26);
            test1.Insert(31);
            test1.Insert(44);
            test1.Insert(2);
            test1.Insert(6);
            test1.Insert(23);
            test1.Insert(17);
            test1.Insert(26);
            test1.Insert(22);
            test1.Insert(39);
            test1.Insert(8);
            test1.Insert(0);

            Console.WriteLine("\nDespués de añadir elementos...");
            Console.Write("Heap: ");
            Console.WriteLine(test1);
            Console.WriteLine("Is Empty: " + test1.IsEmpty);
            Console.Write("Size: " + test1.Size);
            Console.WriteLine("\nHeight: " + test1.Height());
            Console.WriteLine("Min Value: " + test1.Min());

            Console.WriteLine("\n- - - - - - - - - - - - - - - - - - REMOVIENDO ELEMENTOS - - - - - - - - - - - - - - - - - -");
            Console.Write("\nRemove Min: " + test1.RemoveMin());
            Console.Write("\nHeap: ");
            Console.WriteLine(test1);
            Console.WriteLine("Is Empty: " + test1.IsEmpty);
            Console.Write("Size: " + test1.Size);
            Console.WriteLine("\nHeight: " + test1.Height());
            Console.WriteLine("Min Value: " + test1.Min());

            Console.Write("\nRemove Min: " + test1.RemoveMin());
            Console.Write("\nHeap: ");
            Console.WriteLine(test1);
            Console.WriteLine("Is Empty: " + test1.IsEmpty);
            Console.Write("Size: " + test1.Size);
            Console.WriteLine("\nHeight: " + test1.Height());
            Console.WriteLine("Min Value: " + test1.Min());

            Console.Write("\nRemove Min: " + test1.RemoveMin());
            Console.Write("\nHeap: ");
            Console.WriteLine(test1);
            Console.WriteLine("Is Empty: " + test1.IsEmpty);
            Console.Write("Size: " + test1.Size);
            Console.WriteLine("\nHeight: " + test1.Height());
            Console.WriteLine("Min Value: " + test1.Min());

            Console.WriteLine("\n- - - - - - - - - - - - - - - - - - HEAPSORT - - - - - - - - - - - - - - - - - -");
            List<int> list = new List<int> { 35, 33, 42, 10, 14, 19, 27, 44, 26, 31 };

            Heap<int> test2 = new Heap<int>(list);

            Console.Write("\nHeapSort: ");
            Console.WriteLine(test2);
            Console.WriteLine("Is Empty: " + test2.IsEmpty);
            Console.Write("Size: " + test2.Size);
            Console.WriteLine("\nHeight: " + test2.Height());
            Console.WriteLine("Min Value: " + test2.Min());

            Console.WriteLine("\n- - - - - - - - - - - - - REMOVIENDO ELEMENTOS DEL HEAP - - - - - - - - - - - - -");
            Console.Write("\nRemove Min: " + test2.RemoveMin());
            Console.Write("\nHeapSort: ");
            Console.WriteLine(test2);
            Console.WriteLine("Is Empty: " + test2.IsEmpty);
            Console.Write("Size: " + test2.Size);
            Console.WriteLine("\nHeight: " + test2.Height());
            Console.WriteLine("Min Value: " + test2.Min());

            Console.Write("\nRemove Min: " + test2.RemoveMin());
            Console.Write("\nHeapSort: ");
            Console.WriteLine(test2);
            Console.WriteLine("Is Empty: " + test2.IsEmpty);
            Console.Write("Size: " + test2.Size);
            Console.WriteLine("\nHeight: " + test2.Height());
            Console.WriteLine("Min Value: " + test2.Min());

            Console.Write("\nRemove Min: " + test2.RemoveMin());
            Console.Write("\nHeapSort: ");
            Console.WriteLine(test2);
            Console.WriteLine("Is Empty: " + test2.IsEmpty);
            Console.Write("Size: " + test2.Size);
            Console.WriteLine("\nHeight: " + test2.Height());
            Console.WriteLine("Min Value: " + test2.Min());

            Console.ReadKey();
        }
    }
}
