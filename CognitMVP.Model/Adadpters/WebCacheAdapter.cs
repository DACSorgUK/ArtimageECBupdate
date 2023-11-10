namespace DacsOnline.Model.Adadpters
{
    using System;
    using System.Web;
    using System.Web.Caching;
    using DacsOnline.Model.Enums;
    using DacsOnline.Model.Manager.Interfaces;

    /// <summary>
    /// Web Cache class
    /// </summary>
    public class WebCacheAdapter : ICache
    {
        #region Fields
        /// <summary>
        /// Cache variable
        /// </summary>
        private Cache _cache;
        #endregion Fields

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="WebCacheAdapter"/> class.
        /// </summary>
        public WebCacheAdapter()
        {
            this._cache = HttpContext.Current.Cache;
        }
        #endregion Constructors

        #region Indexers
        /// <summary>
        /// Gets the <see cref="System.Object"/> with the specified key.
        /// </summary>
        /// <param name="key">The key of the value to get.</param>
        /// <remarks></remarks>
        public object this[string key]
        {
            get 
            {
                return this.Get(key);
            }
        }
        #endregion Indexers

        #region Methods
        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key of the item to add.</param>
        /// <param name="value">The value to add.</param>
        /// <param name="type">The cache type.</param>
        /// <param name="minutes">The minutes to cache.</param>
        public void Add(string key, object value, CacheType type, int minutes)
        {
            switch (type)
            {
                case CacheType.ABSOLUTE:
                    this._cache.Add(key, value, null, DateTime.Now.AddMinutes(minutes), Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
                    break;

                case CacheType.SLIDING:
                    this._cache.Add(key, value, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, minutes, 0), CacheItemPriority.Normal, null);
                    break;
            }
        }

        /// <summary>
        /// Adds the specified key.
        /// </summary>
        /// <param name="key">The key of the item to add.</param>
        /// <param name="value">The value to add.</param>
        /// <param name="dependency">The dependancies.</param>
        public void Insert(string key, object value, CacheDependency dependency)
        {
             this._cache.Insert(key, value, dependency);
        }

        /// <summary>
        /// Gets the specified key.
        /// </summary>
        /// <param name="key">The key of the item to get.</param>
        /// <returns>Object with specified key</returns>
        public object Get(string key)
        {
            return this._cache.Get(key);
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        public System.Collections.IEnumerator GetEnumerator()
        {
            return this._cache.GetEnumerator();
        }

        /// <summary>
        /// Removes the specified key.
        /// </summary>
        /// <param name="key">The key to ??.</param>
        public void Remove(string key)
        {
            this._cache.Remove(key);
        }
        #endregion Methods
    }
}