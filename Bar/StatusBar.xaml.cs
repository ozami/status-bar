using System.Windows;
using System.Threading;

namespace Bar
{
    /// <summary>
    /// StatusBar.xaml の相互作用ロジック
    /// </summary>
    public partial class StatusBar : Window
    {
        private Timer timer;
        Clock clock;
        CpuUsage cpuUsage;
        Power power;

        public StatusBar()
        {
            InitializeComponent();
            Left = (System.Windows.SystemParameters.PrimaryScreenWidth - Width) / 2;
            clock = new Clock();
            cpuUsage = new CpuUsage();
            power = new Power();
            clock_label.DataContext = clock;
            cpu_panel.DataContext = cpuUsage;
            power_label.DataContext = power;
            timer = new Timer(new TimerCallback(Update));
            timer.Change(0, 2500);
        }

        private void Update(object args)
        {
            clock.Update();
            cpuUsage.Update();
            power.Update();
        }
        //protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        //{
        //    base.OnMouseLeftButtonDown(e);
        //    DragMove();
        //}
    }
}
