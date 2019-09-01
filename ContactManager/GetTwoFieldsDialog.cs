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

    public partial class GetTwoFieldsDialog : Form
    {
        /// <summary>
        /// Holds the first value to be returned
        /// </summary>
        public String Value1
        {
            get
            {
                return value1;
            }
        }
       
        

        /// <summary>
        /// Holds the second value to be returned
        /// </summary>
        public String Value2
        {
            get
            {
                return value2;
            }
        }

        /// <summary>
        /// Holds the validation function (input Textbox, output bool) for the first value
        /// </summary>
        private Func<TextBox, bool> validationFunc1 = null;

        /// <summary>
        /// Holds the validation function (input Textbox, output bool) for the second value
        /// </summary>
        private Func<TextBox, bool> validationFunc2 = null;

        /// <summary>
        /// Validation message if form validation fails
        /// </summary>
        private String validationMessage = "One or both fields are not valid.";

        private String value1 = null;
        private String value2 = null;

        /// <summary>
        /// Default constructor by VS, not to be used
        /// </summary>
        public GetTwoFieldsDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Creates the 2 field dialog with the parameters specified
        /// </summary>
        /// <param name="titleLabel">Title of form</param>
        /// <param name="value1Label">Label for first value retrieved</param>
        /// <param name="value2Label">Label for second value retrieved</param>
        /// <param name="okButtonText">Text for ok button</param>
        /// <param name="cancelButtonText">Text for cancel button</param>
        /// <param name="validationFunc1">Validation function (input Textbox, output bool) for first value. Defaults to not empty/null</param>
        /// <param name="validationFunc2">Validation function (input Textbox, output bool) for second value. Defaults to not empty/null</param>
        public GetTwoFieldsDialog(String titleLabel, String value1Label, String value2Label, String okButtonText="OK", String cancelButtonText = "Cancel", Func<TextBox,bool> validationFunc1 = null, Func<TextBox,bool> validationFunc2 = null):this()
        {
            this.Text = titleLabel;
            this.value1Label.Text = value1Label;
            this.value2Label.Text = value2Label;
            // Sets validation functions to not empty or null if not specified
            if (validationFunc1 == null)
            {
                this.validationFunc1 = Validation.IsNotEmptyOrNull;
            }
            else
            {
                this.validationFunc1 = validationFunc1;
            }
            if(validationFunc2 == null)
            {
                this.validationFunc2 = Validation.IsNotEmptyOrNull;
            }
            else
            {
                this.validationFunc2 = validationFunc2;
            }
            okButton.Text = okButtonText;
            cancelButton.Text = cancelButtonText;
        }

        /// <summary>
        /// Handles ok button click. Validates form before sending OK result.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkButton_Click(object sender, EventArgs e)
        {
            // Validates both fields before sending OK dialog result
            if (validationFunc1(value1TextBox) && validationFunc2(value2TextBox))
            {
                value1 = value1TextBox.Text.Trim();
                value2 = value2TextBox.Text.Trim();
                DialogResult = DialogResult.OK;
            }
            else
            { // Shows error message
                MessageBox.Show(validationMessage, "Error", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// Sends cancel dialog result
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// Colors first value based on validation rules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Value1TextBox_TextChanged(object sender, EventArgs e)
        {
            Validation.ColorTextBoxValidation(value1TextBox, validationFunc1);
        }

        /// <summary>
        /// Colors second value based on validation rules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Value2TextBox_TextChanged(object sender, EventArgs e)
        {
            Validation.ColorTextBoxValidation(value2TextBox, validationFunc2);
        }
    }
}
