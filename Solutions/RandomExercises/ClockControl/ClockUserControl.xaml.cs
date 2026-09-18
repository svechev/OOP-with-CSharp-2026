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

namespace ClockControl
{
    /// <summary>
    /// Interaction logic for ClockUserControl.xaml
    /// </summary>
    public partial class ClockUserControl : UserControl
    {
        bool suspended = true;

        public int ClockSecond
        {
            get {
                string text = txtDigital.Text;
                int second = int.Parse(text.Substring(text.Length - 2));
                return second;
            }
        }

        public ClockUserControl()
        {
            InitializeComponent();

            Thread thread = new Thread(UpdateTimer);
            thread.Start();
        }

        private void UpdateTimer(object? obj)
        {
            while (true)
            {
                Thread.Sleep(1000);

                lock (this)
                {
                    while (suspended)
                    {
                        Monitor.Wait(this);
                    }
                }

                Dispatcher.Invoke(new Action(() => {
                    int hour = DateTime.Now.Hour;
                    int minute = DateTime.Now.Minute;
                    int second = DateTime.Now.Second;
                    txtDigital.Text = $"{hour:D2}:{minute:D2}:{second:D2}";
                }));
            }

        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            if (suspended)
            {
                lock (this)
                {
                    suspended = false;
                    Monitor.PulseAll(this);
                }
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            suspended = true;
        }
    }
}
