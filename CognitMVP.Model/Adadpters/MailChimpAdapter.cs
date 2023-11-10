using System;
using DacsOnline.Model.Manager.Interfaces;
using System.Configuration;
using CMS.EventLog;
using DacsOnline.Model.Manager;

namespace DacsOnline.Model.Adadpters
{
    public class MailChimpAdapter : ISubscribeEmail
    {
        public MailChimpAdapter()
        {
        }

        #region ISubscribeEmail Members

        /// <summary>
        /// Subscribes the user.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="emailType">Type of the email.</param>
        /// <param name="firstName">The first name.</param>
        /// <param name="lastName">The last name.</param>
        /// <returns></returns>
        public bool SubscribeUser(string email, string emailType, string firstName, string lastName)
        {

            //listBatchSubscribeInput input = new listBatchSubscribeInput();
            //// any directive overrides
            //input.api_Validate = false;
            //input.api_AccessType = EnumValues.AccessType.Serial;
            //input.api_OutputType = EnumValues.OutputType.JSON;
            //// method parameters
            //input.parms.apikey = ConfigurationManager.AppSettings["MailChimpKey"].ToString();
            //input.parms.id = ConfigurationManager.AppSettings["MailChimpListId"].ToString();
            //input.parms.double_optin = false;
            //input.parms.replace_interests = true;
            //input.parms.update_existing = true;
            ////
            //List<Dictionary<string, object>> batch =
            //new List<Dictionary<string, object>>();

            //Dictionary<string, object> entry = new Dictionary<string, object>();
            //entry.Add("EMAIL", email);
            //entry.Add("EMAIL_TYPE", emailType);
            //entry.Add("FNAME", firstName);
            //entry.Add("LNAME", lastName);

            //batch.Add(entry);

            //input.parms.batch = batch;
            //// execution
            //listBatchSubscribe cmd = new listBatchSubscribe(input);
            //listBatchSubscribeOutput output = cmd.Execute();
            // output, format with user control

            MailChimpApi _api = new MailChimpApi();
            var responseData = _api.CreateMember(email, firstName, lastName);

            if (responseData.status != "subscribed")

            {
                var eventLogProvider = new EventLogProvider();
                eventLogProvider.LogEvent("E", DateTime.Now, "Mail Chimp",
                   "type:"+ responseData.type+"</br>"
                   + "title:" + responseData.title + "</br>"
                   + "status:" + responseData.status + "</br>"
                   + "detail:" + responseData.detail + "</br>"
                   + "instance:" + responseData.instance + "</br>"
                   );
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion
    }
}
