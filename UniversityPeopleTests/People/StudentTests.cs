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
    public class StudentTests
    {
        [TestMethod()]
        public void StudentConstructor_NoGraduationYear_ValidParameters()
        {
            // Arrange
            String firstName = "Bob";
            String lastName = "Smith";
            String academicDepartment = "MATH";
            String emailAddress = "bob.smith@gmail.com";
            String mailingAddress = "123 Centre St";
            StudentContactInformation contactInformation = new StudentContactInformation(emailAddress, mailingAddress);
            int expectedGraduationYear = DateTime.Now.Year + 4;

            // Act
            Student student = new Student(firstName, lastName, academicDepartment, contactInformation);

            // Assert
            Assert.AreEqual(firstName, student.FirstName);
            Assert.AreEqual(lastName, student.LastName);
            Assert.AreEqual(academicDepartment, student.AcademicDepartment);
            Assert.AreEqual(emailAddress, student.ContactInformation.EmailAddress);
            Assert.AreEqual(mailingAddress, student.ContactInformation.MailingAddress);
            Assert.AreEqual(expectedGraduationYear, student.ExpectedGraduationYear);
        }

        [TestMethod()]
        public void StudentConstructor_WithGraduationYear_ValidParameters()
        {
            // Arrange
            String firstName = "Bob";
            String lastName = "Smith";
            String academicDepartment = "MATH";
            String emailAddress = "bob.smith@gmail.com";
            String mailingAddress = "123 Centre St";
            StudentContactInformation contactInformation = new StudentContactInformation(emailAddress, mailingAddress);
            int expectedGraduationYear = 2060;

            // Act
            Student student = new Student(firstName, lastName, academicDepartment, contactInformation, expectedGraduationYear);

            // Assert
            Assert.AreEqual(firstName, student.FirstName);
            Assert.AreEqual(lastName, student.LastName);
            Assert.AreEqual(academicDepartment, student.AcademicDepartment);
            Assert.AreEqual(emailAddress, student.ContactInformation.EmailAddress);
            Assert.AreEqual(mailingAddress, student.ContactInformation.MailingAddress);
            Assert.AreEqual(expectedGraduationYear, student.ExpectedGraduationYear);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentConstructor_InvalidFirstName()
        {
            // Arrange
            String firstName = "";
            String lastName = "Smith";
            String academicDepartment = "MATH";
            String emailAddress = "bob.smith@gmail.com";
            String mailingAddress = "123 Centre St";
            StudentContactInformation contactInformation = new StudentContactInformation(emailAddress, mailingAddress);
            int expectedGraduationYear = 2060;

            // Act
            Student student = new Student(firstName, lastName, academicDepartment, contactInformation, expectedGraduationYear);

            // Assert
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentConstructor_InvalidLastName()
        {
            // Arrange
            String firstName = "Bob";
            String lastName = "";
            String academicDepartment = "MATH";
            String emailAddress = "bob.smith@gmail.com";
            String mailingAddress = "123 Centre St";
            StudentContactInformation contactInformation = new StudentContactInformation(emailAddress, mailingAddress);
            int expectedGraduationYear = 2060;

            // Act
            Student student = new Student(firstName, lastName, academicDepartment, contactInformation, expectedGraduationYear);

            // Assert
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentConstructor_InvalidDept()
        {
            // Arrange
            String firstName = "Bob";
            String lastName = "Smith";
            String academicDepartment = "";
            String emailAddress = "bob.smith@gmail.com";
            String mailingAddress = "123 Centre St";
            StudentContactInformation contactInformation = new StudentContactInformation(emailAddress, mailingAddress);
            int expectedGraduationYear = 2060;

            // Act
            Student student = new Student(firstName, lastName, academicDepartment, contactInformation, expectedGraduationYear);

            // Assert
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentConstructor_InvalidEmail()
        {
            // Arrange
            String firstName = "Bob";
            String lastName = "Smith";
            String academicDepartment = "MATH";
            String emailAddress = "bob.smithgmail.com";
            String mailingAddress = "123 Centre St";
            StudentContactInformation contactInformation = new StudentContactInformation(emailAddress, mailingAddress);
            int expectedGraduationYear = 2060;

            // Act
            Student student = new Student(firstName, lastName, academicDepartment, contactInformation, expectedGraduationYear);

            // Assert
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void StudentConstructor_InvalidMailingAddress()
        {
            // Arrange
            String firstName = "Bob";
            String lastName = "Smith";
            String academicDepartment = "MATH";
            String emailAddress = "bob.smith@gmail.com";
            String mailingAddress = "";
            StudentContactInformation contactInformation = new StudentContactInformation(emailAddress, mailingAddress);
            int expectedGraduationYear = 2060;

            // Act
            Student student = new Student(firstName, lastName, academicDepartment, contactInformation, expectedGraduationYear);

            // Assert
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentConstructor_InvalidGraduationYear()
        {
            // Arrange
            String firstName = "Bob";
            String lastName = "Smith";
            String academicDepartment = "MATH";
            String emailAddress = "bob.smith@gmail.com";
            String mailingAddress = "123 Centre St";
            StudentContactInformation contactInformation = new StudentContactInformation(emailAddress, mailingAddress);
            int expectedGraduationYear = 2018;

            // Act
            Student student = new Student(firstName, lastName, academicDepartment, contactInformation, expectedGraduationYear);

            // Assert
            Assert.Fail();
        }

        [TestMethod()]
        public void Student_AddCourse_ValidCourse()
        {
            // Arrange
            String firstName = "Bob";
            String lastName = "Smith";
            String academicDepartment = "MATH";
            String emailAddress = "bob.smith@gmail.com";
            String mailingAddress = "123 Centre St";
            StudentContactInformation contactInformation = new StudentContactInformation(emailAddress, mailingAddress);
            int expectedGraduationYear = DateTime.Now.Year + 4;
            Student student = new Student(firstName, lastName, academicDepartment, contactInformation);

            String newCourse = "MATH 271";

            // Act
            student.AddCourse(newCourse);

            // Assert
            Assert.AreEqual("MATH 271", student.CourseList[0]);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void Student_AddCourse_InvalidCourse()
        {
            // Arrange
            String firstName = "Bob";
            String lastName = "Smith";
            String academicDepartment = "MATH";
            String emailAddress = "bob.smith@gmail.com";
            String mailingAddress = "123 Centre St";
            StudentContactInformation contactInformation = new StudentContactInformation(emailAddress, mailingAddress);
            int expectedGraduationYear = DateTime.Now.Year + 4;
            Student student = new Student(firstName, lastName, academicDepartment, contactInformation);

            String newCourse = "";

            // Act
            student.AddCourse(newCourse);

            // Assert
            Assert.Fail();
        }

        [TestMethod()]
        public void Student_RemoveCourse_ValidCourse()
        {
            // Arrange
            String firstName = "Bob";
            String lastName = "Smith";
            String academicDepartment = "MATH";
            String emailAddress = "bob.smith@gmail.com";
            String mailingAddress = "123 Centre St";
            StudentContactInformation contactInformation = new StudentContactInformation(emailAddress, mailingAddress);
            int expectedGraduationYear = DateTime.Now.Year + 4;
            Student student = new Student(firstName, lastName, academicDepartment, contactInformation);
            String newCourse = "MATH 271";
            student.AddCourse(newCourse);
            newCourse = "PHIL 200";
            student.AddCourse(newCourse);

            // Act
            bool removedCourse = student.RemoveCourse("MATH 271");

            // Assert
            Assert.AreEqual("PHIL 200", student.CourseList[0]);
            Assert.AreEqual(1, student.CourseList.Count);
            Assert.IsTrue(removedCourse);
        }

        [TestMethod()]
        public void Student_RemoveCourse_InvalidCourse()
        {
            // Arrange
            String firstName = "Bob";
            String lastName = "Smith";
            String academicDepartment = "MATH";
            String emailAddress = "bob.smith@gmail.com";
            String mailingAddress = "123 Centre St";
            StudentContactInformation contactInformation = new StudentContactInformation(emailAddress, mailingAddress);
            int expectedGraduationYear = DateTime.Now.Year + 4;
            Student student = new Student(firstName, lastName, academicDepartment, contactInformation);
            String newCourse = "MATH 271";
            student.AddCourse(newCourse);
            newCourse = "PHIL 200";
            student.AddCourse(newCourse);

            // Act
            bool removedCourse = student.RemoveCourse("MATH 272");

            // Assert
            Assert.AreEqual("MATH 271", student.CourseList[0]);
            Assert.AreEqual("PHIL 200", student.CourseList[1]);
            Assert.AreEqual(2, student.CourseList.Count);
            Assert.IsFalse(removedCourse);
        }

        [TestMethod()]
        public void Student_TryRemoveAtCourse_ValidCourseIndex()
        {
            // Arrange
            String firstName = "Bob";
            String lastName = "Smith";
            String academicDepartment = "MATH";
            String emailAddress = "bob.smith@gmail.com";
            String mailingAddress = "123 Centre St";
            StudentContactInformation contactInformation = new StudentContactInformation(emailAddress, mailingAddress);
            int expectedGraduationYear = DateTime.Now.Year + 4;
            Student student = new Student(firstName, lastName, academicDepartment, contactInformation);
            String newCourse = "MATH 271";
            student.AddCourse(newCourse);
            newCourse = "PHIL 200";
            student.AddCourse(newCourse);

            // Act
            bool removedCourse = student.TryRemoveAtCourse(0);

            // Assert
            Assert.AreEqual("PHIL 200", student.CourseList[0]);
            Assert.AreEqual(1, student.CourseList.Count);
            Assert.IsTrue(removedCourse);
        }

        [TestMethod()]
        public void Student_TryRemoveAtCourse_CourseIndexOutOfRange()
        {
            // Arrange
            String firstName = "Bob";
            String lastName = "Smith";
            String academicDepartment = "MATH";
            String emailAddress = "bob.smith@gmail.com";
            String mailingAddress = "123 Centre St";
            StudentContactInformation contactInformation = new StudentContactInformation(emailAddress, mailingAddress);
            int expectedGraduationYear = DateTime.Now.Year + 4;
            Student student = new Student(firstName, lastName, academicDepartment, contactInformation);
            String newCourse = "MATH 271";
            student.AddCourse(newCourse);
            newCourse = "PHIL 200";
            student.AddCourse(newCourse);

            // Act
            bool removedCourse = student.TryRemoveAtCourse(2);

            // Assert
            Assert.AreEqual("MATH 271", student.CourseList[0]);
            Assert.AreEqual("PHIL 200", student.CourseList[1]);
            Assert.AreEqual(2, student.CourseList.Count);
            Assert.IsFalse(removedCourse);
        }

        [TestMethod()]
        public void Student_RemoveAllCourses()
        {
            // Arrange
            String firstName = "Bob";
            String lastName = "Smith";
            String academicDepartment = "MATH";
            String emailAddress = "bob.smith@gmail.com";
            String mailingAddress = "123 Centre St";
            StudentContactInformation contactInformation = new StudentContactInformation(emailAddress, mailingAddress);
            int expectedGraduationYear = DateTime.Now.Year + 4;
            Student student = new Student(firstName, lastName, academicDepartment, contactInformation);
            String newCourse = "MATH 271";
            student.AddCourse(newCourse);
            newCourse = "PHIL 200";
            student.AddCourse(newCourse);

            // Act
            student.RemoveAllCourses();

            // Assert
            Assert.AreEqual(0, student.CourseList.Count);
        }
    }
}