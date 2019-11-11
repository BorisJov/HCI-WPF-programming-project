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
using System.Windows.Shapes;

namespace HCI_Project.Login
{
    /// <summary>
    /// Interaction logic for LoginWindowxaml.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        String user = "admin";
        String password = "admin";
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            if (TBUsername.Text.Equals(user) && PassBox.Password.Equals(password))
            {
                MainWindow mainWindow = new MainWindow();
                Application.Current.MainWindow = mainWindow;
                mainWindow.Show();
                this.Close();
            }
            else
            {
                LabelError.Visibility = Visibility.Visible;
            }
        }
    }
}
