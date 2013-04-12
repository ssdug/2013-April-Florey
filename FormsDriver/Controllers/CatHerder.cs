using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DataDriver;
using DataDriver.Objects;
using FormsDriver.Forms;
using NHibernateWrapper;

using Iesi.Collections.Generic;
using NHibernate;

namespace FormsDriver.Controllers
{

    public delegate void NewCatsAvailableHandler(object sender);
    public delegate void NewNomAvailableHandler(object sender, Nom newNom);
    public delegate void CatDietChangedHandler(object sender, List<Nom> newDiet);

    public class CatHerder
    {
        public event NewCatsAvailableHandler OnNewCatsAvailable;
        public event NewNomAvailableHandler OnNewNomAvailable;
        public event CatDietChangedHandler OnCatDietChanged;

        public List<Cat> Cats { get; set; }
        private Cat _catInProgress = null;
        private CatsModel _model = null;
        private string _ownerNameInProgress = null;
        private List<Nom> _dietInProgress = null;

        public CatHerder()
        {
            _model = new CatsModel();
            try
            {
                Cats = _model.GetCats();
                Cats.Sort((catA, catB) =>
                    catA.CompareTo(catB));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }

        }

        public void HerdCats()
        {
            StartHere dlg = new StartHere(this);
            dlg.ShowDialog();
        }

        public Owner GetOwner(Cat inCat)
        {
            Owner owner = new Owner
            {
                Name = _model.DefaultOwnerName,
            };
            if (Equals(null, inCat)) return owner;
            return _model.GetOwner(inCat);
        }

        public bool IsAdoptable(Cat inCat)
        {
            var owners =
                from cat in Cats
                where cat.Id == inCat.Id
                select cat.MyOwner
                ;
            if (owners.Count<Owner>() > 0)
                return Equals(null, owners.ElementAt<Owner>(0));
            return true;
        }

        public List<Cat> GetSiblings(Cat cat)
        {
            List<Cat> cats = new List<Cat>();
            if (Equals(null, _model) ||
                Equals(null, cat) ||
                Equals(null, cat.MyOwner)) return cats;           
            return _model.GetOwnerCats(cat.MyOwner.Id);
        }

        public IEnumerable<Nom> GetNoms()
        {
            if (Equals(null, _model)) return new List<Nom>();
            return _model.GetAll<Nom>();
        }

        public IList<Nom> GetNomsAsList()
        {
            List<Nom> nomsList = new List<Nom>();
            foreach (Nom nom in GetNoms()) 
                nomsList.Add(nom);
            nomsList.Sort((nomA, nomB) => nomA.CompareTo(nomB));
            return nomsList;
        }

        public bool IsValidNom(string nomName)
        {
            if (Equals(null, _model)) return false;
            Nom nom = _model.GetNom(nomName);
            return !Equals(null, nom);
        }

        public bool ValidateNomName(string nomName)
        {
            if (Equals(null, _model)) return false;
            Nom nom = _model.GetNom(nomName);
            if (!Equals(null, nom)) return true;
            nom = new Nom
            {
                Name = nomName
            };
            NomProperties dlg = new NomProperties(nom);
            if (DialogResult.OK == dlg.ShowDialog())
            {
                // Now store the new nom
                _model.SaveObject<Nom>(nom);
                if (!Equals(null, OnNewNomAvailable))
                    OnNewNomAvailable(this, nom);
                return true;
            }
            return false;
        }

        public void FeedACat(Cat cat)
        {
            _catInProgress = cat;
            Meal meal = new Meal
            {
                MyCat = cat,
                Time = System.DateTime.Now
            };
            MealTime dlg = new MealTime(this, meal);
            string result = String.Empty;
            MessageBoxIcon icon = MessageBoxIcon.None;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                result = "Yum!";
                icon = MessageBoxIcon.Exclamation;
                SaveAMeal(dlg.MyMeal, _catInProgress);
            }
            else
            {
                result = "Yuck!";
                icon = MessageBoxIcon.Question;
            }
            MessageBox.Show(result, "Feed Me", MessageBoxButtons.OK, icon, MessageBoxDefaultButton.Button1);
        }

        public void UpdateANom(Nom nom)
        {
            if (Equals(null, nom) ||
                Equals(null, _model)) return;
            _model.SaveObject<Nom>(nom);
        }

        public void SaveAMeal(Meal meal, Cat cat)
        {
            if (Equals(null, _model)) return;
            meal.MyCat = cat;
            meal.Time = System.DateTime.Now;
            foreach (NomsThisMeal nom in meal.Noms)
                _model.SaveObject<NomsThisMeal>(nom);
            _model.SaveObject<Meal>(meal);            
        }

        public void WeighACat(Cat cat)
        {
            if (Equals(null, _model)) return;
            _model.GetCurrentWeight(cat);
            if (Equals(null, cat.CurrentWeight))
            {
                cat.CurrentWeight = new Weight();
                cat.CurrentWeight.CatKey = cat.Id;
            }
            Weight newWeight = new Weight(cat.CurrentWeight);
            WeighACatNoBindings(cat, newWeight);
            WeighACatWithBindings(cat, newWeight);
        }

        private void WeighACatNoBindings(Cat cat, Weight weight)
        {
            Scale dlg = new Scale(weight.Pounds, weight.Date);
            if (DialogResult.OK == dlg.ShowDialog())
            {
                weight.Pounds = dlg.Pounds;
                weight.Date = dlg.WeighDate;
                _model.SaveObject<Weight>(weight);
                cat.CurrentWeight = weight;
            }
        }

        private void WeighACatWithBindings(Cat cat, Weight weight)
        {
            Scale dlg = new Scale(weight);
            if (DialogResult.OK == dlg.ShowDialog())
            {
                _model.SaveObject<Weight>(weight);
                cat.CurrentWeight = weight;
            }
        }

        public void AdoptACat(Cat cat)
        {
            if (Equals(null, _model)) return;
            if (!IsAdoptable(cat)) return;
            SelectOwner dlg = new SelectOwner(this, false);
            if (DialogResult.OK == dlg.ShowDialog() && 0 < _ownerNameInProgress.Length)
            {
                IEnumerable<Owner> allOwners = _model.GetAll<Owner>();
                var owners =
                    from owner in allOwners
                    where 0 == String.Compare(owner.Name, _ownerNameInProgress, true)
                    select owner;
                if (owners.Count<Owner>() > 0)
                {
                    cat.MyOwner = owners.ElementAt<Owner>(0);
                    _model.SaveObject<Cat>(cat);
                }
            }
        }

        public List<String> OwnerNames
        {
            get
            {
                List<String> names = new List<string>();
                if (Equals(null, _model)) return names;
                IEnumerable<Owner> owners = _model.GetAll<Owner>();
                names.AddRange(
                    from owner in owners
                    select owner.Name);
                return names;
            }
        }

        public bool ValidateOwner(string name)
        {
            _ownerNameInProgress = name;
            if (OwnerNames.Any(s => s.Equals(name, StringComparison.OrdinalIgnoreCase)))
                return true;
            DialogResult createOwner =
                MessageBox.Show(String.Format("{0} is not a recognized owner. \nDo you want to create a new owner?",
                name), "Adopt A Cat", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button1);
            if (DialogResult.Yes == createOwner)
            {
                Owner owner = new Owner(name);
                _model.SaveObject<Owner>(owner);
                return true;
            }
            else
                _ownerNameInProgress = String.Empty;
            return false;
        }

        public void CreateACat()
        {
            if (Equals(null, _model)) return;
            Cat cat = new Cat();
            CatProperties dlg = new CatProperties(cat);
            if (DialogResult.OK == dlg.ShowDialog())
            {
                _model.SaveObject<Cat>(cat);
                // Refresh the cats list
                Cats.Add(cat);
                Cats.Sort((catA, catB) =>
                    catA.CompareTo(catB));
            }
            if (!Equals(null, OnNewCatsAvailable))
                OnNewCatsAvailable(this);
        }

        public void AddNomToMeal(Meal meal, Nom nom, double grams)
        {
            if (Equals(null, meal) ||
                Equals(null, nom)) return;
            if (0 == meal.Id) _model.SaveObject<Meal>(meal);
            meal.AddNom(nom, grams);
        }

        public void CreateAnOwner()
        {
            SelectOwner dlg = new SelectOwner(this, true);
            if (OwnerNames.Any(s => s.Equals(dlg.OwnerName, StringComparison.OrdinalIgnoreCase)))
                return;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                _model.SaveObject<Owner>(
                    new Owner
                    {
                        Name = dlg.OwnerName
                    });
            }
        }

        public void ModifyDiet(Cat cat)
        {
            if (Equals(null, _model)) return;
            _dietInProgress = new List<Nom>(cat.NomsAsList);
            Diet dlg = new Diet(this, cat, _dietInProgress);
            try
            {
                if (DialogResult.OK == dlg.ShowDialog())
                {
                    cat.NomsICanEat.Clear();
                    foreach (Nom nom in _dietInProgress)
                        cat.NomsICanEat.Add(nom);
                    _model.SaveObject<Cat>(cat);
                }
            }
            finally
            {
                dlg.Close();
            }          
        }

        public void AddNomToDiet(string nomName)
        {
            if (Equals(null, _model)) return;
            Nom nom = _model.GetNom(nomName);
            if (Equals(null, nom)) return;
            _dietInProgress.Add(nom);
            if (!Equals(null, OnCatDietChanged))
                OnCatDietChanged(this, _dietInProgress);
        }

        public void RemoveNomFromDiet(Nom nom)
        {
            _dietInProgress.Remove(nom);
            //if (!Equals(null, OnCatDietChanged))
            //    OnCatDietChanged(this, _dietInProgress);
        }
    }
}
