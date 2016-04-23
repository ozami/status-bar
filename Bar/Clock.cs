using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Bar
{
    class Clock : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string time;
        private Timer timer;

        public Clock()
        {
            time = "";
            timer = new Timer(new TimerCallback(Update));
            timer.Change(0, 1000);
        }

        public void Update(object args)
        {
            TimeString = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
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
