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
            time = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
            timer = new Timer(new TimerCallback(Update));
            timer.Change(0, 2000);
        }

        public void Update(object args)
        {
            TimeString = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public string TimeString
        {
            get
            {
                return time;
            }

            set
            {
                time = value;
                NotifyPropertyChanged();
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
