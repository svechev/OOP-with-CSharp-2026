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

namespace ClockApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var b = new Binding()
            {
                Source = CtrlClock.ClockSecond,
                StringFormat = "D2"
            };
            lblBind.SetBinding(Label.ContentProperty, b);
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void lblBind_KeyDown(object sender, KeyEventArgs e)
        {
            var key = e.Key;
            _ = key switch
            {
                Key.R => lblBind.Background = Brushes.Red,
                Key.B => lblBind.Background = Brushes.Blue,
                Key.G => lblBind.Background = Brushes.Green,
                Key.Y => lblBind.Background = Brushes.Yellow,
                _ => lblBind.Background // do nothing
            };

        }
    }
}