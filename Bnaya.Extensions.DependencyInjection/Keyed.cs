namespace Microsoft.Extensions.DependencyInjection
{
    internal class Keyed<T> : Microsoft.Extensions.DependencyInjection.IKeyed<T> where T : class
    {
        private readonly IServiceProvider _serviceProvider;

        public Keyed(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        T IKeyed<T>.this[string key] =>
                            _serviceProvider.GetServices<IKeyedBridge<T>>()
                                .First(m => m.Key == key)
                                .Target;

        bool IKeyed<T>.TryGet(string key, out T value){
            var result = _serviceProvider.GetServices<IKeyedBridge<T>>()
                                .FirstOrDefault(m => m.Key == key)
                                ?.Target ?? default;
#pragma warning disable CS8601 
            value = result ?? default;
#pragma warning restore CS8601

            return value != null;
        }
    }
}
