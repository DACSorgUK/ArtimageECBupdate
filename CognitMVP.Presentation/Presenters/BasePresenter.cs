using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Utilities.Interfaces;
using Microsoft.Practices.Unity;
using WebFormsMvp;

namespace DacsOnline.Presentation.Presenters
{
    public abstract class BasePresenter<TView> : Presenter<TView>
        where TView : class, IView
    {
        #region //Constructor
        public BasePresenter(TView view)
            : base(view)
        {
        }
        #endregion

        #region //Public Properties
        /// <summary>
        /// Gets or sets the event log service.
        /// </summary>
        /// <value>
        /// The event log service.
        /// </value>
        [Dependency]
        public IEventLogService EventLogService { get; set; }
        #endregion

    }
}
