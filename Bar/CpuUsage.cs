using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Bar
{
    class CpuUsage : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string usage;
        private PerformanceCounter counter;

        public CpuUsage()
        {
            counter = new PerformanceCounter("Processor", "% Processor Time", "_Total", ".");
        }

        public string UsageString
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
            UsageString = counter.NextValue().ToString("F0") + " %";
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
