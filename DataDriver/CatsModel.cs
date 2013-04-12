using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using NHibernate;
using NHibernateWrapper;

namespace DataDriver
{
    public class CatsModel
    {
        private ISession _session;

        public CatsModel()
        {
            _session = MySessionFactory.Instance.GetSession();
        }

        public CatsModel(ISession session)
        {
            _session = session;
        }

        public string DefaultOwnerName
        { get { return Properties.Settings.Default.DefaultOwnerName; } }

        public List<Cat> GetCats()
        {
            List<Cat> cats = new List<Cat>();
            if (Equals(null, _session)) return cats;
            try
            {
                cats.AddRange(
                                    from cat in NHibernateTest.Load<Cat>(String.Empty, _session).Cast<Cat>()
                                    where cat.Id >= 0
                                    select cat)
                ;
            }
            catch (Exception ex)
            {
                cats = new List<Cat>();
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
            return cats;
        }

        public Owner GetOwner(Cat inCat)
        {
            Owner owner = new Owner
            {
                Name = DefaultOwnerName,
            };
            if (Equals(null, _session) ||
                Equals(null, inCat)) return owner;
            try
            {
                List<Owner> owners = new List<DataDriver.Owner>(
                                  from cat in NHibernateTest.Load<Cat>(
                                  String.Format("FROM Cat WHERE CatKey={0}", inCat.Id), _session).Cast<Cat>()
                                  select cat.MyOwner)
                ;
                if (owners.Count > 0)
                    return owners[0];
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                Debug.WriteLine(ex.StackTrace);
            }
            return owner;
        }

        public Owner GetOwner(string ownerName)
        {
            List<Owner> owners = new List<Owner>(
                from owner in NHibernateTest.Load<Owner>(
                String.Format("FROM Owner WHERE Name = {0}", ownerName), _session).Cast<Owner>()
                select owner);
            if (1 == owners.Count)
                return owners[0];
            if (0 == owners.Count)
            {
                Owner owner = new Owner(ownerName);
                SaveObject<Owner>(owner);
                return owner;
            }
            return null;
        }

        public List<Cat> GetOwnerCats(int ownerId)
        {
            List<Cat> cats = new List<Cat>();
            if (Equals(null, _session)) return cats;
            Owner owner =
                (from test in NHibernateTest.Load<Owner>(
                 String.Format("FROM Owner WHERE OwnerKey={0}", ownerId), _session).Cast<Owner>()
                 select test).First<Owner>();

            if (Equals(null, owner)) return cats;
            foreach (Cat aCat in owner.MyCats)
            {
                GetCurrentWeight(aCat);
                cats.Add(aCat);
            }
            return cats;
        }

        public void GetCurrentWeight(Cat cat)
        {
            if (Equals(null, _session)) return;
            var weights =
                 from weight in
                     NHibernateTest.Load<Weight>(
                     String.Format("FROM Weight WHERE CatKey = {0} ORDER BY Date desc", cat.Id), _session).Cast<Weight>()
                 select weight;
            if (weights.Count<Weight>() > 0)
            {
                cat.CurrentWeight = weights.ElementAt<Weight>(0);
            }
        }

        public void SaveObject<T>(T t) where T : class
        {
            if (Equals(null, _session) ||
                Equals(null, t)) return;
            NHibernateTest.Save<T>(t, _session);
        }

        public IEnumerable<Meal> GetMeals(Cat cat)
        {
            if (Equals(null, _session)) return new List<Meal>();
            return
                 from meal in
                     NHibernateTest.Load<Meal>(
                     String.Format("FROM Meal WHERE CatKey = {0}", cat.Id.ToString()), _session).Cast<Meal>()
                 select meal;
        }

        public Nom GetNom(string nomName)
        {
            if (Equals(null, _session)) return null;
            return GetNom(String.Format("FROM Nom WHERE Name='{0}'", nomName), _session);
        }

        public Nom GetNom(int nomKey)
        {
            if (Equals(null, _session)) return null;
            return GetNom(String.Format("FROM Nom WHERE NomKey={0}", nomKey), _session);
        }

        private Nom GetNom(string query, ISession session)
        {
            IEnumerable<Nom> noms =
               from test in NHibernateTest.Load<Nom>(query,
                _session).Cast<Nom>()
               select test;
            if (noms.Count<Nom>() > 0)
                return noms.ElementAt<Nom>(0);
            return null;
        }

        public IEnumerable<T> GetAll<T>() where T : class
        {
            if (Equals(null, _session)) return new List<T>();
            return
                from t in NHibernateTest.Load<T>(String.Empty, _session).Cast<T>()
                select t;
        }

        
    }
}
