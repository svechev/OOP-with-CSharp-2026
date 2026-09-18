using System;
using System.Collections.Generic;
using System.Data;
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

namespace Problem1Lab13a
{
    /// <summary>
    /// Interaction logic for ClockUserControl.xaml
    /// </summary>
    public partial class ClockUserControl : UserControl
    {
        private bool suspended = false;

        public ClockUserControl()
        {
            InitializeComponent();
            Thread thread = new Thread(TicTac);
            thread.Start();
        }

        private void TicTac(object? obj)
        {
            while (true)
            {
                // Thread.Sleep(1000);
                Task.Delay(1000).Wait(); // both work

                lock (this)
                {
                    while (suspended) // Monitor wait must ALWAYS be in a WHILE
                    {
                        Monitor.Wait(this); // this method must be in a lock
                    }
                }
                SetClockTime();
            }
        }

        /// <summary>
        /// Executes in a thread different from the event dispatcher thread
        /// </summary>
        private void SetClockTime()
        {
            if (hourHand == null || minuteHand == null || secondHand == null) return;
            try
            {
                // use BeginInvoke for asynchronous operations 
                // use Invoke for synchronous operations
                this.Dispatcher.BeginInvoke(new Action(() =>
                {
                    var hour = DateTime.Now.Hour;
                    var minute = DateTime.Now.Minute;
                    var second = DateTime.Now.Second;

                    hourHand.Angle = hour * 30 + minute * 0.5;
                    minuteHand.Angle = minute * 6;
                    secondHand.Angle = second * 6;
                }));
            }
            catch (TaskCanceledException)
            {
                MessageBox.Show("Operation cancelled...");
                Environment.Exit(1);
            }
        }

        /// <summary>
        /// to be executed in the event dispatcher thread
        /// </summary>
        public void StopClock() // suspend
        {
            suspended = true;
        }

        /// <summary>
        /// to be executed in the event dispatcher thread
        /// </summary>
        public void StartClock() // resume
        {
            lock (this)
            {
                if (suspended)
                {
                    suspended = false;
                    Monitor.PulseAll(this); // this method must be in a lock
                }
            }
        }
    }
}
