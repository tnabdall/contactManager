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

        public String Value1 = null;
        public Func<TextBox, bool> ValidationFunc1 = null;
        public String Value2 = null;
        public Func<TextBox, bool> ValidationFunc2 = null;
        public String ValidationMessage = "One or both fields are not valid.";
        public GetTwoFieldsDialog()
        {
            InitializeComponent();
        }

        public GetTwoFieldsDialog(String titleLabel, String value1Label, String value2Label, String okButtonText="OK", String cancelButtonText = "Cancel", Func<TextBox,bool> validationFunc1 = null, Func<TextBox,bool> validationFunc2 = null):this()
        {
            this.Text = titleLabel;
            this.value1Label.Text = value1Label;
            this.value2Label.Text = value2Label;
            if (validationFunc1 == null)
            {
                ValidationFunc1 = Validation.IsNotEmptyOrNull;
            }
            else
            {
                ValidationFunc1 = validationFunc1;
            }
            if(validationFunc2 == null)
            {
                ValidationFunc2 = Validation.IsNotEmptyOrNull;
            }
            else
            {
                ValidationFunc2 = validationFunc2;
            }
            okButton.Text = okButtonText;
            cancelButton.Text = cancelButtonText;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidationFunc1(value1TextBox) && ValidationFunc2(value2TextBox))
            {
                Value1 = value1TextBox.Text.Trim();
                Value2 = value2TextBox.Text.Trim();
                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show(ValidationMessage, "Error", MessageBoxButtons.OK);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Value1TextBox_TextChanged(object sender, EventArgs e)
        {
            Validation.ColorTextBoxValidation(value1TextBox, ValidationFunc1);
        }

        private void Value2TextBox_TextChanged(object sender, EventArgs e)
        {
            Validation.ColorTextBoxValidation(value2TextBox, ValidationFunc2);
        }
    }
}
