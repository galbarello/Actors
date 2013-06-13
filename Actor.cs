public class Actor
{
    private Task lastTask = TaskEx.FromResult(0);
    private object objLock = newobject();
    
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