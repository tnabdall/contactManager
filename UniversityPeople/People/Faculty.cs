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

        public Faculty(String fromFile) : base(fromFile)
        {
            // Parse parameters from string with specified delimiter
            char[] delimiters = { '|' };
            String[] parameters = fromFile.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            ContactInformation = new FacultyContactInformation(parameters[4], parameters[5]);
        }

        public override string ToListBoxString()
        {
            return $"{ FirstName,12}{LastName,12}{"Faculty",12}{AcademicDepartment,20}";
        }

        public override string ToFileString()
        {
            return $"F|{base.ToFileString()}|{ContactInformation.EmailAddress}|{ContactInformation.BuildingLocation}";
        }

        public override String ToString()
        {
            return base.ToString() + $"Type: Faculty \nEmail: {ContactInformation.EmailAddress} \nOffice Location: {ContactInformation.BuildingLocation}";
        }
    }
}
