using System;
using System.Collections.Generic;
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

namespace Problem1
{
    /// <summary>
    /// Interaction logic for LoginPasswordUserControl.xaml
    /// </summary>
    public partial class LoginPasswordUserControl : UserControl
    {
        public event EventHandler<LoginEventArgs> Login;

        public string Username { 
            get => TxtUserName.Text;
            set { TxtUserName.Text = value; }
        }
        public string Password
        {
            get => PwdUser.Password;
            set { PwdUser.Password = value; }
        }
        public LoginPasswordUserControl()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            TxtUserName.Text = "";
            PwdUser.Password = "";
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            Login?.Invoke(this, new LoginEventArgs(){ Username=Username, Password=Password});
        }
    }
}
