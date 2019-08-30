using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UniversityPeople.ContactInformations
{
    public abstract class ContactInformation
    {
        /// <summary>
        /// Email address. Requires correct format.
        /// </summary>
        public String EmailAddress
        {
            get
            {
                return emailAddress;
            }
            set
            {
                bool isEmail = Regex.IsMatch(value, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (isEmail)
                {
                    emailAddress = value;
                }
                else
                {
                    throw new ArgumentException("You have not specified a correct email format.");
                }
            }
        }

        private String emailAddress;

        /// <summary>
        /// Constructor that initializes email address
        /// </summary>
        /// <param name="initialEmailAddress">Contact's email</param>
        public ContactInformation(String initialEmailAddress)
        {
            EmailAddress = initialEmailAddress;
        }
    }
}
