using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Moravia.Rulebase.ConsoleTest
{
    class Program
    {
        private static int Actors = 100000;
        private static int sleepy = 4;
        

        static void Main(string[] args)
        {
            var clock = new Stopwatch();
            var actors = new Actor[Actors];
            var tasks = new List<Task>();
            clock.Start();
            for (int i = 0; i < Actors; i++)
            {
                actors[i] = new Actor();
               tasks.Add(actors[i].Execute(Foo, i));
            }

            Console.WriteLine("done queuing");
            Task.WaitAll(tasks.ToArray());
            clock.Stop();
            Console.WriteLine("Enlapsed:" + clock.Elapsed);
            
            Console.ReadLine();
        }

        // dummy task (4 sec sleep)
        static async Task<string> Foo(int i)
        {
            
            
            await Task.Delay(TimeSpan.FromSeconds(sleepy));
            Console.WriteLine("done " + i);            
            
            return "done";
        }
    }
}
