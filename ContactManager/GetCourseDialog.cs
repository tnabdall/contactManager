using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager
{

    public partial class GetCourseDialog : Form
    {

        public String CourseName = null;
        public GetCourseDialog()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (Validation.IsNotEmptyOrNull(courseNameTextBox))
            {
                CourseName = courseNameTextBox.Text.Trim();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Must enter a course.", "Error", MessageBoxButtons.OK);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
