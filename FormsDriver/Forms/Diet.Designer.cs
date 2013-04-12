namespace FormsDriver.Forms
{
    partial class Diet
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
            this._name = new System.Windows.Forms.Label();
            this._nameValue = new System.Windows.Forms.TextBox();
            this._nomLbl = new System.Windows.Forms.Label();
            this._selectNom = new System.Windows.Forms.ComboBox();
            this._nomViewLbl = new System.Windows.Forms.Label();
            this._nomsSelected = new System.Windows.Forms.DataGridView();
            this._ok = new System.Windows.Forms.Button();
            this._cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._nomsSelected)).BeginInit();
            this.SuspendLayout();
            // 
            // _name
            // 
            this._name.Location = new System.Drawing.Point(15, 7);
            this._name.Name = "_name";
            this._name.Size = new System.Drawing.Size(63, 23);
            this._name.TabIndex = 0;
            this._name.Text = "Name:  ";
            this._name.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _nameValue
            // 
            this._nameValue.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this._nameValue.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this._nameValue.Location = new System.Drawing.Point(84, 7);
            this._nameValue.Name = "_nameValue";
            this._nameValue.ReadOnly = true;
            this._nameValue.Size = new System.Drawing.Size(175, 20);
            this._nameValue.TabIndex = 1;
            // 
            // _nomLbl
            // 
            this._nomLbl.Location = new System.Drawing.Point(1, 31);
            this._nomLbl.Name = "_nomLbl";
            this._nomLbl.Size = new System.Drawing.Size(77, 23);
            this._nomLbl.TabIndex = 2;
            this._nomLbl.Text = "Select Nom:  ";
            this._nomLbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _selectNom
            // 
            this._selectNom.FormattingEnabled = true;
            this._selectNom.Location = new System.Drawing.Point(84, 33);
            this._selectNom.Name = "_selectNom";
            this._selectNom.Size = new System.Drawing.Size(175, 21);
            this._selectNom.TabIndex = 3;
            this._selectNom.Validating += new System.ComponentModel.CancelEventHandler(this._selectNom_Validating);
            // 
            // _nomViewLbl
            // 
            this._nomViewLbl.AutoSize = true;
            this._nomViewLbl.Location = new System.Drawing.Point(21, 70);
            this._nomViewLbl.Name = "_nomViewLbl";
            this._nomViewLbl.Size = new System.Drawing.Size(81, 13);
            this._nomViewLbl.TabIndex = 4;
            this._nomViewLbl.Text = "Noms I Can Eat";
            this._nomViewLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _nomsSelected
            // 
            this._nomsSelected.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._nomsSelected.Location = new System.Drawing.Point(22, 86);
            this._nomsSelected.Name = "_nomsSelected";
            this._nomsSelected.Size = new System.Drawing.Size(240, 150);
            this._nomsSelected.TabIndex = 5;
            this._nomsSelected.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this._nomsSelected_RowsRemoved);
            this._nomsSelected.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this._nomsSelected_UserDeletingRow);
            // 
            // _ok
            // 
            this._ok.Location = new System.Drawing.Point(49, 248);
            this._ok.Name = "_ok";
            this._ok.Size = new System.Drawing.Size(75, 23);
            this._ok.TabIndex = 6;
            this._ok.Text = "OK";
            this._ok.UseVisualStyleBackColor = true;
            this._ok.Click += new System.EventHandler(this._ok_Click);
            // 
            // _cancel
            // 
            this._cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancel.Location = new System.Drawing.Point(161, 248);
            this._cancel.Name = "_cancel";
            this._cancel.Size = new System.Drawing.Size(75, 23);
            this._cancel.TabIndex = 7;
            this._cancel.Text = "Cancel";
            this._cancel.UseVisualStyleBackColor = true;
            // 
            // Diet
            // 
            this.AcceptButton = this._ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancel;
            this.ClientSize = new System.Drawing.Size(284, 283);
            this.Controls.Add(this._cancel);
            this.Controls.Add(this._ok);
            this.Controls.Add(this._nomsSelected);
            this.Controls.Add(this._nomViewLbl);
            this.Controls.Add(this._selectNom);
            this.Controls.Add(this._nomLbl);
            this.Controls.Add(this._nameValue);
            this.Controls.Add(this._name);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Diet";
            this.Text = "Noms I Can Eat";
            this.Load += new System.EventHandler(this.Diet_Load);
            ((System.ComponentModel.ISupportInitialize)(this._nomsSelected)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _name;
        private System.Windows.Forms.TextBox _nameValue;
        private System.Windows.Forms.Label _nomLbl;
        private System.Windows.Forms.ComboBox _selectNom;
        private System.Windows.Forms.Label _nomViewLbl;
        private System.Windows.Forms.DataGridView _nomsSelected;
        private System.Windows.Forms.Button _ok;
        private System.Windows.Forms.Button _cancel;
    }
}