using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Presentation.Views;
using DacsOnline.Service.Service.Interfaces;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Utilities;

namespace DacsOnline.Presentation.Presenters
{
    public class CopyRightLicencingFormPresenter : BasePresenter<ICopyRightLicencingFormView>, IDisposable
    {
        #region //Private Properties
        /// <summary>
        /// 
        /// </summary>
        ICopyRightLicencingFormService copyrightFormService;
        #endregion

        public CopyRightLicencingFormPresenter(ICopyRightLicencingFormView view, ICopyRightLicencingFormService service)
            : base(view)
        {
            view.SubmitData += new EventHandler(SaveCopyrightFormData);
            view.LoadData += new EventHandler(LoadFormData);
            copyrightFormService = service;
        }

        #region //Public Methods
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.View.SubmitData -= new EventHandler(SaveCopyrightFormData);
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
            string[] Title = copyrightFormService.LoadTitles();
            this.View.BindTitles(Title);
            CopyrightLicencingFormdata obj = copyrightFormService.LoadCookieObject();
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
               /// this.View.Fax = obj.Fax;
                this.View.LastName = obj.LastName;
               /// this.View.Mobile = obj.Mobile;
                this.View.Name = obj.Name;
                this.View.Phone = obj.Phone;
                this.View.PostCode = obj.PostCode;
                this.View.Title = obj.Title;
                this.View.Website = obj.Website;
                this.View.VatNumber = obj.VatNumber;
                this.View.BillingEmailAddress = obj.BillingEmailAddress;
                this.View.BillingContactName = obj.BillingContactName;
                this.View.UseContactDetailsInvoice = obj.UseContactDetails;


                this.View.InvoiceCompany = obj.InvoiceCompany;
                this.View.InvoiceAddressLine1 = obj.InvoiceAddressLine1;
                this.View.InvoiceAddressLine2 = obj.InvoiceAddressLine2;
                this.View.InvoiceAddressLine3 = obj.InvoiceAddressLine3;
                this.View.InvoiceCity = obj.InvoiceCity;
                this.View.InvoiceCountry = obj.InvoiceCountry;
                this.View.InvoiceCountyRegion = obj.InvoiceCountyRegion;
                this.View.InvoicePostCode = obj.InvoicePostCode;
                this.View.Files = obj.Files;

            }

            
           
        }


        /// <summary>
        /// Saves the copyright form data.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SaveCopyrightFormData(object sender, EventArgs e)
        {
            CopyrightLicencingFormdata obj = new CopyrightLicencingFormdata();
            obj.AddressLine1 = this.View.AddressLine1;
            obj.AddressLine2 = this.View.AddressLine2;
            obj.AddressLine3 = this.View.AddressLine3;
            obj.City = this.View.City;
            obj.Company=this.View.Company;
            obj.Country = this.View.Country;
            obj.CountyRegion = this.View.CountyRegion;
            obj.EmailAddress = this.View.EmailAddress;
           //// obj.Fax = this.View.Fax;
            obj.LastName = this.View.LastName;
          ////  obj.Mobile = this.View.Mobile;
            obj.Name = this.View.Name;
            obj.Phone = this.View.Phone;
            obj.PostCode = this.View.PostCode;
            obj.Title = this.View.Title;
            obj.Website = this.View.Website;
            obj.VatNumber = this.View.VatNumber;
            obj.BillingContactName = this.View.BillingContactName;
            obj.BillingEmailAddress = this.View.BillingEmailAddress;
            obj.UseContactDetails = this.View.UseContactDetailsInvoice;

            obj.InvoiceAddressLine1 = this.View.InvoiceAddressLine1;
            obj.InvoiceAddressLine2 = this.View.InvoiceAddressLine2;
            obj.InvoiceAddressLine3 = this.View.InvoiceAddressLine3;
            obj.InvoiceCity = this.View.InvoiceCity;
            obj.InvoiceCompany = this.View.InvoiceCompany;
            obj.InvoiceCountry = this.View.InvoiceCountry;
            obj.InvoiceCountyRegion = this.View.InvoiceCountyRegion;
            obj.InvoicePostCode = this.View.InvoicePostCode;
            obj.Files = this.View.Files;

            int recordId;
            bool status = copyrightFormService.Submit(obj, this.View.CopyRightLicencingProductInformation, out recordId);
            if (status && this.View.RememberDetails)
                copyrightFormService.SaveCookie(obj);
           


            if (status)
            {
                string url = string.Format(this.View.ConfirmationUrl + "?Id={0}&form={1}", recordId, "CL");
                System.Web.HttpContext.Current.Session.Clear();
                System.Web.HttpContext.Current.Session["emailUser"] = this.View.EmailAddress;

                this.View.RedirectForm(url);
            }
            else
            {
                System.Web.HttpContext.Current.Session.Clear();
                this.View.ShowError();
            }
        }
        #endregion
    }
}
