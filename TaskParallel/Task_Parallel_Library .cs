using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskParallel
{
    class Task_Parallel_Library
    {
        static void Main(string[] args)
        {
            RunOperation obj = new RunOperation();
            Console.WriteLine("Creating and Running Task implicitely");
            obj.parallelinvoke_implicitly();
            Console.WriteLine();
            Console.WriteLine("Creating and Running task explicitely");
            obj.parallelinvoke_explicitly_01();
            Console.WriteLine();
            Console.WriteLine("Creating and Running Task explicitely by reference");
            obj.parallelinvoke_explicitly_03();
            Console.ReadLine();
        }
    }

    class RunOperation
    {
        static RunOperation() { }

        public void parallelinvoke_implicitly()
        {
            Parallel.Invoke(() => Console.WriteLine("Perform Operation 1"),() => Console.WriteLine("Perfom Operation 2"));
        }

        public void parallelinvoke_explicitly_01()
        {
            Parallel.Invoke(() => doWork("task- One"),() => doWork("Task- Two"),() => doWork("Task- Three"));
        }
        private void doWork(string input)
        {
            Console.WriteLine("I have been cancelled by '{0}'", input);
        }
        public void parallelinvoke_explicitly_03()
        {
            Parallel.Invoke(action1);
        }

        Action action1 = new Action(delegate
        {
            Console.WriteLine("Hi.......I am actionDelegate.....I am inline coded with anonymous type");
        });
    }
}
