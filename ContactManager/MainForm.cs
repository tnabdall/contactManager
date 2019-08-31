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
        public List<Person> contactsList = new List<Person>();
        private String Filepath = null;
        bool fileSaved = true;
        public MainForm()
        {
            InitializeComponent();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!fileSaved)
            {
                DialogResult result = MessageBox.Show("Would you like to save before closing?","Confirm Exit",MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    bool userSavedFile = SaveFile(true);
                    if (!userSavedFile) { return; }
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
                else // They chose No
                {
                    // Continue to exit
                }
            }
            Application.Exit(); 
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(contactsListBox.SelectedIndices.Count.ToString());
            String message = "This application allows you to manage contact information for members of the university.\n" +
                "Right click on contacts box to bring up options to add, edit, delete, or search for contacts\n" +
                "This application currently supports adding faculty and students\n" +
                "Please contact Tarik if you need help.";
            MessageBox.Show(message, "Contact Manager Help", MessageBoxButtons.OK);
        }

        private void FacultyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditFacultyForm facultyForm = new AddEditFacultyForm();
            DialogResult result = facultyForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                contactsList.Add(facultyForm.NewFaculty);
                contactsListBox.Items.Add(facultyForm.NewFaculty.ToListBoxString());
                fileSaved = false;
            }
        }

        private void StudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditStudentForm studentForm = new AddEditStudentForm();
            DialogResult result = studentForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                contactsList.Add(studentForm.newStudent);
                contactsListBox.Items.Add(studentForm.newStudent.ToListBoxString());
                fileSaved = false;
            }
        }

        private void ContactDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<int> selectedIndices = contactsListBox.SelectedIndices.Cast<int>().ToList();
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

        private void DeleteContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<int> selectedIndices = contactsListBox.SelectedIndices.Cast<int>().ToList();
            selectedIndices.Sort();
            if (selectedIndices.Count>0)
            {
                for (int i = selectedIndices.Count - 1; i > -1; i--)
                {
                    contactsList.RemoveAt(selectedIndices[i]);
                    contactsListBox.Items.RemoveAt(selectedIndices[i]);
                }
            }
            else
            {
                MessageBox.Show("Must select a contact to remove.", "No contact selected.", MessageBoxButtons.OK);
            }
        }

        private void EditContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<int> selectedIndices = contactsListBox.SelectedIndices.Cast<int>().ToList();
            if (selectedIndices.Count==1)
            {
                Person person = contactsList[selectedIndices[0]];
                if (person is Student)
                {
                    AddEditStudentForm addEditStudentForm = new AddEditStudentForm((Student)person);
                    DialogResult result = addEditStudentForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        MessageBox.Show($"Saved changes to student {person.FirstName} {person.LastName}");
                        contactsListBox.Items[selectedIndices[0]] = contactsList[selectedIndices[0]].ToListBoxString();
                        fileSaved = false;
                    }
                }
                else if (person is Faculty)
                {
                    AddEditFacultyForm addEditFacultyForm = new AddEditFacultyForm((Faculty)person);
                    DialogResult result = addEditFacultyForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        MessageBox.Show($"Saved changes to student {person.FirstName} {person.LastName}");
                        contactsListBox.Items[selectedIndices[0]] = contactsList[selectedIndices[0]].ToListBoxString();
                        fileSaved = false;
                    }
                }
                else
                {
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

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile(true);
        }

        private void SaveContactsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFile(false);
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!fileSaved)
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
            contactsList.Clear();
            contactsListBox.Items.Clear();
            LoadFile();
        }

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
                Filepath = saveFileDialog.FileName;
                return true;
            }
            else
            {
                return false;
            }
        }

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
                Filepath = openFileDialog.FileName;
                fileSaved = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool SaveFile(bool saveAs)
        {
            if(saveAs || Filepath == null)
            {
                if (!SaveFilePathDialog())
                {
                    return false ;
                }
            }
            StreamWriter output = null;
            try
            {
                output = new StreamWriter(Filepath);
                for(int i = 0; i<contactsList.Count; i++)
                {
                    output.WriteLine(contactsList[i].ToFileString());
                }
                output.Close();
                fileSaved = true;
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

        private bool LoadFile()
        {
            if (!OpenFilePathDialog()) { return false; }
          
            StreamReader input = null;
            try
            {
                bool lineReadIssues = false;
                input = new StreamReader(Filepath);
                String newPersonLine = null;
                Person newPerson = null;
                while (!input.EndOfStream)
                {
                    newPerson = null;
                    newPersonLine = input.ReadLine();
                    try
                    {
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
                        lineReadIssues = true;
                    }
                    if (newPerson != null)
                    {
                        contactsList.Add(newPerson);
                        contactsListBox.Items.Add(newPerson.ToListBoxString());
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

        private void FirstNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetOneFieldDialog dialog = new GetOneFieldDialog("Enter first name", "First Name", "Search", "Cancel", Validation.IsNotEmptyOrNull);
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                for(int i = 0; i<contactsList.Count; i++)
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

        private void LastNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetOneFieldDialog dialog = new GetOneFieldDialog("Enter last name", "Last Name", "Search", "Cancel", Validation.IsNotEmptyOrNull);
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
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

        private void FirstAndLastNameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetTwoFieldsDialog dialog = new GetTwoFieldsDialog("Enter first and last name", "First Name", "Last Name", "Search", "Cancel", Validation.IsNotEmptyOrNull, Validation.IsNotEmptyOrNull);
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                for (int i = 0; i < contactsList.Count; i++)
                {
                    if (contactsList[i].FirstName.ToUpper() == dialog.Value1.ToUpper() && contactsList[i].LastName.ToUpper()==dialog.Value2.ToUpper())
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
    }
}
