using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestAsync
{
    internal class Program
    {
        static void Main()
        {
            var demo = new AsyncAwaitDemo();
            demo.DoStuff();

            while (true)
            {
                Thread.Sleep(100);
                Console.WriteLine("Doing Stuff on the Main Thread...................");
            }
        }
        public class AsyncAwaitDemo
        {
            public async Task<string> DoStuff()
            {
                return await Task.Run(() => LongRunningOperation());
            }

            private static string LongRunningOperation()
            {
                int counter;

                for (counter = 0; counter < 5000000; counter++)
                {
                    Console.WriteLine(counter);
                    Thread.Sleep(100);
                }

                return "Counter = " + counter;
            }
        }
    }
}
