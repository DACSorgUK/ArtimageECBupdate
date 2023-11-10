using CMS.CMSHelper;
using CMS.EmailEngine;
using CMS.EventLog;
using CMS.GlobalHelper;
using CMS.SiteProvider;
using System;

namespace DacsOnline.Model.Utilities
{
	public class SendEmail
	{
		public SendEmail()
		{
		}

		public static int GetSiteInfo()
		{
			return SiteInfoProvider.GetCurrentSite().get_SiteID();
		}

		public static void SendEmailUsingTemplate(string emailTemplateName, string recipientEmail, string[,] replacements)
		{
			SendEmail.SendUserEmail(emailTemplateName, recipientEmail, replacements, string.Empty);
		}

		public static void SendEmailUsingTemplate(string emailTemplateName, string recipientEmail, string[,] replacements, string bodyReplacements)
		{
			SendEmail.SendUserEmail(emailTemplateName, recipientEmail, replacements, bodyReplacements);
		}

		private static void SendUserEmail(string emailTemplateName, string recipientEmail, string[,] replacements, string bodyReplacements)
		{
			ContextResolver resolver = CMSContext.get_CurrentResolver();
			resolver.set_SourceParameters(replacements);
			EmailTemplateInfo template = EmailTemplateProvider.GetEmailTemplate(emailTemplateName, SendEmail.GetSiteInfo());
			if (template != null)
			{
				EmailMessage emailMessage1 = new EmailMessage();
				emailMessage1.set_EmailFormat(0);
				emailMessage1.set_Recipients(template.get_TemplateCc());
				emailMessage1.set_From(template.get_TemplateFrom());
				emailMessage1.set_CcRecipients(recipientEmail);
				emailMessage1.set_BccRecipients(template.get_TemplateBcc());
				emailMessage1.set_Subject(resolver.ResolveMacros(template.get_TemplateSubject()));
				emailMessage1.set_PlainTextBody(resolver.ResolveMacros(template.get_TemplatePlainText()));
				EmailMessage emailMessage = emailMessage1;
				resolver.set_EncodeResolvedValues(true);
				if (string.IsNullOrEmpty(bodyReplacements.Trim()))
				{
					emailMessage.set_Body(resolver.ResolveMacros(template.get_TemplateText()));
				}
				else
				{
					emailMessage.set_Body(resolver.ResolveMacros(template.get_TemplateText()));
					emailMessage.set_Body(emailMessage.get_Body().Replace("|**|", bodyReplacements));
				}
				resolver.set_EncodeResolvedValues(false);
				try
				{
					MetaFileInfoProvider.ResolveMetaFileImages(emailMessage, template.get_TemplateID(), "cms.emailtemplate", "Template");
					EmailSender.SendEmail(CMSContext.get_CurrentSiteName(), emailMessage, true);
				}
				catch (Exception exception)
				{
					(new EventLogProvider()).LogEvent("E", emailTemplateName, exception);
					throw;
				}
			}
		}
	}
}