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

        public override string ToListBoxString()
        {
            return $"{ FirstName,12}{LastName,12}{"Faculty",12}{AcademicDepartment,20}";
        }

        public override String ToString()
        {
            return base.ToString() + $"Type: Faculty \nEmail: {ContactInformation.EmailAddress} \nOffice Location: {((FacultyContactInformation)ContactInformation).BuildingLocation}";
        }
    }
}
