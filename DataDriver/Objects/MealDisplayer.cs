using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DataDriver.Objects;

namespace DataDriver
{
    public class MealDisplayer : IComparable<MealDisplayer>
    {
        public string CatName
        {
            get
            {
                if (Equals(null, _nom)) return string.Empty;
                return _nom.CatName;
            }
        }

        public string FoodName 
        {
            get
            {
                if (Equals(null, _nom)) return String.Empty;
                return _nom.FoodName;
            }
        }

        public DateTime Time
        {
            get
            {
                if (Equals(null, _nom)) return DateTime.Now;
                return _nom.MealTime;
            }
        }

        public double Grams
        {
            get
            {
                if (Equals(null, _nom)) return 0;
                return _nom.Grams;
            }
        }

        private NomsThisMeal _nom = null;

        public MealDisplayer()
        {
        }

        public MealDisplayer(NomsThisMeal noms)
        {
            _nom = noms;
        }

        #region IComparable<MealDisplayer> Members

        public int CompareTo(MealDisplayer other)
        {
            int current = String.Compare(this.CatName, other.CatName, true);
            if (current != 0) return current;
            current = DateTime.Compare(this.Time, other.Time);
            if (current != 0) return current;
            current = String.Compare(this.FoodName, other.FoodName);
            if (current != 0) return current;
            return this.Grams.CompareTo(other.Grams);
        }

        #endregion
    }
}
