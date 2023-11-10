using CMS.SettingsProvider;
using CMS.SiteProvider;
using DacsOnline.Model.Business_Objects;
using DacsOnline.Model.Dto;
using DacsOnline.Model.Enums;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Configuration;

namespace DacsOnline.Model.Manager
{
    public class MailChimpApi
    {
        string baseURL = "https://us2.api.mailchimp.com/3.0";
        //SettingsKeyProvider.GetStringValue("BaseURL");
        //"https://dacs-api.sapphire-cloud.net/SapWebAPI/api/1234/";

        string token = "db6b9518647326397567b354b85d8a69-us2";
        public MailChimpMembersCreateResult CreateMember(string email, string firstName, string lastName)
        {
            RestClient client = new RestClient();
            client.BaseUrl = new Uri(baseURL);
            string uri = "/lists/de159500fe/members";

            var request = new RestRequest(uri, Method.POST);

            request.AddHeader("authorization", "Basic " + token);
            request.RequestFormat = DataFormat.Json;

            var data = new MailChimpMembersCreateRequest
            {
                email_address = email,
                status = "subscribed",
                email_type = "html",
                merge_fields =
                    new Merge_Fields
                    {
                        FNAME = firstName,
                        LNAME = lastName
                    }
            };

            request.AddJsonBody(data);

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;

            var response = client.Execute<MailChimpMembersCreateResult>(request);

            return response.Data;
        }
    }
}

namespace DacsOnline.Model.Dto
{
    public class MailChimpMembersCreateRequest
    {
        public string email_address { get; set; }
        public string status { get; set; }
        public string email_type { get; set; }
        public Merge_Fields merge_fields { get; set; }
    }

    public class MailChimpMembersCreateResult
    {
        public string id { get; set; }
        public string email_address { get; set; }
        public string unique_email_id { get; set; }
        public int web_id { get; set; }
        public string email_type { get; set; }
        public string status { get; set; }

        public string ip_signup { get; set; }
        public string timestamp_signup { get; set; }
        public string ip_opt { get; set; }
        //  public DateTime timestamp_opt { get; set; }
        public int member_rating { get; set; }
        //  public DateTime last_changed { get; set; }
        public string language { get; set; }
        public bool vip { get; set; }
        public string email_client { get; set; }
        //  public Location location { get; set; }
        public string source { get; set; }
        public int tags_count { get; set; }


        public string type { get; set; }
        public string title { get; set; }
        public string detail { get; set; }
        public string instance { get; set; }
        public Error[] errors { get; set; }
    }

    public class Merge_Fields
    {
        public string FNAME { get; set; }
        public string LNAME { get; set; }
    }

    public class Error
    {
        public string field { get; set; }
        public string message { get; set; }
    }


}
