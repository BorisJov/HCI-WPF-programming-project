using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using HCI_Project.Model;
using HCI_Project.AddFestival;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using HCI_Project.ShowFestival;
using HCI_Project.Tables;
using HCI_Project.FestivalTypeView;
using HCI_Project.TagView;

namespace HCI_Project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private ObservableCollection<Festival> _festivals;
        private ObservableCollection<FestivalType> _festivalTypes;
        private ObservableCollection<Tag> _tags;

        internal ObservableCollection<Festival> Festivals
        {
            get { return _festivals; }
            set
            {
                if (_festivals != value)
                {
                    _festivals = value;
                    OnPropertyChanged();
                }
            }
        }

        internal ObservableCollection<FestivalType> FestivalTypes { get => _festivalTypes; set => _festivalTypes = value; }
        internal ObservableCollection<Tag> Tags { get => _tags; set => _tags = value; }

        public MainWindow()
        {
            Festivals = new ObservableCollection<Festival>();
            FestivalTypes = new ObservableCollection<FestivalType>();
            Tags = new ObservableCollection<Tag>();
            Festivals.CollectionChanged += FestivalCollectionChanged;
            InitializeComponent();
        }

        public void InitMap()
        {
            Map.Children.Clear();

            foreach (Festival fest in Festivals)
            {
                if (!(fest.Position.X == 0 && fest.Position.Y == 0))
                {
                    Button btn = GetDataForButton(fest);
                    Canvas.SetTop(btn, fest.Position.Y);
                    Canvas.SetLeft(btn, fest.Position.X);
                    Map.Children.Add(btn);
                }
            }
        }

        private void FestivalCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            LBFestivals.Items.Clear();
            foreach (Festival fest in Festivals)
            {
                if (fest.Position.X == 0 && fest.Position.Y == 0)
                {
                    ListBoxItem lbi = new ListBoxItem();
                    lbi.Content = GetDataForButton(fest);
                    LBFestivals.Items.Add(lbi);
                }
            }
            LBFestivals.Items.Add(NewEventButton);
            InitMap();
        }

        private Button GetDataForButton(Festival fest)
        {
            Grid tmpGrid = new Grid();
            tmpGrid.Height = 70;
            tmpGrid.Width = 60;
            tmpGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2, GridUnitType.Star) });
            tmpGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2, GridUnitType.Star) });
            tmpGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(1, GridUnitType.Star) });
            tmpGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(2, GridUnitType.Star) });
            tmpGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(2, GridUnitType.Star) });
            tmpGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            Image icon = new Image()
            {
                Source = new BitmapImage(new Uri(fest.IconPath)),
                Height = 50,
                Width = 40,
                VerticalAlignment = VerticalAlignment.Top
            };
            Grid.SetColumn(icon, 0);
            Grid.SetRow(icon, 0);
            Grid.SetRowSpan(icon, 3);
            tmpGrid.Children.Add(icon);

            Label name = new Label
            {
                Content = fest.Name,
                HorizontalAlignment = HorizontalAlignment.Center,
                Foreground = new SolidColorBrush(Color.FromRgb(255, 135, 71)),
                FontSize = 10,
                FontWeight = FontWeights.Bold,
                Width = 60,
                Height = 25
            };
            Grid.SetColumn(name, 0);
            Grid.SetRow(name, 3);
            Grid.SetColumnSpan(name, 2);
            tmpGrid.Children.Add(name);

            for (int i = 0; i < fest.Tags.Count(); i++)
            {
                if (i < 2)
                {
                    StackPanel stmp = new StackPanel()
                    {
                        Background = new SolidColorBrush(fest.Tags[i].Color),
                        Height = 20,
                        Width = 20
                    };
                    Grid.SetColumn(stmp, 1);
                    Grid.SetRow(stmp, i);
                    tmpGrid.Children.Add(stmp);
                }
                else
                {
                    String path = AppDomain.CurrentDomain.BaseDirectory.Replace("bin\\Debug\\", "");
                    path += "Resources\\DotDotDot.png";
                    Image im = new Image()
                    {
                        Source = new BitmapImage(new Uri(path)),
                        Height = 10,
                        Width = 20
                    };
                    Grid.SetColumn(im, 1);
                    Grid.SetRow(im, 2);
                    tmpGrid.Children.Add(im);
                    break;
                }
            }

            Button btmp = new Button();
            //TODO: Znas da ovo ne valja
            btmp.Name = fest.Name;
            btmp.Content = tmpGrid;
            SolidColorBrush scb = new SolidColorBrush(Color.FromRgb(23, 50, 143));
            scb.Opacity = 0;
            btmp.Background = scb;
            btmp.Width = 65;
            btmp.Height = 80;
            //btmp.Opacity = 0.6;
            btmp.MouseDoubleClick += new MouseButtonEventHandler(ShowFestivalDoubleClick);
            btmp.ToolTip = "Double-click to show details. Click and drag to place on/remove from map.";

            return btmp;
        }

        public void ShowFestivalDoubleClick(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            IEnumerable<Festival> festcol = Festivals.Where(f => f.Name == btn.Name);
            Festival fest = festcol.First();
            ShowFestivalWindow sfw = new ShowFestivalWindow(fest);
            sfw.ShowDialog();
            FestivalCollectionChanged(null, null);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }  


        private void NewEventButton_Click(object sender, RoutedEventArgs e)
        {
            if (FestivalTypes.Count > 0)
            {
                NewFestivalWindow nfw = new NewFestivalWindow();
                nfw.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please first create a festival type.", "Message");
            }
            FestivalCollectionChanged(null, null);
        }

        private void MenuOpen_Click(object sender, RoutedEventArgs e)
        {
            DataBase db = DataBase.Deserialize();
            Tags = db.Tags;
            FestivalTypes = db.FestivalTypes;
            Festivals = db.Festivals;
            FestivalCollectionChanged(null, null);
        }

        private void MenuSave_Click(object sender, RoutedEventArgs e)
        {
            DataBase db = new DataBase(Festivals, FestivalTypes, Tags);
            DataBase.Serialize(db);
        }

        private void SidePanelButton_Click(object sender, RoutedEventArgs e)
        {
            if (LBFestivals.Visibility == Visibility.Visible)
            {
                LBFestivals.Visibility = Visibility.Collapsed;
                SidePanelButton.Content = "<<";
            }
            else
            {
                LBFestivals.Visibility = Visibility.Visible;
                SidePanelButton.Content = ">>";
            }
        }

        private void MenuAllFestivals_Click(object sender, RoutedEventArgs e)
        {
            FestivalsTableView tw = new FestivalsTableView();
            tw.ShowDialog();
        }

        private void MenuNewFestival_Click(object sender, RoutedEventArgs e)
        {
            if (FestivalTypes.Count() > 0)
            {
                NewFestivalWindow nfw = new NewFestivalWindow();
                nfw.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please first create a festival type.", "Message");
            }
            FestivalCollectionChanged(null, null);
        }

        private void MenuNewType_Click(object sender, RoutedEventArgs e)
        {
            NewFestivalTypeWindow nftw = new NewFestivalTypeWindow();
            nftw.ShowDialog();
        }

        private void MenuAllTypes_Click(object sender, RoutedEventArgs e)
        {
            FestivalTypesTableView fttw = new FestivalTypesTableView();
            fttw.ShowDialog();
        }

        private void MenuNewTag_Click(object sender, RoutedEventArgs e)
        {
            CreateTagWindow ctw = new CreateTagWindow();
            ctw.ShowDialog();
        }

        private void MenuAllTags_Click(object sender, RoutedEventArgs e)
        {
            TagsTableView ttw = new TagsTableView();
            ttw.ShowDialog();
        }

        private Point startPoint;
        private void LBFestivals_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void LBFestivals_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;
            Festival fest;
            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                ListBox listBox = sender as ListBox;
                if (listBox.SelectedItem is ListBoxItem) { 
                    ListBoxItem lbi = (ListBoxItem)listBox.SelectedItem;

                    Button btn = (Button)lbi.Content;
                    Grid gr = (Grid)btn.Content;
                    Label l = (Label)gr.Children[1];
                    String id = (String)l.Content;
                    IEnumerable<Festival> festcol = Festivals.Where(f => f.Name == btn.Name);
                    fest = festcol.First();

                    DataObject dragData = new DataObject("myFormat", fest);
                    DragDrop.DoDragDrop(lbi, dragData, DragDropEffects.Move);
                }
            }
        }

        private void Image_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }
        private void Image_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Festival fest = e.Data.GetData("myFormat") as Festival;
                fest.Position = e.GetPosition(BaseDockPanel);

                Button btn = GetDataForButton(fest);

                Canvas.SetTop(btn, fest.Position.Y);
                Canvas.SetLeft(btn, fest.Position.X);

                LBFestivals.Items.Remove(LBFestivals.SelectedItem);

                FestivalCollectionChanged(null, null);
            }
        }

        private void Image_Dock(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Festival fest = e.Data.GetData("myFormat") as Festival;
                fest.Position = new Point(0, 0);
                
                Button btn = GetDataForButton(fest);

                ListBoxItem lbi = new ListBoxItem();
                lbi.Content = btn;
                LBFestivals.Items.Insert(0, lbi);

                FestivalCollectionChanged(null, null);
            }
        }

        private void Map_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void Map_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(Map);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                UIElement uIElement = (UIElement)e.OriginalSource;
                double top = Canvas.GetTop(uIElement);
                double left = Canvas.GetLeft(uIElement);

                foreach (Festival fest in Festivals)
                {
                    if (fest.Position.Y == top && fest.Position.X == left)
                    {
                        DataObject dragData = new DataObject("myFormat", fest);
                        DragDrop.DoDragDrop(Map, dragData, DragDropEffects.Move);
                        break;
                    }
                }
            }
        }

        private void MenuClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
