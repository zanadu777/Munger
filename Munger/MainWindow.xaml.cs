using System.Collections.ObjectModel;
using System.Windows;

namespace Munger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        readonly ObservableCollection<WorkArea> workAreas = new ObservableCollection<WorkArea>();
        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            workAreas.Add(new WorkArea {Name = "Join", Control= new Join() });
            workAreas.Add(new WorkArea { Name = "Compare", Control = new Compare() });
            lstAreas.ItemsSource = workAreas;
            lstAreas.SelectedIndex = 0;
        }

        private void lstAreas_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var selected = (WorkArea)e.AddedItems[0];
            contentWorkArea.Content = selected.Control;


        }
    }
}
