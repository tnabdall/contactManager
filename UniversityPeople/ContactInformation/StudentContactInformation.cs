﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityPeople
{
    public class StudentContactInformation : ContactInformation
    {
        /// <summary>
        /// Student's mailing address
        /// </summary>
        public String MailingAddress
        {
            get
            {
                return mailingAddress;
            }

            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Mailing address cannot be empty");
                }
                else
                {
                    mailingAddress = value;
                }
            }
        }

        private String mailingAddress;

        /// <summary>
        /// Creates a student's contact information
        /// </summary>
        /// <param name="initialEmailAddress">Email address. Required.</param>
        /// <param name="initialMailingAddress">Student's mailing address.</param>
        public StudentContactInformation(String initialEmailAddress, String initialMailingAddress) : base(initialEmailAddress)
        {
            MailingAddress = initialMailingAddress;
        }
    }
}