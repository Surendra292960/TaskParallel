using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallel
{
    class Autoreset
    {
        static AutoResetEvent objAuto = new AutoResetEvent(false);

        //static ManualResetEvent objAuto = new ManualResetEvent(false);


        static void Main(string[] args)
        {

            new Thread(SomeMethod).Start();
            //signal to start again
            Console.ReadLine();
            //signal to start again
            objAuto.Set(); //wait at 2
            Console.ReadLine();
            objAuto.Set();

            Console.ReadLine();
        }

        static void SomeMethod()
        {
          // 1st
            Console.WriteLine("Starting 1.....");
            objAuto.WaitOne();
            Console.WriteLine("Finishing 1.....");
          //2nd
            Console.WriteLine("Starting 2.....");
            objAuto.WaitOne();
            Console.WriteLine("Finishing 2.....");
        }
    }
}
