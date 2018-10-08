using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallel
{
    class TaskParalel9
    {
        static void Main(string[] args)
        {
            try
            {
                CancellationTokenSource cts = new CancellationTokenSource();
                CancellationToken ct = cts.Token;
                ParallelOptions po = new ParallelOptions { CancellationToken = ct, MaxDegreeOfParallelism = System.Environment.ProcessorCount };

                Parallel.Invoke(po,
                        new Action(() => DoWork(1, ct)),
                        new Action(() => DoWork(2, ct)),
                        new Action(() => DoWork(3, ct)),
                        new Action(() => DoWork(4, ct)),
                        new Action(() => DoWork(5, ct)),
                        new Action(() => DoWork(6, ct)),
                        new Action(() => { cts.Cancel(); }),
                        new Action(() => DoWork(7, ct)),
                        new Action(() => DoWork(8, ct))
                    );
            }
            catch (OperationCanceledException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }

        static void DoWork(int args, CancellationToken ct)
        {
            Console.WriteLine("Hello DoWork");
        }
    }
}
