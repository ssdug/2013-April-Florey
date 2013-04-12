using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DataDriver;
using NHibernateWrapper;
using FormsDriver.Controllers;

using FormsDriver.Forms;

namespace FormsDriver
{
    public partial class StartHere : Form
    {
        private CatHerder _catHerder;
        public StartHere()
        {
            InitializeComponent();
        }

        public StartHere(CatHerder controller)
        {
            _catHerder = controller;
            InitializeComponent();
        }

        private void _close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _clickMe_Click(object sender, EventArgs e)
        {
            List<Cat> cats = _catHerder.GetSiblings(_catsList.SelectedItem as Cat);
            if (cats.Count == 0) return;
            richTextBox1.Text = String.Empty;
            foreach (Cat cat in cats)
                richTextBox1.Text = richTextBox1.Text + cat.ToString() + "\n";
        }

        private void StartHere_Load(object sender, EventArgs e)
        {
            if (Equals(null, _catHerder))
                _catHerder = new CatHerder();
            _catsList.DataSource = new BindingList<Cat>(_catHerder.Cats);
            _catHerder.OnNewCatsAvailable += new NewCatsAvailableHandler(_catHerder_OnNewCatsAvailable);
        }

        void _catHerder_OnNewCatsAvailable(object sender)
        {
            _catsList.DataSource = new BindingList<Cat>(_catHerder.Cats);
            _catsList.Refresh();
        }

        private void _catsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cat cat = _catsList.SelectedItem as Cat;
            _adoptMe.Enabled = _catHerder.IsAdoptable(cat);
            if (_adoptMe.Enabled)
                _ownerText.Text = String.Empty;
            else
                _ownerText.Text = _catHerder.GetOwner(cat).Name;

        }

        private void _feedMe_Click(object sender, EventArgs e)
        {
            _catHerder.FeedACat(_catsList.SelectedItem as Cat);
        }

        private void _weighMe_Click(object sender, EventArgs e)
        {
            _catHerder.WeighACat(_catsList.SelectedItem as Cat);
        }

        private void _adoptMe_Click(object sender, EventArgs e)
        {
            _catHerder.AdoptACat(_catsList.SelectedItem as Cat);
        }

        private void _newCat_Click(object sender, EventArgs e)
        {
            _catHerder.CreateACat();
        }

        private void _feedMeMenu_Click(object sender, EventArgs e)
        {
            _catHerder.FeedACat(_catsList.SelectedItem as Cat);
        }

        private void _newOwner_Click(object sender, EventArgs e)
        {
            _catHerder.CreateAnOwner();
        }

        private void _modifyDiet_Click(object sender, EventArgs e)
        {
            _catHerder.ModifyDiet(_catsList.SelectedItem as Cat);
        }

    }
}
