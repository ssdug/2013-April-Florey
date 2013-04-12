namespace FormsDriver.Forms
{
    partial class SelectOwner
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
            this._selectOwner = new System.Windows.Forms.ComboBox();
            this._ok = new System.Windows.Forms.Button();
            this._cancel = new System.Windows.Forms.Button();
            this._createOwner = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // _selectOwner
            // 
            this._selectOwner.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this._selectOwner.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this._selectOwner.FormattingEnabled = true;
            this._selectOwner.Location = new System.Drawing.Point(13, 13);
            this._selectOwner.Name = "_selectOwner";
            this._selectOwner.Size = new System.Drawing.Size(259, 21);
            this._selectOwner.TabIndex = 0;
            // 
            // _ok
            // 
            this._ok.Location = new System.Drawing.Point(59, 50);
            this._ok.Name = "_ok";
            this._ok.Size = new System.Drawing.Size(75, 23);
            this._ok.TabIndex = 1;
            this._ok.Text = "OK";
            this._ok.UseVisualStyleBackColor = true;
            this._ok.Click += new System.EventHandler(this._ok_Click);
            // 
            // _cancel
            // 
            this._cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancel.Location = new System.Drawing.Point(151, 50);
            this._cancel.Name = "_cancel";
            this._cancel.Size = new System.Drawing.Size(75, 23);
            this._cancel.TabIndex = 2;
            this._cancel.Text = "Cancel";
            this._cancel.UseVisualStyleBackColor = true;
            // 
            // _createOwner
            // 
            this._createOwner.Location = new System.Drawing.Point(13, 13);
            this._createOwner.Name = "_createOwner";
            this._createOwner.Size = new System.Drawing.Size(259, 20);
            this._createOwner.TabIndex = 3;
            this._createOwner.Visible = false;
            // 
            // SelectOwner
            // 
            this.AcceptButton = this._ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancel;
            this.ClientSize = new System.Drawing.Size(284, 81);
            this.Controls.Add(this._createOwner);
            this.Controls.Add(this._cancel);
            this.Controls.Add(this._ok);
            this.Controls.Add(this._selectOwner);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectOwner";
            this.Text = "Select Owner";
            this.Load += new System.EventHandler(this.SelectOwner_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _selectOwner;
        private System.Windows.Forms.Button _ok;
        private System.Windows.Forms.Button _cancel;
        private System.Windows.Forms.TextBox _createOwner;
    }
}