using HCI_Project.Model;
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

namespace HCI_Project.TagView
{
    /// <summary>
    /// Interaction logic for ChooseTagsDialog.xaml
    /// </summary>
    public partial class ChooseTagsDialog : Window
    {
        private MainWindow _mainWindow = (MainWindow)Application.Current.MainWindow;

        public ChooseTagsDialog(Festival selectedFest)
        {
            AvailableTags = new List<CheckedListItem>();
            SelectedFestival = selectedFest;
            foreach (Tag t in _mainWindow.Tags)
            {
                CheckedListItem cli = new CheckedListItem(t, _mainWindow.Tags.IndexOf(t));
                if (selectedFest.Tags.Contains(t))
                    cli.IsChecked = true;
                else
                    cli.IsChecked = false;
                AvailableTags.Add(cli);
            }
            InitializeComponent();
            this.DataContext = this;
        }

        public List<CheckedListItem> AvailableTags { get; set; }
        public Festival SelectedFestival { get; set; }

        public class CheckedListItem
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public bool IsChecked { get; set; }
            public Tag tag { get; set; }

            public CheckedListItem(Tag t, int index)
            {
                this.ID = index;
                this.Name = t.Id;
                this.tag = t;
            }

        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            SelectedFestival.Tags.Clear();
            foreach (CheckedListItem cli in CLBox.Items)
            {
                if (cli.IsChecked)
                {
                    SelectedFestival.Tags.Add(cli.tag);
                }
            }
            this.Close();
        }
    }
}
