using ClockLib;
using System.Media;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AlarmClockApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        (int hour, int minute, int second) startTime;
        (int hour, int minute, int second) currentTime;
        Random rand = new Random();
        double ringAfter;

        public MainWindow()
        {
            InitializeComponent();

            //< TextBox x: Name = "txtRingAfter" Grid.Column = "1" MinHeight = "20" Width = "35" HorizontalAlignment = "Left" >
            //        < TextBox.Text >
            //            < Binding ElementName = "slrRing" Path = "Value" StringFormat = "F2" UpdateSourceTrigger = "PropertyChanged" >
            //                < Binding.ValidationRules >
            //                    < local:RingValidator MinRings = "0" MaxRings = "5" />
            //                </ Binding.ValidationRules >
            //            </ Binding >
            //        </ TextBox.Text >
            //    </ TextBox >

            var b = new Binding()
            {
                ElementName = "slrRing",
                Path = new PropertyPath("Value"),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                StringFormat = "F2"
            };
            b.ValidationRules.Add(new RingValidator() { MinRings=0, MaxRings=5});

            txtRingAfter.SetBinding(TextBox.TextProperty, b);
        }


        private void DigitalClock_ClockStarted(object sender, EventArgs e)
        {

            startTime = ((ClockTickArgs)e).ClockTick;
            ringAfter = double.Parse(txtRingAfter.Text);
            txtDisplayStart.Text = $"Start time: {startTime.hour}:{startTime.minute}:{startTime.second}";
        }

        private void DigitalClock_TimeUpdated(object sender, EventArgs e)
        {
            currentTime = ((ClockTickArgs)e).ClockTick;


            if (currentTime.second % 2 == 0)
            {
                int randNum = rand.Next(10, 51);
                txtBeepIndicator.Text += $"{randNum} ";
            }


            int startTotalSeconds =
                startTime.hour * 3600 +
                startTime.minute * 60 +
                startTime.second;

            int currentTotalSeconds =
                currentTime.hour * 3600 +
                currentTime.minute * 60 +
                currentTime.second;

            double elapsedMins =
                (currentTotalSeconds - startTotalSeconds) / 60.0;

            if (elapsedMins >= ringAfter)
            {
                blockBeepIndicator.Text = "Start ringing";
                SystemSounds.Beep.Play();
            }
        }

        private void btnDistinct_Click(object sender, RoutedEventArgs e)
        {
            txtDisplayStart.Text = "Distinct numbers\n";
            // get numbers
            List<string> numbersInput = txtBeepIndicator.Text.TrimEnd().Split(' ').ToList();
            List<int> numbers = new List<int>();
            for (int i = 0; i < numbersInput.Count; i++) { 
                numbers.Add(int.Parse(numbersInput[i]));
            }

            // declare linq
            var sortedDistinctNumbers = numbers.Order().Distinct();

            // execute linq
            foreach (int num in sortedDistinctNumbers)
            {
                txtDisplayStart.Text += $"{num} ";
            }

            txtDisplayStart.Text += "\nFrequency\n";

            // declare linq - statistics
            var statisticNums = numbers.OrderDescending()
                .GroupBy(num => num)
                .Select(group => new
                {
                    Number = group.Key,
                    Frequency = group.Count()
                });

            // execute linq
            foreach (var group in statisticNums)
            {
                txtDisplayStart.Text += $"Number {group.Number} found {group.Frequency} times.\n";
            }
        }
    }
}