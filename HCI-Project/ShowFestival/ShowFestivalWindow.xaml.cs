using HCI_Project.AddFestival;
using HCI_Project.Model;
using HCI_Project.TagView;
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

namespace HCI_Project.ShowFestival
{
    /// <summary>
    /// Interaction logic for ShowFestivalWindow.xaml
    /// </summary>
    public partial class ShowFestivalWindow : Window
    {
        private Festival selectedFestival;
        private MainWindow _mainWindow = (MainWindow)Application.Current.MainWindow;

        public ShowFestivalWindow(Festival fest)
        {
            this.selectedFestival = fest;
            InitializeComponent();
            this.Title = "Festival: " + fest.Name;
            this.LabelAlcohol.Content = fest.AlcoholServing;
            this.LabelDate.Content = fest.Date;
            this.LabelDesription.Content = fest.Description;
            this.LabelHandicap.Content = fest.HandicapAccessible == true ? "Yes" : "No";
            this.LabelID.Content = fest.Id;
            this.LabelName.Content = fest.Name;
            this.LabelSite.Content = fest.Indoors == true ? "indoors" : "outdoors";
            this.LabelSmoking.Content = fest.SmokingAllowed == true ? "Yes" : "No";
            this.LabelType.Content = fest.Type;
            this.ImageIcon.Source = new BitmapImage(new Uri(fest.IconPath));
            this.ImageIcon.MaxHeight = 50;
            this.ImageIcon.MaxWidth = 60;
            this.LabelPrice.Content = fest.PriceCategory;

            foreach (Tag t in fest.Tags)
            {
                Label newTagLabel = new Label
                {
                    Content = t.Id,
                    Foreground = new SolidColorBrush(t.Color)
                };
                this.SPTags.Children.Add(newTagLabel);
            }
        }

        private void ButtonClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult messageBoxResult = MessageBox.Show("This will delete the festival from your list, are you sure?", "Delete Confirmation", MessageBoxButton.YesNo);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                _mainWindow.Festivals.Remove(selectedFestival);
                this.Close();
            }
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            NewFestivalWindow nfw = new NewFestivalWindow(selectedFestival);
            nfw.ShowDialog();
        }

        private void ButtonChooseTags_Click(object sender, RoutedEventArgs e)
        {
            ChooseTagsDialog ctd = new ChooseTagsDialog(selectedFestival);
            ctd.ShowDialog();
            SPTags.Children.Clear();
            foreach (Tag t in selectedFestival.Tags)
            {
                Label newTagLabel = new Label
                {
                    Content = t.Id,
                    Foreground = new SolidColorBrush(t.Color)
                };
                this.SPTags.Children.Add(newTagLabel);
            }
        }
    }
}
