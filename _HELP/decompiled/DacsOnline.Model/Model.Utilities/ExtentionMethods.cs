using DacsOnline.Model.Enums;
using System;
using System.Runtime.CompilerServices;

namespace DacsOnline.Model.Utilities
{
	public static class ExtentionMethods
	{
		public static bool ContainsFirstCharartor(this string str, string value)
		{
			bool flag;
			if (string.IsNullOrEmpty(str))
			{
				flag = false;
			}
			else
			{
				flag = (str.Substring(0, 1).ToUpper() == value.ToUpper() ? true : false);
			}
			return flag;
		}

		public static ARRConfirmedNationalityType GetValidARRConfirmedNationality(this object obj)
		{
			ARRConfirmedNationalityType aRRConfirmedNationalityType;
			try
			{
				if ((obj == null ? false : !string.IsNullOrEmpty(obj.ToString().Trim())))
				{
					aRRConfirmedNationalityType = (!Enum.IsDefined(typeof(ARRConfirmedNationalityType), obj) ? ARRConfirmedNationalityType.Default : (ARRConfirmedNationalityType)Enum.Parse(typeof(ARRConfirmedNationalityType), obj.ToString(), true));
				}
				else
				{
					aRRConfirmedNationalityType = ARRConfirmedNationalityType.Default;
				}
			}
			catch (Exception exception)
			{
				throw;
			}
			return aRRConfirmedNationalityType;
		}

		public static ARRMembershipType GetValidARRMember(this object obj)
		{
			ARRMembershipType aRRMembershipType;
			try
			{
				if ((obj == null ? false : !string.IsNullOrEmpty(obj.ToString().Trim())))
				{
					aRRMembershipType = (!Enum.IsDefined(typeof(ARRMembershipType), obj) ? ARRMembershipType.Default : (ARRMembershipType)Enum.Parse(typeof(ARRMembershipType), obj.ToString(), true));
				}
				else
				{
					aRRMembershipType = ARRMembershipType.Default;
				}
			}
			catch (Exception exception)
			{
				throw;
			}
			return aRRMembershipType;
		}

		public static ARRPaidRoyalties GetValidARRPaidRoyalties(this object obj)
		{
			ARRPaidRoyalties aRRPaidRoyalty;
			try
			{
				if ((obj == null ? false : !string.IsNullOrEmpty(obj.ToString().Trim())))
				{
					aRRPaidRoyalty = (!Enum.IsDefined(typeof(ARRPaidRoyalties), obj) ? ARRPaidRoyalties.Default : (ARRPaidRoyalties)Enum.Parse(typeof(ARRPaidRoyalties), obj.ToString(), true));
				}
				else
				{
					aRRPaidRoyalty = ARRPaidRoyalties.Default;
				}
			}
			catch (Exception exception)
			{
				throw;
			}
			return aRRPaidRoyalty;
		}

		public static bool GetValidBoolean(this object obj)
		{
			bool flag;
			try
			{
				flag = (!(obj.ToString().ToLower() == "true") ? false : true);
			}
			catch (Exception exception)
			{
				throw;
			}
			return flag;
		}

		public static CLFullConsultationType GetValidCLFullConsultation(this object obj)
		{
			CLFullConsultationType cLFullConsultationType;
			try
			{
				if ((obj == null ? false : !string.IsNullOrEmpty(obj.ToString().Trim())))
				{
					cLFullConsultationType = (!Enum.IsDefined(typeof(CLFullConsultationType), obj) ? CLFullConsultationType.Default : (CLFullConsultationType)Enum.Parse(typeof(CLFullConsultationType), obj.ToString(), true));
				}
				else
				{
					cLFullConsultationType = CLFullConsultationType.Default;
				}
			}
			catch (Exception exception)
			{
				throw;
			}
			return cLFullConsultationType;
		}

		public static CLMemebershipType GetValidCLMemebershipType(this object obj)
		{
			CLMemebershipType cLMemebershipType;
			try
			{
				if ((obj == null ? false : !string.IsNullOrEmpty(obj.ToString().Trim())))
				{
					cLMemebershipType = (!Enum.IsDefined(typeof(CLMemebershipType), obj) ? CLMemebershipType.Default : (CLMemebershipType)Enum.Parse(typeof(CLMemebershipType), obj.ToString(), true));
				}
				else
				{
					cLMemebershipType = CLMemebershipType.Default;
				}
			}
			catch (Exception exception)
			{
				throw;
			}
			return cLMemebershipType;
		}

		public static DateTime? GetValidDate(this object obj)
		{
			DateTime? nullable;
			try
			{
				if ((obj == null ? false : !string.IsNullOrEmpty(obj.ToString().Trim())))
				{
					nullable = new DateTime?(Convert.ToDateTime(obj));
				}
				else
				{
					nullable = null;
				}
			}
			catch (Exception exception)
			{
				throw;
			}
			return nullable;
		}

		public static string GetValidString(this object obj)
		{
			string str;
			try
			{
				str = (obj != null ? obj.ToString() : string.Empty);
			}
			catch (Exception exception)
			{
				throw;
			}
			return str;
		}
	}
}