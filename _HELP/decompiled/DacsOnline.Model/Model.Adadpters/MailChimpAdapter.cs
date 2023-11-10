using CMS.EventLog;
using DacsOnline.Model.Manager.Interfaces;
using PerceptiveMCAPI;
using PerceptiveMCAPI.Methods;
using PerceptiveMCAPI.Types;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;

namespace DacsOnline.Model.Adadpters
{
	public class MailChimpAdapter : ISubscribeEmail
	{
		public MailChimpAdapter()
		{
		}

		public bool SubscribeUser(string email, string emailType, string firstName, string lastName)
		{
			bool flag;
			listBatchSubscribeInput input = new listBatchSubscribeInput()
			{
				api_Validate = false,
				api_AccessType = EnumValues.AccessType.Serial,
				api_OutputType = EnumValues.OutputType.JSON
			};
			input.parms.apikey = ConfigurationManager.AppSettings["MailChimpKey"].ToString();
			input.parms.id = ConfigurationManager.AppSettings["MailChimpListId"].ToString();
			input.parms.double_optin = false;
			input.parms.replace_interests = true;
			input.parms.update_existing = true;
			List<Dictionary<string, object>> batch = new List<Dictionary<string, object>>();
			Dictionary<string, object> entry = new Dictionary<string, object>()
			{
				{ "EMAIL", email },
				{ "EMAIL_TYPE", emailType },
				{ "FNAME", firstName },
				{ "LNAME", lastName }
			};
			batch.Add(entry);
			input.parms.batch = batch;
			listBatchSubscribeOutput output = (new listBatchSubscribe(input)).Execute();
			if (output.api_ErrorMessages.Count <= 0)
			{
				flag = true;
			}
			else
			{
				EventLogProvider eventLogProvider = new EventLogProvider();
				eventLogProvider.LogEvent("E", DateTime.Now, "Mail Chimp", output.api_ErrorMessages[0].error);
				flag = false;
			}
			return flag;
		}
	}
}