namespace FormsDriver.Forms
{
    partial class Scale
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
            this._recordDate = new System.Windows.Forms.DateTimePicker();
            this._date = new System.Windows.Forms.Label();
            this._weight = new System.Windows.Forms.Label();
            this._recordWeight = new System.Windows.Forms.NumericUpDown();
            this._ok = new System.Windows.Forms.Button();
            this._cancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._recordWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // _recordDate
            // 
            this._recordDate.Location = new System.Drawing.Point(84, 8);
            this._recordDate.Name = "_recordDate";
            this._recordDate.Size = new System.Drawing.Size(188, 20);
            this._recordDate.TabIndex = 1;
            // 
            // _date
            // 
            this._date.Location = new System.Drawing.Point(3, 8);
            this._date.Name = "_date";
            this._date.Size = new System.Drawing.Size(75, 23);
            this._date.TabIndex = 0;
            this._date.Text = "Date:  ";
            this._date.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _weight
            // 
            this._weight.Location = new System.Drawing.Point(3, 44);
            this._weight.Name = "_weight";
            this._weight.Size = new System.Drawing.Size(75, 23);
            this._weight.TabIndex = 2;
            this._weight.Text = "Weight (lbs):  ";
            this._weight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _recordWeight
            // 
            this._recordWeight.DecimalPlaces = 1;
            this._recordWeight.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this._recordWeight.Location = new System.Drawing.Point(84, 47);
            this._recordWeight.Name = "_recordWeight";
            this._recordWeight.Size = new System.Drawing.Size(188, 20);
            this._recordWeight.TabIndex = 3;
            // 
            // _ok
            // 
            this._ok.Location = new System.Drawing.Point(56, 84);
            this._ok.Name = "_ok";
            this._ok.Size = new System.Drawing.Size(75, 23);
            this._ok.TabIndex = 4;
            this._ok.Text = "OK";
            this._ok.UseVisualStyleBackColor = true;
            this._ok.Click += new System.EventHandler(this._ok_Click);
            // 
            // _cancel
            // 
            this._cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._cancel.Location = new System.Drawing.Point(154, 84);
            this._cancel.Name = "_cancel";
            this._cancel.Size = new System.Drawing.Size(75, 23);
            this._cancel.TabIndex = 5;
            this._cancel.Text = "Cancel";
            this._cancel.UseVisualStyleBackColor = true;
            // 
            // Scale
            // 
            this.AcceptButton = this._ok;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancel;
            this.ClientSize = new System.Drawing.Size(284, 123);
            this.Controls.Add(this._cancel);
            this.Controls.Add(this._ok);
            this.Controls.Add(this._recordWeight);
            this.Controls.Add(this._weight);
            this.Controls.Add(this._date);
            this.Controls.Add(this._recordDate);
            this.Name = "Scale";
            this.Text = "Scale";
            this.Load += new System.EventHandler(this.Scale_Load);
            ((System.ComponentModel.ISupportInitialize)(this._recordWeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DateTimePicker _recordDate;
        private System.Windows.Forms.Label _date;
        private System.Windows.Forms.Label _weight;
        private System.Windows.Forms.NumericUpDown _recordWeight;
        private System.Windows.Forms.Button _ok;
        private System.Windows.Forms.Button _cancel;
    }
}