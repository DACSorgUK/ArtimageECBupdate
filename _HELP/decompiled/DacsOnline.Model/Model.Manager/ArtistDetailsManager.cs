using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Model.Models;
using DacsOnline.Model.RepostioriesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace DacsOnline.Model.Manager
{
	public class ArtistDetailsManager : BaseManager<IARRArtistSearchRepository>, IArtistDetailsManager
	{
		private List<Nationality> _listNationlity;

		private IARRArtistSearchManager _arrManager;

		private ICLArtistSearchManager _clManager;

		public ArtistDetailsManager(IARRArtistSearchRepository ArtistDetailsRepository, IARRArtistSearchManager arrManager, ICLArtistSearchManager clManager) : base(ArtistDetailsRepository)
		{
			this._arrManager = arrManager;
			this._clManager = clManager;
			this._listNationlity = base.Repository.GetNationalities();
		}

		public ArtistCombined GetArtist(int idArtist, string YearSale)
		{
			int year;
			string str;
			List<Artist> list = base.Repository.GetArtistsData();
			Artist obj = (
				from p in list
				where p.ArtistId.Trim() == idArtist.ToString()
				select p).FirstOrDefault<Artist>();
			ArtistARRModel objArr = new ArtistARRModel();
			if (string.IsNullOrEmpty(YearSale))
			{
				year = DateTime.Now.Year;
				str = year.ToString();
			}
			else
			{
				str = YearSale;
			}
			this._arrManager.SetMessages(obj, objArr, str);
			ArtistCLModel objCL = new ArtistCLModel();
			ICLArtistSearchManager cLArtistSearchManager = this._clManager;
			year = DateTime.Now.Year;
			cLArtistSearchManager.SetMessages(obj, objCL, year.ToString());
			ArtistCombined objCombined = new ArtistCombined()
			{
				ArtistId = obj.ArtistId,
				ARREligibilityMessage = objArr.EligibilityMessage,
				ARRMandateMessage = objArr.MandateMessage,
				ARRPaymentMessage = objArr.PaymentMessage,
				DisplayArr = objArr.DisplayArr,
				CLImageHireMessage = objCL.ImageHireMessage,
				CLMoreInfoMessage_1 = objCL.MoreInfoMessage_1,
				CLMoreInfoMessage_2 = objCL.MoreInfoMessage_2,
				CLRepresentationMessage = objCL.RepresentationMessage,
				CLServiceDurationMessage = objCL.ServiceDurationMessage,
				CLShowApplyFor = objCL.ShowApplyFor,
				WarningMesssage = objArr.WarningMesssage
			};
			if (objCombined.CLShowApplyFor)
			{
				objCombined.CLArtistDetailsMessage = this.GetMessage("CLArtistDetailsMessage_DACS");
			}
			else if (objCombined.CLMoreInfoMessage_1.Equals(objCombined.CLArtistDetailsMessage))
			{
				objCombined.CLMoreInfoMessage_1 = string.Empty;
			}
			objCombined.FirstName = obj.FirstName;
			objCombined.LastName = obj.LastName;
			objCombined.Nationality = obj.GetNationality(this._listNationlity);
			objCombined.DateOfBirth = this.GetBirthYear(obj);
			objCombined.DateOfDeath = this.GetDeathYear(obj);
			objCombined.Pseudonyms = this.GetPseudonyms(obj);
			return objCombined;
		}

		private string GetBirthYear(Artist obj)
		{
			string str;
			if (!obj.DateOfBirth.HasValue)
			{
				str = (obj.YearOfBirth == null ? string.Empty : obj.YearOfBirth);
			}
			else
			{
				str = obj.DateOfBirth.Value.Year.ToString();
			}
			return str;
		}

		private string GetDeathYear(Artist obj)
		{
			string str;
			if (!obj.DateOfDeath.HasValue)
			{
				str = (obj.YearOfDeath == null ? string.Empty : obj.YearOfDeath);
			}
			else
			{
				str = obj.DateOfDeath.Value.Year.ToString();
			}
			return str;
		}

		private string GetMessage(string key)
		{
			return HttpContext.GetGlobalResourceObject("DACSOnlineResources", key) as string;
		}

		private string GetPseudonyms(Artist obj)
		{
			string returnText = string.Empty;
			if ((!string.IsNullOrEmpty(obj.Pseudonym_1.Trim()) || !string.IsNullOrEmpty(obj.Pseudonym_2.Trim()) || !string.IsNullOrEmpty(obj.Pseudonym_3.Trim()) || !string.IsNullOrEmpty(obj.Pseudonym_4.Trim()) || !string.IsNullOrEmpty(obj.Pseudonym_5.Trim()) ? true : !string.IsNullOrEmpty(obj.Pseudonym_6.Trim())))
			{
				if (!string.IsNullOrEmpty(obj.Pseudonym_1.Trim()))
				{
					returnText = string.Concat(obj.Pseudonym_1.Trim(), "; ");
				}
				if (!string.IsNullOrEmpty(obj.Pseudonym_2.Trim()))
				{
					returnText = string.Concat(returnText, obj.Pseudonym_2.Trim(), "; ");
				}
				if (!string.IsNullOrEmpty(obj.Pseudonym_3.Trim()))
				{
					returnText = string.Concat(returnText, obj.Pseudonym_3.Trim(), "; ");
				}
				if (!string.IsNullOrEmpty(obj.Pseudonym_4.Trim()))
				{
					returnText = string.Concat(returnText, obj.Pseudonym_4.Trim(), "; ");
				}
				if (!string.IsNullOrEmpty(obj.Pseudonym_5.Trim()))
				{
					returnText = string.Concat(returnText, obj.Pseudonym_5.Trim(), "; ");
				}
				if (!string.IsNullOrEmpty(obj.Pseudonym_6.Trim()))
				{
					returnText = string.Concat(returnText, obj.Pseudonym_6.Trim(), "; ");
				}
				if (returnText.Length > 2)
				{
					returnText = returnText.Substring(0, returnText.Length - 2);
				}
			}
			else
			{
				returnText = "None";
			}
			return returnText;
		}
	}
}