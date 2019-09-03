namespace ContactManager
{
    partial class GetTwoFieldsDialog
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
            this.value1Label = new System.Windows.Forms.Label();
            this.value1TextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.value2Label = new System.Windows.Forms.Label();
            this.value2TextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // value1Label
            // 
            this.value1Label.AutoSize = true;
            this.value1Label.Location = new System.Drawing.Point(16, 25);
            this.value1Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.value1Label.Name = "value1Label";
            this.value1Label.Size = new System.Drawing.Size(71, 13);
            this.value1Label.TabIndex = 0;
            this.value1Label.Text = "Enter Value 1";
            // 
            // value1TextBox
            // 
            this.value1TextBox.Location = new System.Drawing.Point(106, 25);
            this.value1TextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.value1TextBox.Name = "value1TextBox";
            this.value1TextBox.Size = new System.Drawing.Size(194, 20);
            this.value1TextBox.TabIndex = 1;
            this.value1TextBox.TextChanged += new System.EventHandler(this.Value1TextBox_TextChanged);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(173, 87);
            this.okButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(56, 24);
            this.okButton.TabIndex = 3;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(244, 87);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(56, 24);
            this.cancelButton.TabIndex = 4;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // value2Label
            // 
            this.value2Label.AutoSize = true;
            this.value2Label.Location = new System.Drawing.Point(16, 63);
            this.value2Label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.value2Label.Name = "value2Label";
            this.value2Label.Size = new System.Drawing.Size(71, 13);
            this.value2Label.TabIndex = 0;
            this.value2Label.Text = "Enter Value 2";
            // 
            // value2TextBox
            // 
            this.value2TextBox.Location = new System.Drawing.Point(106, 60);
            this.value2TextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.value2TextBox.Name = "value2TextBox";
            this.value2TextBox.Size = new System.Drawing.Size(194, 20);
            this.value2TextBox.TabIndex = 2;
            this.value2TextBox.TextChanged += new System.EventHandler(this.Value2TextBox_TextChanged);
            // 
            // GetTwoFieldsDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(326, 121);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.value2TextBox);
            this.Controls.Add(this.value1TextBox);
            this.Controls.Add(this.value2Label);
            this.Controls.Add(this.value1Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "GetTwoFieldsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter values";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label value1Label;
        private System.Windows.Forms.TextBox value1TextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label value2Label;
        private System.Windows.Forms.TextBox value2TextBox;
    }
}