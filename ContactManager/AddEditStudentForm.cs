﻿using System;
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
        private List<string> newCourseList = new List<string>();
        public Student newStudent = null;
        private Student editStudent = null;
        private bool editMode = false;

        public AddEditStudentForm()
        {
            InitializeComponent();
        }

        public AddEditStudentForm(Student editStudent) : this()
        {
            editMode = true;
            this.editStudent = editStudent;
            newCourseList = editStudent.CourseList; // Deep copy list
            addButton.Text = "Save";
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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (!editMode && IsValidForm())
            {
                addNewStudent();
            }
            else if(editMode && IsValidForm())
            {
                editStudentProperties();
            }
            else
            {
                MessageBox.Show("Invalid form entries","Error",MessageBoxButtons.OK);
            }
        }

        private void addNewStudent()
        {
            try
            {
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

        private void editStudentProperties()
        {
            try
            {
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
                int year;
                if(int.TryParse(expectedGraduationYearTextBox.Text.Trim(),out year) && editStudent.ExpectedGraduationYear != year)
                {
                    editStudent.ExpectedGraduationYear = year;
                }
                editStudent.CourseList = newCourseList;
                DialogResult = DialogResult.OK;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error occurred. Please contact Tarik.", MessageBoxButtons.OK);
                DialogResult = DialogResult.Cancel;
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
            GetOneFieldDialog courseDialog = new GetOneFieldDialog("Enter course","Course: ","Add");
            DialogResult result = courseDialog.ShowDialog();
            if(result == DialogResult.OK)
            { 
                newCourseList.Add(courseDialog.Value);
                courseListListBox.Items.Add(courseDialog.Value);                
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
                newCourseList.RemoveAt(selectedIndex);
                courseListListBox.Items.RemoveAt(selectedIndex);
            }
        }

        private void RemoveAllCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newCourseList.Clear();
            courseListListBox.Items.Clear();
        }
    }
}
