using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataDriver.Objects
{
    public class NomsThisMeal
    {
        public virtual int Id { get; set; }
        public virtual Meal MyMeal { get; set; }
        public virtual Nom NomType { get; set; }
        public virtual double Grams { get; set; }

        public string CatName
        {
            get
            {
                if (Equals(null, MyMeal) ||
                    Equals(null, MyMeal.MyCat)) return String.Empty;
                return MyMeal.MyCat.Name;
            }
        }

        public string FoodName
        {
            get
            {
                if (Equals(null, NomType)) return String.Empty;
                return NomType.Name;
            }
        }

        public DateTime MealTime
        {
            get
            {
                if (Equals(null, MyMeal)) return System.DateTime.Now;
                return MyMeal.Time;
            }
        }
    }
}
