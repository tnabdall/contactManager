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

        public String Value = null;
        public Func<TextBox, bool> ValidationFunc = null;
        public String ValidationMessage = "Field is not valid.";
        public GetOneFieldDialog()
        {
            InitializeComponent();
        }

        public GetOneFieldDialog(String titleLabel, String valueLabel, String okButtonText="OK", String cancelButtonText = "Cancel", Func<TextBox,bool> validationFunc = null):this()
        {
            this.Text = titleLabel;
            this.valueLabel.Text = valueLabel;
            if (validationFunc == null)
            {
                ValidationFunc = Validation.IsNotEmptyOrNull;
                ValidationMessage = "Must enter a value.";
            }
            else
            {
                ValidationFunc = validationFunc;
            }
            okButton.Text = okButtonText;
            cancelButton.Text = cancelButtonText;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (ValidationFunc(valueTextBox))
            {
                Value = valueTextBox.Text.Trim();
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

        private void ValueTextBox_TextChanged(object sender, EventArgs e)
        {
            Validation.ColorTextBoxValidation(valueTextBox, ValidationFunc);
        }
    }
}
