using DacsOnline.Model.Enums;
using DacsOnline.Model.Models;
using DacsOnline.Model.Utilities.Interfaces;
using DacsOnline.Presentation.Views;
using DacsOnline.Service.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using WebFormsMvp;

namespace DacsOnline.Presentation.Presenters
{
	public class ARRArtistSearchPresenter : BasePresenter<IARRArtistSearchView>, IDisposable
	{
		private IARRArtistSearchService _service;

		public ARRArtistSearchPresenter(IARRArtistSearchView view, IARRArtistSearchService service) : base(view)
		{
			base.View.FilterOnClick += new SearchArtistInvoke(this.SearchArtist);
			base.View.PageOnLoad += new EventHandler(this.InitialisePage);
			base.View.SetSearchCookie += new EventHandler(this.SetConfirmCookie);
			this._service = service;
		}

		public void Dispose()
		{
			base.View.FilterOnClick -= new SearchArtistInvoke(this.SearchArtist);
			base.View.PageOnLoad -= new EventHandler(this.InitialisePage);
			base.View.SetSearchCookie -= new EventHandler(this.SetConfirmCookie);
		}

		private void InitialisePage(object sender, EventArgs ee)
		{
			base.View.BindYears(this._service.GetSalesYears());
			base.View.SetControls(this.ReadConfirmCookie());
		}

		private bool ReadConfirmCookie()
		{
			bool flag;
			try
			{
				if ((System.Web.HttpContext.Current.Request.Cookies["DacsOnline.ARRSearchFormCookie"] == null ? true : string.IsNullOrEmpty(System.Web.HttpContext.Current.Request.Cookies["DacsOnline.ARRSearchFormCookie"].Value)))
				{
					flag = false;
				}
				else
				{
					string value = System.Web.HttpContext.Current.Request.Cookies["DacsOnline.ARRSearchFormCookie"].Value.Replace("DacsOnline.ARRSearchFormCookie=", "");
					flag = Convert.ToBoolean(value);
				}
			}
			catch (Exception exception)
			{
				base.EventLogService.LogData(MessageType.Error, "Cookie Convert Error", exception.Message);
				flag = false;
			}
			return flag;
		}

		private void SearchArtist(string Year, string ArtistFirstName, string ArtistLastName, int Pgae, int PageSize)
		{
			int totalItems;
			int exactMatches;
			try
			{
				List<ArtistARRModel> list = this._service.GetArtists(Year, ArtistFirstName, ArtistLastName, Pgae, PageSize, out totalItems, out exactMatches);
				base.View.SetPagingControl(totalItems, PageSize, Pgae, ArtistFirstName, ArtistLastName, Year, exactMatches);
				base.View.Display(list);
			}
			catch (Exception exception)
			{
				base.EventLogService.LogData(MessageType.Error, "SearchArtist-presenter", exception.Message);
				throw;
			}
		}

		private void SetConfirmCookie(object sender, EventArgs ee)
		{
			HttpCookie dacsCookies = new HttpCookie("DacsOnline.ARRSearchFormCookie");
			System.Web.HttpContext.Current.Response.Cookies.Clear();
			System.Web.HttpContext.Current.Response.Cookies.Add(dacsCookies);
			dacsCookies.Values.Add("DacsOnline.ARRSearchFormCookie", "True");
			System.Web.HttpContext.Current.Response.Cookies["DacsOnline.ARRSearchFormCookie"].Expires = DateTime.Now.AddDays(30);
		}
	}
}