namespace FormsDriver
{
    partial class StartHere
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
            this._clickMe = new System.Windows.Forms.Button();
            this._close = new System.Windows.Forms.Button();
            this._catsList = new System.Windows.Forms.ComboBox();
            this._ownerText = new System.Windows.Forms.TextBox();
            this._ownerLabel = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this._menu = new System.Windows.Forms.MenuStrip();
            this._create = new System.Windows.Forms.ToolStripMenuItem();
            this._newCat = new System.Windows.Forms.ToolStripMenuItem();
            this._newOwner = new System.Windows.Forms.ToolStripMenuItem();
            this._newNom = new System.Windows.Forms.ToolStripMenuItem();
            this._catActions = new System.Windows.Forms.ToolStripMenuItem();
            this._adoptMe = new System.Windows.Forms.ToolStripMenuItem();
            this._feedMeMenu = new System.Windows.Forms.ToolStripMenuItem();
            this._weighMe = new System.Windows.Forms.ToolStripMenuItem();
            this._modifyDiet = new System.Windows.Forms.ToolStripMenuItem();
            this._menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // _clickMe
            // 
            this._clickMe.Location = new System.Drawing.Point(50, 254);
            this._clickMe.Name = "_clickMe";
            this._clickMe.Size = new System.Drawing.Size(85, 23);
            this._clickMe.TabIndex = 0;
            this._clickMe.Text = "Show Owners";
            this._clickMe.UseVisualStyleBackColor = true;
            this._clickMe.Click += new System.EventHandler(this._clickMe_Click);
            // 
            // _close
            // 
            this._close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._close.Location = new System.Drawing.Point(159, 254);
            this._close.Name = "_close";
            this._close.Size = new System.Drawing.Size(75, 23);
            this._close.TabIndex = 1;
            this._close.Text = "Close";
            this._close.UseVisualStyleBackColor = true;
            this._close.Click += new System.EventHandler(this._close_Click);
            // 
            // _catsList
            // 
            this._catsList.FormattingEnabled = true;
            this._catsList.Location = new System.Drawing.Point(12, 61);
            this._catsList.Name = "_catsList";
            this._catsList.Size = new System.Drawing.Size(260, 21);
            this._catsList.TabIndex = 2;
            this._catsList.SelectedIndexChanged += new System.EventHandler(this._catsList_SelectedIndexChanged);
            // 
            // _ownerText
            // 
            this._ownerText.Location = new System.Drawing.Point(127, 88);
            this._ownerText.Name = "_ownerText";
            this._ownerText.Size = new System.Drawing.Size(145, 20);
            this._ownerText.TabIndex = 3;
            // 
            // _ownerLabel
            // 
            this._ownerLabel.AutoSize = true;
            this._ownerLabel.Location = new System.Drawing.Point(12, 91);
            this._ownerLabel.Name = "_ownerLabel";
            this._ownerLabel.Size = new System.Drawing.Size(78, 13);
            this._ownerLabel.TabIndex = 4;
            this._ownerLabel.Text = "Owner Name:  ";
            this._ownerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 119);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(260, 129);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";

            #region AddMenu
            // 
            // _menu
            // 
            this._menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._create,
            this._catActions});
            this._menu.Location = new System.Drawing.Point(0, 0);
            this._menu.Name = "_menu";
            this._menu.Size = new System.Drawing.Size(284, 24);
            this._menu.TabIndex = 7;
            this._menu.Text = "Menu";
            // 
            // _create
            // 
            this._create.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._newCat,
            this._newOwner,
            this._newNom});
            this._create.Name = "_create";
            this._create.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this._create.Size = new System.Drawing.Size(53, 20);
            this._create.Text = "&Create";
            // 
            // _newCat
            // 
            this._newCat.Name = "_newCat";
            this._newCat.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this._newCat.Size = new System.Drawing.Size(152, 22);
            this._newCat.Text = "C&at";
            this._newCat.Click += new System.EventHandler(this._newCat_Click);
            // 
            // _newOwner
            // 
            this._newOwner.Name = "_newOwner";
            this._newOwner.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this._newOwner.Size = new System.Drawing.Size(152, 22);
            this._newOwner.Text = "&Owner";
            this._newOwner.Click += new System.EventHandler(this._newOwner_Click);
            // 
            // _newNom
            // 
            this._newNom.Name = "_newNom";
            this._newNom.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this._newNom.Size = new System.Drawing.Size(152, 22);
            this._newNom.Text = "&Nom";
            // 
            // _catActions
            // 
            this._catActions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._adoptMe,
            this._feedMeMenu,
            this._weighMe,
            this._modifyDiet});
            this._catActions.Name = "_catActions";
            this._catActions.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this._catActions.Size = new System.Drawing.Size(37, 20);
            this._catActions.Text = "Ca&t";
            // 
            // _adoptMe
            // 
            this._adoptMe.Name = "_adoptMe";
            this._adoptMe.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D)));
            this._adoptMe.Size = new System.Drawing.Size(181, 22);
            this._adoptMe.Text = "A&dopt Me";
            this._adoptMe.Click += new System.EventHandler(this._adoptMe_Click);
            // 
            // _feedMeMenu
            // 
            this._feedMeMenu.Name = "_feedMeMenu";
            this._feedMeMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this._feedMeMenu.Size = new System.Drawing.Size(181, 22);
            this._feedMeMenu.Text = "&Feed Me";
            this._feedMeMenu.Click += new System.EventHandler(this._feedMeMenu_Click);
            // 
            // _weighMe
            // 
            this._weighMe.Name = "_weighMe";
            this._weighMe.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this._weighMe.Size = new System.Drawing.Size(181, 22);
            this._weighMe.Text = "&Weigh Me";
            this._weighMe.Click += new System.EventHandler(this._weighMe_Click);
            // 
            // _modifyDiet
            // 
            this._modifyDiet.Name = "_modifyDiet";
            this._modifyDiet.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.M)));
            this._modifyDiet.Size = new System.Drawing.Size(181, 22);
            this._modifyDiet.Text = "&Modify Diet";
            this._modifyDiet.Click += new System.EventHandler(this._modifyDiet_Click);

            #endregion
            // 
            // StartHere
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._close;
            this.ClientSize = new System.Drawing.Size(284, 287);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this._ownerLabel);
            this.Controls.Add(this._ownerText);
            this.Controls.Add(this._catsList);
            this.Controls.Add(this._close);
            this.Controls.Add(this._clickMe);
            this.Controls.Add(this._menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this._menu;
            this.Name = "StartHere";
            this.Text = "Start Here";
            this.Load += new System.EventHandler(this.StartHere_Load);
            this._menu.ResumeLayout(false);
            this._menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _clickMe;
        private System.Windows.Forms.Button _close;
        private System.Windows.Forms.ComboBox _catsList;
        private System.Windows.Forms.TextBox _ownerText;
        private System.Windows.Forms.Label _ownerLabel;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.MenuStrip _menu;
        private System.Windows.Forms.ToolStripMenuItem _create;
        private System.Windows.Forms.ToolStripMenuItem _newCat;
        private System.Windows.Forms.ToolStripMenuItem _newOwner;
        private System.Windows.Forms.ToolStripMenuItem _newNom;
        private System.Windows.Forms.ToolStripMenuItem _catActions;
        private System.Windows.Forms.ToolStripMenuItem _adoptMe;
        private System.Windows.Forms.ToolStripMenuItem _feedMeMenu;
        private System.Windows.Forms.ToolStripMenuItem _weighMe;
        private System.Windows.Forms.ToolStripMenuItem _modifyDiet;
    }
}

