using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
