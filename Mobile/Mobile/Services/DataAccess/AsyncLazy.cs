using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Mobile.Services.DataAccess
{
    public class AsyncLazy<T>
    {
        private readonly Lazy<Task<T>> _instance;

        public AsyncLazy(Func<T> factory) => _instance = new Lazy<Task<T>>(() => Task.Run(factory));

        public AsyncLazy(Func<Task<T>> factory) => _instance = new Lazy<Task<T>>(factory);

        public TaskAwaiter<T> GetAwaiter() => _instance.Value.GetAwaiter();
    }
}