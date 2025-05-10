using System.Windows.Controls;

namespace WpfApp2
{
    public partial class HistoryPage : UserControl
    {
        public HistoryPage()
        {
            InitializeComponent();
            LoadHistory();
        }

        private void LoadHistory()
        {
            HistoryList.Items.Add("2025-04-27 분석 결과");
            HistoryList.Items.Add("2025-04-26 분석 결과");
            HistoryList.Items.Add("2025-04-25 분석 결과");
        }
    }
}
