// Contact Manager program to add faculty/student contacts in a university
// Author: Tarik Abdalla
// Date: September 2019
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UniversityPeople;
using UniversityPeople.ContactInformations;
using UniversityPeople.People;


namespace ContactManager
{
    public partial class MainForm : Form
    {
        
        private List<Person> contactsList = new List<Person>(); // Holds contact list of all university persons in file
        private String Filepath = null; // Holds filepath, null means no file loaded or saved yet
        private bool fileSavedSinceLastChange = true; // Lets us know if the file was saved since last change
        private bool exitByMenuButton = false; // Lets form closing event know if exit from menu was pressed

        /// <summary>
        /// Creates form
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Proccesses exit request
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Prompt for user to save form if there has been any changes
            if (!fileSavedSinceLastChange)
            {
                DialogResult result = MessageBox.Show("There are unsaved changes. Would you like to save before exiting the program?","Confirm Exit",MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    bool userSavedFile = SaveFile(true); // Save as prompt
                    if (!userSavedFile)
                    { // If user requested to save file but didn't save file, cancel exit request
                        return;
                    }
                    else
                    {
                        exitByMenuButton = true;
                        Application.Exit();
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    return; // Cancel exit request
                }
                else // They chose No
                {
                    exitByMenuButton = true;
                    Application.Exit();                    
                    // Continue to exit
                }
            }
            else // No changes so no need to confirm exit
            {
                exitByMenuButton = true;
                Application.Exit();
            }
             
        }

        /// <summary>
        /// Displays information on how to use the application.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(contactsListBox.SelectedIndices.Count.ToString());
            String message = "This application allows you to manage contact information for members of the university.\n" +
                "Right click on contacts box to bring up options to add, edit, delete, or search for contacts.\n" +
                "This application currently supports adding faculty and students.\n" +
                "Please contact Tarik if you need help.";
            MessageBox.Show(message, "Contact Manager Help", MessageBoxButtons.OK);
        }

        /// <summary>
        /// Opens form to add a new faculty member to the contact list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FacultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Opens faculty form
            AddEditFacultyForm facultyForm = new AddEditFacultyForm();
            DialogResult result = facultyForm.ShowDialog();
            // If user successfully entered required info, add faculty and flip file save flag
            if (result == DialogResult.OK)
            {
                AddContactToList(facultyForm.NewFaculty);
                fileSavedSinceLastChange = false;
            }
        }

        /// <summary>
        /// Opens form to add a new student member to the contact list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Opens student form
            AddEditStudentForm studentForm = new AddEditStudentForm();
            DialogResult result = studentForm.ShowDialog();
            // If user successfully entered required info, add student and flip file save flag
            if (result == DialogResult.OK)
            {
                AddContactToList(studentForm.newStudent);
                fileSavedSinceLastChange = false;
            }
        }

        /// <summary>
        /// Get contact details for selected person. Only 1 allowed at a time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContactDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Gets all selected contacts.
            List<int> selectedIndices = contactsListBox.SelectedIndices.Cast<int>().ToList();
            // Shows details if only 1 contact is selected. Otherwise, displays error message box.
            if (selectedIndices.Count == 1)
            {
                MessageBox.Show(contactsList[selectedIndices[0]].ToString(), "Contact Details", MessageBoxButtons.OK);
            }
            else if (selectedIndices.Count == 0)
            {
                MessageBox.Show("No contact selected.", "Choose a contact", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Too many contacts selected. Choose only one contact.", "Choose a contact", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Deletes selected contacts
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Gets list of selected contacts
            List<int> selectedIndices = contactsListBox.SelectedIndices.Cast<int>().ToList();
            selectedIndices.Sort();
            // If contacts are selected, delete them. If no contact is selected, display error message.
            if (selectedIndices.Count>0)
            {
                // Goes through all selected contacts and deletes them, starting from the last index (to avoid index shift issues)
                for (int i = selectedIndices.Count - 1; i > -1; i--)
                {
                    contactsList.RemoveAt(selectedIndices[i]);
                    contactsListBox.Items.RemoveAt(selectedIndices[i]);
                }
                fileSavedSinceLastChange = false;
            }
            else
            {
                MessageBox.Show("Must select a contact to remove.", "No contact selected.", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Opens appropriate form to edit contact
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Gets list of selected contacts. Only 1 allowed
            List<int> selectedIndices = contactsListBox.SelectedIndices.Cast<int>().ToList();
            // Ensures only 1 is selected. Otherwise, displays error message
            if (selectedIndices.Count==1)
            {
                Person person = contactsList[selectedIndices[0]];
                // Student edit form
                if (person is Student)
                {
                    // Opens student form for editing
                    AddEditStudentForm addEditStudentForm = new AddEditStudentForm((Student)person);
                    DialogResult result = addEditStudentForm.ShowDialog();
                    // If result is OK, update the contact List with the new string. Flip file flag.
                    if (result == DialogResult.OK)
                    {
                        MessageBox.Show($"Saved changes to student {person.FirstName} {person.LastName}");
                        contactsListBox.Items[selectedIndices[0]] = contactsList[selectedIndices[0]].ToListBoxString();
                        fileSavedSinceLastChange = false;
                    }
                }
                // Faculty edit form
                else if (person is Faculty)
                {
                    // Open faculty form for editing
                    AddEditFacultyForm addEditFacultyForm = new AddEditFacultyForm((Faculty)person);
                    DialogResult result = addEditFacultyForm.ShowDialog();
                    // If result is OK, update the contact List with the new string. Flip file flag.
                    if (result == DialogResult.OK)
                    {
                        MessageBox.Show($"Saved changes to student {person.FirstName} {person.LastName}");
                        contactsListBox.Items[selectedIndices[0]] = contactsList[selectedIndices[0]].ToListBoxString();
                        fileSavedSinceLastChange = false;
                    }
                }
                else
                { // Show error for unsupported type
                    MessageBox.Show("Error. Selected member is not a faculty or student.", "Error", MessageBoxButtons.OK);
                }
            }
            else if (selectedIndices.Count==0)
            {
                MessageBox.Show("Must select a contact to edit.", "No contact selected.", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("Must select only one contact to edit.", "Too many contacts selected.", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Opens file dialog for saving contact list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile(true);
        }

        /// <summary>
        /// Saves contact list as per loaded filepath. If no filepath loaded, works as Save as
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveContactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile(false);
        }

        /// <summary>
        /// Allows us to search contacts by first name. Selects all contacts that match.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Retrieve first name from new modal dialog
            GetOneFieldDialog dialog = new GetOneFieldDialog("Enter first name", "First Name", "Search", "Cancel", Validation.IsNotEmptyOrNull);
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Go through all contacts and selects those that have the same first name as the dialog retrieved value
                for (int i = 0; i < contactsList.Count; i++)
                {
                    if (contactsList[i].FirstName.ToUpper().Equals(dialog.Value.ToUpper()))
                    {
                        contactsListBox.SetSelected(i, true);
                    }
                    else
                    {
                        contactsListBox.SetSelected(i, false);
                    }
                }
            }
        }

        /// <summary>
        /// Allows us to search contacts by last name. Selects all contacts that match.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LastNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Opens new modal dialog to get last name
            GetOneFieldDialog dialog = new GetOneFieldDialog("Enter last name", "Last Name", "Search", "Cancel", Validation.IsNotEmptyOrNull);
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Go through all contacts and selects those that have the same last name as the dialog retrieved value
                for (int i = 0; i < contactsList.Count; i++)
                {
                    if (contactsList[i].LastName.ToUpper().Equals(dialog.Value.ToUpper()))
                    {
                        contactsListBox.SetSelected(i, true);
                    }
                    else
                    {
                        contactsListBox.SetSelected(i, false);
                    }
                }
            }
        }

        /// <summary>
        /// Searches contact list for contacts that have the requested First and Last Name. Selects those that match.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FirstAndLastNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Opens new modal dialog to retrieve first and last name
            GetTwoFieldsDialog dialog = new GetTwoFieldsDialog("Enter first and last name", "First Name", "Last Name", "Search", "Cancel", Validation.IsNotEmptyOrNull, Validation.IsNotEmptyOrNull);
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                // Go through all contacts and selects those that have the same first and last name as the dialog retrieved value
                for (int i = 0; i < contactsList.Count; i++)
                {
                    if (contactsList[i].FirstName.ToUpper() == dialog.Value1.ToUpper() && contactsList[i].LastName.ToUpper() == dialog.Value2.ToUpper())
                    {
                        contactsListBox.SetSelected(i, true);
                    }
                    else
                    {
                        contactsListBox.SetSelected(i, false);
                    }
                }
            }
        }

        /// <summary>
        /// Handles form close request. Prompts user to confirm exit if they have not saved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Prompt for user to save form if there has been any changes
            // and they did not exit by menu button
            if (!exitByMenuButton && !fileSavedSinceLastChange)
            {
                DialogResult result = MessageBox.Show("There are unsaved changes. Would you like to save before exiting the program?", "Confirm Exit", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    bool userSavedFile = SaveFile(true); // Save as prompt
                    if (!userSavedFile)
                    { // If user requested to save file but didn't save file, cancel exit request
                        e.Cancel = true;
                    }
                    else
                    {
                        e.Cancel = false; // Continue to close
                    }
                }
                else if (result == DialogResult.Cancel)
                {
                    e.Cancel = true; ; // Cancel exit request
                }
                else
                {
                    e.Cancel = false;  // Continue to close
                }
            }
        }

        /// <summary>
        /// Opens the requested file and loads the contacts from the file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // If there is an unsaved file thats open, ask if user would like to save
            if (!fileSavedSinceLastChange)
            {
                DialogResult result = MessageBox.Show("Would you like to save before opening a new file?", "Confirm", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveFile(true);
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
                else // They chose No
                {
                    // Continue to clear and load file
                }
            }
            // Clear current contact list before loading new file
            contactsList.Clear();
            contactsListBox.Items.Clear();
            LoadFile();
        }

        /// <summary>
        /// Creates dialog box for saving a file
        /// </summary>
        /// <returns>Was the file saved succesfully?</returns>
        private bool SaveFilePathDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Contact List File|*.cl",
                DefaultExt = ".cl",
                Title = "Save file .."
            };
            if (Filepath != null)
            {
                saveFileDialog.InitialDirectory = Filepath;
            }
            DialogResult result = saveFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Filepath = saveFileDialog.FileName; // Sets the filepath
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Creates a file dialog to open file
        /// </summary>
        /// <returns>Was the file opened successfully?</returns>
        private bool OpenFilePathDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Contact List File|*.cl",
                DefaultExt = ".cl",
                Title = "Load file .."
            };
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                Filepath = openFileDialog.FileName; // Sets file path and sets save changes flag
                fileSavedSinceLastChange = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Processes save or save as request
        /// </summary>
        /// <param name="saveAs">Run in save as mode? (True: Save As, False: Save)</param>
        /// <returns>Save successful?</returns>
        private bool SaveFile(bool saveAs)
        {
            // Opens file dialog if no filepath set or save as requested
            if(saveAs || Filepath == null)
            {
                if (!SaveFilePathDialog()) // User didn't select a file to save.
                {
                    return false ;
                }
            }
            // Try to write to the file
            StreamWriter output = null;
            try
            {
                output = new StreamWriter(Filepath);
                for(int i = 0; i<contactsList.Count; i++)
                {
                    output.WriteLine(contactsList[i].ToFileString());
                }
                output.Close();
                fileSavedSinceLastChange = true; // Change file saved flag
                return true;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Could not write file " + Filepath + ". " + ex.Message);
                return false;
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error in writing " + Filepath + ". " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Loads the file requested into contacts list
        /// </summary>
        /// <returns>If load was successful</returns>
        private bool LoadFile()
        {
            if (!OpenFilePathDialog()) { return false; } // Cancel if user didn't select file to load
          
            // Load file
            StreamReader input = null;
            try
            {
                bool lineReadIssues = false; // Lets user know if any data could not be read properly

                input = new StreamReader(Filepath);
                // Stores information to create new person
                String newPersonLine = null;
                Person newPerson = null;
                while (!input.EndOfStream)
                {
                    // Read new line
                    newPerson = null;
                    newPersonLine = input.ReadLine();
                    try
                    {
                        // Depending on person type, create that person
                        switch (newPersonLine[0].ToString().ToUpper())
                        {
                            case "S":
                                newPerson = new Student(newPersonLine);
                                break;
                            case "F":
                                newPerson = new Faculty(newPersonLine);
                                break;
                            default:
                                throw new ArgumentOutOfRangeException("Unsupported person type");                                
                        }
                    }
                    catch(ArgumentOutOfRangeException)
                    {
                        lineReadIssues = true; //Unable to read line
                    }
                    // If new person created successfully, add them to the list
                    if (newPerson != null)
                    {
                        AddContactToList(newPerson);
                    }
                }
                if (lineReadIssues)
                {
                    MessageBox.Show("Could not read some file data.", "Error", MessageBoxButtons.OK);
                }
                input.Close();
                return true;
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Could not find file " + Filepath + ". " + ex.Message);
                return false;
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error in reading " + Filepath + ". " + ex.Message);
                return false;
            }

        }

        private void AddContactToList(Person contact)
        {
            contactsList.Add(contact);
            contactsListBox.Items.Add(contact.ToListBoxString());
        }

        
    }
}
