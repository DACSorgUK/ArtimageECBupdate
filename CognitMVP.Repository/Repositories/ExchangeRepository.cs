using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using DacsOnline.Model.Dto;
using DacsOnline.Model.RepostioriesInterfaces;
using RestSharp;

namespace DacsOnline.Repository.Repositories
{
    public class ExchangeRepository : IExchangeRepository
    {
        /// <summary>
        /// GetExchangeGBP get the rate exchage in pounds for a datetime
        /// </summary>
        /// <param name="datetime">the date time that insert the user</param>
        /// <returns>the exchange in pounds</returns>
        public decimal GetExchangeGBP(DateTime datetime)
        {
            bool rep = true;
            int count = 1; //only check 5 days if know return 0
            DateTime preferredExchangeDate = datetime;
            string result = "-1";
            //check if the date if more than 5 days in the future then get the day of today. 
            TimeSpan diff = datetime.Subtract(DateTime.Today);
            if (diff.Days > 5)
            {
                preferredExchangeDate = DateTime.Today;
            }
            while (rep && count > 0)
            {
                // using System.Net;
                ServicePointManager.Expect100Continue = true;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
                // Use SecurityProtocolType.Ssl3 if needed for compatibility reasons

                //string url =
                //    "https://data-api.ecb.europa.eu/service/data/EXR/D.GBP.EUR.SP00.A?type=sdmx&startPeriod=" +
                //    FormatDate(preferredExchangeDate) + "&endPeriod=" + FormatDate(preferredExchangeDate) + "";
                ///////
                ///

                //string baseURL = "https://data-api.ecb.europa.eu/service/data/EXR";
                //string uri = "/D.GBP.EUR.SP00.A?format=jsondata&startPeriod=2023-11-06&endPeriod=2023-11-06";

                string baseURL = "https://data-api.ecb.europa.eu/service/data/EXR";
                string uri = "/D.GBP.EUR.SP00.A?startPeriod=2023-11-06&endPeriod=2023-11-06";

                rep = false;
                count--;


                RestClient client = new RestClient();
                client.BaseUrl = new Uri(baseURL);
               
                var request = new RestRequest(uri, Method.GET);

                //request.RequestFormat = DataFormat.Json;
                //var response = client.Execute<RootResponse>(request);
                //var value = response.Data.dataSets[0].series._00000;

                request.RequestFormat = DataFormat.Xml;
                var response = client.Execute<dynamic>(request);
                // var value = response.Data.dataSets[0].series._00000;

                XmlDocument xmlDoc = new XmlDocument();
                string data = response.Content;
                if(data.Contains("<generic:ObsValue"))
                {
                    string[] temp = data.Split(new string[] { "generic:ObsValue value=" }, StringSplitOptions.None);
                    string[] temp2 = temp[1].Split(new string[] { "/>" }, StringSplitOptions.None);
                    result = temp2[0].Trim('"');
                }

            }

            return Decimal.Parse(result);



        }

        private string FormatDate(DateTime datetime)
        {
            return  datetime.Year + "-" + AddZero(datetime.Month.ToString()) + "-" + AddZero(datetime.Day.ToString());

        }

        private string AddZero(string s)
        {
            if (s.Length == 1)
                return "0" + s;
            else
                return s;
        }

        private static XElement RemoveAllNamespaces(XElement xmlDocument)
        {
            if (!xmlDocument.HasElements)
            {
                XElement xElement = new XElement(xmlDocument.Name.LocalName);
                xElement.Value = xmlDocument.Value;

                foreach (XAttribute attribute in xmlDocument.Attributes())
                    xElement.Add(attribute);

                return xElement;
            }
            return new XElement(xmlDocument.Name.LocalName, xmlDocument.Elements().Select(el => RemoveAllNamespaces(el)));
        }


    }

    
}
