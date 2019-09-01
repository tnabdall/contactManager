using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityPeople.ContactInformations;

namespace UniversityPeople.People
{
    public class Student : Person
    {
        /// <summary>
        /// Expected graduation year. Must be equal to or greater than the current year.
        /// </summary>
        public int ExpectedGraduationYear
        {
            get
            {
                return expectedGraduationYear;
            }
            set
            {
                if(value>= DateTime.Now.Year) // Check that set year is equal to or greater than current year.
                {
                    expectedGraduationYear = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Cannot set a expected graduation year before the current year.");
                }
            }
        }

        /// <summary>
        /// Course List. Accessing list returns copy. Setting list sets new copy. Use public methods to alter list.
        /// </summary>
        public List<string> CourseList
        {
            get
            {
                return courseList.ToList<string>(); // Deep Copy
            }

            set
            {
                courseList = value.ToList<string>(); // Deep copy
            }
            
        }

        /// <summary>
        /// Returns contact information in base class as StudentContactInformation type
        /// </summary>
        public new StudentContactInformation ContactInformation
        {
            get
            {
                return (StudentContactInformation) base.ContactInformation;
            }
            set
            {
                base.ContactInformation = value;
            }
        }

     
        private int expectedGraduationYear;
        private List<string> courseList;

        /// <summary>
        /// Creates a student. Sets the expected graduation year to 4 years from now.
        /// </summary>
        /// <param name="initialFirstName">First name. Required.</param>
        /// <param name="initialLastName">Last name. Required.</param>
        /// <param name="initialAcademicDepartment">Academic Department. Required.</param>
        /// <param name="initialContactInformation">Contact Information. Required.</param>
        /// <param name="initialCourseList">Initial course list. If not supplied, empty course list will be created.</param>
        public Student(String initialFirstName, String initialLastName, String initialAcademicDepartment, StudentContactInformation initialContactInformation, List<string> initialCourseList = null) : base(initialFirstName, initialLastName, initialAcademicDepartment, initialContactInformation)
        {
            if (initialCourseList == null)
            {
                CourseList = new List<string>();
            }
            else
            {
                CourseList = initialCourseList;
            }
            ExpectedGraduationYear = DateTime.Now.Year + 4;
        }

        // <summary>
        /// Creates a student.
        /// </summary>
        /// <param name="initialFirstName">First name. Required.</param>
        /// <param name="initialLastName">Last name. Required.</param>
        /// <param name="initialAcademicDepartment">Academic Department. Required.</param>
        /// <param name="initialContactInformation">Contact Information. Required.</param>
        /// <param name="initialExpectedGraduationYear">Expected graduation year. Required. Should be greater than or equal to current year.</param>
        /// <param name="initialCourseList">Initial course list. If not supplied, empty course list will be created.</param>
        public Student(String initialFirstName, String initialLastName, String initialAcademicDepartment, StudentContactInformation initialContactInformation, int initialExpectedGraduationYear, List<string> initialCourseList = null) : base(initialFirstName, initialLastName, initialAcademicDepartment, initialContactInformation)
        {
            if (courseList == null)
            {
                courseList = new List<string>();
            }
            else
            {
                courseList = initialCourseList.ToList<string>();
            }
            ExpectedGraduationYear = initialExpectedGraduationYear;
        }

        /// <summary>
        /// Creates a student from a file formatted string
        /// </summary>
        /// <param name="fromFile">File formatted string</param>
        public Student(String fromFile):base(fromFile)
        {
            // Parse parameters from string with specified delimiter
            char[] delimiters = { '|' };
            String[] parameters = fromFile.Split(delimiters, StringSplitOptions.None);

            ContactInformation = new StudentContactInformation(parameters[4], parameters[5]);

            // Throws exception if can't parse the graduation year
            int expectedGraduationYear;
            if (int.TryParse(parameters[6], out expectedGraduationYear))
            {
                ExpectedGraduationYear = expectedGraduationYear;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Cannot read graduation year from file");
            }
            // Course list is reconstructed from comma separated list in file (empty entries removed)
            courseList = new List<string>(parameters[7].Split(new char[] { ',' },StringSplitOptions.RemoveEmptyEntries));
        
        }

        /// <summary>
        /// Adds a course to the course list
        /// </summary>
        /// <param name="course">Course to be added</param>
        public void AddCourse(String course)
        {
            if (String.IsNullOrEmpty(course)) // Can't add an empty course
            {
                throw new ArgumentException("Cannot add an empty course.");
            }
            courseList.Add(course);
        }

        /// <summary>
        /// Removes a course from the course list
        /// </summary>
        /// <param name="course">Course to be removed</param>
        /// <returns>Whether course removal was successful</returns>
        public bool RemoveCourse(String course)
        {
            return courseList.Remove(course);
        }

        /// <summary>
        /// Removes course at selected index
        /// </summary>
        /// <param name="index">Index to remove</param>
        /// <returns>Whether course removal was successful</returns>
        public bool TryRemoveAtCourse(int index)
        {
            try
            {
                courseList.RemoveAt(index);
                return true;
            }
            catch(ArgumentOutOfRangeException)
            {
                return false;
            }
        }

        /// <summary>
        /// Removes all courses for this student
        /// </summary>
        public void RemoveAllCourses()
        {
            courseList.Clear();
        }


        /// <summary>
        /// Creates string that is padded for display to list box
        /// </summary>
        /// <returns>String</returns>
        public override string ToListBoxString()
        {
            return base.ToListBoxString("Student");
        }

        /// <summary>
        /// Creates string that stores information for file storage
        /// </summary>
        /// <returns>File string</returns>
        public override string ToFileString()
        {
            // Courses in list are separated by commas
            return $"S|{FirstName}|{LastName}|{AcademicDepartment}|{ContactInformation.EmailAddress}|{ContactInformation.MailingAddress}|{ExpectedGraduationYear}|{String.Join(",",courseList)}";
        }

        /// <summary>
        /// String that displays all information for student
        /// </summary>
        /// <returns>Information string</returns>
        public override string ToString()
        {
            String infoString = base.ToString() + $"Type: Student \nEmail: {ContactInformation.EmailAddress} \nMailing Address: {ContactInformation.MailingAddress}\nExpected Graduation Year: {ExpectedGraduationYear}\nCourse List:\n";
            // Adds all courses to string
            for(int i = 0; i<courseList.Count; i++)
            {
                infoString += courseList[i] + "\n";
            }
            return infoString;

        }
    }
}
