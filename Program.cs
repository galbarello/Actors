public class Program
{
    static int NoActors = 50000;
    
    static async void Main(string[] args)
    {
        var actors = new Actor[NoActors];
        var tasks = new List<Task>();
        
        for (int i = 0; i < NoActors; i++)
        {
            actors[i] = new Actor();
            actors[i].Execute(Foo, i);
        }
        
        Console.WriteLine("done queuing");
        Task.WaitAll(tasks.ToArray());
        Console.ReadLine();
    }
    
    static async Task<string> Foo(int i)
    {
        await TaskEx.Delay(TimeSpan.FromSeconds(4));
        Console.WriteLine("done " + i);
        
        return "done";
    }
}