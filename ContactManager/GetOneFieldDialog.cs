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

    public partial class GetOneFieldDialog : Form
    {
        
        public String Value {
            get
            {
                return value;
            }
        }

        /// <summary>
        /// Holds validation function that takes Textbox and returns bool. Default is to ensure field is not null or empty.
        /// </summary>
        private Func<TextBox, bool> validationFunc = null;

        /// <summary>
        /// Holds validation message if validation conditions are not met.
        /// </summary>
        private String validationMessage = "Field is not valid.";

        private String value = null;

        /// <summary>
        /// Creates dialog. Not to be used.
        /// </summary>
        public GetOneFieldDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates dialog with specified parameters.
        /// </summary>
        /// <param name="titleLabel">Title of dialog</param>
        /// <param name="valueLabel">Label for textbox</param>
        /// <param name="okButtonText">Text for Ok Button</param>
        /// <param name="cancelButtonText">Text for Cancel Button</param>
        /// <param name="validationFunc">Function that takes in textbox and returns bool if text is valid or not</param>
        public GetOneFieldDialog(String titleLabel, String valueLabel, String okButtonText="OK", String cancelButtonText = "Cancel", Func<TextBox,bool> validationFunc = null):this()
        {
            this.Text = titleLabel;
            this.valueLabel.Text = valueLabel;
            // If no funciton provided, default to not empty or null
            if (validationFunc == null)
            {
                this.validationFunc = Validation.IsNotEmptyOrNull;
                validationMessage = "Must enter a value.";
            }
            else
            {
                this.validationFunc = validationFunc;
            }
            okButton.Text = okButtonText;
            cancelButton.Text = cancelButtonText;
        }

        /// <summary>
        /// Validates field and returns OK result if valid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            if (validationFunc(valueTextBox))
            {
                value = valueTextBox.Text.Trim();
                DialogResult = DialogResult.OK;
            }
            else
            { // Display validation message if invalid
                MessageBox.Show(validationMessage, "Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Sends cancel result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Colors field text box according to validation rules.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ValueTextBox_TextChanged(object sender, EventArgs e)
        {
            Validation.ColorTextBoxValidation(valueTextBox, validationFunc);
        }
    }
}
