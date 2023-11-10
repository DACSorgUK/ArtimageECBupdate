using DacsOnline.Model.Enums;
using DacsOnline.Model.Manager.Interfaces;
using System;
using System.Collections;
using System.Reflection;
using System.Web;
using System.Web.Caching;

namespace DacsOnline.Model.Adadpters
{
	public class WebCacheAdapter : ICache, IEnumerable
	{
		private Cache _cache;

		public object this[string key]
		{
			get
			{
				return this.Get(key);
			}
		}

		public WebCacheAdapter()
		{
			this._cache = HttpContext.Current.Cache;
		}

		public void Add(string key, object value, CacheType type, int minutes)
		{
			switch (type)
			{
				case CacheType.SLIDING:
				{
					this._cache.Add(key, value, null, Cache.NoAbsoluteExpiration, new TimeSpan(0, minutes, 0), CacheItemPriority.Normal, null);
					break;
				}
				case CacheType.ABSOLUTE:
				{
					Cache caches = this._cache;
					DateTime now = DateTime.Now;
					caches.Add(key, value, null, now.AddMinutes((double)minutes), Cache.NoSlidingExpiration, CacheItemPriority.Normal, null);
					break;
				}
			}
		}

		public object Get(string key)
		{
			return this._cache.Get(key);
		}

		public IEnumerator GetEnumerator()
		{
			return this._cache.GetEnumerator();
		}

		public void Insert(string key, object value, CacheDependency dependency)
		{
			this._cache.Insert(key, value, dependency);
		}

		public void Remove(string key)
		{
			this._cache.Remove(key);
		}
	}
}