using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSliderButtonDemo.ViewModel
{
    public class MainViewModel : System.ComponentModel.INotifyPropertyChanged
    {
        private bool _enabled = false;
        public bool IsEnabled
        {
            get
            {
                return _enabled;
            }
            set
            {
                _enabled = value;
                NotifyPropertyChanged(nameof(IsEnabled));
            }
        }

        #region System.ComponentModel.INotifyPropertyChanged

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
 
                PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
 
        }

        #endregion System.ComponentModel.INotifyPropertyChanged
    }
}
