using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CMS.TreeEngine;
using CMS.SettingsProvider;
using CMS.FormEngine;
using CMS.FormControls;
using DacsOnline.Model.Manager.Interfaces;
using DacsOnline.Model.Adadpters;
using CMS.DataEngine;
using CMS.GlobalHelper;

/// <summary>
/// Summary description for CustomFormEvents
/// </summary>
public class CustomFormEvents
{
    public CustomFormEvents()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}

[CustomFormEvents]
public partial class CMSModuleLoader
{
    /// <summary>
    /// Attribute class that ensures the loading of custom handlers
    /// </summary>
    private class CustomFormEventsAttribute : CMSLoaderAttribute
    {
        /// <summary>
        /// Called automatically when the application starts
        /// </summary>
        public override void Init()
        {
            // Assigns custom handlers to the appropriate events
            ObjectEvents.Insert.After += Form_Insert_After;
        }

        private void Form_Insert_After(object sender, ObjectEventArgs e)
        {

            //if (e.Object.TypeInfo.ObjectType == "bizformitem.bizform.artistresalesrightservice")
            //{
            //    IDataClass dataItem = (IDataClass)e.Object;

            //    string firstname = ValidationHelper.GetString(dataItem.GetValue("firstname"), "--");
            //    string lastname = ValidationHelper.GetString(dataItem.GetValue("lastname"), "--");
            //    string email = ValidationHelper.GetString(dataItem.GetValue("Email"), "--");

            //    // we want to handle only updates of user objects
            //    //if (dataItem.ClassName.ToLower() == "cms.user")
            //    //{
            //    //    // we will use the CMS.EmailProvider to send e-mails
            //    //    EmailMessage email = new EmailMessage();
            //    //    email.From = "admin@domain.com";
            //    //    // get the user's e-mail address
            //    //    email.Recipients = ValidationHelper.GetString(dataItem.GetValue("Email"), "admin@domain.com");
            //    //    email.Subject = "Your password";
            //    //    // get the user's password
            //    //    email.Body = "Your password is:" + ValidationHelper.GetString(dataItem.GetValue("UserPassword"), "");
            //    //    EmailSender.SendEmail(email);
            //    //}

            //    ISubscribeEmail subscribeAdapter = new MailChimpAdapter();
            //    bool apiStatus =  subscribeAdapter.SubscribeUser(email, "HTML", firstname, lastname);
            //}

            // Add custom actions here
            //switch (e.Object.TypeInfo.ObjectType)
            //{
            //    case "bizformitem.bizform.artistresalesrightservice":
            //        // do your work here
            //        break;
            //    default:
            //        break;
            //}
        }

        private void Form_InsertLink_Before(object sender, DocumentEventArgs e)
        {
            // Add custom actions here
        }
    }
}