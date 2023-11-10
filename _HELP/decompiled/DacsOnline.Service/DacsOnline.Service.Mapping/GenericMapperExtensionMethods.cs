using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DacsOnline.Service.Mapping
{
	public static class GenericMapperExtensionMethods
	{
		public static List<TViewModel> ConvertToListViewModel<TViewModel, TBusinessObject>(this List<TBusinessObject> businessObjects)
		{
			List<TViewModel> list = (
				from p in businessObjects
				select p.ConvertToViewModel<TViewModel, TBusinessObject>()).ToList<TViewModel>();
			return list;
		}

		public static TViewModel ConvertToViewModel<TViewModel, TBusinessObject>(this TBusinessObject businessObject)
		{
			Mapper.CreateMap<TBusinessObject, TViewModel>();
			return (TViewModel)Mapper.Map(businessObject, typeof(TBusinessObject), typeof(TViewModel));
		}
	}
}