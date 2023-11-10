using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Presentation.Views;
using DacsOnline.Service.Service.Interfaces;
using DacsOnline.Model.Enums;

namespace DacsOnline.Presentation.Presenters
{
    public class ArtistDetailsPresenter : BasePresenter<IArtistDetailsView>, IDisposable
    {
        #region //Private Properties

        private IArtistDetailsService _service;
        #endregion


        #region //Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ArtistDetailsPresenter"/> class.
        /// </summary>
        /// <param name="view">The view.</param>
        /// <param name="service">The service.</param>
        public ArtistDetailsPresenter(IArtistDetailsView view, IArtistDetailsService service)
            : base(view)
        {
            this.View.PageOnLoad += new EventHandler(InitialisePage);
            _service = service;
        }
        #endregion 

        public void InitialisePage(object sender, EventArgs e)
        {
            try
            {
                if (this.View.idArtist.Trim() != "")
                {
                    int _artistIdInt = 0;

                    try
                    {
                        _artistIdInt = int.Parse(this.View.idArtist);
                    }
                    catch { }

                    string _artistIdString = this.View.idArtist.ToString();

                    this.View.Load(_service.GetArtist(_artistIdInt, _artistIdString));
                }
            }
            catch (Exception ex)
            {
                EventLogService.LogData(MessageType.Error, "InitialisePage-ArtistDetailsPresenter", ex.Message);
                throw;
            }
        }

        public void Dispose()
        {
            this.View.PageOnLoad -= new EventHandler(InitialisePage);
        }
    }
}
