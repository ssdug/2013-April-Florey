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
using FormsDriver.Controllers;

namespace FormsDriver.Forms
{
    public partial class DataGridTester : Form
    {

        private BindingList<MealDisplayer> _meals;
        private BindingList<string> _names;
        private CatHerder _controller;

        public DataGridTester()
        {
            _controller = new CatHerder();
            InitializeComponent();
        }

        private void DataGridTester_Load(object sender, EventArgs e)
        {
            this._names = new BindingList<string>();
            CreateNoms();
            CreateNames();
            _selectCat.DataSource = _controller.Cats;
        }

        private void CreateNoms()
        {
            //_meals = new BindingList<MealDisplayer>();
            //_meals.Add(new MealDisplayer
            //{
            //    CatName = "Frodo",
            //    FoodName = "SO",
            //    Time = System.DateTime.Now,
            //    Grams = 9.3
            //});
            //dataGridView1.DataSource = _meals;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //_meals.Add(new MealDisplayer
            //{
            //    CatName = "Frodo",
            //    FoodName = "CD",
            //    Time = System.DateTime.Now,
            //    Grams = 7.3
            //});
            //this.Refresh();
            InsertName("Kira");
            comboBox1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateNames()
        {
            InsertName("Frodo");
            InsertName("Amelia");
            comboBox1.DataSource = _names;
        }

        private void InsertName(string name)
        {
            if (_names.Count == 0)
            {
                _names.Add(name);
                return;
            }
            int index = 0;
            while (index < _names.Count &&
                0 > String.Compare(_names.ElementAt<string>(index), name)) 
                index += 1;
            _names.Insert(index, name);
        }

        private void InsertMeal(MealDisplayer displayer)
        {
            if (0 == _meals.Count)
            {
                _meals.Add(displayer);
                return;
            }
            int index = 0;
            while (index < _meals.Count &&
                0 > displayer.CompareTo(_meals.ElementAt<MealDisplayer>(index)))
                index += 1;
            _meals.Insert(index, displayer);
        }

        private void _selectCat_Leave(object sender, EventArgs e)
        {
            if (Equals(null, _selectCat.SelectedItem))
                Debug.WriteLine("SelectedItem is null");
            else
                Debug.WriteLine(_selectCat.SelectedItem.ToString());
        }

    }

    public class CompareStrings : IComparer<string>
    {
        public int Compare(string one, string two)
        { return String.Compare(one, two); }
    }
}
