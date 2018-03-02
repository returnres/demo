using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        [ThreadStatic]
        private static int _count = 5;


        public static ThreadLocal<int> _countLocal =
            new ThreadLocal<int>(() => 5);

        static void Main(string[] args)
        {
            int nnn = 0;
            var t = Task.Run(() =>
            {
                for (int i = 1; i < 100000000; i++)
                {
                    //nnn++;
                    Interlocked.Increment(ref nnn);
                }
            });

            for (int i = 1; i < 100000000; i++)
            {
                //nnn--;
                Interlocked.Decrement(ref nnn);
            }
            t.Wait();
            Console.WriteLine("nnn = " + nnn);
            Console.ReadLine();

            return;

            object _sync = new object();

            //Concurrence
            var list = Enumerable.Range(0, 100000);
            List<int> ll = new List<int>();
            Parallel.ForEach(list, item =>
            {
                //senza questo ll non sarà 100000 ma meno
                lock (_sync)
                {
                    int x = item - 100;
                    ll.Add(x);
                }

                //int x = item - 100;
                //ll.Add(x);
            });

            Console.WriteLine("tot l " + ll.Count);
            Console.ReadLine();

            Thread th = new Thread(new ThreadStart(() => {Console.WriteLine("th");}));
            Thread th1 = new Thread(new ThreadStart(delegate { Console.WriteLine("th1"); }));
            Thread th2 = new Thread(new ThreadStart(Dosometh2));
            Thread th3 = new Thread(new ThreadStart(Dosometh3));
            Console.WriteLine(th.ThreadState);
            Console.ReadLine();
            th.Start();
            Console.WriteLine("_count main:" + _count);
            Console.WriteLine("_countLocal main:" + _countLocal.Value);
            th2.Start();
            th3.Start();
            Console.WriteLine(th.ThreadState);
            Console.ReadLine();

        }


        static void Dosometh2()
        {
            _count++;
            _countLocal.Value++;
            Console.WriteLine("_count th2:" + _count);
            Console.WriteLine("_countLocal th2:" + _countLocal.Value);

        }
        static void Dosometh3()
        {
            _count++;
            _countLocal.Value++;
            Console.WriteLine("_count th3:" + _count);
            Console.WriteLine("_countLocal th3:" + _countLocal.Value);

        }
    }
}
