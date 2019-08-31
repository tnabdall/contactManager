using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityPeople.ContactInformations;

namespace UniversityPeople.People
{
    public class Faculty : Person
    {
        /// <summary>
        /// Accessor for contact information so that the FacultyContactInformation type is returned
        /// </summary>
        public new FacultyContactInformation ContactInformation
        {
            get
            {
                return (FacultyContactInformation)base.ContactInformation;
            }
            set
            {
                base.ContactInformation = value;
            }
        }

        /// <summary>
        /// Creates a faculty member.
        /// </summary>
        /// <param name="initialFirstName">First name. Required.</param>
        /// <param name="initialLastName">Last name. Required.</param>
        /// <param name="initialAcademicDepartment">Academic Department. Required.</param>
        /// <param name="initialContactInformation">Contact Information. Required.</param>
        public Faculty(String initialFirstName, String initialLastName, String initialAcademicDepartment, FacultyContactInformation initialContactInformation) : base(initialFirstName, initialLastName, initialAcademicDepartment, initialContactInformation)
        {
            // Nothing unique yet
        }

        /// <summary>
        /// Builds a Faculty from file string
        /// </summary>
        /// <param name="fromFile">String containing faculty information</param>
        public Faculty(String fromFile) : base(fromFile)
        {
            // Parse parameters from string with specified delimiter
            char[] delimiters = { '|' };
            String[] parameters = fromFile.Split(delimiters, StringSplitOptions.None);

            ContactInformation = new FacultyContactInformation(parameters[4], parameters[5]);
        }

        /// <summary>
        /// Creates a string to be displayed in a list box control
        /// </summary>
        /// <returns>Formatted string</returns>
        public override string ToListBoxString()
        {
            return base.ToListBoxString("Faculty");
        }

        /// <summary>
        /// Creates a string to store faculty member in file
        /// </summary>
        /// <returns>Formatted data string</returns>
        public override string ToFileString()
        {
            return $"F|{FirstName}|{LastName}|{AcademicDepartment}|{ContactInformation.EmailAddress}|{ContactInformation.BuildingLocation}";
        }

        /// <summary>
        /// Returns string that displays all details on faculty member
        /// </summary>
        /// <returns>Formmated string</returns>
        public override String ToString()
        {
            return base.ToString() + $"Type: Faculty \nEmail: {ContactInformation.EmailAddress} \nOffice Location: {ContactInformation.BuildingLocation}";
        }
    }
}
