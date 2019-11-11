using HCI_Project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace HCI_Project.Tables
{
    /// <summary>
    /// Interaction logic for TagsTableView.xaml
    /// </summary>
    public partial class TagsTableView : Window
    {
        private ObservableCollection<Tag> _tags;
        private MainWindow _mainWindow = (MainWindow)Application.Current.MainWindow;


        public TagsTableView()
        {
            this.Tags = _mainWindow.Tags;
            InitializeComponent();
            this.DataContext = this;
        }

        public ObservableCollection<Tag> Tags { get => _tags; set => _tags = value; }
    }
}
