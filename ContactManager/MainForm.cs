using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        public MainForm()
        {
            InitializeComponent();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String message = "This application allows you to manage contact information for members of the university.\n\n" +
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
            }
        }

        private void ContactDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedIndex = contactsListBox.SelectedIndex;
            if (selectedIndex != -1)
            {
                MessageBox.Show(contactsList[selectedIndex].ToString(), "Contact Details", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("No contact selected.", "Choose a contact", MessageBoxButtons.OK);
            }
        }

        private void DeleteContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedIndex = contactsListBox.SelectedIndex;
            if (selectedIndex != -1)
            {
                contactsList.RemoveAt(selectedIndex);
                contactsListBox.Items.RemoveAt(selectedIndex);
            }
            else
            {
                MessageBox.Show("Must select a contact to remove.", "No contact selected.", MessageBoxButtons.OK);
            }
        }

        private void EditContactToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int selectedIndex = contactsListBox.SelectedIndex;
            if (selectedIndex != -1)
            {
                Person person = contactsList[selectedIndex];
                if(person is Student)
                {
                    AddEditStudentForm addEditStudentForm = new AddEditStudentForm((Student) person);
                }
                else if (person is Faculty)
                {
                    
                }
                else
                {
                    MessageBox.Show("Error. Selected member is not a faculty or student.","Error",MessageBoxButtons.OK);
                }
            }
            else
            {
                MessageBox.Show("Must select a contact to edit.", "No contact selected.", MessageBoxButtons.OK);
            }
        }
    }
}
