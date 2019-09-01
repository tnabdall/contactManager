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
    public class StudentContactInformationTests
    {
        [TestMethod()]
        public void StudentContactInformation_ValidParameters()
        {
            //Arrange
            String emailAddress = "bob@gmail.com";
            String mailingAddress = "123 Centre St";

            //Act
            StudentContactInformation contactInformation = new StudentContactInformation(emailAddress,mailingAddress);

            //Assert
            Assert.AreEqual(emailAddress, contactInformation.EmailAddress);
            Assert.AreEqual(mailingAddress, contactInformation.MailingAddress);

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentContactInformation_InvalidEmail1()
        {
            //Arrange
            String emailAddress = "bobxgmail.com";
            String mailingAddress = "123 Centre St";

            //Act
            StudentContactInformation contactInformation = new StudentContactInformation(emailAddress, mailingAddress);

            //Assert
            Assert.Fail();

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentContactInformation_InvalidEmail2()
        {
            //Arrange
            String emailAddress = "bob@gmailxcom";
            String mailingAddress = "123 Centre St";

            //Act
            StudentContactInformation contactInformation = new StudentContactInformation(emailAddress, mailingAddress);

            //Assert
            Assert.Fail();

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentContactInformation_NoEmail()
        {
            //Arrange
            String emailAddress = "";
            String mailingAddress = "123 Centre St";

            //Act
            StudentContactInformation contactInformation = new StudentContactInformation(emailAddress, mailingAddress);

            //Assert
            Assert.Fail();

        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentContactInformation_NoMailingAddress()
        {
            //Arrange
            String emailAddress = "bob@gmail.com";
            String mailingAddress = "";

            //Act
            StudentContactInformation contactInformation = new StudentContactInformation(emailAddress, mailingAddress);

            //Assert
            Assert.Fail();

        }
    }
}