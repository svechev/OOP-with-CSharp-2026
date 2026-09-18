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

namespace Problem4Lab3b
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Random rand = new Random();
        private int num1;
        private int num2;

        public MainWindow()
        {
            InitializeComponent();
            GenerateQuestion();
        }

        private void GenerateQuestion()
        {
            num1 = rand.Next(1, 10);
            num2 = rand.Next(1, 10);
            LblQuestion.Content = $"How much is {num1} times {num2}?";
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            string? input = TxtAnswer.Text;
            if (!int.TryParse(input, out int answer))
            {
                MessageBox.Show("Please enter an integer", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                TxtAnswer.Text = "";
                return;
            }
            if (answer == num1 * num2) {
                LblFeedback.Foreground = Brushes.Green;
                LblFeedback.Content = "Well done!";
                GenerateQuestion();
            }
            else
            {
                LblFeedback.Foreground = Brushes.Red;
                LblFeedback.Content = "Wrong, loser.";
            }
        }
    }
}