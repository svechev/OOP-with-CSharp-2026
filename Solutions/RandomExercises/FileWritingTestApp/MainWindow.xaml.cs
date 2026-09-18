using System.IO;
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

namespace FileWritingTestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StreamWriter? writer;

        public MainWindow()
        {
            InitializeComponent();


            FileStream file = new FileStream("example.txt",
                                            FileMode.OpenOrCreate,
                                            FileAccess.Write);
            writer = new StreamWriter(file);

        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {

            if (!CheckValidAge())
            {

                MessageBox.Show("Invalid data entered", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
            {
                string toWrite = $"{txtName.Text}, {txtAge.Text}";
                writer.WriteLine(toWrite);

                ClearTextBoxes();

            }
            catch (Exception)
            {
                MessageBox.Show("Problem with file!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearTextBoxes();
        }

        private bool CheckValidAge()
        {
            string txt = txtAge.Text;
            if (!int.TryParse(txt, out int age))
            {
                return false;
            }
            else
            {
                return age > 0 && age < 125; // whatever
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (writer != null)
            {
                writer.Close();
            }
            Environment.Exit(0);
        }

        private void ClearTextBoxes()
        {
            txtName.Text = "";
            txtAge.Text = "";
        }
    }
}