using System;
using System.Collections.Generic;
using System.IO;
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

namespace HCI_Project.Help
{
    /// <summary>
    /// Interaction logic for HelpViewerWindow.xaml
    /// </summary>
    public partial class HelpViewerWindow : Window
    {
        public HelpViewerWindow(string key)
        {
            InitializeComponent();

            string path = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\", "");

            Uri u = new Uri(String.Format("file:///{0}Help/{1}.html", path, key));
            Browser.Navigate(u);
        }
    }
}
