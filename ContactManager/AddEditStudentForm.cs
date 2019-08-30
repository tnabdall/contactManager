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
        public List<string> courseList = new List<string>();
        public Student newStudent = null;

        public AddEditStudentForm()
        {
            InitializeComponent();
        }

        public AddEditStudentForm(Student editStudent) : this()
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (IsValidForm())
            {
                try
                {
                    newStudent = new Student(
                        firstNameTextBox.Text.Trim(),
                        lastNameTextBox.Text.Trim(),
                        academicDepartmentTextBox.Text.Trim(),
                        new StudentContactInformation(emailAddressTextBox.Text.Trim(), mailingAddressTextBox.Text.Trim()),
                        courseList);
                    DialogResult = DialogResult.OK;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
                    DialogResult = DialogResult.Cancel;
                }
            }
        }

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

        private void FirstNameTextBox_TextChanged(object sender, EventArgs e)
        {
            Validation.ColorTextBoxValidation(firstNameTextBox, Validation.IsNotEmptyOrNull);
        }

        private void LastNameTextBox_TextChanged(object sender, EventArgs e)
        {
            Validation.ColorTextBoxValidation(lastNameTextBox, Validation.IsNotEmptyOrNull);
        }

        private void AcademicDepartmentTextBox_TextChanged(object sender, EventArgs e)
        {
            Validation.ColorTextBoxValidation(academicDepartmentTextBox, Validation.IsNotEmptyOrNull);
        }

        private void EmailAddressTextBox_TextChanged(object sender, EventArgs e)
        {
            Validation.ColorTextBoxValidation(emailAddressTextBox, Validation.IsValidEmail);
        }

        private void MailingAddressTextBox_TextChanged(object sender, EventArgs e)
        {
            Validation.ColorTextBoxValidation(mailingAddressTextBox, Validation.IsNotEmptyOrNull);
        }

        private void ExpectedGraduationYearTextBox_TextChanged(object sender, EventArgs e)
        {
            Validation.ColorTextBoxValidation(expectedGraduationYearTextBox, Validation.IsGreaterThanOrEqualToCurrentYear);
        }

        private void CourseListListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AddCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetCourseDialog courseDialog = new GetCourseDialog();
            DialogResult result = courseDialog.ShowDialog();
            if(result == DialogResult.OK)
            {
                courseList.Add(courseDialog.CourseName);
                courseListListBox.Items.Add(courseDialog.CourseName);
            }
            
        }

        private void RemoveCourseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedIndex = courseListListBox.SelectedIndex;
            if (selectedIndex == -1)
            {
                MessageBox.Show("Must select a course to remove first.", "Error", MessageBoxButtons.OK);
            }
            else
            {                
                courseList.Remove(courseListListBox.Items[selectedIndex].ToString());
                courseListListBox.Items.RemoveAt(selectedIndex);
            }
        }

        private void RemoveAllCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            courseList.Clear();
            courseListListBox.Items.Clear();
        }
    }
}
