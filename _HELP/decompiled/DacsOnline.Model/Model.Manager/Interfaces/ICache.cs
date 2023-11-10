using DacsOnline.Model.Enums;
using System;
using System.Collections;
using System.Reflection;
using System.Web.Caching;

namespace DacsOnline.Model.Manager.Interfaces
{
	public interface ICache : IEnumerable
	{
		object this[string key]
		{
			get;
		}

		void Add(string key, object value, CacheType type, int minutes);

		object Get(string key);

		void Insert(string key, object value, CacheDependency dependancy);

		void Remove(string key);
	}
}