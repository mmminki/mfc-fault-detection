//using System;
//using System.Diagnostics;
//using System.IO;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Media.Imaging;

//namespace WpfApp2
//{
//    public partial class UploadPage : UserControl
//    {
//        public UploadPage()
//        {
//            InitializeComponent();
//        }
//        private void ShowPlotImage()
//        {
//            try
//            {
//                string plotImagePath = @"C:\path\to\result_plot.png"; // 그래프 이미지 경로 설정
//                if (File.Exists(plotImagePath))
//                {
//                    BitmapImage bitmap = new BitmapImage(new Uri(plotImagePath));
//                    ImagePlot.Source = bitmap; // XAML에서 ImagePlot에 이미지를 표시
//                }
//                else
//                {
//                    MessageBox.Show("그래프 이미지를 찾을 수 없습니다.");
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"이미지 표시 오류: {ex.Message}");
//            }
//        }
//        // 파일 선택 버튼 클릭 시
//        private void SelectFileButton_Click(object sender, RoutedEventArgs e)
//        {
//            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
//            openFileDialog.Filter = "CSV 파일 (*.csv)|*.csv";

//            if (openFileDialog.ShowDialog() == true)
//            {
//                string filePath = openFileDialog.FileName;
//                SelectedFilePath.Text = filePath;

//                // Python 스크립트 실행
//                string result = RunPythonScript(filePath);

//                // 결과 출력
//                MessageBox.Show($"Python 모델 실행 결과: {result}");

//                // 그래프 이미지 표시
//                ShowPlotImage();
//            }
//        }

//        // Python 스크립트 실행
//        private string RunPythonScript(string filePath)
//        {
//            try
//            {
//                // Python 스크립트 경로
//                string pythonScriptPath = @"C:\Users\cmg11\Desktop\4-1\산프2\gui_연숩\WpfApp2\your_script.py"; // 스크립트 경로 설정
//                string arguments = $"\"{filePath}\""; // 파일 경로를 인수로 전달

//                // Python 프로세스 시작
//                ProcessStartInfo start = new ProcessStartInfo();
//                start.FileName = @"C:\Users\cmg11\AppData\Local\Programs\Python\Python310\python.exe"; // Python 경로 설정
//                start.Arguments = $"{pythonScriptPath} {arguments}";
//                start.UseShellExecute = false;
//                start.RedirectStandardOutput = true;
//                start.CreateNoWindow = true;

//                using (Process process = Process.Start(start))
//                using (StreamReader reader = process.StandardOutput)
//                {
//                    string result = reader.ReadToEnd();
//                    return result; // Python 스크립트 출력 결과 반환
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Python 스크립트 실행 중 오류 발생: {ex.Message}");
//                return null;
//            }
//        }

//        // 그래프 이미지를 화면에 표시
//        private void ShowPlotImage()
//        {
//            try
//            {
//                string plotImagePath = @"C:\Users\cmg11\Desktop\4-1\산프2\gui_연숩\WpfApp2\sine_wave.png"; // 그래프 이미지 경로 설정
//                if (File.Exists(plotImagePath))
//                {
//                    BitmapImage bitmap = new BitmapImage(new Uri(plotImagePath));
//                    ImagePlot.Source = bitmap; // XAML에서 ImagePlot에 이미지를 표시
//                }
//                else
//                {
//                    MessageBox.Show("그래프 이미지를 찾을 수 없습니다.");
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"이미지 표시 오류: {ex.Message}");
//            }
//        }
//    }
//}

using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfApp2
{
    public partial class UploadPage : UserControl
    {
        public UploadPage()
        {
            InitializeComponent();
        }

        // 그래프 이미지를 화면에 표시
        private void ShowPlotImage()
        {
            try
            {
                string plotImagePath = @"C:\Users\cmg11\Desktop\4-1\산프2\gui_연숩\WpfApp2\sine_wave.png"; // 그래프 이미지 경로 설정
                if (File.Exists(plotImagePath))
                {
                    BitmapImage bitmap = new BitmapImage(new Uri(plotImagePath));
                    ImagePlot.Source = bitmap; // XAML에서 ImagePlot에 이미지를 표시
                }
                else
                {
                    MessageBox.Show("그래프 이미지를 찾을 수 없습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"이미지 표시 오류: {ex.Message}");
            }
        }

        // 파일 선택 버튼 클릭 시
        private void SelectFileButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            openFileDialog.Filter = "CSV 파일 (*.csv)|*.csv";

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                Console.WriteLine($"Selected file: {filePath}"); // 콘솔에 선택한 파일 경로 출력
                MessageBox.Show($"Python 파일 경로: {filePath}");
                SelectedFilePath.Text = filePath;

                // Python 스크립트 실행
                string result = RunPythonScript(filePath);

                // 결과 출력
                //MessageBox.Show($"Python 모델 실행 결과: {result}");

                // 그래프 이미지 표시
                //ShowPlotImage();
            }
        }

        // Python 스크립트 실행 함수
        private string RunPythonScript(string filePath)
        {
            try
            {
                // Python 스크립트 경로
                string pythonScriptPath = @"C:\Users\민기조\Desktop\4-1강의자료들\산프\만들던거\mfc-fault-detection\your_script.py"; // 스크립트 경로 설정
                string arguments = $"\"{filePath}\""; // 파일 경로를 인수로 전달

                // Python 프로세스 시작
                ProcessStartInfo start = new ProcessStartInfo();
                start.FileName = @"C:\Users\민기조\AppData\Local\Programs\Python\Python312\python.exe"; // Python 경로 설정
                start.Arguments = $"{pythonScriptPath} {arguments}";
                start.UseShellExecute = false;
                start.RedirectStandardOutput = true;
                start.RedirectStandardError = true;  // 표준 오류도 리디렉션
                start.CreateNoWindow = true;

                using (Process process = Process.Start(start))
                using (StreamReader reader = process.StandardOutput)
                using (StreamReader errorReader = process.StandardError) // 오류 스트림 읽기
                {
                    string result = reader.ReadToEnd();
                    string errorResult = errorReader.ReadToEnd(); // 오류 출력 읽기
                    if (!string.IsNullOrEmpty(errorResult))
                    {
                        MessageBox.Show($"Python 스크립트 오류: {errorResult}");
                    }
                    return result; // Python 스크립트 출력 결과 반환
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Python 스크립트 실행 중 오류 발생: {ex.Message}");
                return null;
            }
        }

    }
}

//using Microsoft.Win32;
//using System;
//using System.IO;
//using System.Linq;
//using System.Windows;
//using System.Windows.Controls;
//using CsvHelper;
//using CsvHelper.Configuration;
//using System.Globalization;

//namespace WpfApp2
//{
//    public partial class UploadPage : UserControl
//    {
//        public UploadPage()
//        {
//            InitializeComponent();
//        }

//        private void SelectFileButton_Click(object sender, RoutedEventArgs e)
//        {
//            OpenFileDialog openFileDialog = new OpenFileDialog();
//            openFileDialog.Filter = "CSV 파일 (*.csv)|*.csv|엑셀 파일 (*.xlsx)|*.xlsx|모든 파일 (*.*)|*.*";

//            if (openFileDialog.ShowDialog() == true)
//            {
//                // 파일 경로를 SelectedFilePath에 표시
//                SelectedFilePath.Text = openFileDialog.FileName;
//                string filePath = openFileDialog.FileName;

//                // 파일 읽기
//                ReadCsvFile(filePath);
//            }
//        }

//        private void ReadCsvFile(string filePath)
//        {
//            try
//            {
//                using (var reader = new StreamReader(filePath))
//                using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)))
//                {
//                    var records = csv.GetRecords<MyDataModel>().ToList();
//                    // 여기에 데이터를 처리할 로직 추가
//                    Console.WriteLine($"파일에서 {records.Count}개의 데이터가 로드되었습니다.");
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"파일을 읽는 중 오류가 발생했습니다: {ex.Message}");
//            }
//        }
//    }

//    // CSV 파일에 매핑될 데이터 모델
//    public class MyDataModel
//    {
//        public string FileName { get; set; }
//        public string FileContent { get; set; }
//    }
//}
