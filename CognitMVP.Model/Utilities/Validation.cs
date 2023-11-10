using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DacsOnline.Model.Utilities
{
    public class Validation
    {
        /// <summary>
        /// Validates the email address.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns></returns>
        public static bool ValidateEmailAddress(string email)
        {
            var regex = new Regex(@"[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?");
            return regex.IsMatch(email); 
            

        }

        /// <summary>
        /// Validates the phone number.
        /// </summary>
        /// <param name="mobile">The mobile.</param>
        /// <returns></returns>
        public static bool ValidatePhoneNumber(string mobile)
        {
            var regex = new Regex(@"(^(\+?\-? *[0-9]+)([,0-9 ]*)([0-9 ])*$)|(^ *$)");
            return regex.IsMatch(mobile);

        }

        /// <summary>
        /// Validates the website.
        /// </summary>
        /// <param name="website">The website.</param>
        /// <returns></returns>
        public static bool ValidateWebsite(string website)
        {
            var regex = new Regex(@"(([\w]+:)?\/\/)?(([\d\w]|%[a-fA-f\d]{2,2})+(:([\d\w]|%[a-fA-f\d]{2,2})+)?@)?([\d\w][-\d\w]{0,253}[\d\w]\.)+[\w]{2,4}(:[\d]+)?(\/([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)*(\?(&?([-+_~.\d\w]|%[a-fA-f\d]{2,2})=?)*)?(#([-+_~.\d\w]|%[a-fA-f\d]{2,2})*)?$");
            return regex.IsMatch(website);

        }

        /// <summary>
        /// Validates the date.
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns></returns>
        public static bool ValidateDate(string date)
        {
            DateTime temp; 
            if(DateTime.TryParse(date, out temp)) 
            {
                return true;
            }
            else{
                return false;
            }

        }
    }
}
