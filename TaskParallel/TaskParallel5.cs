using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallel
{
    class TaskParallel5
    {
        static void Main(string[] args)
        {
            var t1 = new Task(() => DoWork(1, 1000));
            t1.Start();
            var t2 = new Task(() => DoWork(2, 2000));
            t2.Start();
            var t3 = new Task(() => DoWork(3, 3000));
            t3.Start();
            Console.WriteLine("Press any ke to exit....!");
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

