using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Iesi.Collections.Generic;
namespace DataDriver
{
    public class Cat
    {
        public Cat() 
        {
            Gender = String.Empty;
        }
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual Owner MyOwner { get; set; }
        public virtual string Gender { get; set; }
        public Iesi.Collections.Generic.ISet<Meal> _meals = new HashedSet<Meal>();
        public Iesi.Collections.Generic.ISet<Nom> _nomsICanEat = new HashedSet<Nom>();
        public Weight CurrentWeight { get; set; }

        public virtual Iesi.Collections.Generic.ISet<Meal> MyMeals
        {
            get { return _meals; }
            set { _meals = value; }
        }

        public virtual Iesi.Collections.Generic.ISet<Nom> NomsICanEat
        {
            get { return _nomsICanEat; }
            set { _nomsICanEat = value; }
        }

        public bool DietIsRestricted
        { get { return _nomsICanEat.Count > 0; } }

        public IList<Nom> NomsAsList
        {
            get
            {
                IList<Nom> noms = new List<Nom>();
                foreach (Nom nom in NomsICanEat) noms.Add(nom);
                return noms;
            }
        }

        public double IWeigh 
        { 
            get 
            {
                double weight = double.MinValue;
                if (Equals(null, CurrentWeight)) return 0;
                if (Double.TryParse(CurrentWeight.Pounds.ToString(), out weight))
                    return weight;
                return 0; 
            } 
        }

        public string Age
        {
            get
            {
                return CalculateAge(System.DateTime.Now);
            }
        }

        public bool IsFemale
        {
            get 
            { 
                return 0 == String.Compare(Gender, "F", true); 
            }
            set 
            { 
                Gender = value ? "F" : "M"; 
            }
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", Name, Age);
        }

        public int CompareTo(Cat other)
        {
            if (Equals(null, other)) return 1;
            if (this.BirthDate > other.BirthDate) return -1;
            if (this.BirthDate < other.BirthDate) return 1;
            return String.Compare(this.Name, other.Name, true);
        }

        public void AdoptMe(Owner newOwner)
        {
            MyOwner = newOwner;
            newOwner.MyCats.Add(this);
        }

        public void FeedMe(Meal meal)
        {
            _meals.Add(meal);
            meal.MyCat = this;
        }

        private string CalculateAge(DateTime now)
        {
            if (Equals(null, BirthDate)) return "Unknown";
            if (BirthDate.Year < now.Year - 30) return "Unknown";
            TimeSpan diff = now - BirthDate;
            if (diff.Days < 7)
                return String.Format("{0} Days", diff.Days);
            if (diff.Days / 7 <= 12)
                return String.Format("{0} Weeks", diff.Days / 7);
            if (diff.Days / 30 < 12)
                return String.Format("{0} Months", diff.Days / 30);
            return String.Format("{0} Years", diff.Days / 365);
        }
    }
}
