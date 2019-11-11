using HCI_Project.Model;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace HCI_Project.FestivalTypeView
{
    /// <summary>
    /// Interaction logic for NewFestivalWindow.xaml
    /// </summary>
    public partial class NewFestivalTypeWindow : Window, INotifyPropertyChanged
    {
        private MainWindow _mainWindow = (MainWindow)Application.Current.MainWindow;
        private FestivalType newType;
        private int _errCount;

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public NewFestivalTypeWindow()
        {
            _errCount = 0;
            this.newType = new FestivalType();
            InitializeComponent();
            this.DataContext = newType;
        }

        private void ButtonBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "JPG Picture (.jpg)|*.jpg";

            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                TextBoxChooser.Text = dlg.FileName;
            }

        }


        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            TextBoxFTId.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            TextBoxFTName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            TextBoxChooser.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (_errCount == 0)
            {
                _mainWindow.FestivalTypes.Add(newType);
                this.Close();
            }
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void countError(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _errCount++;
            else if (e.Action == ValidationErrorEventAction.Removed)
                _errCount--;
        }

        private void TextBoxFTName_TextChanged(object sender, TextChangedEventArgs e)
        {
            var types = _mainWindow.FestivalTypes;
            int counter = 0;
            foreach (FestivalType ft in types)
            {
                if (ft.Name.ToLower() == TextBoxFTName.Text.ToLower())
                {
                    counter++;
                }
            }
            TextBoxFTId.Text = "type:" + TextBoxFTName.Text.ToLower().Replace(' ', '_').Replace('\t', '_') + ":" + counter;
        }
    }
}
