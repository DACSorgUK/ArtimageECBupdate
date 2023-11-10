using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Presentation.Views;
using DacsOnline.Service.Service.Interfaces;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Utilities;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace DacsOnline.Presentation.Presenters
{
    public class ArtMarketSalesFormPresenter: BasePresenter<IArtMarketSalesFormView>, IDisposable
    {
        #region //Private Properties
        /// <summary>
        ///
        /// </summary>
        IArtMarketSalesFormService salesFormService;
        #endregion

        public ArtMarketSalesFormPresenter(IArtMarketSalesFormView view, IArtMarketSalesFormService service)
            : base(view)
        {
            view.SubmitData += new EventHandler(SaveSalesFormData);
            view.LoadData += new EventHandler(LoadFormData);
            salesFormService = service;
        }

        #region //Public Methods
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.View.SubmitData -= new EventHandler(SaveSalesFormData);
            this.View.LoadData -= new EventHandler(LoadFormData);
        }
        #endregion

        #region //Private Methods

        /// <summary>
        /// Saves the sales form load data.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LoadFormData(object sender, EventArgs e)
        {
            string[] Title = salesFormService.LoadTitles();
            this.View.BindTitles(Title);
            SalesContactDetails obj = salesFormService.LoadCookieObject();
            if (obj != null)
            {
                this.View.AddressLine1 = obj.AddressLine1;
                this.View.AddressLine2 = obj.AddressLine2;
                this.View.AddressLine3 = obj.AddressLine3;
                this.View.City = obj.City;
                this.View.Company = obj.Company;
                this.View.Country = obj.Country;
                this.View.CountyRegion = obj.CountyRegion;
                this.View.EmailAddress = obj.EmailAddress;
                this.View.Fax = obj.Fax;
                this.View.LastName = obj.LastName;
                this.View.Mobile = obj.Mobile;
                this.View.Name = obj.Name;
                this.View.Phone = obj.Phone;
                this.View.PostCode = obj.PostCode;
                this.View.Title = obj.Title;
                this.View.Website = obj.Website;
            }
        }

        /// <summary>
        /// Saves the sales form data.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SaveSalesFormData(object sender, EventArgs e)
        {
            SalesContactDetails obj = new SalesContactDetails();
            obj.AddressLine1 = this.View.AddressLine1;
            obj.AddressLine2 = this.View.AddressLine2;
            obj.AddressLine3 = this.View.AddressLine3;
            obj.City = this.View.City;
            obj.Company=this.View.Company;
            obj.Country = this.View.Country;
            obj.CountyRegion = this.View.CountyRegion;
            obj.EmailAddress = this.View.EmailAddress;
            obj.Fax = this.View.Fax;
            obj.LastName = this.View.LastName;
            obj.Mobile = this.View.Mobile;
            obj.Name = this.View.Name;
            obj.Phone = this.View.Phone;
            obj.PostCode = this.View.PostCode;
            obj.Title = this.View.Title;
            obj.Website = this.View.Website;
           int recordId;
            bool status=salesFormService.Submit(obj,this.View.SalesInformation,out recordId);
            if (status && this.View.RememberDetails)
                    salesFormService.SaveCookie(obj);



            if (status)
            {
                string url = string.Format(this.View.ConfirmationUrl + "?Id={0}&form={1}", recordId, "AMPS");
                System.Web.HttpContext.Current.Session["emailUser"] = this.View.EmailAddress;
                this.View.RedirectForm(url);
            }
            else
            {
                this.View.ShowError();
            }
        }
        #endregion
    }
}
