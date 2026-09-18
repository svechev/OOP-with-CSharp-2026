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

namespace CommandReverse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            btnReverse.Command = ReverseCommand.Reverse;
            btnReverse.CommandTarget = txtBox;
            btnReverse.Content = ((RoutedUICommand)(btnReverse.Command)).Text;

            btnReverseBgnd.Command = ReverseBackgroundCommand.ReverseBackground;
            btnReverseBgnd.CommandTarget = txtBox;
            btnReverseBgnd.Content = ((RoutedUICommand)(btnReverseBgnd.Command)).Text;

            CommandBinding binding = new CommandBinding();
            binding.Command = ReverseCommand.Reverse;
            binding.Executed += ReverseString_Executed;
            binding.CanExecute += ReverseString_CanExecute;

            CommandBinding bindingBgnd = new CommandBinding();
            bindingBgnd.Command = ReverseBackgroundCommand.ReverseBackground;
            bindingBgnd.Executed += ReverseBackground_Executed;
            bindingBgnd.CanExecute += ReverseBackground_CanExecute;

            CommandBindings.Add(binding);
            CommandBindings.Add(bindingBgnd);
        }
        public void ReverseBackground_Executed(object sender, ExecutedRoutedEventArgs args)
        {
            if (txtBox.Text.Length > 8) { txtBox.Background = new SolidColorBrush(Colors.Green); }
            else { txtBox.Background = new SolidColorBrush(Colors.Red); }
           
        }
        public void ReverseString_Executed(object sender, ExecutedRoutedEventArgs args)
        {
            char[] temp = txtBox.Text.ToCharArray();
            Array.Reverse(temp);
            txtBox.Text = new string(temp);
        }

        public void ReverseString_CanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = txtBox.Text.Length > 0;
        }
        public void ReverseBackground_CanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = txtBox.Text.Length > 0;
        }
    }
}
 