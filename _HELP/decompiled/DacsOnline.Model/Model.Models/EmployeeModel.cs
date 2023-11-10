using System;
using System.Runtime.CompilerServices;

namespace DacsOnline.Model.Models
{
	public class EmployeeModel
	{
		public string Department
		{
			get;
			set;
		}

		public string EmployeeTitle
		{
			get;
			set;
		}

		public string FirstName
		{
			get;
			set;
		}

		public long Id
		{
			get;
			set;
		}

		public string LastName
		{
			get;
			set;
		}

		public decimal Salary
		{
			get;
			set;
		}

		public EmployeeModel()
		{
		}
	}
}