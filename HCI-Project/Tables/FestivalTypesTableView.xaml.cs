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
    /// Interaction logic for FestivalTypesTableView.xaml
    /// </summary>
    public partial class FestivalTypesTableView : Window
    {
        private ObservableCollection<FestivalType> _festivalTypes;
        private MainWindow _mainWindow = (MainWindow)Application.Current.MainWindow;

        public FestivalTypesTableView()
        {
            this.FestivalTypes = _mainWindow.FestivalTypes;
            InitializeComponent();
            this.DataContext = this;
        }

        public ObservableCollection<FestivalType> FestivalTypes { get => _festivalTypes; set => _festivalTypes = value; }
    }
}
