namespace DacsOnline.Model.Manager.Interfaces
{
    using System.Collections;
    using System.Web;
    using System.Web.Caching;
    using DacsOnline.Model.Enums;

    /// <summary>
    /// Cache Interface
    /// </summary>
    public interface ICache : IEnumerable
    {
        #region Properties
        /// <summary>
        /// Gets the <see cref="System.Object"/> with the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <value>Cached object</value>
        object this[string key]
        {
            get;
        }
        #endregion Properties

        #region Methods
        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key of the item to add.</param>
        /// <param name="value">The value to add.</param>
        /// <param name="type">The cache type.</param>
        /// <param name="minutes">The minutes to cache.</param>
        void Add(string key, object value, CacheType type, int minutes);

        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key of the item to add.</param>
        /// <param name="value">The value to add.</param>
        /// <param name="dependancy">The dependancy for this cached item.</param>
        void Insert(string key, object value, CacheDependency dependancy);

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key of the item to get.</param>
        /// <returns>Object with specified key</returns>
        object Get(string key);

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key to ??.</param>
        void Remove(string key);
        #endregion Methods
    }
}