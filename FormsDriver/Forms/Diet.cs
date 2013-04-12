using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using FormsDriver.Controllers;
using DataDriver;

namespace FormsDriver.Forms
{
    public partial class Diet : Form
    {
        private CatHerder _controller = null;
        private Cat _cat = null;
        private List<Nom> _dietInProgress = null;
        private Nom _deletedNom = null;

        private Diet()
        {
            InitializeComponent();
        }

        public Diet(CatHerder controller, Cat cat, List<Nom> currentDiet)
        {
            _controller = controller;
            _cat = cat;
            _dietInProgress = currentDiet;
            InitializeComponent();
        }

        private void Diet_Load(object sender, EventArgs e)
        {
            if (Equals(null, _controller) ||
                Equals(null, _cat)) return;
            _nameValue.DataBindings.Add("Text", _cat, "Name");
            _selectNom.DataSource = new BindingList<Nom>(_controller.GetNomsAsList());
            if (!Equals(null, _dietInProgress))
                _nomsSelected.DataSource = new BindingList<Nom>(_dietInProgress);
            else
                _nomsSelected.DataSource = new BindingList<Nom>();
            _controller.OnNewNomAvailable += new NewNomAvailableHandler(_controller_OnNewNomAvailable);
            _controller.OnCatDietChanged += new CatDietChangedHandler(_controller_OnCatDietChanged);
        }

        void _controller_OnCatDietChanged(object sender, List<Nom> newDiet)
        {
            RefreshNoms(newDiet);
        }

        void _controller_OnNewNomAvailable(object sender, Nom newNom)
        {
            AddANom(newNom);
        }

        private void AddANom(Nom nom)
        {
            List<Nom> sortedNoms = (_selectNom.DataSource as BindingList<Nom>).ToList<Nom>();
            sortedNoms.Add(nom);
            sortedNoms.Sort((nomA, nomB) => nomA.CompareTo(nomB));
            _selectNom.DataSource = new BindingList<Nom>(sortedNoms);
        }

        private void _selectNom_Validating(object sender, CancelEventArgs e)
        {
            if (0 != _selectNom.Text.Length)
            {
                if (_controller.ValidateNomName(_selectNom.Text))
                {
                    _controller.AddNomToDiet(_selectNom.Text);
                }
                else
                {
                    _ok.Enabled = false;
                    _selectNom.Text = String.Empty;
                    e.Cancel = true;
                }
            }
        }

        private void _ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void RefreshNoms(List<Nom> newNoms)
        {
            BindingList<Nom> knownNoms = (BindingList<Nom>)_nomsSelected.DataSource;
            foreach (Nom nom in newNoms)
            {
                if (!knownNoms.Any<Nom>(item => 0 == item.CompareTo(nom)))
                    knownNoms.Add(nom);
            }
            knownNoms.ResetBindings();
        }

        private void _nomsSelected_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            Debug.WriteLine(((BindingList<Nom>)_nomsSelected.DataSource).Count);
            _deletedNom = e.Row.DataBoundItem as Nom;
        }

        private void _nomsSelected_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (!Equals(null, _deletedNom))
                _controller.RemoveNomFromDiet(_deletedNom);
        }
    }
}
