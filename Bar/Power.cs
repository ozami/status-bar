using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Bar
{
    class Power : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private string power;
        private string status;

        public Power()
        {
            Microsoft.Win32.SystemEvents.PowerModeChanged +=
                new Microsoft.Win32.PowerModeChangedEventHandler(OnPowerModeChanged);
        }

        public string PowerString
        {
            get
            {
                return power;
            }

            set
            {
                if (power != value)
                {
                    power = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public void Update()
        {
            PowerString = status;
        }

        private void OnPowerModeChanged(object sender, Microsoft.Win32.PowerModeChangedEventArgs e)
        {
            switch (SystemInformation.PowerStatus.PowerLineStatus)
            {
                case PowerLineStatus.Offline:
                    status = "Off";
                    break;
                case PowerLineStatus.Online:
                    status = "On";
                    break;
                case PowerLineStatus.Unknown:
                    status = "Unknown";
                    break;
            }
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
