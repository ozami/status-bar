using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Bar
{
    class Clock : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string time;

        public Clock()
        {
            time = "";
        }

        public void Update()
        {
            TimeString = DateTime.Now.ToString("M/d H:mm");
        }

        public string TimeString
        {
            get
            {
                return time;
            }

            set
            {
                if (time != value) {
                    time = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
