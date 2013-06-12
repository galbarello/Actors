class Program
         2:  {
         3:  
      static
      int NoActors = 50000;
         4:   
         5:  
      static async void Main(string[] args)
         6:      {
         7:          var actors = new BlockingActor[NoActors];
         8:          var tasks = new List<Task>();
         9:   
        10:  
      for (int i = 0; i < NoActors; i++)
        11:          {
        12:              actors[i] = new BlockingActor();
        13:              actors[i].Execute(Foo, i);
        14:          }
        15:   
        16:          Console.WriteLine("done queuing");
        17:          Task.WaitAll(tasks.ToArray());
        18:          Console.ReadLine();
        19:      }
        20:   
        21:  
      static async Task<string> Foo(int i)
        22:      {
        23:          await TaskEx.Delay(TimeSpan.FromSeconds(4));
        24:          Console.WriteLine("done " + i);
        25:  
      return
      "done";
        26:      }
        27:  }