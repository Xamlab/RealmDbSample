using System;
using System.Threading.Tasks;

namespace RealmDBSample.Core.Extensions
{
    public static class Misc
    {
        public static Action<Action> InvokeOnMainThreadAction { get; set; }

        public static void InvokeOnMainThread(Action action)
        {
            InvokeOnMainThreadAction?.Invoke(action);
        }

        public static Task<T> InvokeOnMainThread<T>(Func<Task<T>> action)
        {
            var task = new TaskCompletionSource<T>();
            InvokeOnMainThreadAction?.Invoke(async () =>
                                             {
                                                 var result = await action();
                                                 task.TrySetResult(result);
                                             });
            return task.Task;
        }

        //public static void PublishOnMainThread<T>(this object obj, T message)
        //{
        //    InvokeOnMainThread(() => obj.Publish(message));
        //}
    }
}