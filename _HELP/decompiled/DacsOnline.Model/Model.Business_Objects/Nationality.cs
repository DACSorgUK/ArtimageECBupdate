using System;
using System.Runtime.CompilerServices;

namespace DacsOnline.Model.Business_Objects
{
	public class Nationality
	{
		public string Country
		{
			get;
			set;
		}

		public bool EEA
		{
			get;
			set;
		}

		public string Person
		{
			get;
			set;
		}

		public Nationality()
		{
		}
	}
}