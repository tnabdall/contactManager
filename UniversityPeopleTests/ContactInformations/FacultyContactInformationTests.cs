using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversityPeople.ContactInformations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityPeople.ContactInformations.Tests
{
    [TestClass()]
    public class FacultyContactInformationTests
    {
        [TestMethod()]
        public void FacultyContactInformation_ValidParameters()
        {
            //Arrange
            String emailAddress = "bob@gmail.com";
            String buildingLocation = "MC 206";
            
            //Act
            FacultyContactInformation contactInformation = new FacultyContactInformation(emailAddress, buildingLocation);

            //Assert
            Assert.AreEqual(emailAddress, contactInformation.EmailAddress);
            Assert.AreEqual(buildingLocation, contactInformation.BuildingLocation);

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void FacultyContactInformation_InvalidEmail1()
        {
            //Arrange
            String emailAddress = "bobxgmail.com";
            String buildingLocation = "MC 206";

            //Act
            FacultyContactInformation contactInformation = new FacultyContactInformation(emailAddress, buildingLocation);

            //Assert
            Assert.Fail();

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void FacultyContactInformation_InvalidEmail2()
        {
            //Arrange
            String emailAddress = "bob@gmailxcom";
            String buildingLocation = "MC 206";

            //Act
            FacultyContactInformation contactInformation = new FacultyContactInformation(emailAddress, buildingLocation);

            //Assert
            Assert.Fail();

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void FacultyContactInformation_NoEmail()
        {
            //Arrange
            String emailAddress = "";
            String buildingLocation = "MC 206";

            //Act
            FacultyContactInformation contactInformation = new FacultyContactInformation(emailAddress, buildingLocation);

            //Assert
            Assert.Fail();

        }

        
    }
}