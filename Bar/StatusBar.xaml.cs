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

        public StatusBar()
        {
            InitializeComponent();
            clock = new Clock();
            cpuUsage = new CpuUsage();
            clock_label.DataContext = clock;
            cpu_label.DataContext = cpuUsage;
            timer = new Timer(new TimerCallback(Update));
            timer.Change(0, 2500);
        }

        private void Update(object args)
        {
            clock.Update();
            cpuUsage.Update();
        }

        //protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        //{
        //    base.OnMouseLeftButtonDown(e);
        //    DragMove();
        //}
    }
}
