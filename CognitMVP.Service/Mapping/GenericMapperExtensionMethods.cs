using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace DacsOnline.Service.Mapping
{
    public static class GenericMapperExtensionMethods
    {
        #region //Public Methods
        /// <summary>
        /// Converts to list view model.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <typeparam name="TBusinessObject">The type of the business object.</typeparam>
        /// <param name="businessObjects">The business objects.</param>
        /// <returns></returns>
        public static List<TViewModel> ConvertToListViewModel<TViewModel, TBusinessObject>(this List<TBusinessObject> businessObjects)
        {
            return businessObjects.Select(p => p.ConvertToViewModel < TViewModel, TBusinessObject>()).ToList();
        }

        /// <summary>
        /// Converts to view model.
        /// </summary>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <typeparam name="TBusinessObject">The type of the business object.</typeparam>
        /// <param name="businessObject">The business object.</param>
        /// <returns></returns>
        public static TViewModel ConvertToViewModel<TViewModel, TBusinessObject>(this TBusinessObject businessObject)
        {
            Mapper.CreateMap<TBusinessObject, TViewModel>();
            var viewModel = (TViewModel)Mapper.Map(businessObject, typeof(TBusinessObject), typeof(TViewModel));
            return viewModel;
        }
        #endregion
    }
}
