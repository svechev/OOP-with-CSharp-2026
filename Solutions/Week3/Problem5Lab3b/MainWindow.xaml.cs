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

namespace Problem5Lab3b
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int HeadsCount { get; set; }
        public int TailsCount { get; set; }
        private Random rand = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnToss_Click(object sender, RoutedEventArgs e)
        {
            int res = rand.Next(2);
            if (res == 0) {
                LblResult.Content = "Heads!";
                ++HeadsCount;
                LblHeads.Content = $"{HeadsCount}";
            }
            else
            {
                LblResult.Content = "Tails!";
                ++TailsCount;
                LblTails.Content = $"{TailsCount}";
            }
        }
    }
}