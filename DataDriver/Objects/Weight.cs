using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace DataDriver
{
    public class Weight : INotifyPropertyChanged
    {
        public virtual decimal Pounds { get; set; }
        public virtual int Id { get; set; }
        public virtual DateTime Date { get; set; }
        public virtual int CatKey { get; set; }

        public override string ToString()
        {
            return Pounds.ToString();
        }

        public Weight() 
        {
            Date = DateTime.Now;
        }

        public Weight(Weight weight)
        {
            Pounds = weight.Pounds;
            Id = 0;
            Date = weight.Date;
            CatKey = weight.CatKey;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        private void NotifyPropertyChanged(string propertyName = "")
        {
            if (!Equals(null, PropertyChanged))
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
