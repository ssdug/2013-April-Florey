using System;
//using System.Collections.Generic;
using System.Linq;
using System.Text;

using Iesi.Collections.Generic;

namespace DataDriver
{
    public class Owner
    {
        public Owner()
        { Name = Properties.Settings.Default.DefaultOwnerName; }

        public Owner(string name)
        { Name = name; }

        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual bool IsShelter { get; set; }
        public ISet<Cat> _myCats = new HashedSet<Cat>();

        public ISet<Cat> MyCats
        {
            get { return _myCats; }
            set { _myCats = value; }
        }

        public int NumCats
        {
            get
            {
                if (Equals(null, _myCats)) return 0;
                return _myCats.Count;
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
