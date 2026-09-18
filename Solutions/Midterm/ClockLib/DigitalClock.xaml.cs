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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ClockLib
{
    /// <summary>
    /// Interaction logic for DigitalClock.xaml
    /// </summary>
    public partial class DigitalClock : UserControl
    {
        private DispatcherTimer timer;

        public event EventHandler ClockStarted;
        public event EventHandler TimeUpdated;


        public DigitalClock()
        {
            InitializeComponent();
            txtDigital.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += UpdateTimer!;
            timer.Start();
            ClockStarted?.Invoke(this, new ClockTickArgs(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second));
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtDigital.Text = "";
        }

        private void UpdateTimer(object sender, EventArgs e)
        {
            txtDigital.Text = string.Format("{0:D2}:{1:D2}:{2:D2}", DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
            TimeUpdated?.Invoke(this, new ClockTickArgs(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second));
        }
    }
}
