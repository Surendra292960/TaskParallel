using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallel
{
    class TaskParallel2
    {
        static void Main(string[] args)
        {
            //var t1 = new Task(() => DoWork(1, 1000));
            //t1.Start();
            //var t2 = new Task(() => DoWork(2, 2000));
            //t2.Start();
            //var t3 = new Task(() => DoWork(3, 3000));
            //t3.Start();
            //Console.WriteLine("Press any ke to exit....!");


            //Task t1 = Task.Factory.StartNew(() => DoWork(1, 2000));
            //Task t2 = Task.Factory.StartNew(() => DoWork(2, 2500));
            //Task t3 = Task.Factory.StartNew(() => DoWork(3, 3000));

            Task t1 = Task.Factory.StartNew(() => DoWork(1, 2000)).ContinueWith((prev) => DoOtherWork(1, 2000));
            Task t2 = Task.Factory.StartNew(() => DoWork(2, 3000)).ContinueWith((prev) => DoOtherWork(2, 6000));
            Task t3 = Task.Factory.StartNew(() => DoWork(3, 4000)).ContinueWith((prev) => DoOtherWork(3, 7000));

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
