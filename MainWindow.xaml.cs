using System.Configuration;
using System.Windows;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new UploadPage();
        }

        private void HistoryButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new HistoryPage();
        }
        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = new SettingsPage();
        }

    }
}
