
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WpfApp2;
namespace WpfApp2
{
    /// <summary>
    /// ModelSetPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ModelSetPage : UserControl
    {
        public ModelSetPage()
        {
            InitializeComponent();

            SelectDriftBox.Items.Add("Use Drift(recommended)");       // 콤보박스 아이템 추가 이런식으로 파장 추가하면 될듯 
            SelectDriftBox.Items.Add("None");     // 고정적으로 할거면 xaml에 ComboBoxItem 으로 추가해도 될듯 한데 이 방식이 나을듯
            // raw image 띄우는 코드 필요
            SelectDriftBox.SelectedIndex = 0; // 기본 선택값 설정
        }

        private void SelectDriftBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 선택된 아이템에 따라 다른 작업 수행
            ComboBox comboBox = sender as ComboBox;
            string selectedItem = comboBox.SelectedItem as string;

            if (selectedItem == "Use Drift(recommended)")
            {
                // O2에 대한 작업 수행
                MessageBox.Show("Select using Drift.");
            }
            else if (selectedItem == "None")
            {
                // SiH4에 대한 작업 수행       이것보단 selectedItem을 바로 인자로 넘겨주는게 나을듯
            }
        }

        private void SelectRecipeButtonClick(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "CSV 파일 (*.csv)|*.csv";

            if (openFileDialog.ShowDialog() == true)
            {
                App.RecipeFilePath = openFileDialog.FileName;
                Console.WriteLine($"Selected file: {App.RecipeFilePath}"); // 콘솔에 선택한 파일 경로 출력
                MessageBox.Show($"recipe 파일 경로: {App.RecipeFilePath}");
                SelectedRecipeFilePath.Text = App.RecipeFilePath;
            }
        }

        private void TrainModelButtonClick(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            mainWindow.MainFrame.Content = new ModelDetailPage();
        }
    }
}