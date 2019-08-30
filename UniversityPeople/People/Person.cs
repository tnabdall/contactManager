using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityPeople.ContactInformations;

namespace UniversityPeople.People
{
    public abstract class Person
    {
        /// <summary>
        /// First name. Can't be empty.
        /// </summary>
        public String FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("First name cannot be empty");
                }
                else
                {
                    firstName = value;
                }
            }
        }

        /// <summary>
        /// Last name. Can't be empty.
        /// </summary>
        public String LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Last name cannot be empty");
                }
                else
                {
                    lastName = value;
                }
            }
        }

        /// <summary>
        /// Academic department. Can't be empty.
        /// </summary>
        public String AcademicDepartment
        {
            get
            {
                return academicDepartment;
            }
            set
            {
                if (String.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Must assign an academic department. Uses GNST for general studies.");
                }
                else
                {
                    academicDepartment = value;
                }
            }
        }

        /// <summary>
        /// Contact information. Can't be empty.
        /// </summary>
        public ContactInformation ContactInformation
        {
            get
            {
                return contactInformation;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Must have contact info");
                }
                else
                {
                    contactInformation = value;
                }
            }
        }

        private String firstName;
        private String lastName;
        private String academicDepartment;
        private ContactInformation contactInformation;

        /// <summary>
        /// Creates a person.
        /// </summary>
        /// <param name="initialFirstName">First name. Required.</param>
        /// <param name="initialLastName">Last name. Required.</param>
        /// <param name="initialAcademicDepartment">Academic Department. Required.</param>
        /// <param name="initialContactInformation">Contact Information. Required.</param>
        public Person(String initialFirstName, String initialLastName, String initialAcademicDepartment, ContactInformation initialContactInformation)
        {
            FirstName = initialFirstName;
            LastName = initialLastName;
            AcademicDepartment = initialAcademicDepartment;
            ContactInformation = initialContactInformation;
        }

        /// <summary>
        /// Displays a formatted string for list box
        /// </summary>
        /// <returns>Listbox string</returns>
        public abstract String ToListBoxString();

        public override string ToString()
        {
            return $"First Name: {FirstName} \nLast Name: {LastName} \nDepartment: {AcademicDepartment} \n";
        }
    }
}
