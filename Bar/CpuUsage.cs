using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Bar
{
    class CpuUsage : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int usage; // 0-5
        private PerformanceCounter counter;

        public CpuUsage()
        {
            counter = new PerformanceCounter("Processor", "% Processor Time", "_Total", ".");
        }

        public int Usage
        {
            get
            {
                return usage;
            }

            set
            {
                if (usage != value)
                {
                    usage = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public void Update()
        {
            var u = counter.NextValue();
            var level = (u + 10) / 20;
            Usage = (int)level;
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
