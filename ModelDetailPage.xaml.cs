using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace WpfApp2
{
    public partial class ModelDetailPage : UserControl
    {
        public ModelDetailPage()
        {
            InitializeComponent();

            // 예시 바인딩 데이터 – 나중에 파이썬 실행 결과로 교체하면 됨
            var sampleData = new ModelDetailViewModel
            {
                RelatedVariables = new List<RelatedVariable>
                {
                    new RelatedVariable { Name = "O2", Value = "0.87" },
                    new RelatedVariable { Name = "SiH4", Value = "0.34" },
                    new RelatedVariable { Name = "Ar", Value = "0.15" }
                },
                EuclidImagePath = "./image/euclid.png", // 상대 경로 가능
                ModelPerformanceText = "Accuracy: 93.4%\nF1 Score: 0.89",
                ModelPerformanceImagePath = "./image/performance.png"
            };

            this.DataContext = sampleData;
        }
    }

    public class ModelDetailViewModel
    {
        public List<RelatedVariable> RelatedVariables { get; set; }
        public string EuclidImagePath { get; set; }
        public string ModelPerformanceText { get; set; }
        public string ModelPerformanceImagePath { get; set; }
    }

    public class RelatedVariable
    {
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
