using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Model.Models;
using DacsOnline.Model.RepostioriesInterfaces;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Utilities;
using DacsOnline.Model.Enums;
using System.Web;
using System.Configuration;
using AutoMapper;
using DacsOnline.Model.DACSArtistSearchWebService;

namespace DacsOnline.Model.Manager
{
    public class CLArtistSearchManager : BaseManager<IARRArtistSearchRepository>, ICLArtistSearchManager
    {
        #region //Private Properties
        /// <summary>
        /// 
        /// </summary>
        private List<Nationality> _listNationlity;
        #endregion

        #region //Constructor
        public CLArtistSearchManager(IARRArtistSearchRepository ARRSearchRepository)
            : base(ARRSearchRepository)
        {
            _listNationlity = this.Repository.GetNationalities();
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Searches the artist.
        /// </summary>
        /// <param name="SaleYear">The sale year.</param>
        /// <param name="ArtistName">Name of the artist.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="TotalItems"></param>
        /// <returns></returns>
        public List<ArtistCLModel> SearchArtist(string SaleYear, string ArtistFirstName, string ArtistLastName, int page, int pageSize, out int TotalItems, string dataSource)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback =
               ((sender, certificate, chain, sslPolicyErrors) => true);

            List<ArtistCLModel> artistsModel = new List<ArtistCLModel>();
            List<Artist> refinedArtists = new List<Artist>();

            TotalItems = 0;

            if ((ArtistFirstName != string.Empty || ArtistLastName != string.Empty))
            {
                if (dataSource == "DACS_SITE")
                {
                    // List<Artist> refinedArtists = new List<Artist>();
                    List<Artist> refinedPseudonymArtists = new List<Artist>();
                    // List<ArtistCLModel> artistsModel = new List<ArtistCLModel>();
                    List<Artist> artistsByFirstNameAndLastName = this.Repository.GetArtistsData();
                    List<Artist> artistsByPseudonym = this.Repository.GetArtistsData();

                    //Search based on First name and Last name
                    if (ArtistFirstName != string.Empty && ArtistLastName != string.Empty)
                    {
                        artistsByFirstNameAndLastName = artistsByFirstNameAndLastName.Where(p => p.AuthenticFirstNames.ToUpper().Contains(ArtistFirstName.ToUpper()) || p.FirstName.ToUpper().Contains(ArtistFirstName.ToUpper())).ToList<Artist>();

                        artistsByFirstNameAndLastName = artistsByFirstNameAndLastName.Where(p => p.AuthenticLastName.ToUpper().Contains(ArtistLastName.ToUpper()) || p.LastName.ToUpper().Contains(ArtistLastName.ToUpper())).ToList<Artist>();
                    }
                    else if (ArtistFirstName != string.Empty)
                    {
                        artistsByFirstNameAndLastName = artistsByFirstNameAndLastName.Where(p => p.AuthenticFirstNames.ToUpper().Contains(ArtistFirstName.ToUpper()) || p.FirstName.ToUpper().Contains(ArtistFirstName.ToUpper())).ToList<Artist>();
                    }
                    else if (ArtistLastName != string.Empty)
                    {
                        artistsByFirstNameAndLastName = artistsByFirstNameAndLastName.Where(p => p.AuthenticLastName.ToUpper().Contains(ArtistLastName.ToUpper()) || p.LastName.ToUpper().Contains(ArtistLastName.ToUpper())).ToList<Artist>();
                    }
                    else
                    {
                    }

                    artistsByFirstNameAndLastName = artistsByFirstNameAndLastName.Select(x => { x.Relevence = "1"; return x; }).ToList<Artist>();

                    refinedArtists.AddRange(artistsByFirstNameAndLastName);

                    if (ArtistFirstName != string.Empty)
                    {
                        refinedPseudonymArtists.AddRange(artistsByPseudonym.Where(p =>
                                     p.Pseudonym_1.ToUpper().Contains(ArtistFirstName.ToUpper()) ||
                                     p.Pseudonym_2.ToUpper().Contains(ArtistFirstName.ToUpper()) ||
                                     p.Pseudonym_3.ToUpper().Contains(ArtistFirstName.ToUpper()) ||
                                     p.Pseudonym_4.ToUpper().Contains(ArtistFirstName.ToUpper()) ||
                                     p.Pseudonym_5.ToUpper().Contains(ArtistFirstName.ToUpper()) ||
                                     p.Pseudonym_6.ToUpper().Contains(ArtistFirstName.ToUpper())
                                     ).ToList<Artist>());
                    }
                    if (ArtistLastName != string.Empty)
                    {
                        refinedPseudonymArtists.AddRange(artistsByPseudonym.Where(p =>
                                     p.Pseudonym_1.ToUpper().Contains(ArtistLastName.ToUpper()) ||
                                     p.Pseudonym_2.ToUpper().Contains(ArtistLastName.ToUpper()) ||
                                     p.Pseudonym_3.ToUpper().Contains(ArtistLastName.ToUpper()) ||
                                     p.Pseudonym_4.ToUpper().Contains(ArtistLastName.ToUpper()) ||
                                     p.Pseudonym_5.ToUpper().Contains(ArtistLastName.ToUpper()) ||
                                     p.Pseudonym_6.ToUpper().Contains(ArtistLastName.ToUpper())
                                     ).ToList<Artist>());
                    }

                    refinedPseudonymArtists = refinedPseudonymArtists.Distinct(new DistinctArtistId()).ToList<Artist>();


                    foreach (Artist obj in artistsByFirstNameAndLastName)
                    {
                        Artist remove = refinedPseudonymArtists.Where(p => p.ArtistId == obj.ArtistId).FirstOrDefault();

                        if (remove != null)
                        {
                            refinedPseudonymArtists.Remove(remove);
                        }
                    }

                    refinedPseudonymArtists = refinedPseudonymArtists.Select(x => { x.Relevence = "2"; return x; }).ToList<Artist>();

                    refinedArtists.AddRange(refinedPseudonymArtists);


                    //refinedArtists = refinedArtists.Distinct(new DistinctArtistId()).ToList<Artist>();
                    refinedArtists = refinedArtists.OrderBy(p => p.Relevence).ThenBy(p => p.LastName).ThenBy(p => p.FirstName).ToList<Artist>();
                    TotalItems = refinedArtists.Count();
                    refinedArtists = GetCurrentPageData(refinedArtists, pageSize, page);

                }
                else if (dataSource == "CRM")
                {
                    string key = ConfigurationManager.AppSettings["CRMWebServiceAccessKey"].ToString();
                    DACSAccessSoapClient _service = new DACSArtistSearchWebService.DACSAccessSoapClient();
                    DACSAtristList _items = _service.SearchARRArtist(key, ArtistFirstName, ArtistLastName, pageSize, page);
                    TotalItems = _items.TotalArtist;

                    foreach (DACSArtist obj in _items.ArtistList)
                    {
                        Artist artist = new Business_Objects.Artist();

                        Mapper.CreateMap<DACSArtist, Artist>()
                            .ForMember(x => x.ARRConfirmedNationality, opt => opt.Ignore())
                            .ForMember(x => x.ARRMembership, opt => opt.Ignore())
                            .ForMember(x => x.CLMemebershipType, opt => opt.Ignore());

                        artist = Mapper.Map<Artist>(obj);

                        if (artist.LastName == null)
                            artist.LastName = "";
                        if (artist.FirstName == null)
                            artist.FirstName = "";
                        if (artist.Pseudonym_1 == null)
                            artist.Pseudonym_1 = "";
                        if (artist.Pseudonym_2 == null)
                            artist.Pseudonym_2 = "";
                        if (artist.Pseudonym_3 == null)
                            artist.Pseudonym_3 = "";
                        if (artist.Pseudonym_4 == null)
                            artist.Pseudonym_4 = "";
                        if (artist.Pseudonym_5 == null)
                            artist.Pseudonym_5 = "";
                        if (artist.Pseudonym_6 == null)
                            artist.Pseudonym_6 = "";
                        if (artist.Nationality1 == null)
                            artist.Nationality1 = "";
                        if (artist.Nationality2 == null)
                            artist.Nationality2 = "";
                        if (artist.Nationality3 == null)
                            artist.Nationality3 = "";
                        if (artist.Nationality4 == null)
                            artist.Nationality4 = "";

                        if (obj.ARRConfirmedNationality.Trim() == "Confirmed")
                        {
                            artist.ARRConfirmedNationality = ARRConfirmedNationalityType.Confirmed;
                        }
                        else if (obj.ARRConfirmedNationality.Trim() == "Unconfirmed")
                        {
                            artist.ARRConfirmedNationality = ARRConfirmedNationalityType.Unconfirmed;
                        }
                        else
                        {
                            artist.ARRConfirmedNationality = ARRConfirmedNationalityType.Default;
                        }


                        if (obj.ARRMembership == "DACS")
                        {
                            artist.ARRMembership = ARRMembershipType.DACS;
                        }
                        else if (obj.ARRMembership == "SisterSociety")
                        {
                            artist.ARRMembership = ARRMembershipType.SisterSociety;
                        }
                        else if (obj.ARRMembership == "ACS")
                        {
                            artist.ARRMembership = ARRMembershipType.ACS;
                        }
                        else if (obj.ARRMembership == "ARA")
                        {
                            artist.ARRMembership = ARRMembershipType.ARA;
                        }
                        else if (obj.ARRMembership == "Rosenstiel's")
                        {
                            artist.ARRMembership = ARRMembershipType.Rosenstiel;
                        }
                        else
                        {
                            artist.ARRMembership = ARRMembershipType.NotApplicable;
                        }


                        if (obj.CLMemebershipType == "DACS")
                        {
                            artist.CLMemebershipType = CLMemebershipType.DACS;
                        }
                        else if (obj.CLMemebershipType == "SisterSociety")
                        {
                            artist.CLMemebershipType = CLMemebershipType.SisterSociety;
                        }
                        else
                        {
                            artist.CLMemebershipType = CLMemebershipType.Default;
                        }

                        refinedArtists.Add(artist);
                    }
                }
                else if (dataSource == "SAP")
                {
                    //string key = ConfigurationManager.AppSettings["CRMWebServiceAccessKey"].ToString();
                    //DACSAccessSoapClient _service = new DACSArtistSearchWebService.DACSAccessSoapClient();
                    //DACSAtristList _items = _service.SearchARRArtist(key, ArtistFirstName, ArtistLastName, pageSize, page);
                    //TotalItems = _items.TotalArtist;
                    SAPApi _sapApi = new SAPApi();

                    DacsOnline.Model.Dto.SearchAllArtistResult _items = _sapApi.SearchAllArtistResult(ArtistFirstName, ArtistLastName,"","Y", page, pageSize);
                    TotalItems = _items.TotalArtist;

                    foreach (DacsOnline.Model.Dto.DACSArtist obj in _items.ArtistList.DACSArtistList)
                    {
                        Artist artist = new Business_Objects.Artist();

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

                        artist = Mapper.Map<Artist>(obj);

                        if (artist.LastName == null)
                            artist.LastName = "";
                        if (artist.FirstName == null)
                            artist.FirstName = "";

                        if (string.IsNullOrEmpty(artist.FirstName) && string.IsNullOrEmpty(artist.LastName))
                        {
                            string[] artistCardName = artist.CardName.Split(' ');

                            if (artistCardName.Length > 0)
                                artist.LastName = artistCardName[0];
                            if (artistCardName.Length > 1)
                                artist.FirstName = artistCardName[1];
                        }

                        if (artist.Pseudonym_1 == null)
                            artist.Pseudonym_1 = "";
                        if (artist.Pseudonym_2 == null)
                            artist.Pseudonym_2 = "";
                        if (artist.Pseudonym_3 == null)
                            artist.Pseudonym_3 = "";
                        if (artist.Pseudonym_4 == null)
                            artist.Pseudonym_4 = "";
                        if (artist.Pseudonym_5 == null)
                            artist.Pseudonym_5 = "";
                        if (artist.Pseudonym_6 == null)
                            artist.Pseudonym_6 = "";
                        if (artist.Nationality1 == null)
                            artist.Nationality1 = "";
                        if (artist.Nationality2 == null)
                            artist.Nationality2 = "";
                        if (artist.Nationality3 == null)
                            artist.Nationality3 = "";
                        if (artist.Nationality4 == null)
                            artist.Nationality4 = "";


                        //if (obj.CLRightsMultimediaOnly == "False" || obj.CLRightsMultimediaOnly == "")
                        //    artist.CLRightsMultimediaOnly = false;
                        //else
                        //    artist.CLRightsMultimediaOnly = true;

                        if (obj.ImageHire == "False")
                            artist.ImageHire = false;
                        else
                            artist.ImageHire = true;

                        if (obj.InCopyright == "False")
                            artist.InCopyright = false;
                        else
                            artist.InCopyright = true;

                        if (obj.CLRightsAuctionHouseOnly == "False")
                            artist.CLRightsAuctionHouseOnly = false;
                        else
                            artist.CLRightsAuctionHouseOnly = true;

                        if (!string.IsNullOrEmpty(obj.ARRConfirmedNationality))
                            if (obj.ARRConfirmedNationality.Trim() == "Confirmed")
                            {
                                artist.ARRConfirmedNationality = ARRConfirmedNationalityType.Confirmed;
                            }
                            else if (obj.ARRConfirmedNationality.Trim() == "Unconfirmed")
                            {
                                artist.ARRConfirmedNationality = ARRConfirmedNationalityType.Unconfirmed;
                            }
                            else
                            {
                                artist.ARRConfirmedNationality = ARRConfirmedNationalityType.Default;
                            }

                        if (!string.IsNullOrEmpty(obj.ARRMembershipType))
                            if (obj.ARRMembershipType == "DACS")
                            {
                                artist.ARRMembership = ARRMembershipType.DACS;
                            }
                            else if (obj.ARRMembershipType == "SisterSociety")
                            {
                                artist.ARRMembership = ARRMembershipType.SisterSociety;
                            }
                            else if (obj.ARRMembershipType == "ACS")
                            {
                                artist.ARRMembership = ARRMembershipType.ACS;
                            }
                            else if (obj.ARRMembershipType == "ARA")
                            {
                                artist.ARRMembership = ARRMembershipType.ARA;
                            }
                            else if (obj.ARRMembershipType == "Rosenstiel's")
                            {
                                artist.ARRMembership = ARRMembershipType.Rosenstiel;
                            }
                            else
                            {
                                artist.ARRMembership = ARRMembershipType.NotApplicable;
                            }

                       // if (!string.IsNullOrEmpty(obj.CLMemebershipType))
                            if (obj.CLMemebershipType == "DACS")
                            {
                                artist.CLMemebershipType = CLMemebershipType.DACS;
                            }
                            else if (obj.CLMemebershipType == "SisterSociety")
                            {
                                artist.CLMemebershipType = CLMemebershipType.SisterSociety;
                            }
                            else
                            {
                                artist.CLMemebershipType = CLMemebershipType.Default;
                            }

                        refinedArtists.Add(artist);
                    }
                }

                foreach (Artist obj in refinedArtists)
                {
                    ArtistCLModel objModel = new ArtistCLModel();
                    objModel.ArtistId = obj.ArtistId;
                    //objModel.FirstName = obj.FirstName;
                    //objModel.LastName = obj.LastName;
                    objModel.FirstName = obj.FirstName != null ? obj.FirstName.ToString() : "";
                    objModel.LastName = obj.LastName != null ? obj.LastName.ToString() : "";
                    objModel.Nationality = obj.GetNationality(_listNationlity);
                    objModel.YearOfBirth = GetBirthYear(obj);
                    objModel.YearOfDeath = GetDeathYear(obj);
                    SetMessages(obj, objModel, SaleYear);
                    artistsModel.Add(objModel);
                }

                return artistsModel;
            }
            else
            {
                TotalItems = 0;
                return artistsModel;
            }
        }


        #endregion

        #region //Private Methods


        /// <summary>
        /// Gets the current page data.
        /// </summary>
        /// <param name="artists">The artists.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="page">The page.</param>
        /// <returns></returns>
        private List<Artist> GetCurrentPageData(List<Artist> artists, int pageSize, int page)
        {
            int take = page * pageSize;
            int skip = page == 1 ? 0 : take - pageSize;
            return artists.Take(take).Skip(skip).ToList<Artist>();
        }

        /// <summary>
        /// Sets the messages.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="modObj">The mod obj.</param>
        /// <param name="SaleYear">The sale year.</param>
        public void SetMessages(Artist obj, ArtistCLModel modObj, string Year)
        {
            bool saleYear = IsArtistSeventyYears(obj, Year);
            if (saleYear)
            {
                if (obj.InCopyright)
                {
                    if (obj.CLMemebershipType == CLMemebershipType.Default)
                    {
                        modObj.RepresentationMessage = GetMessage(ConstantDataArtistSearch.RepresentationMessage_2); //✘  DACS does not represent this artist for Copyright licensing
                        modObj.MoreInfoMessage_1 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_4); //"Sorry, we do not hold information on who represents this artist for copyright licensing.";
                        modObj.ShowApplyFor = false;
                    }
                    if (obj.CLMemebershipType == CLMemebershipType.DACS)
                    {
                        SetMessageWhenUserMemberShip_DACS(obj, modObj);
                    }
                    if (obj.CLMemebershipType == CLMemebershipType.SisterSociety)
                    {
                        SetMessageWhenUserMemberShip_SisterSociety(obj, modObj);
                    }
                }
                else
                {
                    if (obj.CLMemebershipType == CLMemebershipType.Default)
                    {
                        modObj.RepresentationMessage = GetMessage(ConstantDataArtistSearch.RepresentationMessage_2); //✘  DACS does not represent this artist for Copyright licensing
                        modObj.MoreInfoMessage_1 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_5); //"Sorry, we do not hold information on which organisation represents this artist. DACS does not hold information about the copyright status of this artist. If you would like to help us update our database, please get in touch.";
                        modObj.ShowApplyFor = false;
                    }
                    if (obj.CLMemebershipType == CLMemebershipType.DACS)
                    {
                        modObj.RepresentationMessage = GetMessage(ConstantDataArtistSearch.RepresentationMessage_2); //✘  DACS does not represent this artist for Copyright licensing
                        modObj.MoreInfoMessage_1 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_5); //"Sorry, we do not hold information on which organisation represents this artist. DACS does not hold information about the copyright status of this artist. If you would like to help us update our database, please get in touch.";
                        modObj.ShowApplyFor = false;
                    }
                    if (obj.CLMemebershipType == CLMemebershipType.SisterSociety)
                    {
                        modObj.RepresentationMessage = GetMessage(ConstantDataArtistSearch.RepresentationMessage_2); //✘  DACS does not represent this artist for Copyright licensing
                        modObj.MoreInfoMessage_1 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_5); //"Sorry, we do not hold information on which organisation represents this artist. DACS does not hold information about the copyright status of this artist. If you would like to help us update our database, please get in touch.";
                        modObj.ShowApplyFor = false;
                    }

                }
            }
            else
            {
                SetMessageWhenYearGreaterThanSeventy(obj, modObj);
            }

        }

        /// <summary>
        /// Sets the message when year greater than seventy.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="modObj">The mod obj.</param>
        private void SetMessageWhenYearGreaterThanSeventy(Artist obj, ArtistCLModel modObj)
        {
            if (obj.InCopyright)
            {
                if (obj.CLMemebershipType == CLMemebershipType.DACS)
                {
                    modObj.RepresentationMessage = GetMessage(ConstantDataArtistSearch.RepresentationMessage_1); //""✔ DACS represents this artist for Copyright licensing";
                    modObj.ServiceDurationMessage = GetMessage(ConstantDataArtistSearch.ServiceDurationMessage_1); //"✔  Your licence request will take roughly 1-2 weeks";
                    modObj.ShowApplyFor = true;
                }
                else
                {
                    modObj.RepresentationMessage = GetMessage(ConstantDataArtistSearch.RepresentationMessage_2); //✘  DACS does not represent this artist for Copyright licensing
                    modObj.MoreInfoMessage_1 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_6); //"As their date of death is over seventy years ago, this artist is likely out of copyright. Photographs of this artists work may still be in copyright: please check with your image supplier.";
                    modObj.ShowApplyFor = false;
                }

            }
            else
            {
                modObj.RepresentationMessage = GetMessage(ConstantDataArtistSearch.RepresentationMessage_2); //✘  DACS does not represent this artist for Copyright licensing
                modObj.MoreInfoMessage_1 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_6); //"As their date of death is over seventy years ago, this artist is likely out of copyright. Photographs of this artists work may still be in copyright: please check with your image supplier.";
                modObj.ShowApplyFor = false;
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
        /// Sets the message when user DACS.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="modObj">The mod obj.</param>
        private void SetMessageWhenUserMemberShip_DACS(Artist obj, ArtistCLModel modObj)
        {
            if (!obj.CLFullConsultation)
            {
                if (obj.ImageHire)
                {
                    if (obj.CLRightsAuctionHouseOnly ||
                        obj.CLRightsExcludingMerchandise ||
                        obj.CLRightsExcludingMultimedia ||
                        obj.CLRightsMultimediaOnly)
                    {

                        modObj.RepresentationMessage = GetMessage(ConstantDataArtistSearch.RepresentationMessage_1); //"✔  DACS represents this artist for Copyright licensing";
                        modObj.ServiceDurationMessage = GetMessage(ConstantDataArtistSearch.ServiceDurationMessage_1); //"✔  Your licence request will take roughly 1-2 weeks";
                        modObj.ImageHireMessage = GetMessage(ConstantDataArtistSearch.ImageHireMessage_1); //"Images by this artist are available from DACS. (LINK TO PAGE OF INFO ABOUT IMAGE HIRE?)";
                        modObj.ShowApplyFor = true;
                        modObj.MoreInfoMessage_1 = string.Empty;
                        modObj.MoreInfoMessage_2 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_3); //"There may be restrictions on certain uses of this artist's work. Please get in touch, and we'll be happy to advise you.";


                    }
                    else
                    {
                        modObj.RepresentationMessage = GetMessage(ConstantDataArtistSearch.RepresentationMessage_1); //"✔  DACS represents this artist for Copyright licensing";
                        modObj.ServiceDurationMessage = GetMessage(ConstantDataArtistSearch.ServiceDurationMessage_1); // ✔  Your licence request will take roughly 1-2 weeks
                        modObj.ImageHireMessage = GetMessage(ConstantDataArtistSearch.ImageHireMessage_1); //"Images by this artist are available from DACS. (LINK TO PAGE OF INFO ABOUT IMAGE HIRE?)";
                        modObj.ShowApplyFor = true;
                        modObj.MoreInfoMessage_1 = string.Empty;
                        modObj.MoreInfoMessage_2 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_2); //"You may need to supply imagery depicting their work in context (e.g. a PDF).";
                    }
                }
                else
                {
                    if (obj.CLRightsAuctionHouseOnly ||
                        obj.CLRightsExcludingMerchandise ||
                        obj.CLRightsExcludingMultimedia ||
                        obj.CLRightsMultimediaOnly)
                    {


                        modObj.RepresentationMessage = GetMessage(ConstantDataArtistSearch.RepresentationMessage_1); //"✔  DACS represents this artist for Copyright licensing";
                        modObj.ServiceDurationMessage = GetMessage(ConstantDataArtistSearch.ServiceDurationMessage_1); //"✔  Your licence request will take roughly 1-2 weeks";
                        modObj.ImageHireMessage = string.Empty;
                        modObj.ShowApplyFor = true;
                        modObj.MoreInfoMessage_1 = string.Empty;
                        modObj.MoreInfoMessage_2 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_3); //"There may be restrictions on certain uses of this artist's work. Please get in touch, and we'll be happy to advise you.";

                    }
                    else
                    {
                        modObj.RepresentationMessage = GetMessage(ConstantDataArtistSearch.RepresentationMessage_1); //"✔  DACS represents this artist for Copyright licensing";
                        modObj.ServiceDurationMessage = GetMessage(ConstantDataArtistSearch.ServiceDurationMessage_1); //"✔  Your licence request will take roughly 1-2 weeks";
                        modObj.ImageHireMessage = string.Empty;
                        modObj.ShowApplyFor = true;
                        modObj.MoreInfoMessage_1 = string.Empty;
                        modObj.MoreInfoMessage_2 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_2); //"You may need to supply imagery depicting their work in context (e.g. a PDF).";
                    }

                }
            }
            else  //if (obj.CLFullConsultation)
            {
                if (obj.ImageHire)
                {
                    if (obj.CLRightsAuctionHouseOnly ||
                        obj.CLRightsExcludingMerchandise ||
                        obj.CLRightsExcludingMultimedia ||
                        obj.CLRightsMultimediaOnly)
                    {


                        modObj.RepresentationMessage = GetMessage(ConstantDataArtistSearch.RepresentationMessage_1); //"✔  DACS represents this artist for Copyright licensing";
                        modObj.ServiceDurationMessage = GetMessage(ConstantDataArtistSearch.ServiceDurationMessage_1); // "✔  Full consultation is required for this artist:  your license request may take more than 2 weeks";
                        modObj.ImageHireMessage = GetMessage(ConstantDataArtistSearch.ImageHireMessage_1); //"Images by this artist are available from DACS. (LINK TO PAGE OF INFO ABOUT IMAGE HIRE?)";
                        modObj.ShowApplyFor = true;
                        modObj.MoreInfoMessage_1 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_1); //"Full consultation means that all license requests need to be reviewed and signed-off by the artist or their estate. This can be time consuming.";
                        modObj.MoreInfoMessage_2 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_2); //"You may need to supply imagery depicting their work in context (e.g. a PDF).";
                    }
                    else
                    {
                        modObj.RepresentationMessage = GetMessage(ConstantDataArtistSearch.RepresentationMessage_1); //"✔  DACS represents this artist for Copyright licensing";
                        modObj.ServiceDurationMessage = GetMessage(ConstantDataArtistSearch.ServiceDurationMessage_1); //"✔  Full consultation is required for this artist:  your license request may take more than 2 weeks";
                        modObj.ImageHireMessage = GetMessage(ConstantDataArtistSearch.ImageHireMessage_1); //"Images by this artist are available from DACS. (LINK TO PAGE OF INFO ABOUT IMAGE HIRE?)";
                        modObj.ShowApplyFor = true;
                        modObj.MoreInfoMessage_1 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_1); //"Full consultation means that all license requests need to be reviewed and signed-off by the artist or their estate. This can be time consuming.";
                        modObj.MoreInfoMessage_2 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_2); //"You may need to supply imagery depicting their work in context (e.g. a PDF).";
                    }
                }
                else
                {
                    if (obj.CLRightsAuctionHouseOnly ||
                        obj.CLRightsExcludingMerchandise ||
                        obj.CLRightsExcludingMultimedia ||
                        obj.CLRightsMultimediaOnly)
                    {


                        modObj.RepresentationMessage = GetMessage(ConstantDataArtistSearch.RepresentationMessage_1); //"✔  DACS represents this artist for Copyright licensing";
                        modObj.ServiceDurationMessage = GetMessage(ConstantDataArtistSearch.ServiceDurationMessage_2); //"✔  Full consultation is required for this artist:  your license request may take more than 2 weeks";
                        modObj.ImageHireMessage = string.Empty;
                        modObj.ShowApplyFor = true;
                        modObj.MoreInfoMessage_1 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_1); //"Full consultation means that all license requests need to be reviewed and signed-off by the artist or their estate. This can be time consuming.";
                        modObj.MoreInfoMessage_2 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_2); //"You may need to supply imagery depicting their work in context (e.g. a PDF).";
                    }
                    else
                    {
                        modObj.RepresentationMessage = GetMessage(ConstantDataArtistSearch.RepresentationMessage_1); //"✔  DACS represents this artist for Copyright licensing";
                        modObj.ServiceDurationMessage = GetMessage(ConstantDataArtistSearch.ServiceDurationMessage_2); //"✔  Full consultation is required for this artist:  your license request may take more than 2 weeks";
                        modObj.ImageHireMessage = string.Empty;
                        modObj.ShowApplyFor = true;
                        modObj.MoreInfoMessage_1 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_1); //"Full consultation means that all license requests need to be reviewed and signed-off by the artist or their estate. This can be time consuming.";
                        modObj.MoreInfoMessage_2 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_2); //"You may need to supply imagery depicting their work in context (e.g. a PDF).";
                    }

                }
            }


        }

        /// <summary>
        /// Sets the message when user sister society.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="modObj">The mod obj.</param>
        private void SetMessageWhenUserMemberShip_SisterSociety(Artist obj, ArtistCLModel modObj)
        {
            if (!obj.CLFullConsultation)
            {
                if (obj.ImageHire)
                {
                    if (obj.CLRightsAuctionHouseOnly ||
                        obj.CLRightsExcludingMerchandise ||
                        obj.CLRightsExcludingMultimedia ||
                        obj.CLRightsMultimediaOnly)
                    {
                        modObj.RepresentationMessage = GetMessage(ConstantDataArtistSearch.RepresentationMessage_1); //"✔  DACS represents this artist for Copyright licensing";
                        modObj.ServiceDurationMessage = GetMessage(ConstantDataArtistSearch.ServiceDurationMessage_1); //"✔  Your licence request will take roughly 1-2 weeks";
                        modObj.ImageHireMessage = GetMessage(ConstantDataArtistSearch.ImageHireMessage_1); //"Images by this artist are available from DACS. (LINK TO PAGE OF INFO ABOUT IMAGE HIRE?)";
                        modObj.ShowApplyFor = true;
                        modObj.MoreInfoMessage_1 = string.Empty;
                        modObj.MoreInfoMessage_2 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_3); //"There may be restrictions on certain uses of this artist's work. Please get in touch, and we'll be happy to advise you.";
                    }
                    else
                    {
                        modObj.RepresentationMessage = GetMessage(ConstantDataArtistSearch.RepresentationMessage_1); //"✔  DACS represents this artist for Copyright licensing";
                        modObj.ServiceDurationMessage = GetMessage(ConstantDataArtistSearch.ServiceDurationMessage_1); //"✔  Your licence request will take roughly 1-2 weeks";
                        modObj.ImageHireMessage = GetMessage(ConstantDataArtistSearch.ImageHireMessage_1); // "Images by this artist are available from DACS. (LINK TO PAGE OF INFO ABOUT IMAGE HIRE?)";
                        modObj.ShowApplyFor = true;
                        modObj.MoreInfoMessage_1 = string.Empty;
                        modObj.MoreInfoMessage_2 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_2); //"You may need to supply imagery depicting their work in context (e.g. a PDF).";
                    }
                }
                else
                {
                    if (obj.CLRightsAuctionHouseOnly ||
                        obj.CLRightsExcludingMerchandise ||
                        obj.CLRightsExcludingMultimedia ||
                        obj.CLRightsMultimediaOnly)
                    {


                        modObj.RepresentationMessage = GetMessage(ConstantDataArtistSearch.RepresentationMessage_1); //"✔  DACS represents this artist for Copyright licensing";
                        modObj.ServiceDurationMessage = GetMessage(ConstantDataArtistSearch.ServiceDurationMessage_1); //"✔  Your licence request will take roughly 1-2 weeks";
                        modObj.ImageHireMessage = string.Empty;
                        modObj.ShowApplyFor = true;
                        modObj.MoreInfoMessage_1 = string.Empty;
                        modObj.MoreInfoMessage_2 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_3); //"There may be restrictions on certain uses of this artist's work. Please get in touch, and we'll be happy to advise you.";
                    }
                    else
                    {
                        modObj.RepresentationMessage = GetMessage(ConstantDataArtistSearch.RepresentationMessage_1); //"✔  DACS represents this artist for Copyright licensing";
                        modObj.ServiceDurationMessage = GetMessage(ConstantDataArtistSearch.ServiceDurationMessage_1); //"✔  Your licence request will take roughly 1-2 weeks";
                        modObj.ImageHireMessage = string.Empty;
                        modObj.ShowApplyFor = true;
                        modObj.MoreInfoMessage_1 = string.Empty;
                        modObj.MoreInfoMessage_2 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_2); //"You may need to supply imagery depicting their work in context (e.g. a PDF).";
                    }

                }
            }
            else //if (obj.CLFullConsultation)
            {
                if (obj.ImageHire)
                {
                    if (obj.CLRightsAuctionHouseOnly ||
                        obj.CLRightsExcludingMerchandise ||
                        obj.CLRightsExcludingMultimedia ||
                       obj.CLRightsMultimediaOnly)
                    {


                        modObj.RepresentationMessage = GetMessage(ConstantDataArtistSearch.RepresentationMessage_1); //"✔  DACS represents this artist for Copyright licensing";
                        modObj.ServiceDurationMessage = GetMessage(ConstantDataArtistSearch.ServiceDurationMessage_1); //"✔  Full consultation is required for this artist:  your license request may take more than 2 weeks";
                        modObj.ImageHireMessage = GetMessage(ConstantDataArtistSearch.ImageHireMessage_1); // "Images by this artist are available from DACS. (LINK TO PAGE OF INFO ABOUT IMAGE HIRE?)";
                        modObj.ShowApplyFor = true;
                        modObj.MoreInfoMessage_1 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_1); //"Full consultation means that all license requests need to be reviewed and signed-off by the artist or their estate. This can be time consuming. ";
                        modObj.MoreInfoMessage_2 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_2); //"You may need to supply imagery depicting their work in context (e.g. a PDF).";
                    }
                    else
                    {
                        modObj.RepresentationMessage = GetMessage(ConstantDataArtistSearch.RepresentationMessage_1); //"✔  DACS represents this artist for Copyright licensing";
                        modObj.ServiceDurationMessage = GetMessage(ConstantDataArtistSearch.ServiceDurationMessage_1); //"✔  Full consultation is required for this artist:  your license request may take more than 2 weeks";
                        modObj.ImageHireMessage = GetMessage(ConstantDataArtistSearch.ImageHireMessage_1); //"Images by this artist are available from DACS. (LINK TO PAGE OF INFO ABOUT IMAGE HIRE?)";
                        modObj.ShowApplyFor = true;
                        modObj.MoreInfoMessage_1 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_1); //"Full consultation means that all license requests need to be reviewed and signed-off by the artist or their estate. This can be time consuming. ";
                        modObj.MoreInfoMessage_2 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_2); //"You may need to supply imagery depicting their work in context (e.g. a PDF).";
                    }
                }
                else
                {
                    if (obj.CLRightsAuctionHouseOnly ||
                        obj.CLRightsExcludingMerchandise ||
                        obj.CLRightsExcludingMultimedia ||
                        obj.CLRightsMultimediaOnly)
                    {
                        modObj.RepresentationMessage = GetMessage(ConstantDataArtistSearch.RepresentationMessage_1); //"✔  DACS represents this artist for Copyright licensing";
                        modObj.ServiceDurationMessage = GetMessage(ConstantDataArtistSearch.ServiceDurationMessage_1); //"✔  Full consultation is required for this artist:  your license request may take more than 2 weeks";
                        modObj.ImageHireMessage = string.Empty;
                        modObj.ShowApplyFor = true;
                        modObj.MoreInfoMessage_1 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_1); //"Full consultation means that all license requests need to be reviewed and signed-off by the artist or their estate. This can be time consuming. ";
                        modObj.MoreInfoMessage_2 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_2); //"You may need to supply imagery depicting their work in context (e.g. a PDF).";



                    }
                    else
                    {
                        modObj.RepresentationMessage = GetMessage(ConstantDataArtistSearch.RepresentationMessage_1); //"✔  DACS represents this artist for Copyright licensing";
                        modObj.ServiceDurationMessage = GetMessage(ConstantDataArtistSearch.ServiceDurationMessage_1); // "✔  Full consultation is required for this artist:  your license request may take more than 2 weeks";
                        modObj.ImageHireMessage = string.Empty;
                        modObj.ShowApplyFor = true;
                        modObj.MoreInfoMessage_1 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_1); //"Full consultation means that all license requests need to be reviewed and signed-off by the artist or their estate. This can be time consuming. ";
                        modObj.MoreInfoMessage_2 = GetMessage(ConstantDataArtistSearch.MoreInfoMessage_2); //"You may need to supply imagery depicting their work in context (e.g. a PDF).";
                    }

                }
            }
        }




        /// <summary>
        /// Determines whether [is artist seventy years] [the specified obj].
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns>
        ///   <c>true</c> if [is artist seventy years] [the specified obj]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsArtistSeventyYears(Artist obj, string SaleYear)
        {
            try
            {
                if (obj.DateOfDeath != null)
                {
                    int diff = Convert.ToInt32(SaleYear) - obj.DateOfDeath.Value.Year;
                    if (diff > 70)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else if (obj.YearOfDeath != null)
                {

                    int diff = Convert.ToInt32(SaleYear) - Convert.ToInt32(obj.YearOfDeath);
                    if (diff > 70)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }

                }
                else
                {
                    return true;
                }

            }
            catch
            {
                return true;
            }
        }




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
        #endregion

    }


}
