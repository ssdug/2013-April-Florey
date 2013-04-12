namespace FormsDriver.Forms
{
    partial class CatProperties
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
            this._ok = new System.Windows.Forms.Button();
            this._cancel = new System.Windows.Forms.Button();
            this._name = new System.Windows.Forms.Label();
            this._dateOfBirth = new System.Windows.Forms.Label();
            this._enterName = new System.Windows.Forms.TextBox();
            this._selectBirthdate = new System.Windows.Forms.DateTimePicker();
            this._gender = new System.Windows.Forms.GroupBox();
            this._male = new System.Windows.Forms.RadioButton();
            this._female = new System.Windows.Forms.RadioButton();
            this._gender.SuspendLayout();
            this.SuspendLayout();
            // 
            // _ok
            // 
            this._ok.Location = new System.Drawing.Point(58, 104);
            this._ok.Name = "_ok";
            this._ok.Size = new System.Drawing.Size(75, 23);
            this._ok.TabIndex = 5;
            this._ok.Text = "OK";
            this._ok.UseVisualStyleBackColor = true;
            this._ok.Click += new System.EventHandler(this._ok_Click);
            // 
            // _cancel
            // 
            this._cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancel.Location = new System.Drawing.Point(152, 104);
            this._cancel.Name = "_cancel";
            this._cancel.Size = new System.Drawing.Size(75, 23);
            this._cancel.TabIndex = 6;
            this._cancel.Text = "Cancel";
            this._cancel.UseVisualStyleBackColor = true;
            // 
            // _name
            // 
            this._name.Location = new System.Drawing.Point(46, 11);
            this._name.Name = "_name";
            this._name.Size = new System.Drawing.Size(35, 13);
            this._name.TabIndex = 0;
            this._name.Text = "Name:  ";
            this._name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _dateOfBirth
            // 
            this._dateOfBirth.Location = new System.Drawing.Point(12, 40);
            this._dateOfBirth.Name = "_dateOfBirth";
            this._dateOfBirth.Size = new System.Drawing.Size(69, 13);
            this._dateOfBirth.TabIndex = 2;
            this._dateOfBirth.Text = "Date of Birth:";
            this._dateOfBirth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _enterName
            // 
            this._enterName.Location = new System.Drawing.Point(91, 8);
            this._enterName.Name = "_enterName";
            this._enterName.Size = new System.Drawing.Size(181, 20);
            this._enterName.TabIndex = 1;
            // 
            // _selectBirthdate
            // 
            this._selectBirthdate.Location = new System.Drawing.Point(91, 34);
            this._selectBirthdate.Name = "_selectBirthdate";
            this._selectBirthdate.Size = new System.Drawing.Size(181, 20);
            this._selectBirthdate.TabIndex = 3;
            // 
            // _gender
            // 
            this._gender.Controls.Add(this._male);
            this._gender.Controls.Add(this._female);
            this._gender.Location = new System.Drawing.Point(15, 61);
            this._gender.Name = "_gender";
            this._gender.Size = new System.Drawing.Size(257, 37);
            this._gender.TabIndex = 4;
            this._gender.TabStop = false;
            this._gender.Text = "Gender";
            // 
            // _male
            // 
            this._male.AutoSize = true;
            this._male.Location = new System.Drawing.Point(150, 16);
            this._male.Name = "_male";
            this._male.Size = new System.Drawing.Size(48, 17);
            this._male.TabIndex = 1;
            this._male.TabStop = true;
            this._male.Text = "Male";
            this._male.UseVisualStyleBackColor = true;
            // 
            // _female
            // 
            this._female.AutoSize = true;
            this._female.Location = new System.Drawing.Point(51, 16);
            this._female.Name = "_female";
            this._female.Size = new System.Drawing.Size(59, 17);
            this._female.TabIndex = 0;
            this._female.TabStop = true;
            this._female.Text = "Female";
            this._female.UseVisualStyleBackColor = true;
            this._female.CheckedChanged += new System.EventHandler(this._female_CheckedChanged);
            // 
            // CatProperties
            // 
            this.AcceptButton = this._ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancel;
            this.ClientSize = new System.Drawing.Size(284, 139);
            this.Controls.Add(this._gender);
            this.Controls.Add(this._selectBirthdate);
            this.Controls.Add(this._enterName);
            this.Controls.Add(this._dateOfBirth);
            this.Controls.Add(this._name);
            this.Controls.Add(this._cancel);
            this.Controls.Add(this._ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CatProperties";
            this.Text = "Cat Properties";
            this.Load += new System.EventHandler(this.CatProperties_Load);
            this._gender.ResumeLayout(false);
            this._gender.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _ok;
        private System.Windows.Forms.Button _cancel;
        private System.Windows.Forms.Label _name;
        private System.Windows.Forms.Label _dateOfBirth;
        private System.Windows.Forms.TextBox _enterName;
        private System.Windows.Forms.DateTimePicker _selectBirthdate;
        private System.Windows.Forms.GroupBox _gender;
        private System.Windows.Forms.RadioButton _male;
        private System.Windows.Forms.RadioButton _female;
    }
}