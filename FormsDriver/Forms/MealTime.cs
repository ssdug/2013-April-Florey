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
    public partial class MealTime : Form
    {
        private CatHerder _controller;
        private Meal _meal;
        private BindingList<MealDisplayer> _nomsThisMeal = new BindingList<MealDisplayer>();

        public Meal MyMeal { get { return _meal; } }
        private MealTime()
        {
            InitializeComponent();
        }

        public MealTime(CatHerder controller, Meal meal)
        {
            _controller = controller;
            _meal = meal;
            _controller.OnNewNomAvailable += new NewNomAvailableHandler(_controller_OnNewNomAvailable);
            InitializeComponent();
        }

        void _controller_OnNewNomAvailable(object sender, Nom newNom)
        {
            AddANom(newNom);
        }

        private void _ok_Click(object sender, EventArgs e)
        {
            if (!Equals(null, _controller))
                _controller.SaveAMeal(_meal, _meal.MyCat);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void MealTime_Load(object sender, EventArgs e)
        {
            try
            {
                if (Equals(null, _controller))
                {
                    foreach (Control control in this.Controls)
                    {
                        if (0 != String.Compare(control.Text, "Cancel", false))
                            control.Enabled = false;
                    }
                    return;
                }
                BindingList<Nom> noms = new BindingList<Nom>();
                if (_meal.MyCat.DietIsRestricted)
                {
                    foreach (Nom nom in _meal.MyCat.NomsAsList)
                        noms.Add(nom);
                    _selectNom.DropDownStyle = ComboBoxStyle.DropDownList;
                }
                else
                {
                    foreach (Nom nom in _controller.GetNoms())
                        noms.Add(nom);
                    _selectNom.DropDownStyle = ComboBoxStyle.DropDown;
                }
                _selectNom.DataSource = noms;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
        }

        private void _selectNom_Validating(object sender, CancelEventArgs e)
        {
            if (0 != _selectNom.Text.Length)
            {
                if (_controller.ValidateNomName(_selectNom.Text))
                {
                    _ok.Enabled = true;
                }
                else
                {
                    _ok.Enabled = false;
                    _selectNom.Text = String.Empty;
                    e.Cancel = true;
                }
            }
        }


        private void _enterGrams_KeyPress(object sender, KeyPressEventArgs e)
        {
            char entry = e.KeyChar;
            if (Char.IsDigit(entry) || entry == '.')
                e.Handled = false;
            else
                e.Handled = 8 != Convert.ToInt16(entry);
            base.OnKeyPress(e);
        }

        private void _updateNom_Click(object sender, EventArgs e)
        {
            _controller.UpdateANom(_selectNom.SelectedItem as Nom);
        }

        private void AddANom(Nom nom)
        {
            List<Nom> sortedNoms = (_selectNom.DataSource as BindingList<Nom>).ToList<Nom>();
            sortedNoms.Add(nom);
            sortedNoms.Sort((nomA, nomB) => nomA.CompareTo(nomB));
            _selectNom.DataSource = new BindingList<Nom>(sortedNoms);
        }

        private void _addNom_Click(object sender, EventArgs e)
        {
            double grams;
            if (Double.TryParse(_enterGrams.Text, out grams))
            {
                _controller.AddNomToMeal(_meal, _selectNom.SelectedItem as Nom, grams);
                UpdateNomsList();
            }
        }

        private void UpdateNomsList()
        {
            if (Equals(null, _meal)) return;
            bool refresh = _nomsThisMeal.RaiseListChangedEvents;
            _nomsThisMeal.RaiseListChangedEvents = false;
            _nomsThisMeal.Clear();
            foreach (MealDisplayer displayer in _meal.GetMealDisplays())
                _nomsThisMeal.Add(displayer);
            _nomsThisMeal.RaiseListChangedEvents = true;
            _nomsView.DataSource = _nomsThisMeal;
        }
    }
}
