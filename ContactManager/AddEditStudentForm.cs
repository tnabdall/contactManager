using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityPeople.ContactInformations;
using UniversityPeople.People;

namespace ContactManager
{
    public partial class AddEditStudentForm : Form
    {
        /// <summary>
        /// Holds new student reference
        /// </summary>
        public Student newStudent = null;

        private List<string> newCourseList = new List<string>(); // Course list to be set for new or edited student     
        private Student editStudent = null; // Stores edit student reference
        private bool editMode = false; // Lets form know we are in edit mode

        /// <summary>
        /// Creates form to add a new student
        /// </summary>
        public AddEditStudentForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates form to edit a student
        /// </summary>
        /// <param name="editStudent"></param>
        public AddEditStudentForm(Student editStudent) : this()
        {
            if (editStudent == null)
            {
                throw new ArgumentNullException("Must supply a student");
            }

            // Sets edit mode, stores references for student
            editMode = true;
            this.editStudent = editStudent;
            newCourseList = editStudent.CourseList; // Deep copy list
            addButton.Text = "Update"; // Add button becomes update button
            this.Text = "Edit Student Form"; // Title changed

            // Populates all fields on form with editing student's current fields
            for(int i = 0; i< this.newCourseList.Count; i++)
            {
                courseListListBox.Items.Add(this.newCourseList[i]);
            }
            firstNameTextBox.Text = editStudent.FirstName;
            lastNameTextBox.Text = editStudent.LastName;
            academicDepartmentTextBox.Text = editStudent.AcademicDepartment;
            emailAddressTextBox.Text = editStudent.ContactInformation.EmailAddress;
            mailingAddressTextBox.Text = editStudent.ContactInformation.MailingAddress;
            expectedGraduationYearTextBox.Text = editStudent.ExpectedGraduationYear.ToString();

        }

        /// <summary>
        /// Sends a cancel result to main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Processes add/save action
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            // Ensures form is valid before processing add/edit student
            if (!editMode && IsValidForm())
            {
                addNewStudent();
            }
            else if(editMode && IsValidForm())
            {
                editStudentProperties();
            }
        }
                

        /// <summary>
        /// Colors first name according to validation rules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            Validation.ColorTextBoxValidation(firstNameTextBox, Validation.IsNotEmptyOrNull);
        }

        /// <summary>
        /// Colors last name according to validation rules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            Validation.ColorTextBoxValidation(lastNameTextBox, Validation.IsNotEmptyOrNull);
        }

        /// <summary>
        /// Colors department according to validation rules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AcademicDepartmentTextBox_TextChanged(object sender, EventArgs e)
        {
            Validation.ColorTextBoxValidation(academicDepartmentTextBox, Validation.IsNotEmptyOrNull);
        }

        /// <summary>
        /// Colors email according to validation rules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmailAddressTextBox_TextChanged(object sender, EventArgs e)
        {
            Validation.ColorTextBoxValidation(emailAddressTextBox, Validation.IsValidEmail);
        }

        /// <summary>
        /// Colors mailing address according to validation rules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MailingAddressTextBox_TextChanged(object sender, EventArgs e)
        {
            Validation.ColorTextBoxValidation(mailingAddressTextBox, Validation.IsNotEmptyOrNull);
        }

        /// <summary>
        /// Colors graduation year according to validation rules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExpectedGraduationYearTextBox_TextChanged(object sender, EventArgs e)
        {
            Validation.ColorTextBoxValidation(expectedGraduationYearTextBox, Validation.IsGreaterThanOrEqualToCurrentYear);
        }

        /// <summary>
        /// Creates a dialog to add a new course to the list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Sets general dialog properties to enter a new course
            GetOneFieldDialog courseDialog = new GetOneFieldDialog("Enter course","Course: ","Add");
            DialogResult result = courseDialog.ShowDialog();
            // Adds to the list if result is ok
            if(result == DialogResult.OK)
            { 
                newCourseList.Add(courseDialog.Value);
                courseListListBox.Items.Add(courseDialog.Value);                
            }
            
        }

        /// <summary>
        /// Removes selected course from the course list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Checks that a course is selected, then removes it
            int selectedIndex = courseListListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Must select a course to remove first.", "Error", MessageBoxButtons.OK);
            }
            else
            {               
                newCourseList.RemoveAt(selectedIndex);
                courseListListBox.Items.RemoveAt(selectedIndex);
            }
        }

        /// <summary>
        /// Clears all courses from course list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveAllCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newCourseList.Clear();
            courseListListBox.Items.Clear();
        }

        /// <summary>
        /// Adds new studnet to newStudent reference in form
        /// </summary>
        private void addNewStudent()
        {
            try
            {
                // Try to create new student. Should pass as form is validated.
                newStudent = new Student(
                    firstNameTextBox.Text.Trim(),
                    lastNameTextBox.Text.Trim(),
                    academicDepartmentTextBox.Text.Trim(),
                    new StudentContactInformation(emailAddressTextBox.Text.Trim(), mailingAddressTextBox.Text.Trim()),
                    newCourseList);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                DialogResult = DialogResult.Cancel;
            }
        }

        /// <summary>
        /// Edits the student properties to the ones on the form
        /// </summary>
        private void editStudentProperties()
        {
            try
            {
                // Sets student's properties to new values if they have been changed
                if (editStudent.FirstName != firstNameTextBox.Text.Trim())
                {
                    editStudent.FirstName = firstNameTextBox.Text.Trim();
                }
                if (editStudent.LastName != lastNameTextBox.Text.Trim())
                {
                    editStudent.LastName = lastNameTextBox.Text.Trim();
                }
                if (editStudent.AcademicDepartment != academicDepartmentTextBox.Text.Trim())
                {
                    editStudent.AcademicDepartment = academicDepartmentTextBox.Text.Trim();
                }
                if (editStudent.ContactInformation.EmailAddress != emailAddressTextBox.Text.Trim())
                {
                    editStudent.ContactInformation.EmailAddress = emailAddressTextBox.Text.Trim();
                }
                if (editStudent.ContactInformation.MailingAddress != mailingAddressTextBox.Text.Trim())
                {
                    editStudent.ContactInformation.MailingAddress = mailingAddressTextBox.Text.Trim();
                }
                // Assigns graduation year if not changed
                int year;
                if (int.TryParse(expectedGraduationYearTextBox.Text.Trim(), out year) && editStudent.ExpectedGraduationYear != year)
                {
                    editStudent.ExpectedGraduationYear = year;
                }
                editStudent.CourseList = newCourseList; // Setter deep copies list
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error occurred. Please contact Tarik.", MessageBoxButtons.OK);
                DialogResult = DialogResult.Cancel;
            }
        }

        /// <summary>
        /// Checks if form entries are valid
        /// </summary>
        /// <returns>Yes/No</returns>
        private bool IsValidForm()
        {
            String message = "";
            if (!Validation.IsNotEmptyOrNull(firstNameTextBox))
            {
                message += "First name is required.\n";
            }
            if (!Validation.IsNotEmptyOrNull(lastNameTextBox))
            {
                message += "Last name is required.\n";
            }
            if (!Validation.IsNotEmptyOrNull(academicDepartmentTextBox))
            {
                message += "Academic department is required.\n";
            }
            if (!Validation.IsNotEmptyOrNull(mailingAddressTextBox))
            {
                message += "Mailing address is required.\n";
            }
            if (!Validation.IsValidEmail(emailAddressTextBox))
            {
                message += "Email address is required in a correct format.\n";
            }
            if (!Validation.IsGreaterThanOrEqualToCurrentYear(expectedGraduationYearTextBox))
            {
                message += "Expected graduation year must be equal to or greater than the current year.";
            }
            if (message == "")
            {
                return true;
            }
            else
            {
                MessageBox.Show(message, "Please fix form fields below", MessageBoxButtons.OK);
                return false;
            }
        }
    }
}
