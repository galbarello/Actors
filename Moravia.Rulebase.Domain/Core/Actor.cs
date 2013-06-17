using System;
using System.Threading.Tasks;

public class Actor
{
    private Task lastTask = Task.FromResult(0);
    private object objLock = new object();
    
    public Task<R> Execute<T, R>(Func<T, Task<R>> function, T arg)
    {
        if (!function.Method.IsStatic)
        {
            new ArgumentException("Function must be static");    
        }
        
        var tcs = new TaskCompletionSource<R>();
        
        Task<R> task = null;
        
        lock (this.objLock)
        {
            task = this.lastTask.ContinueWith(_ => function(arg)).Unwrap();
            this.lastTask = task;
        }
        
        task.ContinueWith(t => tcs.TrySetResult(t.Result), TaskContinuationOptions.OnlyOnRanToCompletion);
        task.ContinueWith(t => tcs.TrySetException(t.Exception), TaskContinuationOptions.OnlyOnFaulted);
        task.ContinueWith(t => tcs.TrySetCanceled(), TaskContinuationOptions.OnlyOnCanceled);
        
        return tcs.Task;
    }
}