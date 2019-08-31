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
        /// <summary>
        /// Stores new faculty member from form
        /// </summary>
        public Faculty NewFaculty = null;
        
        private Faculty editFaculty = null; // Stores reference to edit faculty member
        private bool editMode = false; // Flag to let form know we are in edit mode

        /// <summary>
        /// Creates add faculty form
        /// </summary>
        public AddEditFacultyForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates edit faculty form 
        /// </summary>
        /// <param name="editFaculty">Faculty member to edit</param>
        public AddEditFacultyForm(Faculty editFaculty) : this()
        {
            if (editFaculty == null)
            {
                throw new ArgumentException("Cannot edit null faculty");
            }
            // Program is in edit mode. Store reference to faculty member.
            editMode = true;
            this.editFaculty = editFaculty;
            addButton.Text = "Save"; // Add button becomes save

            // Populates all fields with faculty member information
            firstNameTextBox.Text = editFaculty.FirstName;
            lastNameTextBox.Text = editFaculty.LastName;
            academicDepartmentTextBox.Text = editFaculty.AcademicDepartment;
            emailAddressTextBox.Text = editFaculty.ContactInformation.EmailAddress;
            officeLocationBuildingTextBox.Text = editFaculty.ContactInformation.BuildingLocation;            
        }

        /// <summary>
        /// Changes the properties of the faculty member that is being edited
        /// </summary>
        private void editFacultyProperties()
        {
            try
            {
                // Sets properties where they have changed from the original value
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
        /// Processes add/save button click to add/edit faculty member
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            if (IsValidForm())
            {
                if (editMode)
                {
                    editFacultyProperties();
                }
                else // Not editing
                {
                    addNewFaculty();
                }                
            }
            else
            {
                MessageBox.Show("Invalid form entries", "Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Creates a new faculty member for the main form to access. Fields must be validated before calling this.
        /// </summary>
        private void addNewFaculty()
        {
            try
            {
                // Creates new faculty member
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

        /// <summary>
        /// Validates all form fields
        /// </summary>
        /// <returns></returns>
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
            if (message == "") // If none of the above validation failed, the message will be empty so form is valid
            {
                return true;
            }
            else
            {
                MessageBox.Show(message, "Please fix form fields below", MessageBoxButtons.OK);
                return false;
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
        /// Colors building location according to validation rules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OfficeLocationBuildingTextBox_TextChanged(object sender, EventArgs e)
        {
            Validation.ColorTextBoxValidation(officeLocationBuildingTextBox, Validation.IsNotEmptyOrNull);
        }
    }
}
