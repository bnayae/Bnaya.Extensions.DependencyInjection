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
    }
}
