using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallel
{
    class TaskParallel7
    {

        static void Main(string[] args)
        {
           // var intList = new List<int> { 1, 2, 5, 6, 7, 8, 76, 5, 3, 54, 6, 78, 9, 7, 6, 5, 4, 4 };

            Parallel.For(0, 100, (i) => Console.WriteLine(i+","));
            Parallel.For(0, 100, (i) => Console.WriteLine(i + ","));

            // Parallel.ForEach(intList, (i) => Console.WriteLine(i));

            Console.WriteLine("Press any key");
            Console.ReadKey();
        }

        static void DoWork(int id, int sleep)
        {
            Console.WriteLine("Task {0} DoWork is begining...", id);
            Thread.Sleep(sleep);
            Console.WriteLine("Task {0} DoWork is completed...", id);
        }

        static void DoOtherWork(int id, int sleep)
        {
            Console.WriteLine("Task {0} DoOtherWork is begining...", id);
            Thread.Sleep(sleep);
            Console.WriteLine("Task {0} DoOtherWork is completed...", id);
        }
    }
}

