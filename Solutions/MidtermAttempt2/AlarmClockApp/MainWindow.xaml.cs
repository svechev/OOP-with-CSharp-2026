using System.Media;
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
using ClockLib;

namespace AlarmClockApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private (int hour, int minute, int second) startTime;
        private (int hour, int minute, int second) currentTime;
        private Random rand;
        private double ringAfter;

        public MainWindow()
        {
            InitializeComponent();
            rand = new Random();

            var b = new Binding()
            {
                ElementName = "slrRing",
                Path = new PropertyPath("Value"),
                StringFormat = "F2",
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
            };
            b.ValidationRules.Add(new RingValidator() { MinRings = 0, MaxRings = 5 });
            txtRing.SetBinding(TextBox.TextProperty, b);

        }

        private void DigitalClock_ClockStarted(object sender, EventArgs e)
        {
            ClockTickArgs args = (ClockTickArgs)e;
            startTime = args.ClockTick;
            bool res = double.TryParse(txtRing.Text, out var minutes);
            if (res)
            {
                ringAfter = minutes;
                txtDistinct.Text = $"Start time: {startTime.hour:D2}:{startTime.minute:D2}:{startTime.second:D2}\n";
            }
            else
            {
                MessageBox.Show("invalid ring after", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void DigitalClock_TimeUpdated(object sender, EventArgs e)
        {
            ClockTickArgs args = (ClockTickArgs)e;
            currentTime = args.ClockTick;
            if (currentTime.second % 2 == 0)
            {
                int num = rand.Next(10, 51);
                txtIndicator.Text += $"{num} ";
            }

            int startTotalSeconds = startTime.second
                + startTime.minute * 60
                + startTime.hour * 3600;
            int currentTotalSeconds = currentTime.second
                + currentTime.minute * 60
                + currentTime.hour * 3600;
            double minutesElapsed = (double)(currentTotalSeconds - startTotalSeconds) / 60;

            if (minutesElapsed >= ringAfter) {
                lblBeep.Content = "Start ringing";
                SystemSounds.Beep.Play();
            }
        }

        private void btnDistinct_Click(object sender, RoutedEventArgs e)
        {
            string[] numberStrings = txtIndicator.Text.Trim().Split(' ');
            List<int> numbers = numberStrings.Select(num => int.Parse(num)).ToList();

            var distinctNums = numbers.Distinct().Order();

            txtDistinct.Text = "Distinct numbers\n";
            foreach (int num in distinctNums)
            {
                txtDistinct.Text += $"{num} ";
            }

            var statistic = numbers.OrderDescending()
                            .GroupBy(num => num);

            txtDistinct.Text += "\nFrequency\n";
            foreach (var num in statistic)
            {
                txtDistinct.Text += $"Number {num.Key} found {num.Count()} times\n";
            }

        }
    }
}