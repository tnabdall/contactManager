using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityPeople
{
    public class FacultyContactInformation : ContactInformation
    {
        /// <summary>
        /// Where the faculty member's office is
        /// </summary>
        public String BuildingLocation { get; set; }
        
        /// <summary>
        /// Creates contact info for faculty member
        /// </summary>
        /// <param name="initialEmailAddress">Faculty's email address</param>
        /// <param name="initialBuildingLocation">Faculty's office location</param>
        public FacultyContactInformation(String initialEmailAddress, String initialBuildingLocation) : base(initialEmailAddress)
        {
            BuildingLocation = initialBuildingLocation;
        }
    }
}
