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
        public event EventHandler? ClockStarted;
        public event EventHandler? TimeUpdated;

        public DigitalClock()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += UpdateTimer!;
        }

        private void UpdateTimer(object? sender, EventArgs e)
        {
            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            int second = DateTime.Now.Second;

            txtDigital.Text = $"{hour:D2}:{minute:D2}:{second:D2}";
            TimeUpdated?.Invoke(this, new ClockTickArgs((hour, minute, second)));
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();

            int hour = DateTime.Now.Hour;
            int minute = DateTime.Now.Minute;
            int second = DateTime.Now.Second;

            ClockStarted?.Invoke(this, new ClockTickArgs((hour, minute, second)));
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            txtDigital.Text = "";
        }
    }
}
