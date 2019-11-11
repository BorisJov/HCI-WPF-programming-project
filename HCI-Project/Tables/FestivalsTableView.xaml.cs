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
    /// Interaction logic for FestivalsTableView.xaml
    /// </summary>
    public partial class FestivalsTableView : Window
    {
        private ObservableCollection<Festival> _festivals;
        private MainWindow _mainWindow = (MainWindow)Application.Current.MainWindow;

        public FestivalsTableView()
        {
            this.Festivals = _mainWindow.Festivals;
            InitializeComponent();
            this.DataContext = this;

            CBPrice.ItemsSource = Enum.GetValues(typeof(Festival.PriceCategoryEnum)).Cast<Festival.PriceCategoryEnum>();
            CBAlcohol.ItemsSource = Enum.GetValues(typeof(Festival.AlcoholServingEnum)).Cast<Festival.AlcoholServingEnum>();
            CBType.ItemsSource = _mainWindow.FestivalTypes;
        }

        public ObservableCollection<Festival> Festivals { get => _festivals; set => _festivals = value; }

        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
            Festivals = _mainWindow.Festivals;
            ObservableCollection<Festival> refined = new ObservableCollection<Festival>();

            foreach (Festival fest in Festivals)
            {
                if (PassesSearch(fest.Id, TBId.Text))
                {
                    if (PassesSearch(fest.Name, TBName.Text))
                    {
                        if (PassesSearch(fest.Date.ToString(), DatePicker.Text))
                        {
                            if (PassesSearch(fest.Description, TBDescription.Text))
                            {
                                if (CBType.SelectedItem == null || fest.Type == CBType.SelectedItem)
                                {
                                    if (CBAlcohol.SelectedItem == null || fest.AlcoholServing.Equals(CBAlcohol.SelectedItem))
                                    {
                                        if (CBPrice.SelectedItem == null || fest.PriceCategory.Equals(CBPrice.SelectedItem))
                                        {
                                            if (fest.Indoors == CBIndoors.IsChecked)
                                            {
                                                if (fest.HandicapAccessible == CBHandicap.IsChecked)
                                                {
                                                    if (fest.SmokingAllowed == CBSmoking.IsChecked)
                                                    {
                                                        if (PassesSearch(fest.ExpectedCrowdSize.ToString(), TBExpected.Text))
                                                        {
                                                            refined.Add(fest);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            Festivals = refined;
            DG.ItemsSource = null;
            DG.ItemsSource = Festivals;
        }

        private bool PassesSearch(string model, object view)
        {
            if (view == null)
            {
                return true;
            }
            String str = null;
            if (view is string)
            {
                str = (String)view;
            }
            if (model.ToLower().Contains(str.ToLower()))
            {
                return true;
            }
            return false;
        }


    }
}
