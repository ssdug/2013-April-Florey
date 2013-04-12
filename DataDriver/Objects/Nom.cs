using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataDriver
{
    public class Nom
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual double CaloriesPerGram { get; set; }
        public virtual bool Gushy { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public int CompareTo(Nom other)
        {
            int result = String.Compare(this.Name, other.Name, true);
            if (0 == result)
                result = this.CaloriesPerGram.CompareTo(other.CaloriesPerGram);
            if (0 == result)
                result = this.Gushy.CompareTo(other.Gushy);
            return result;
        }
    }
}
