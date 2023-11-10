using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DacsOnline.Model.Enums;
using DacsOnline.Model.Business_Objects;

namespace DacsOnline.Model.Utilities
{
    public static  class ExtentionMethods
    {
        #region //static Method
        /// <summary>
        /// Gets the valid string.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public static string GetValidString(this Object obj)
        {
            try
            {
                if (obj == null)
                {
                    return string.Empty;
                }
                else
                {
                    return obj.ToString();
                }
            }
            catch (Exception ee)
            {
                throw;
            }
            
        }
        /// <summary>
        /// Gets the valid date.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public static DateTime ? GetValidDate(this Object obj)
        {
            try
            {
                if (obj == null || string.IsNullOrEmpty(obj.ToString().Trim()))
                {
                    return null;
                }
                else
                {
                    return Convert.ToDateTime(obj);
                }

            }
            catch (Exception ee)
            {
                throw;
            }

        }

        /// <summary>
        /// Gets the valid date.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public static bool GetValidBoolean(this Object obj)
        {
            try
            {
                if (obj.ToString().ToLower() == "true")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ee)
            {

                throw;
            }
           

        }

        /// <summary>
        /// Gets the valid ARR member.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public static ARRMembershipType GetValidARRMember(this Object obj)
        {
            try
            {
                if (obj == null || string.IsNullOrEmpty(obj.ToString().Trim()))
                {
                    return ARRMembershipType.Default;
                }
                else
                {
                    if (Enum.IsDefined(typeof(ARRMembershipType), obj))
                    {
                        return (ARRMembershipType)Enum.Parse(typeof(ARRMembershipType), obj.ToString(), true);
                    }
                    else
                    {
                        return ARRMembershipType.Default;
                    }


                }
            }
            catch (Exception ee)
            {

                throw;
            }
 
        }

        /// <summary>
        /// Gets the valid ARR confirmed nationality.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public static ARRConfirmedNationalityType GetValidARRConfirmedNationality(this Object obj)
        {
            try
            {
                if (obj == null || string.IsNullOrEmpty(obj.ToString().Trim()))
                {
                    return ARRConfirmedNationalityType.Default;
                }
                else
                {
                    if (Enum.IsDefined(typeof(ARRConfirmedNationalityType), obj))
                    {
                        return (ARRConfirmedNationalityType)Enum.Parse(typeof(ARRConfirmedNationalityType), obj.ToString(), true);
                    }
                    else
                    {
                        return ARRConfirmedNationalityType.Default;
                    }


                }
            }
            catch (Exception ee)
            {
                throw;
            }

        }

        /// <summary>
        /// Gets the valid ARR paid royalties.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public static ARRPaidRoyalties GetValidARRPaidRoyalties(this Object obj)
        {
            try
            {
                if (obj == null || string.IsNullOrEmpty(obj.ToString().Trim()))
                {
                    return ARRPaidRoyalties.Default;
                }
                else
                {
                    if (Enum.IsDefined(typeof(ARRPaidRoyalties), obj))
                    {
                        return (ARRPaidRoyalties)Enum.Parse(typeof(ARRPaidRoyalties), obj.ToString(), true);
                    }
                    else
                    {
                        return ARRPaidRoyalties.Default;
                    }


                }
            }
            catch (Exception ee)
            {
                throw;
            }

        }

        /// <summary>
        /// Gets the type of the valid CL memebership.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public static CLMemebershipType GetValidCLMemebershipType(this Object obj)
        {
            try
            {
                if (obj == null || string.IsNullOrEmpty(obj.ToString().Trim()))
                {
                    return CLMemebershipType.Default;
                }
                else
                {
                    if (Enum.IsDefined(typeof(CLMemebershipType), obj))
                    {
                        return (CLMemebershipType)Enum.Parse(typeof(CLMemebershipType), obj.ToString(), true);
                    }
                    else
                    {
                        return CLMemebershipType.Default;
                    }


                }
            }
            catch (Exception ee)
            {
                throw;
            }

        }


        /// <summary>
        /// Gets the valid CL full consultation.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public static CLFullConsultationType GetValidCLFullConsultation(this Object obj)
        {
            try
            {
                if (obj == null || string.IsNullOrEmpty(obj.ToString().Trim()))
                {
                    return CLFullConsultationType.Default;
                }
                else
                {
                    if (Enum.IsDefined(typeof(CLFullConsultationType), obj))
                    {
                        return (CLFullConsultationType)Enum.Parse(typeof(CLFullConsultationType), obj.ToString(), true);
                    }
                    else
                    {
                        return CLFullConsultationType.Default;
                    }


                }
            }
            catch (Exception ee)
            {
                throw;
            }

        }

        /// <summary>
        /// Determines whether the specified STR contains any.
        /// </summary>
        /// <param name="str">The STR.</param>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified STR contains any; otherwise, <c>false</c>.
        /// </returns>
        public static bool ContainsFirstCharartor(this string str, string value)
        {
            if (!string.IsNullOrEmpty(str))
            {
                string val = str.Substring(0, 1).ToUpper();
                return val==value.ToUpper()?true:false;
            }

            return false;
        }


      

        #endregion
    }
}
