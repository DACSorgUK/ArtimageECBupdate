using DacsOnline.Model.RepostioriesInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace DacsOnline.Repository.Repositories
{
	public class ExchangeRepository : IExchangeRepository
	{
		public ExchangeRepository()
		{
		}

		private string AddZero(string s)
		{
			string str;
			str = (s.Length != 1 ? s : string.Concat("0", s));
			return str;
		}

		private string FormatDate(DateTime datetime)
		{
			object[] year = new object[5];
			int day = datetime.Day;
			year[0] = this.AddZero(day.ToString());
			year[1] = "-";
			day = datetime.Month;
			year[2] = this.AddZero(day.ToString());
			year[3] = "-";
			year[4] = datetime.Year;
			return string.Concat(year);
		}

		public decimal GetExchangeGBP(DateTime datetime)
		{
			bool rep = true;
			int count = 7;
			DateTime preferredExchangeDate = datetime;
			string result = "-1";
			if (datetime.Subtract(DateTime.Today).Days > 5)
			{
				preferredExchangeDate = DateTime.Today;
			}
			while (true)
			{
				if ((!rep ? true : count <= 0))
				{
					break;
				}
				string url = string.Concat("http://sdw.ecb.europa.eu/quickviewexport.do?SERIES_KEY=EXR.D.GBP.EUR.SP00.A&type=sdmx&start=", this.FormatDate(preferredExchangeDate), "&end=", this.FormatDate(preferredExchangeDate));
				XElement exchangeRates = XElement.Load(url);
				exchangeRates = ExchangeRepository.RemoveAllNamespaces(exchangeRates);
				if (exchangeRates.Element("DataSet") == null)
				{
					preferredExchangeDate = preferredExchangeDate.AddDays(-1);
					count--;
				}
				else
				{
					result = (
						from item in exchangeRates.Elements("DataSet").Elements<XElement>("Series").Elements<XElement>("Obs")
						select item.Attribute("OBS_VALUE").Value).First<string>().ToString();
					if (!(result != "NaN"))
					{
						preferredExchangeDate = preferredExchangeDate.AddDays(-1);
						count--;
					}
					else
					{
						rep = false;
					}
				}
			}
			return decimal.Parse(result);
		}

		private static XElement RemoveAllNamespaces(XElement xmlDocument)
		{
			XElement xElement1;
			if (xmlDocument.HasElements)
			{
				xElement1 = new XElement(xmlDocument.Name.LocalName, 
					from el in xmlDocument.Elements()
					select ExchangeRepository.RemoveAllNamespaces(el));
			}
			else
			{
				XElement xElement = new XElement(xmlDocument.Name.LocalName)
				{
					Value = xmlDocument.Value
				};
				foreach (XAttribute attribute in xmlDocument.Attributes())
				{
					xElement.Add(attribute);
				}
				xElement1 = xElement;
			}
			return xElement1;
		}
	}
}