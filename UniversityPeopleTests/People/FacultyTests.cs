using Microsoft.VisualStudio.TestTools.UnitTesting;
using UniversityPeople.ContactInformations;
using UniversityPeople.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityPeople.People.Tests
{
    [TestClass()]
    public class FacultyTests
    {
        [TestMethod()]
        public void Faculty_Constructor_ValidParameters()
        {
            // Arrange
            String firstName = "Bob";
            String lastName = "Smith";
            String academicDepartment = "MATH";
            String emailAddress = "bob.smith@gmail.com";
            String buildingLocation = "MD 206";
            FacultyContactInformation contactInformation = new FacultyContactInformation(emailAddress, buildingLocation);

            // Act
            Faculty faculty = new Faculty(firstName, lastName, academicDepartment, contactInformation);

            // Assert
            Assert.AreEqual(firstName, faculty.FirstName);
            Assert.AreEqual(lastName, faculty.LastName);
            Assert.AreEqual(academicDepartment, faculty.AcademicDepartment);
            Assert.AreEqual(emailAddress, faculty.ContactInformation.EmailAddress);
            Assert.AreEqual(buildingLocation, faculty.ContactInformation.BuildingLocation);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Faculty_Constructor_InvalidFirstName()
        {
            // Arrange
            String firstName = "";
            String lastName = "Smith";
            String academicDepartment = "MATH";
            String emailAddress = "bob.smith@gmail.com";
            String buildingLocation = "MD 206";
            FacultyContactInformation contactInformation = new FacultyContactInformation(emailAddress, buildingLocation);

            // Act
            Faculty faculty = new Faculty(firstName, lastName, academicDepartment, contactInformation);

            // Assert
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Faculty_Constructor_InvalidLastName()
        {
            // Arrange
            String firstName = "Bob";
            String lastName = "";
            String academicDepartment = "MATH";
            String emailAddress = "bob.smith@gmail.com";
            String buildingLocation = "MD 206";
            FacultyContactInformation contactInformation = new FacultyContactInformation(emailAddress, buildingLocation);

            // Act
            Faculty faculty = new Faculty(firstName, lastName, academicDepartment, contactInformation);

            // Assert
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Faculty_Constructor_InvalidAcademicDepartment()
        {
            // Arrange
            String firstName = "Bob";
            String lastName = "Smith";
            String academicDepartment = "";
            String emailAddress = "bob.smith@gmail.com";
            String buildingLocation = "MD 206";
            FacultyContactInformation contactInformation = new FacultyContactInformation(emailAddress, buildingLocation);

            // Act
            Faculty faculty = new Faculty(firstName, lastName, academicDepartment, contactInformation);

            // Assert
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Faculty_Constructor_InvalidEmail()
        {
            // Arrange
            String firstName = "Bob";
            String lastName = "Smith";
            String academicDepartment = "MATH";
            String emailAddress = "bob.smithxgmail.com";
            String buildingLocation = "MD 206";
            FacultyContactInformation contactInformation = new FacultyContactInformation(emailAddress, buildingLocation);

            // Act
            Faculty faculty = new Faculty(firstName, lastName, academicDepartment, contactInformation);

            // Assert
            Assert.Fail();
        }

    }
}