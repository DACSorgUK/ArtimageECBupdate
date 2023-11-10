using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.RepostioriesInterfaces;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Model.Models;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Utilities;
using System.Configuration;
using DacsOnline.Model.DACSArtistSearchWebService;
using AutoMapper;
using DacsOnline.Model.Enums;

namespace DacsOnline.Model.Manager
{
    public class AllArtistSearchManager : BaseManager<IARRArtistSearchRepository>, IAllArtistDetailsManager
    {
        private IARRArtistSearchManager _arrManager;
        private ICLArtistSearchManager _clManager;
        private List<Nationality> _listNationlity;

        #region constructor
        public AllArtistSearchManager(IARRArtistSearchRepository ARRSearchRepository, IARRArtistSearchManager arrManager, ICLArtistSearchManager clManager)
            : base(ARRSearchRepository)
        {
            _arrManager = arrManager;
            _clManager = clManager;
            _listNationlity = this.Repository.GetNationalities();


        }
        #endregion

        #region //Public Methods


        /// <summary>
        /// Searches the artist.
        /// </summary>
        /// <param name="StartingWord">The starting word.</param>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="TotalItems">The total items.</param>
        /// <returns></returns>
        public List<ArtistCombined> SearchArtist(string StartingWord, int page, int pageSize, out int TotalItems, string dataSource)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback =
              ((sender, certificate, chain, sslPolicyErrors) => true);

            List<ArtistCombined> artistsModel = new List<ArtistCombined>();
            string year = DateTime.Now.Year.ToString();
            List<Artist> artists = new List<Artist>();
            TotalItems = 0;

            if (dataSource == "DACS_SITE")
            {
                artists = this.Repository.GetArtistsData();
                artists = artists.Where(p => p.AuthenticLastName.ContainsFirstCharartor(StartingWord) || p.LastName.ContainsFirstCharartor(StartingWord))
                                 .OrderBy(p => p.LastName)
                                 .ThenBy(p => p.FirstName).ToList<Artist>();
                TotalItems = artists.Count();
                artists = GetCurrentPageData(artists, pageSize, page);
            }
            else if (dataSource == "CRM")
            {
                string key = ConfigurationManager.AppSettings["CRMWebServiceAccessKey"].ToString();
                DACSAccessSoapClient _service = new DACSArtistSearchWebService.DACSAccessSoapClient();
                DACSAtristList _items = _service.SearchAllArtist(key, StartingWord, StartingWord, pageSize, page);
                TotalItems = _items.TotalArtist;

                foreach (DACSArtist obj in _items.ArtistList)
                {
                    Artist artist = new Business_Objects.Artist();

                    Mapper.CreateMap<DACSArtist, Artist>()
                            .ForMember(x => x.ARRConfirmedNationality, opt => opt.Ignore())
                            .ForMember(x => x.ARRMembership, opt => opt.Ignore())
                            .ForMember(x => x.CLMemebershipType, opt => opt.Ignore());

                    artist = Mapper.Map<Artist>(obj);

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

                    artists.Add(artist);
                }
            }
            else if (dataSource == "SAP")
            {
                //string key = ConfigurationManager.AppSettings["CRMWebServiceAccessKey"].ToString();
                //DACSAccessSoapClient _service = new DACSArtistSearchWebService.DACSAccessSoapClient();
                //DACSAtristList _items = _service.SearchAllArtist(key, StartingWord, StartingWord, pageSize, page);
                //TotalItems = _items.TotalArtist;
                SAPApi _sapApi = new SAPApi();

                DacsOnline.Model.Dto.SearchAllArtistResult _items = _sapApi.SearchAlphabeticalArtist("",StartingWord, page, pageSize);
                TotalItems = _items.TotalArtist;

                foreach (DacsOnline.Model.Dto.DACSArtist obj in _items.ArtistList.DACSArtistList)
                {
                    Artist artist = new Business_Objects.Artist();

                    Mapper.CreateMap<DacsOnline.Model.Dto.DACSArtist, Artist>()
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

                    //if (obj.CLRightsMultimediaOnly == "False" || obj.CLRightsMultimediaOnly == "")
                    //    artist.CLRightsMultimediaOnly = false;
                    //else
                    //    artist.CLRightsMultimediaOnly = true;

                    if (string.IsNullOrEmpty(obj.FirstName) && string.IsNullOrEmpty(obj.LastName))
                    {
                        string[] artistCardName = obj.CardName.Split(' ');

                        if (artistCardName.Length > 0)
                            artist.LastName = artistCardName[0];
                        if (artistCardName.Length > 1)
                            artist.FirstName = artistCardName[1];
                    }


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

                    artists.Add(artist);
                }
            }

            foreach (Artist obj in artists)
            {
                ArtistARRModel objArr = new ArtistARRModel();
                _arrManager.SetMessages(obj, objArr, year);

                ArtistCLModel objCL = new ArtistCLModel();
                _clManager.SetMessages(obj, objCL, year);

                ArtistCombined objCombined = new ArtistCombined();
                objCombined.ArtistId = obj.ArtistId;
                objCombined.ARREligibilityMessage = objArr.EligibilityMessage;
                objCombined.ARRMandateMessage = objArr.MandateMessage;
                objCombined.ARRPaymentMessage = objArr.PaymentMessage;
                objCombined.CLImageHireMessage = objCL.ImageHireMessage;
                objCombined.CLMoreInfoMessage_1 = objCL.MoreInfoMessage_1;
                objCombined.CLMoreInfoMessage_2 = objCL.MoreInfoMessage_2;
                objCombined.CLRepresentationMessage = objCL.RepresentationMessage;
                objCombined.CLServiceDurationMessage = objCL.ServiceDurationMessage;
                objCombined.CLShowApplyFor = objCL.ShowApplyFor;
                //objCombined.FirstName = obj.FirstName;
                //objCombined.LastName = obj.LastName;

                objCombined.FirstName = obj.FirstName != null ? obj.FirstName.ToString() : "";
                objCombined.LastName = obj.LastName != null ? obj.LastName.ToString() : "";

                objCombined.Nationality = obj.GetNationality(_listNationlity);
                objCombined.YearOfBirth = obj.YearOfBirth;
                objCombined.YearOfDeath = obj.YearOfDeath;
                objCombined.DisplayArr = objArr.DisplayArr;

                artistsModel.Add(objCombined);
            }
            return artistsModel;
        }

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
        /// Gets the charactors.
        /// </summary>
        /// <returns></returns>
        public List<string> GetCharactors()
        {
            return Enumerable.Range('A', 26)
                              .Select(x => (char)x + "")
                              .ToList();
        }
        #endregion
    }
}
