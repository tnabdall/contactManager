using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        /// Course List. Accessing list returns copy. Use public methods to alter list.
        /// </summary>
        public List<string> CourseList
        {
            get
            {
                return courseList.ToList<string>();
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
            if (courseList == null)
            {
                courseList = new List<string>();
            }
            else
            {
                courseList = initialCourseList.ToList<string>();
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
        /// Adds a course to the course list
        /// </summary>
        /// <param name="course">Course to be added</param>
        public void AddCourse(String course)
        {
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
        /// Removes all courses for this student
        /// </summary>
        public void RemoveAllCourses()
        {
            courseList.Clear();
        }
    }
}
