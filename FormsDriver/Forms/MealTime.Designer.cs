namespace FormsDriver.Forms
{
    partial class MealTime
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
            this._selectNom = new System.Windows.Forms.ComboBox();
            this._select = new System.Windows.Forms.Label();
            this._ok = new System.Windows.Forms.Button();
            this._cancel = new System.Windows.Forms.Button();
            this._grams = new System.Windows.Forms.Label();
            this._enterGrams = new System.Windows.Forms.TextBox();
            this._nomsView = new System.Windows.Forms.DataGridView();
            this._editNom = new System.Windows.Forms.Button();
            this._addNom = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._nomsView)).BeginInit();
            this.SuspendLayout();
            // 
            // _selectNom
            // 
            this._selectNom.FormattingEnabled = true;
            this._selectNom.Location = new System.Drawing.Point(107, 12);
            this._selectNom.Name = "_selectNom";
            this._selectNom.Size = new System.Drawing.Size(165, 21);
            this._selectNom.TabIndex = 1;
            this._selectNom.Validating += new System.ComponentModel.CancelEventHandler(this._selectNom_Validating);
            // 
            // _select
            // 
            this._select.Location = new System.Drawing.Point(12, 10);
            this._select.Name = "_select";
            this._select.Size = new System.Drawing.Size(75, 23);
            this._select.TabIndex = 0;
            this._select.Text = "Select Nom:  ";
            this._select.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _ok
            // 
            this._ok.Location = new System.Drawing.Point(64, 192);
            this._ok.Name = "_ok";
            this._ok.Size = new System.Drawing.Size(75, 23);
            this._ok.TabIndex = 7;
            this._ok.Text = "OK";
            this._ok.UseVisualStyleBackColor = true;
            this._ok.Click += new System.EventHandler(this._ok_Click);
            // 
            // _cancel
            // 
            this._cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancel.Location = new System.Drawing.Point(164, 192);
            this._cancel.Name = "_cancel";
            this._cancel.Size = new System.Drawing.Size(75, 23);
            this._cancel.TabIndex = 8;
            this._cancel.Text = "Cancel";
            this._cancel.UseVisualStyleBackColor = true;
            // 
            // _grams
            // 
            this._grams.Location = new System.Drawing.Point(5, 46);
            this._grams.Name = "_grams";
            this._grams.Size = new System.Drawing.Size(94, 23);
            this._grams.TabIndex = 2;
            this._grams.Text = "Grams This Nom:  ";
            this._grams.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _enterGrams
            // 
            this._enterGrams.Location = new System.Drawing.Point(107, 46);
            this._enterGrams.Name = "_enterGrams";
            this._enterGrams.Size = new System.Drawing.Size(165, 20);
            this._enterGrams.TabIndex = 3;
            this._enterGrams.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._enterGrams_KeyPress);
            // 
            // _nomsView
            // 
            this._nomsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._nomsView.Location = new System.Drawing.Point(8, 104);
            this._nomsView.Name = "_nomsView";
            this._nomsView.Size = new System.Drawing.Size(291, 82);
            this._nomsView.TabIndex = 6;
            // 
            // _editNom
            // 
            this._editNom.Enabled = false;
            this._editNom.Location = new System.Drawing.Point(171, 72);
            this._editNom.Name = "_editNom";
            this._editNom.Size = new System.Drawing.Size(75, 23);
            this._editNom.TabIndex = 5;
            this._editNom.Text = "Edit &Nom";
            this._editNom.UseVisualStyleBackColor = true;
            // 
            // _addNom
            // 
            this._addNom.Location = new System.Drawing.Point(64, 72);
            this._addNom.Name = "_addNom";
            this._addNom.Size = new System.Drawing.Size(75, 23);
            this._addNom.TabIndex = 4;
            this._addNom.Text = "&Add Nom";
            this._addNom.UseVisualStyleBackColor = true;
            this._addNom.Click += new System.EventHandler(this._addNom_Click);
            // 
            // MealTime
            // 
            this.AcceptButton = this._ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancel;
            this.ClientSize = new System.Drawing.Size(311, 229);
            this.Controls.Add(this._addNom);
            this.Controls.Add(this._editNom);
            this.Controls.Add(this._nomsView);
            this.Controls.Add(this._grams);
            this.Controls.Add(this._enterGrams);
            this.Controls.Add(this._ok);
            this.Controls.Add(this._cancel);
            this.Controls.Add(this._select);
            this.Controls.Add(this._selectNom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MealTime";
            this.Text = "Meal Time";
            this.Load += new System.EventHandler(this.MealTime_Load);
            ((System.ComponentModel.ISupportInitialize)(this._nomsView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox _selectNom;
        private System.Windows.Forms.Label _select;
        private System.Windows.Forms.Button _ok;
        private System.Windows.Forms.Button _cancel;
        private System.Windows.Forms.Label _grams;
        private System.Windows.Forms.TextBox _enterGrams;
        private System.Windows.Forms.DataGridView _nomsView;
        private System.Windows.Forms.Button _editNom;
        private System.Windows.Forms.Button _addNom;

    }
}