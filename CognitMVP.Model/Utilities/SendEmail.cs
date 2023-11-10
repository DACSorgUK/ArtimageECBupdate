using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CMS.GlobalHelper;
using CMS.CMSHelper;
using CMS.EmailEngine;
using CMS.SiteProvider;
using CMS.EventLog;
using DacsOnline.Model.Enums;

namespace DacsOnline.Model.Utilities
{
    public class SendEmail
    {

        #region //Public  Methods
        /// <summary>
        /// Sends the email using template.
        /// </summary>
        /// <param name="emailTemplateName">Name of the email template.</param>
        /// <param name="recipientEmail">The recipient email.</param>
        /// <param name="replacements">The replacements.</param>
        /// <param name="eventName">Name of the event.</param>
        public static void SendEmailUsingTemplate(string emailTemplateName, string recipientEmail, string[,] replacements)
        {
            SendUserEmail(emailTemplateName, recipientEmail, replacements, string.Empty);
        }

        /// <summary>
        /// Sends the email using template.
        /// </summary>
        /// <param name="emailTemplateName">Name of the email template.</param>
        /// <param name="recipientEmail">The recipient email.</param>
        /// <param name="replacements">The replacements.</param>
        /// <param name="bodyReplacements">The body replacements.</param>
        public static void SendEmailUsingTemplate(string emailTemplateName, string recipientEmail, string[,] replacements, string bodyReplacements)
        {
            SendUserEmail(emailTemplateName, recipientEmail, replacements, bodyReplacements);

        }

        /// <summary>
        /// Gets the site info.
        /// </summary>
        /// <returns></returns>
        public static int GetSiteInfo()
        {
            return SiteInfoProvider.GetCurrentSite().SiteID;
        }
        #endregion

        #region //Private Methods
        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="emailTemplateName">Name of the email template.</param>
        /// <param name="recipientEmail">The recipient email.</param>
        /// <param name="replacements">The replacements.</param>
        /// <param name="bodyReplacements">The body replacements.</param>
        private static void SendUserEmail(string emailTemplateName, string recipientEmail, string[,] replacements, string bodyReplacements)
        {
            // Set resolver  
            ContextResolver resolver = CMSContext.CurrentResolver;
            resolver.SourceParameters = replacements;

            // Get the email template  
            var template = EmailTemplateProvider.GetEmailTemplate(emailTemplateName, GetSiteInfo());

            if (template != null)
            {
                // Email message  
                var emailMessage = new EmailMessage
                {
                    EmailFormat = EmailFormatEnum.Html,
                    Recipients = template.TemplateCc,
                    From = template.TemplateFrom,
                    CcRecipients = recipientEmail,
                    BccRecipients = template.TemplateBcc,
                    Subject = resolver.ResolveMacros(template.TemplateSubject),
                    PlainTextBody = resolver.ResolveMacros(template.TemplatePlainText)
                };

                // Enable macro encoding for body  
                resolver.EncodeResolvedValues = true;

                if (!string.IsNullOrEmpty(bodyReplacements.Trim()))
                {
                    emailMessage.Body = resolver.ResolveMacros(template.TemplateText);
                    emailMessage.Body = emailMessage.Body.Replace("|**|", bodyReplacements);
                }
                else
                {
                    emailMessage.Body = resolver.ResolveMacros(template.TemplateText);
                }



                // Disable macro encoding for plaintext body and subject  
                resolver.EncodeResolvedValues = false;

                try
                {
                    MetaFileInfoProvider.ResolveMetaFileImages(emailMessage, template.TemplateID, EmailObjectType.EMAILTEMPLATE, MetaFileInfoProvider.OBJECT_CATEGORY_TEMPLATE);
                    // Send the e-mail immediately  
                    EmailSender.SendEmail(CMSContext.CurrentSiteName, emailMessage, true);
                }
                catch (Exception ex)
                {
                    var eventLogProvider = new EventLogProvider();
                    eventLogProvider.LogEvent("E", emailTemplateName, ex);

                    throw;

                }
            }
        }

        public static void SendSimpleEmail(string from, string to, string sub, string body)
        {
            // Set resolver  
            ContextResolver resolver = CMSContext.CurrentResolver;

            var emailMessage = new EmailMessage
            {
                EmailFormat = EmailFormatEnum.Html,
                Recipients = to,
                From = from,
                Subject = sub,
                PlainTextBody = resolver.ResolveMacros(body),
                Body = body

            };

            try
            {
                //  MetaFileInfoProvider.ResolveMetaFileImages(emailMessage, template.TemplateID, EmailObjectType.EMAILTEMPLATE, MetaFileInfoProvider.OBJECT_CATEGORY_TEMPLATE);
                // Send the e-mail immediately  
                EmailSender.SendEmail(CMSContext.CurrentSiteName, emailMessage, true);
            }
            catch (Exception ex)
            {

            }
        }


        #endregion
    }
}
