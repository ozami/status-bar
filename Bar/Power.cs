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
        private string mode;

        public Power()
        {
            Microsoft.Win32.SystemEvents.PowerModeChanged +=
                new Microsoft.Win32.PowerModeChangedEventHandler(OnPowerModeChanged);
            UpdatePowerMode();
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
            var status = SystemInformation.PowerStatus;
            var lifetime = status.BatteryLifeRemaining / 60.0 / 60;
            var percent = status.BatteryLifePercent * 100;
            PowerString = mode + " " + percent + "% " + lifetime.ToString("F1") + "h";
        }

        private void UpdatePowerMode()
        {
            switch (SystemInformation.PowerStatus.PowerLineStatus)
            {
                case PowerLineStatus.Offline:
                    mode = "🔋";
                    break;
                case PowerLineStatus.Online:
                    mode = "🔌";
                    break;
                case PowerLineStatus.Unknown:
                    mode = "？";
                    break;
            }
        }

        private void OnPowerModeChanged(object sender, Microsoft.Win32.PowerModeChangedEventArgs e)
        {
            UpdatePowerMode();
        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
