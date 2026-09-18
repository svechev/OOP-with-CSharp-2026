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

namespace Problem2
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
                ElementName = "slrData",
                Path = new PropertyPath("Value"),
                UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                Converter = new Double2TextConverter()
            };
            txtCode.SetBinding(TextBox.TextProperty, b);
        }
    }
}