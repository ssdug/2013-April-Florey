using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DataDriver;

namespace FormsDriver.Forms
{
    public partial class Scale : Form
    {
        private Weight _current = new Weight();

        private Scale()
        {
            InitializeComponent();
        }

        public Scale(Weight weight)
        {
            _current = weight;
            InitializeComponent();
        }

        public Scale(decimal weight, DateTime date)
        {
            _pounds = weight;
            _weighDate = date;
            InitializeComponent();
        }


        #region DataBinding Comment Start

        //#region DataBinding Source
        //private void _ok_Click(object sender, EventArgs e)
        //{
        //    this.DialogResult = DialogResult.OK;
        //    if (_current.Pounds != _recordWeight.Value)
        //        _current.Pounds = _recordWeight.Value;
        //    this.Close();
        //}

        //private void Scale_Load(object sender, EventArgs e)
        //{
        //    _recordDate.DataBindings.Add("Value", _current, "Date", true, DataSourceUpdateMode.OnPropertyChanged, System.DateTime.Now);
        //    _recordWeight.DataBindings.Add("Value", _current, "Pounds", true, DataSourceUpdateMode.OnPropertyChanged, String.Empty);
        //}
        //#endregion

        #endregion

        #region OldSchool Source

        #region OldSchool Comment Start

        private decimal _pounds = 0;
        public decimal Pounds { get { return _pounds; } }
        private DateTime _weighDate = System.DateTime.Now;
        public DateTime WeighDate { get { return _weighDate; } }

        private void _ok_Click(object sender, EventArgs e)
        {
            _pounds = _recordWeight.Value;
            _weighDate = _recordDate.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Scale_Load(object sender, EventArgs e)
        {
            _recordDate.Value = _weighDate;
            _recordWeight.Value = _pounds;
        }

        #endregion

        #endregion

    }
}
