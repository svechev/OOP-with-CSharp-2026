using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Problem2Lab13
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool suspended = false;
        public MainWindow()
        {
            InitializeComponent();
            Thread thread = new Thread(TicTac);
            thread.Start();
        }

        private void TicTac()
        {
            while (true)
            {
                Task.Delay(1000).Wait();
                lock (this) 
                {
                    while (suspended)
                    {
                        Monitor.Wait(this);
                    }
                }
                SetClockTime();
            }
        }

        private void SetClockTime()
        {
            try
            {
                this.Dispatcher.Invoke(new Action(() => {
                    var hour = DateTime.Now.Hour;
                    var minute = DateTime.Now.Minute;
                    var second = DateTime.Now.Second;
                    TxtClock.Text = $"{hour:D2}:{minute:D2}:{second:D2}";
                }));
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Operation cancelled...");
                Environment.Exit(1);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            lock (this) { 
                if (suspended)
                {
                    suspended = false;
                    Monitor.Pulse(this);
                }
            }
        }

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {
            suspended = true;
        }
    }
}