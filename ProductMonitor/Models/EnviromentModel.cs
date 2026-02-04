using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ProductMonitor.Models
{
    public class EnviromentModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // 輔助方法：發送通知
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string _enItemName;
        public string EnItemName
        {
            get { return _enItemName; }
            set
            {
                if (_enItemName != value)
                {
                    _enItemName = value;
                    OnPropertyChanged("EnItemName");
                }
            }
        }

        private int _enItemValue;
        public int EnItemValue
        {
            get { return _enItemValue; }
            set
            {
                if (_enItemValue != value)
                {
                    _enItemValue = value;
                    OnPropertyChanged("EnItemValue");
                }
            }
        }
    }
}
