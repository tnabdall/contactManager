using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityPeople.People;
using UniversityPeople.ContactInformations;

namespace ContactManager
{
    public partial class AddEditFacultyForm : Form
    {
        public Faculty NewFaculty = null;
        private Faculty editFaculty = null;
        private bool editMode = false;
        public AddEditFacultyForm()
        {
            InitializeComponent();
        }

        public AddEditFacultyForm(Faculty editFaculty) : this()
        {
            editMode = true;
            this.editFaculty = editFaculty;

            addButton.Text = "Save";

            firstNameTextBox.Text = editFaculty.FirstName;
            lastNameTextBox.Text = editFaculty.LastName;
            academicDepartmentTextBox.Text = editFaculty.AcademicDepartment;
            emailAddressTextBox.Text = editFaculty.ContactInformation.EmailAddress;
            officeLocationBuildingTextBox.Text = editFaculty.ContactInformation.BuildingLocation;
            
        }

        private void editFacultyProperties()
        {
            try
            {
                if (editFaculty.FirstName != firstNameTextBox.Text.Trim())
                {
                    editFaculty.FirstName = firstNameTextBox.Text.Trim();
                }
                if (editFaculty.LastName != lastNameTextBox.Text.Trim())
                {
                    editFaculty.LastName = lastNameTextBox.Text.Trim();
                }
                if (editFaculty.AcademicDepartment != academicDepartmentTextBox.Text.Trim())
                {
                    editFaculty.AcademicDepartment = academicDepartmentTextBox.Text.Trim();
                }
                if (editFaculty.ContactInformation.EmailAddress != emailAddressTextBox.Text.Trim())
                {
                    editFaculty.ContactInformation.EmailAddress = emailAddressTextBox.Text.Trim();
                }
                if (editFaculty.ContactInformation.BuildingLocation != officeLocationBuildingTextBox.Text.Trim())
                {
                    editFaculty.ContactInformation.BuildingLocation = officeLocationBuildingTextBox.Text.Trim();
                }
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error occurred. Please contact Tarik.", MessageBoxButtons.OK);
                DialogResult = DialogResult.Cancel;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (IsValidForm())
            {
                if (editMode)
                {
                    editFacultyProperties();
                }
                else
                {
                    addNewFaculty();
                }                
            }
            else
            {
                MessageBox.Show("Invalid form entries", "Error", MessageBoxButtons.OK);
            }
        }

        private void addNewFaculty()
        {
            try
            {
                NewFaculty = new Faculty(
                    firstNameTextBox.Text.Trim(),
                    lastNameTextBox.Text.Trim(),
                    academicDepartmentTextBox.Text.Trim(),
                    new FacultyContactInformation(emailAddressTextBox.Text.Trim(), officeLocationBuildingTextBox.Text.Trim())
                    );
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
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
            if (!Validation.IsNotEmptyOrNull(officeLocationBuildingTextBox))
            {
                message += "Office building location is required.\n";
            }
            if (!Validation.IsValidEmail(emailAddressTextBox))
            {
                message += "Email address is required in a correct format.\n";
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

        private void OfficeLocationBuildingTextBox_TextChanged(object sender, EventArgs e)
        {
            Validation.ColorTextBoxValidation(officeLocationBuildingTextBox, Validation.IsNotEmptyOrNull);
        }
    }
}
