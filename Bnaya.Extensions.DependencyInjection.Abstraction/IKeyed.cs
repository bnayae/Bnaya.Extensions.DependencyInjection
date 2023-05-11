namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// Wrapper for keyed dependencies injection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IKeyed<T> where T : class
    {
        /// <summary>
        /// Indexer for keyed dependencies injection
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        T this[string key] { get; }

        /// <summary>
        /// Tries to get a keyed value if exists.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        bool TryGet(string key, out T value);
    }
}
