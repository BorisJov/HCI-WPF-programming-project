using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using HCI_Project.Model;
using Microsoft.Win32;
using HCI_Project.Validation;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls;
using System.Collections.ObjectModel;
using HCI_Project.Help;

namespace HCI_Project.AddFestival
{
    /// <summary>
    /// Interaction logic for NewFestivalWindow.xaml
    /// </summary>
    public partial class NewFestivalWindow : Window, INotifyPropertyChanged
    {
        private Color _elipseBlue = Color.FromRgb(66, 134, 244);
        private Color _elipseWhite = Color.FromRgb(239, 245, 255);
        private int _step;
        private int _errCount;
        private bool _isEdit;

        private MainWindow _mainWindow = (MainWindow) Application.Current.MainWindow;
        private ObservableCollection<FestivalType> _types;

        private Festival newFest;

        private string _tbChooserDef;
        private string _tbCrowdsizeDef;

        public ObservableCollection<FestivalType> Types { get => _types; set => _types = value; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public NewFestivalWindow()
        {
            _isEdit = false;
            _step = 1;
            _errCount = 0;
            newFest = new Festival();
            InitializeComponent();
            this.DataContext = newFest;

            _tbChooserDef = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\","");
            _tbChooserDef += "Resources\\red-pin.jpg";
            _tbCrowdsizeDef = "0";
            newFest.IconPath = _tbChooserDef;
            this.Types = _mainWindow.FestivalTypes;
            CBFestivalTypes.ItemsSource = Types;
            newFest.Date = DateTime.Today;
        }
        public NewFestivalWindow(Festival target)
        {
            _isEdit = true;
            _step = 1;
            _errCount = 0;
            newFest = target;
            InitializeComponent();
            this.DataContext = newFest;

            _tbChooserDef = target.IconPath;
            _tbCrowdsizeDef = target.ExpectedCrowdSize.ToString();
            this.Types = _mainWindow.FestivalTypes;
            CBFestivalTypes.ItemsSource = Types;
            CBFestivalTypes.SelectedItem = target.Type;
            CBPrice.SelectedIndex = (int)target.PriceCategory;
            CBAlcohol.SelectedIndex = (int)target.AlcoholServing;
        }

        private void NextStepButton_Click(object sender, RoutedEventArgs e)
        {
            switch (_step)
            {
                case 1:
                    IDTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                    NameTextBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                    if (_errCount == 0)
                    {
                        TLstep1.Visibility = Visibility.Collapsed;
                        SP1step1.Visibility = Visibility.Collapsed;
                        SP2step1.Visibility = Visibility.Collapsed;
                        SP3step1.Visibility = Visibility.Collapsed;
                        SP4step1.Visibility = Visibility.Collapsed;
                        TLstep2.Visibility = Visibility.Visible;
                        SP1step2.Visibility = Visibility.Visible;
                        SP2step2.Visibility = Visibility.Visible;
                        SP3step2.Visibility = Visibility.Visible;
                        SP4step2.Visibility = Visibility.Visible;
                        Elipse2.Fill = new SolidColorBrush(_elipseBlue);
                        BackButton.Visibility = Visibility.Visible;
                        _step++;
                    }
                    break;
                case 2:
                    TBChooser.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                    if (_errCount == 0)
                    {
                        TLstep2.Visibility = Visibility.Collapsed;
                        SP1step2.Visibility = Visibility.Collapsed;
                        SP2step2.Visibility = Visibility.Collapsed;
                        SP3step2.Visibility = Visibility.Collapsed;
                        SP4step2.Visibility = Visibility.Collapsed;
                        TLstep3.Visibility = Visibility.Visible;
                        SP1step3.Visibility = Visibility.Visible;
                        SP2step3.Visibility = Visibility.Visible;
                        SP3step3.Visibility = Visibility.Visible;
                        SP4step3.Visibility = Visibility.Visible;
                        Elipse3.Fill = new SolidColorBrush(_elipseBlue);
                        _step++;
                    }

                    //TODO: See if necessary
                    newFest.Type = (FestivalType)CBFestivalTypes.SelectedItem;

                    break;
                case 3:
                    TBCrowdSize.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                    if (_errCount == 0)
                    { 
                        TLstep3.Visibility = Visibility.Collapsed;
                        SP1step3.Visibility = Visibility.Collapsed;
                        SP2step3.Visibility = Visibility.Collapsed;
                        SP3step3.Visibility = Visibility.Collapsed;
                        SP4step3.Visibility = Visibility.Collapsed;
                        TLstep4.Visibility = Visibility.Visible;
                        SP1step4.Visibility = Visibility.Visible;
                        SP2step4.Visibility = Visibility.Visible;
                        //SP3step4.Visibility = Visibility.Visible;
                        //SP4step4.Visibility = Visibility.Visible;
                        Elipse4.Fill = new SolidColorBrush(_elipseBlue);
                        NextStepButton.Content = "Confirm";
                        _step++;
                        ButtonHelp.Visibility = Visibility.Collapsed;
                    }
                    break;
                case 4:
                    newFest.PriceCategory = (Festival.PriceCategoryEnum)CBPrice.SelectedIndex;
                    newFest.AlcoholServing = (Festival.AlcoholServingEnum)CBAlcohol.SelectedIndex;

                    if (!_isEdit)
                    {
                        _mainWindow.Festivals.Insert(0, newFest);
                    }
                    this.Close();
                    break;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            switch (_step)
            {
                case 1:
                    break;
                case 2:
                    TLstep2.Visibility = Visibility.Collapsed;
                    SP1step2.Visibility = Visibility.Collapsed;
                    SP2step2.Visibility = Visibility.Collapsed;
                    SP3step2.Visibility = Visibility.Collapsed;
                    SP4step2.Visibility = Visibility.Collapsed;
                    TLstep1.Visibility = Visibility.Visible;
                    SP1step1.Visibility = Visibility.Visible;
                    SP2step1.Visibility = Visibility.Visible;
                    SP3step1.Visibility = Visibility.Visible;
                    SP4step1.Visibility = Visibility.Visible;
                    Elipse2.Fill = new SolidColorBrush(_elipseWhite);
                    BackButton.Visibility = Visibility.Hidden;
                    if (_errCount > 0)
                    {
                        TBCrowdSize.Text = _tbCrowdsizeDef;
                        TBCrowdSize.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                    }
                    _step--;
                    break;
                case 3:
                    TLstep3.Visibility = Visibility.Collapsed;
                    SP1step3.Visibility = Visibility.Collapsed;
                    SP2step3.Visibility = Visibility.Collapsed;
                    SP3step3.Visibility = Visibility.Collapsed;
                    SP4step3.Visibility = Visibility.Collapsed;
                    TLstep2.Visibility = Visibility.Visible;
                    SP1step2.Visibility = Visibility.Visible;
                    SP2step2.Visibility = Visibility.Visible;
                    SP3step2.Visibility = Visibility.Visible;
                    SP4step2.Visibility = Visibility.Visible;
                    Elipse3.Fill = new SolidColorBrush(_elipseWhite);
                    if (_errCount > 0)
                    {
                        TBChooser.Text = _tbChooserDef;
                        TBChooser.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                    }
                    _step--;
                    break;
                case 4:
                    TLstep4.Visibility = Visibility.Collapsed;
                    SP1step4.Visibility = Visibility.Collapsed;
                    SP2step4.Visibility = Visibility.Collapsed;
                    //SP3step4.Visibility = Visibility.Collapsed;
                    //SP4step4.Visibility = Visibility.Collapsed;
                    TLstep3.Visibility = Visibility.Visible;
                    SP1step3.Visibility = Visibility.Visible;
                    SP2step3.Visibility = Visibility.Visible;
                    SP3step3.Visibility = Visibility.Visible;
                    SP4step3.Visibility = Visibility.Visible;
                    Elipse4.Fill = new SolidColorBrush(_elipseWhite);
                    NextStepButton.Content = "Next Step";
                    _step--;
                    ButtonHelp.Visibility = Visibility.Visible;
                    break;
            }
        }

        private void ChkUseFromType_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)ChkUseFromType.IsChecked)
            {
                ButtonBrowse.IsEnabled = false;
                newFest.IconPath = newFest.Type.IconPath;
                ImagePreview.Source = new BitmapImage(new Uri(newFest.Type.IconPath));
            }
        }

        private void ChkUseFromType_Unchecked(object sender, RoutedEventArgs e)
        {
            if(!(bool)ChkUseFromType.IsChecked)
            {
                ButtonBrowse.IsEnabled = true;
                newFest.IconPath = TBChooser.Text;
                ImagePreview.Source = new BitmapImage(new Uri(newFest.IconPath));
            }
        }

        private void ButtonBrowse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.FileName = "Document";
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "JPG Picture (.jpg)|*.jpg";

            Nullable<bool> result = dlg.ShowDialog();
      
            if (result == true)
            {
                TBChooser.Text = dlg.FileName;
                ImagePreview.Source = new BitmapImage(new Uri(dlg.FileName));
            }
        }

        private void Count_Error(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
                _errCount++;
            else if (e.Action == ValidationErrorEventAction.Removed)
                _errCount--;
        }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var festivals = _mainWindow.Festivals;
            int counter = 0;
            foreach (Festival fest in festivals)
            {
                if (fest.Name.ToLower() == NameTextBox.Text.ToLower())
                {
                    counter++;
                }
            }
            IDTextBox.Text = "fest:" + NameTextBox.Text.ToLower().Replace(' ', '_').Replace('\t', '_') + ":" + counter;
        }

        private void ButtonHelp_Click(object sender, RoutedEventArgs e)
        {
            HelpViewerWindow hvw = new HelpViewerWindow("Step" + _step);
            hvw.Show();
        }
    }
}
