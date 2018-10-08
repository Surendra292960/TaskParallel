using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallel
{
    class TaskParallel8
    {
        static void Main(string[] args)
        {
            var source = new CancellationTokenSource();

            try
            {
                var t1 = Task.Factory.StartNew(() => DoWork(1, 2000,source.Token)).ContinueWith((prev) => DoOtherWork(1, 3000, source.Token));
                source.Cancel();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType());
            }     
            Console.WriteLine("Press any key");
            Console.ReadKey();
        }
        static void DoWork(int id, int sleep,CancellationToken token)
        {
            if(token.IsCancellationRequested)
            {
                Console.WriteLine("Cancellation requested.");
                token.ThrowIfCancellationRequested();
            }
            Console.WriteLine("Task {0} DoWork is begining...", id);
            Thread.Sleep(sleep);
            Console.WriteLine("Task {0} DoWork is completed...", id);
        }
        static void DoOtherWork(int id, int sleep,CancellationToken token)
        {
            if(token.IsCancellationRequested)
            {
                Console.WriteLine("Cancellation requested.");
                token.ThrowIfCancellationRequested();
            }
            Console.WriteLine("Task {0} DoOtherWork is begining...", id);
            Thread.Sleep(sleep);
            Console.WriteLine("Task {0} DoOtherWork is completed...", id);
        }
    }
}