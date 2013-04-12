using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FormsDriver.Controllers;

namespace FormsDriver.Forms
{
    public partial class SelectOwner : Form
    {
        private CatHerder _controller;
        private bool _createNew = false;
        private string _name = String.Empty;

        public string OwnerName { get { return _name; } }

        private SelectOwner()
        {
            InitializeComponent();
        }

        public SelectOwner(CatHerder controller, bool createNew)
        {
            _controller = controller;
            _createNew = createNew;
            InitializeComponent();
        }

        private void SelectOwner_Load(object sender, EventArgs e)
        {
            if (!_createNew)
                _selectOwner.DataSource = _controller.OwnerNames;
            _selectOwner.Visible = !_createNew;
            _selectOwner.Enabled = !_createNew;
            _createOwner.Visible = _createNew;
            _createOwner.Enabled = _createNew;

        }

        private void _ok_Click(object sender, EventArgs e)
        {
            if (_createNew)
            {
                _name = _createOwner.Text;
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
            else
            {
                if (_controller.ValidateOwner(_selectOwner.Text))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Hide();
                }
            }

        }


    }
}
