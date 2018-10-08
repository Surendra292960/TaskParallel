using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallel
{
    class TaskParallel6
    {
        static void Main(string[] args)
        {
            var t1 = Task.Factory.StartNew(() => DoWork(1, 2000));
            var t2 = Task.Factory.StartNew(() => DoWork(2, 2500));
            var t3 = Task.Factory.StartNew(() => DoWork(3, 3000));

            var taskList = new List<Task> { t1, t2, t3 };
            Task.WaitAll(taskList.ToArray());

            for(var i = 0; i<10; i++ )
            {
                Console.WriteLine("Do some other work");
                Thread.Sleep(250);
                Console.WriteLine("i = {0}", i);
            }
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

