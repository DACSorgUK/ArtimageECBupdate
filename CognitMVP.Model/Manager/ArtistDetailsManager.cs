using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Model.RepostioriesInterfaces;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Models;
using System.Web;
using DacsOnline.Model.Utilities;
using System.Configuration;
using DacsOnline.Model.DACSArtistSearchWebService;
using AutoMapper;
using DacsOnline.Model.Enums;

namespace DacsOnline.Model.Manager
{
    public class ArtistDetailsManager : BaseManager<IARRArtistSearchRepository>, IArtistDetailsManager
    {
        #region //Private Properties
        /// <summary>
        /// 
        /// </summary>
        private List<Nationality> _listNationlity;
        private IARRArtistSearchManager _arrManager;
        private ICLArtistSearchManager _clManager;
        #endregion

        #region constructor
        public ArtistDetailsManager(IARRArtistSearchRepository ArtistDetailsRepository, IARRArtistSearchManager arrManager, ICLArtistSearchManager clManager)
            : base(ArtistDetailsRepository)
        {
            _arrManager = arrManager;
            _clManager = clManager;
            _listNationlity = this.Repository.GetNationalities();
        }
        #endregion

        #region //Public Methods
        /// <summary>
        /// Gets the artist.
        /// </summary>
        /// <param name="idArtist">The id artist.</param>
        /// <returns></returns>
        public ArtistCombined GetArtist(int idArtist, string idArtistString)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback =
              ((sender, certificate, chain, sslPolicyErrors) => true);

            string dataSource = ConfigurationManager.AppSettings["ArtistSearchSource"].ToString();
            string key = ConfigurationManager.AppSettings["CRMWebServiceAccessKey"].ToString();

            List<Artist> list = new List<Business_Objects.Artist>();
            Artist obj = new Business_Objects.Artist();

            if (dataSource == "DACS_SITE")
            {

                list = this.Repository.GetArtistsData();
                obj = list.Where(p => p.ArtistId.Trim() == idArtist.ToString()).FirstOrDefault();
            }
            else if (dataSource == "CRM")
            {

                Guid id = new Guid(idArtistString);
                DACSAccessSoapClient _service = new DACSArtistSearchWebService.DACSAccessSoapClient();
                DACSArtist _DACSAtrist = _service.SearchArtistDetail(id);

                //  Artist artist = new Business_Objects.Artist();

                Mapper.CreateMap<DACSArtist, Artist>()
                    .ForMember(x => x.ARRConfirmedNationality, opt => opt.Ignore())
                    .ForMember(x => x.ARRMembership, opt => opt.Ignore())
                    .ForMember(x => x.CLMemebershipType, opt => opt.Ignore());

                obj = Mapper.Map<Artist>(_DACSAtrist);

                if (obj.LastName == null)
                    obj.LastName = "";
                if (obj.FirstName == null)
                    obj.FirstName = "";
                if (obj.Pseudonym_1 == null)
                    obj.Pseudonym_1 = "";
                if (obj.Pseudonym_2 == null)
                    obj.Pseudonym_2 = "";
                if (obj.Pseudonym_3 == null)
                    obj.Pseudonym_3 = "";
                if (obj.Pseudonym_4 == null)
                    obj.Pseudonym_4 = "";
                if (obj.Pseudonym_5 == null)
                    obj.Pseudonym_5 = "";
                if (obj.Pseudonym_6 == null)
                    obj.Pseudonym_6 = "";
                if (obj.Nationality1 == null)
                    obj.Nationality1 = "";
                if (obj.Nationality2 == null)
                    obj.Nationality2 = "";
                if (obj.Nationality3 == null)
                    obj.Nationality3 = "";
                if (obj.Nationality4 == null)
                    obj.Nationality4 = "";

                if (_DACSAtrist.ARRConfirmedNationality.Trim() == "Confirmed")
                {
                    obj.ARRConfirmedNationality = ARRConfirmedNationalityType.Confirmed;
                }
                else if (_DACSAtrist.ARRConfirmedNationality.Trim() == "Unconfirmed")
                {
                    obj.ARRConfirmedNationality = ARRConfirmedNationalityType.Unconfirmed;
                }
                else
                {
                    obj.ARRConfirmedNationality = ARRConfirmedNationalityType.Default;
                }


                if (_DACSAtrist.ARRMembership == "DACS")
                {
                    obj.ARRMembership = ARRMembershipType.DACS;
                }
                else if (_DACSAtrist.ARRMembership == "SisterSociety")
                {
                    obj.ARRMembership = ARRMembershipType.SisterSociety;
                }
                else if (_DACSAtrist.ARRMembership == "ACS")
                {
                    obj.ARRMembership = ARRMembershipType.ACS;
                }
                else if (_DACSAtrist.ARRMembership == "ARA")
                {
                    obj.ARRMembership = ARRMembershipType.ARA;
                }
                else if (_DACSAtrist.ARRMembership == "Rosenstiel's")
                {
                    obj.ARRMembership = ARRMembershipType.Rosenstiel;
                }
                else
                {
                    obj.ARRMembership = ARRMembershipType.NotApplicable;
                }


                if (_DACSAtrist.CLMemebershipType == "DACS")
                {
                    obj.CLMemebershipType = CLMemebershipType.DACS;
                }
                else if (_DACSAtrist.CLMemebershipType == "SisterSociety")
                {
                    obj.CLMemebershipType = CLMemebershipType.SisterSociety;
                }
                else
                {
                    obj.CLMemebershipType = CLMemebershipType.Default;
                }
            }
            else if (dataSource == "SAP")
            {
                SAPApi _sapApi = new SAPApi();

                DacsOnline.Model.Dto.SearchAllArtistResult _items = _sapApi.GetArtistByCode(idArtistString);

                Mapper.CreateMap<DacsOnline.Model.Dto.DACSArtist, Artist>()
                      //.ForMember(x => x.CLRightsMultimediaOnly, opt => opt.Ignore())
                      //.ForMember(x => x.CLRightsExcludingMerchandise, opt => opt.Ignore())
                      //.ForMember(x => x.CLRightsExcludingMultimedia, opt => opt.Ignore())
                      //.ForMember(x => x.CLFullConsultation, opt => opt.Ignore());

                      .ForMember(x => x.ARRConfirmedNationality, opt => opt.Ignore())
                            .ForMember(x => x.ARRMembership, opt => opt.Ignore())
                             .ForMember(x => x.InCopyright, opt => opt.Ignore())
                             .ForMember(x => x.CLRightsAuctionHouseOnly, opt => opt.Ignore())


                    .ForMember(x => x.CLRightsMultimediaOnly, opt => opt.Ignore())
                    .ForMember(x => x.CLRightsExcludingMerchandise, opt => opt.Ignore())
                    .ForMember(x => x.CLRightsExcludingMultimedia, opt => opt.Ignore())
                    .ForMember(x => x.CLFullConsultation, opt => opt.Ignore())

                         .ForMember(x => x.ImageHire, opt => opt.Ignore())
                            .ForMember(x => x.CLMemebershipType, opt => opt.Ignore());

                DacsOnline.Model.Dto.DACSArtist apiObj = _items.ArtistList.DACSArtistList.SingleOrDefault();

                obj = Mapper.Map<Artist>(apiObj);


                if (obj.LastName == null)
                    obj.LastName = "";
                if (obj.FirstName == null)
                    obj.FirstName = "";
                if (obj.Pseudonym_1 == null)
                    obj.Pseudonym_1 = "";
                if (obj.Pseudonym_2 == null)
                    obj.Pseudonym_2 = "";
                if (obj.Pseudonym_3 == null)
                    obj.Pseudonym_3 = "";
                if (obj.Pseudonym_4 == null)
                    obj.Pseudonym_4 = "";
                if (obj.Pseudonym_5 == null)
                    obj.Pseudonym_5 = "";
                if (obj.Pseudonym_6 == null)
                    obj.Pseudonym_6 = "";
                if (obj.Nationality1 == null)
                    obj.Nationality1 = "";
                if (obj.Nationality2 == null)
                    obj.Nationality2 = "";
                if (obj.Nationality3 == null)
                    obj.Nationality3 = "";
                if (obj.Nationality4 == null)
                    obj.Nationality4 = "";



                if (apiObj.ImageHire == "False")
                    obj.ImageHire = false;
                else
                    obj.ImageHire = true;

                if (apiObj.InCopyright == "False")
                    obj.InCopyright = false;
                else
                    obj.InCopyright = true;

                if (apiObj.CLRightsAuctionHouseOnly == "False")
                    obj.CLRightsAuctionHouseOnly = false;
                else
                    obj.CLRightsAuctionHouseOnly = true;



                if (!string.IsNullOrEmpty(apiObj.ARRConfirmedNationality))
                    if (apiObj.ARRConfirmedNationality.Trim() == "Confirmed")
                    {
                        obj.ARRConfirmedNationality = ARRConfirmedNationalityType.Confirmed;
                    }
                    else if (apiObj.ARRConfirmedNationality.Trim() == "Unconfirmed")
                    {
                        obj.ARRConfirmedNationality = ARRConfirmedNationalityType.Unconfirmed;
                    }
                    else
                    {
                        obj.ARRConfirmedNationality = ARRConfirmedNationalityType.Default;
                    }


                if (!string.IsNullOrEmpty(apiObj.ARRMembershipType))
                    if (apiObj.ARRMembershipType == "DACS")
                    {
                        obj.ARRMembership = ARRMembershipType.DACS;
                    }
                    else if (apiObj.ARRMembershipType == "SisterSociety")
                    {
                        obj.ARRMembership = ARRMembershipType.SisterSociety;
                    }
                    else if (apiObj.ARRMembershipType == "ACS")
                    {
                        obj.ARRMembership = ARRMembershipType.ACS;
                    }
                    else if (apiObj.ARRMembershipType == "ARA")
                    {
                        obj.ARRMembership = ARRMembershipType.ARA;
                    }
                    else if (apiObj.ARRMembershipType == "Rosenstiel's")
                    {
                        obj.ARRMembership = ARRMembershipType.Rosenstiel;
                    }
                    else
                    {
                        obj.ARRMembership = ARRMembershipType.NotApplicable;
                    }


               // if (!string.IsNullOrEmpty(apiObj.CLMemebershipType))
                    if (apiObj.CLMemebershipType == "DACS")
                    {
                        obj.CLMemebershipType = CLMemebershipType.DACS;
                    }
                    else if (apiObj.CLMemebershipType == "SisterSociety")
                    {
                        obj.CLMemebershipType = CLMemebershipType.SisterSociety;
                    }
                    else
                    {
                        obj.CLMemebershipType = CLMemebershipType.Default;
                    }
            }

            ArtistARRModel objArr = new ArtistARRModel();
            _arrManager.SetMessages(obj, objArr, DateTime.Now.Year.ToString());

            ArtistCLModel objCL = new ArtistCLModel();
            _clManager.SetMessages(obj, objCL, DateTime.Now.Year.ToString());

            ArtistCombined objCombined = new ArtistCombined();
            objCombined.ArtistId = obj.ArtistId;

            objCombined.ARREligibilityMessage = objArr.EligibilityMessage;
            objCombined.ARRMandateMessage = objArr.MandateMessage;
            objCombined.ARRPaymentMessage = objArr.PaymentMessage;
            objCombined.DisplayArr = objArr.DisplayArr;

            objCombined.CLImageHireMessage = objCL.ImageHireMessage;
            objCombined.CLMoreInfoMessage_1 = objCL.MoreInfoMessage_1;
            objCombined.CLMoreInfoMessage_2 = objCL.MoreInfoMessage_2;
            objCombined.CLRepresentationMessage = objCL.RepresentationMessage;
            objCombined.CLServiceDurationMessage = objCL.ServiceDurationMessage;
            objCombined.CLShowApplyFor = objCL.ShowApplyFor;

            if (objCombined.CLShowApplyFor)
                objCombined.CLArtistDetailsMessage = GetMessage(ConstantDataArtistSearch.CLArtistDetailsMessage_DACS);
            else
            {
                objCombined.CLArtistDetailsMessage = GetMessage(ConstantDataArtistSearch.CLArtistDetailsMessage_NOT_DACS);
                if (objCombined.CLMoreInfoMessage_1.Equals(objCombined.CLArtistDetailsMessage))
                {
                    objCombined.CLMoreInfoMessage_1 = string.Empty;
                }
            }

            objCombined.FirstName = obj.FirstName;
            objCombined.LastName = obj.LastName;

            if (string.IsNullOrEmpty(obj.FirstName) && string.IsNullOrEmpty(obj.LastName))
            {
                string[] artistCardName = obj.CardName.Split(' ');

                if (artistCardName.Length > 0)
                    objCombined.LastName = artistCardName[0];
                if (artistCardName.Length > 1)
                    objCombined.FirstName = artistCardName[1];
            }
            else
            {
                objCombined.Pseudonyms = obj.CardName + "; ";
            }


            objCombined.Nationality = obj.GetNationality(_listNationlity);
            objCombined.DateOfBirth = GetBirthYear(obj); //obj.DateOfBirth == null ? "" : obj.DateOfBirth.ToString();
            objCombined.DateOfDeath = GetDeathYear(obj);//(obj.DateOfBirth == null ? "" : (obj.DateOfDeath == null ? "" : "-" + obj.DateOfDeath.ToString());
            objCombined.Pseudonyms += GetPseudonyms(obj);

            objCombined.Pseudonyms = objCombined.Pseudonyms.TrimEnd(' ',';');

            return objCombined;
        }
        #endregion

        #region //private Methods

        /// <summary>
        /// Gets the birth year.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        private string GetBirthYear(Artist obj)
        {
            if (obj.DateOfBirth != null)
            {
                return obj.DateOfBirth.Value.Year.ToString();
            }
            else if (obj.YearOfBirth != null)
            {
                return obj.YearOfBirth;

            }
            else
            {
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the death year.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        private string GetDeathYear(Artist obj)
        {
            if (obj.DateOfDeath != null)
            {
                return obj.DateOfDeath.Value.Year.ToString();
            }
            else if (obj.YearOfDeath != null)
            {
                return obj.YearOfDeath;

            }
            else
            {
                return string.Empty;
            }
        }


        /// <summary>
        /// Gets the message.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        private string GetMessage(string key)
        {
            return HttpContext.GetGlobalResourceObject(ConstantDataArtistSearch.ArtistResourceFile, key) as string;
        }

        /// <summary>
        /// Gets the pseudonyms.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        private string GetPseudonyms(Artist obj)
        {
            string returnText = string.Empty;
            if (string.IsNullOrEmpty(obj.Pseudonym_1.Trim()) &&
                string.IsNullOrEmpty(obj.Pseudonym_2.Trim()) &&
                string.IsNullOrEmpty(obj.Pseudonym_3.Trim()) &&
                string.IsNullOrEmpty(obj.Pseudonym_4.Trim()) &&
                string.IsNullOrEmpty(obj.Pseudonym_5.Trim()) &&
                string.IsNullOrEmpty(obj.Pseudonym_6.Trim()))
            {
                returnText = "None";
            }
            else
            {
                if (!string.IsNullOrEmpty(obj.Pseudonym_1.Trim()))
                {
                    returnText = obj.Pseudonym_1.Trim() + "; ";
                }
                if (!string.IsNullOrEmpty(obj.Pseudonym_2.Trim()))
                {
                    returnText = returnText + obj.Pseudonym_2.Trim() + "; ";
                }
                if (!string.IsNullOrEmpty(obj.Pseudonym_3.Trim()))
                {
                    returnText = returnText + obj.Pseudonym_3.Trim() + "; ";
                }
                if (!string.IsNullOrEmpty(obj.Pseudonym_4.Trim()))
                {
                    returnText = returnText + obj.Pseudonym_4.Trim() + "; ";
                }
                if (!string.IsNullOrEmpty(obj.Pseudonym_5.Trim()))
                {
                    returnText = returnText + obj.Pseudonym_5.Trim() + "; ";
                }
                if (!string.IsNullOrEmpty(obj.Pseudonym_6.Trim()))
                {
                    returnText = returnText + obj.Pseudonym_6.Trim() + "; ";
                }

                if (returnText.Length > 2)
                {
                    returnText = returnText.Substring(0, returnText.Length - 2);
                }

            }

            return returnText;
        }
        #endregion
    }
}
