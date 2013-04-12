using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DataDriver;

namespace FormsDriver.Forms
{
    public partial class CatProperties : Form
    {
        private Cat _cat = null;
        private bool _dateBindingFailed = false;

        private CatProperties()
        {
            InitializeComponent();
        }

        public CatProperties(Cat cat)
        {
            _cat = cat;
            InitializeComponent();
        }

        private void _ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            if (_dateBindingFailed) _cat.BirthDate = _selectBirthdate.Value;
            this.Hide();
        }

        private void CatProperties_Load(object sender, EventArgs e)
        {
            if (Equals(null, _cat)) return;
            _female.DataBindings.Add(new Binding("Checked", _cat, "IsFemale"));
            _enterName.DataBindings.Add(new Binding("Text", _cat, "Name"));
            try
            {
                _selectBirthdate.DataBindings.Add(new Binding("Text", _cat, "BirthDate"));
            }
            catch (Exception ex)
            {
                _dateBindingFailed = true;
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }

        }

        private void _female_CheckedChanged(object sender, EventArgs e)
        {
            //if (Equals(null, _cat)) return;
            //_cat.IsFemale = _female.Checked;
        }


    }
}
