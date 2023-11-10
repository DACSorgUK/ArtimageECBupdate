using System;
using System.Runtime.CompilerServices;

namespace DacsOnline.Model.Business_Objects
{
	public class Document
	{
		public string DocumentPath
		{
			get;
			set;
		}

		public string FormBelong
		{
			get;
			set;
		}

		public string Title
		{
			get;
			set;
		}

		public bool Visible
		{
			get;
			set;
		}

		public Document()
		{
		}
	}
}