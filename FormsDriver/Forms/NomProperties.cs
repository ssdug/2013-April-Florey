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
    public partial class NomProperties : Form
    {
        private Nom _nom = null;

        private NomProperties()
        {
            InitializeComponent();
        }

        public NomProperties(Nom nom)
        {
            _nom = nom;
            InitializeComponent();
        }

        private void BindNewNom()
        {
            _enterName.DataBindings.Add(new Binding("Text", _nom, "Name"));
            _enterCalories.DataBindings.Add(new Binding("Text", _nom, "CaloriesPerGram"));
            _gushy.DataBindings.Add(new Binding("Checked", _nom, "Gushy"));
        }

        private void NomProperties_Load(object sender, EventArgs e)
        {
            BindNewNom();
        }

        private void _updateNom_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void _enterCalories_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entry = e.KeyChar;
            if (Char.IsDigit(entry) || entry == '.')
                e.Handled = false;
            else
                e.Handled = 8 != Convert.ToInt16(entry);
            base.OnKeyPress(e);
        }
    }
}
