namespace FormsDriver.Forms
{
    partial class NomProperties
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
            this._gushy = new System.Windows.Forms.CheckBox();
            this._updateNom = new System.Windows.Forms.Button();
            this._enterCalories = new System.Windows.Forms.TextBox();
            this._enterName = new System.Windows.Forms.TextBox();
            this._calories = new System.Windows.Forms.Label();
            this._name = new System.Windows.Forms.Label();
            this._cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _gushy
            // 
            this._gushy.AutoSize = true;
            this._gushy.Location = new System.Drawing.Point(38, 64);
            this._gushy.Name = "_gushy";
            this._gushy.Size = new System.Drawing.Size(193, 17);
            this._gushy.TabIndex = 6;
            this._gushy.Text = "Check Me For Yummy Gushy Noms";
            this._gushy.UseVisualStyleBackColor = true;
            // 
            // _updateNom
            // 
            this._updateNom.Location = new System.Drawing.Point(53, 87);
            this._updateNom.Name = "_updateNom";
            this._updateNom.Size = new System.Drawing.Size(75, 23);
            this._updateNom.TabIndex = 5;
            this._updateNom.Text = "Update";
            this._updateNom.UseVisualStyleBackColor = true;
            this._updateNom.Click += new System.EventHandler(this._updateNom_Click);
            // 
            // _enterCalories
            // 
            this._enterCalories.Location = new System.Drawing.Point(106, 38);
            this._enterCalories.Name = "_enterCalories";
            this._enterCalories.Size = new System.Drawing.Size(166, 20);
            this._enterCalories.TabIndex = 3;
            this._enterCalories.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._enterCalories_KeyPress);
            // 
            // _enterName
            // 
            this._enterName.Location = new System.Drawing.Point(106, 12);
            this._enterName.Name = "_enterName";
            this._enterName.Size = new System.Drawing.Size(166, 20);
            this._enterName.TabIndex = 2;
            // 
            // _calories
            // 
            this._calories.Location = new System.Drawing.Point(6, 36);
            this._calories.Name = "_calories";
            this._calories.Size = new System.Drawing.Size(100, 23);
            this._calories.TabIndex = 1;
            this._calories.Text = "Calories Per Gram:  ";
            this._calories.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _name
            // 
            this._name.Location = new System.Drawing.Point(6, 9);
            this._name.Name = "_name";
            this._name.Size = new System.Drawing.Size(94, 23);
            this._name.TabIndex = 0;
            this._name.Text = "Name:  ";
            this._name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _cancel
            // 
            this._cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancel.Location = new System.Drawing.Point(156, 87);
            this._cancel.Name = "_cancel";
            this._cancel.Size = new System.Drawing.Size(75, 23);
            this._cancel.TabIndex = 7;
            this._cancel.Text = "Cancel";
            this._cancel.UseVisualStyleBackColor = true;
            // 
            // NomProperties
            // 
            this.AcceptButton = this._updateNom;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancel;
            this.ClientSize = new System.Drawing.Size(284, 122);
            this.Controls.Add(this._cancel);
            this.Controls.Add(this._updateNom);
            this.Controls.Add(this._gushy);
            this.Controls.Add(this._enterName);
            this.Controls.Add(this._enterCalories);
            this.Controls.Add(this._calories);
            this.Controls.Add(this._name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NomProperties";
            this.Text = "Nom Properties";
            this.Load += new System.EventHandler(this.NomProperties_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox _gushy;
        private System.Windows.Forms.Button _updateNom;
        private System.Windows.Forms.TextBox _enterCalories;
        private System.Windows.Forms.TextBox _enterName;
        private System.Windows.Forms.Label _calories;
        private System.Windows.Forms.Label _name;
        private System.Windows.Forms.Button _cancel;
    }
}