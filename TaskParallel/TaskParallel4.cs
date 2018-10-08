using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallel
{
    class TaskParallel4
    {
        static void Main(string[] args)
        {
            Task t1 = Task.Factory.StartNew(() => DoWork(1, 2000));
            Task t2 = Task.Factory.StartNew(() => DoWork(2, 2500));
            Task t3 = Task.Factory.StartNew(() => DoWork(3, 3000));
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

