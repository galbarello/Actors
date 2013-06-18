using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Moravia.Rulebase.Domain;
using Moravia.Rulebase.Domain.Config;

namespace Moravia.Rulebase.ConsoleTest
{
    class Program
    {
        
        private static int sleepy = 1;
        
        

        static void Main(string[] args)
        {
            var tasks = new List<Task>();
            var clock = new Stopwatch();

            var document = SegmentCreator.GetSegments("en", "es");
            
            Bootstrapper.Init();    

            clock.Start();

            //this should be catched before

            for (int i = 0; i < Bootstrapper.RuleGetter(); i++)
            {               
                tasks.Add(Bootstrapper.Actors()[i].Execute(Eval, new Segment()));
            }            
            

            Console.WriteLine("done queuing");
            Task.WaitAll(tasks.ToArray());
            clock.Stop();
            Console.WriteLine("Enlapsed:" + clock.Elapsed);
            
            Console.ReadLine();
        }

        // dummy task (4 sec sleep)
        static async Task<bool> Eval(Segment segment)
        {
            await Task.Delay(TimeSpan.FromSeconds(sleepy));
            return true;
        }
    }    
}
