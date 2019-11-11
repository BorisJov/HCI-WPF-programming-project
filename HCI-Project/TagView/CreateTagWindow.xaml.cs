using HCI_Project.Model;
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

namespace HCI_Project.TagView
{
    /// <summary>
    /// Interaction logic for CreateTag.xaml
    /// </summary>
    public partial class CreateTagWindow : Window
    {
        private Tag newTag;
        private MainWindow _mainWindow = (MainWindow)Application.Current.MainWindow;

        private int _errCount;
        private bool _colorError;

        public CreateTagWindow()
        {
            _errCount = 0;
            _colorError = false;
            newTag = new Tag();
            this.DataContext = newTag;
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            TBid.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (ColorPicker.SelectedColor == null)
            {
                _colorError = true;
                ColorError.Visibility = Visibility.Visible;
            }
            if (_errCount == 0 && !_colorError) {
                newTag.Color = (Color)ColorPicker.SelectedColor;
                _mainWindow.Tags.Add(newTag);
                this.Close();
            }
        }

        private void Count_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _errCount++;
            else if (e.Action == ValidationErrorEventAction.Removed)
                _errCount--;
        }

        private void ColorPicker_Opened(object sender, RoutedEventArgs e)
        {
            ColorError.Visibility = Visibility.Hidden;
            _colorError = false;
        }
    }
}
