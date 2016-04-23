using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Bar
{
    /// <summary>
    /// StatusBar.xaml の相互作用ロジック
    /// </summary>
    public partial class StatusBar : Window
    {
        Clock clock;

        public StatusBar()
        {
            InitializeComponent();
            clock = new Clock();
            DataContext = clock;

        }
        //protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        //{
        //    base.OnMouseLeftButtonDown(e);
        //    DragMove();
        //}
    }
}
