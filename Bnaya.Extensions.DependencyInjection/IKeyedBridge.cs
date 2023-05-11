namespace Microsoft.Extensions.DependencyInjection
{
    internal interface IKeyedBridge<out T> where T : class
    {
        T Target { get; }

        string Key { get; }
    }
}
