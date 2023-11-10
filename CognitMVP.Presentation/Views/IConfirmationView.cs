using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebFormsMvp;

namespace DacsOnline.Presentation.Views
{
    public interface IConfirmationView : IView
    {
        #region properties
        /// <summary>
        /// Gets the name of the form.
        /// </summary>
        /// <value>
        /// The name of the form.
        /// </value>
        string FormName { get; }
        /// <summary>
        /// Gets the email.
        /// </summary>
        string Email { get; }
        /// <summary>
        /// Gets the iduser.
        /// </summary>
        int Iduser { get; }
        /// <summary>
        /// Gets the title.
        /// </summary>
        string Title { get; }
        #endregion

        #region EventHandler
        /// <summary>
        /// Occurs when [load form].
        /// </summary>
        event EventHandler LoadForm;
        #endregion

        #region Public Methods
        /// <summary>
        /// Displays the confirmation page depending on the Form.
        /// </summary>
        /// <param name="nameform">The nameform.</param>
        /// <param name="refe">The refe.</param>
        /// <param name="useremail">The useremail.</param>
        /// <param name="dacsemail">The dacsemail.</param>
        void Display(string nameform, string refe, string useremail, string dacsemail);
        #endregion
    }
}
