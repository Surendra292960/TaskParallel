using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallel
{

    class Program1
    {
        static Maths objMaths = new Maths();
        public static void Main()
        {
            Thread t1 = new Thread(objMaths.Divide);
            t1.Start();//child
            objMaths.Divide();//main
            Console.Read();
        }
    }
    class Maths
    {
        public int Num1;
        public int Num2;

        Random o = new Random();

        public void Divide()
        {
            for(long i = 0; i < 1000; i++)
            {
                lock (this)
                {
                    Num1 = o.Next(1, 2); //1 2
                    Num2 = o.Next(1, 2); //1 2
                    int result = Num1 / Num2; //main
                    Num1 = 0; //tozero
                    Num2 = 0;//child
                }
            }
        }
    }
}
