using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Iesi.Collections.Generic;
using NHibernate;
using NHibernateWrapper;

using DataDriver.Objects;

namespace DataDriver
{


    public class Meal
    {
        public virtual int Id { get; set; }
        public virtual DateTime Time { get; set; }
        public virtual Cat MyCat { get; set; }
        public Iesi.Collections.Generic.ISet<NomsThisMeal> _noms = new HashedSet<NomsThisMeal>();

        public Iesi.Collections.Generic.ISet<NomsThisMeal> Noms
        {
            get { return _noms; }
            set { _noms = value; }
        }


        public Meal() 
        { }


        public override string ToString()
        {
            if (!Equals(null, MyCat)) return MyCat.Name;
            return String.Empty;
        }

        public void AddNom(Nom nom, double grams)
        {
            foreach (NomsThisMeal test in _noms)
            {
                if (test.NomType.Id == nom.Id)
                {
                    test.Grams += grams;
                    return;
                }
            }
            NomsThisMeal newNom = new NomsThisMeal
            {
                MyMeal = this,
                NomType = nom,
                Grams = grams
            };
            _noms.Add(newNom);
        }

        public List<MealDisplayer> GetMealDisplays()
        {
            List<MealDisplayer> displayers = new List<MealDisplayer>();
            foreach (NomsThisMeal noms in _noms)
                displayers.Add(new MealDisplayer(noms));
            return displayers;
        }
    }
}
