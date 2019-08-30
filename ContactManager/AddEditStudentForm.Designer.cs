namespace ContactManager
{
    partial class AddEditStudentForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.firstNameLabel = new System.Windows.Forms.Label();
            this.lastNameLabel = new System.Windows.Forms.Label();
            this.academicDepartmentLabel = new System.Windows.Forms.Label();
            this.contactInformationLabel = new System.Windows.Forms.Label();
            this.emailAddressLabel = new System.Windows.Forms.Label();
            this.mailingAddressLabel = new System.Windows.Forms.Label();
            this.firstNameTextBox = new System.Windows.Forms.TextBox();
            this.lastNameTextBox = new System.Windows.Forms.TextBox();
            this.academicDepartmentTextBox = new System.Windows.Forms.TextBox();
            this.emailAddressTextBox = new System.Windows.Forms.TextBox();
            this.mailingAddressTextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.expectedGraduationYearTextBox = new System.Windows.Forms.TextBox();
            this.expectedGraduationYearLabel = new System.Windows.Forms.Label();
            this.courseListLabel = new System.Windows.Forms.Label();
            this.courseListListBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // firstNameLabel
            // 
            this.firstNameLabel.AutoSize = true;
            this.firstNameLabel.Location = new System.Drawing.Point(136, 29);
            this.firstNameLabel.Name = "firstNameLabel";
            this.firstNameLabel.Size = new System.Drawing.Size(80, 17);
            this.firstNameLabel.TabIndex = 0;
            this.firstNameLabel.Text = "First Name:";
            // 
            // lastNameLabel
            // 
            this.lastNameLabel.AutoSize = true;
            this.lastNameLabel.Location = new System.Drawing.Point(136, 59);
            this.lastNameLabel.Name = "lastNameLabel";
            this.lastNameLabel.Size = new System.Drawing.Size(80, 17);
            this.lastNameLabel.TabIndex = 0;
            this.lastNameLabel.Text = "Last Name:";
            // 
            // academicDepartmentLabel
            // 
            this.academicDepartmentLabel.AutoSize = true;
            this.academicDepartmentLabel.Location = new System.Drawing.Point(65, 92);
            this.academicDepartmentLabel.Name = "academicDepartmentLabel";
            this.academicDepartmentLabel.Size = new System.Drawing.Size(151, 17);
            this.academicDepartmentLabel.TabIndex = 0;
            this.academicDepartmentLabel.Text = "Academic Department:";
            // 
            // contactInformationLabel
            // 
            this.contactInformationLabel.AutoSize = true;
            this.contactInformationLabel.Location = new System.Drawing.Point(82, 122);
            this.contactInformationLabel.Name = "contactInformationLabel";
            this.contactInformationLabel.Size = new System.Drawing.Size(134, 17);
            this.contactInformationLabel.TabIndex = 0;
            this.contactInformationLabel.Text = "Contact Information:";
            // 
            // emailAddressLabel
            // 
            this.emailAddressLabel.AutoSize = true;
            this.emailAddressLabel.Location = new System.Drawing.Point(148, 158);
            this.emailAddressLabel.Name = "emailAddressLabel";
            this.emailAddressLabel.Size = new System.Drawing.Size(102, 17);
            this.emailAddressLabel.TabIndex = 0;
            this.emailAddressLabel.Text = "Email Address:";
            // 
            // mailingAddressLabel
            // 
            this.mailingAddressLabel.AutoSize = true;
            this.mailingAddressLabel.Location = new System.Drawing.Point(138, 186);
            this.mailingAddressLabel.Name = "mailingAddressLabel";
            this.mailingAddressLabel.Size = new System.Drawing.Size(112, 17);
            this.mailingAddressLabel.TabIndex = 0;
            this.mailingAddressLabel.Text = "Mailing Address:";
            // 
            // firstNameTextBox
            // 
            this.firstNameTextBox.Location = new System.Drawing.Point(238, 29);
            this.firstNameTextBox.Name = "firstNameTextBox";
            this.firstNameTextBox.Size = new System.Drawing.Size(410, 22);
            this.firstNameTextBox.TabIndex = 1;
            // 
            // lastNameTextBox
            // 
            this.lastNameTextBox.Location = new System.Drawing.Point(238, 57);
            this.lastNameTextBox.Name = "lastNameTextBox";
            this.lastNameTextBox.Size = new System.Drawing.Size(410, 22);
            this.lastNameTextBox.TabIndex = 1;
            // 
            // academicDepartmentTextBox
            // 
            this.academicDepartmentTextBox.Location = new System.Drawing.Point(238, 89);
            this.academicDepartmentTextBox.Name = "academicDepartmentTextBox";
            this.academicDepartmentTextBox.Size = new System.Drawing.Size(410, 22);
            this.academicDepartmentTextBox.TabIndex = 1;
            // 
            // emailAddressTextBox
            // 
            this.emailAddressTextBox.Location = new System.Drawing.Point(256, 156);
            this.emailAddressTextBox.Name = "emailAddressTextBox";
            this.emailAddressTextBox.Size = new System.Drawing.Size(392, 22);
            this.emailAddressTextBox.TabIndex = 1;
            // 
            // mailingAddressTextBox
            // 
            this.mailingAddressTextBox.Location = new System.Drawing.Point(256, 183);
            this.mailingAddressTextBox.Name = "mailingAddressTextBox";
            this.mailingAddressTextBox.Size = new System.Drawing.Size(392, 22);
            this.mailingAddressTextBox.TabIndex = 1;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(470, 449);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 3;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(573, 449);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(470, 449);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 3;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Visible = false;
            this.saveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // expectedGraduationYearTextBox
            // 
            this.expectedGraduationYearTextBox.Location = new System.Drawing.Point(238, 215);
            this.expectedGraduationYearTextBox.Name = "expectedGraduationYearTextBox";
            this.expectedGraduationYearTextBox.Size = new System.Drawing.Size(121, 22);
            this.expectedGraduationYearTextBox.TabIndex = 1;
            // 
            // expectedGraduationYearLabel
            // 
            this.expectedGraduationYearLabel.AutoSize = true;
            this.expectedGraduationYearLabel.Location = new System.Drawing.Point(37, 215);
            this.expectedGraduationYearLabel.Name = "expectedGraduationYearLabel";
            this.expectedGraduationYearLabel.Size = new System.Drawing.Size(179, 17);
            this.expectedGraduationYearLabel.TabIndex = 0;
            this.expectedGraduationYearLabel.Text = "Expected Graduation Year:";
            // 
            // courseListLabel
            // 
            this.courseListLabel.AutoSize = true;
            this.courseListLabel.Location = new System.Drawing.Point(133, 249);
            this.courseListLabel.Name = "courseListLabel";
            this.courseListLabel.Size = new System.Drawing.Size(83, 17);
            this.courseListLabel.TabIndex = 0;
            this.courseListLabel.Text = "Course List:";
            // 
            // courseListListBox
            // 
            this.courseListListBox.FormattingEnabled = true;
            this.courseListListBox.ItemHeight = 16;
            this.courseListListBox.Location = new System.Drawing.Point(238, 249);
            this.courseListListBox.Name = "courseListListBox";
            this.courseListListBox.Size = new System.Drawing.Size(410, 180);
            this.courseListListBox.TabIndex = 2;
            // 
            // AddEditStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 484);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.courseListListBox);
            this.Controls.Add(this.expectedGraduationYearTextBox);
            this.Controls.Add(this.mailingAddressTextBox);
            this.Controls.Add(this.emailAddressTextBox);
            this.Controls.Add(this.academicDepartmentTextBox);
            this.Controls.Add(this.lastNameTextBox);
            this.Controls.Add(this.firstNameTextBox);
            this.Controls.Add(this.mailingAddressLabel);
            this.Controls.Add(this.emailAddressLabel);
            this.Controls.Add(this.courseListLabel);
            this.Controls.Add(this.expectedGraduationYearLabel);
            this.Controls.Add(this.contactInformationLabel);
            this.Controls.Add(this.academicDepartmentLabel);
            this.Controls.Add(this.lastNameLabel);
            this.Controls.Add(this.firstNameLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AddEditStudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddEditFacultyForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label firstNameLabel;
        private System.Windows.Forms.Label lastNameLabel;
        private System.Windows.Forms.Label academicDepartmentLabel;
        private System.Windows.Forms.Label contactInformationLabel;
        private System.Windows.Forms.Label emailAddressLabel;
        private System.Windows.Forms.Label mailingAddressLabel;
        private System.Windows.Forms.TextBox firstNameTextBox;
        private System.Windows.Forms.TextBox lastNameTextBox;
        private System.Windows.Forms.TextBox academicDepartmentTextBox;
        private System.Windows.Forms.TextBox emailAddressTextBox;
        private System.Windows.Forms.TextBox mailingAddressTextBox;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TextBox expectedGraduationYearTextBox;
        private System.Windows.Forms.Label expectedGraduationYearLabel;
        private System.Windows.Forms.Label courseListLabel;
        private System.Windows.Forms.ListBox courseListListBox;
    }
}