namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Wrapper for keyed dependencies injection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IKeyed<out T> where T : class
    {
        /// <summary>
        /// Indexer for keyed dependencies injection
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        T this[string key] { get; }
    }
}
