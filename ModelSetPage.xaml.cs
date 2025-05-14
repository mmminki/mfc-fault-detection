using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

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

            SelectElementBox.Items.Add("O2");       // 콤보박스 아이템 추가 이런식으로 파장 추가하면 될듯 
            SelectElementBox.Items.Add("SiH4");     // 고정적으로 할거면 xaml에 ComboBoxItem 으로 추가해도 될듯 한데 이 방식이 나을듯

        }

        private void SelectElementBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // 선택된 아이템에 따라 다른 작업 수행
            ComboBox comboBox = sender as ComboBox;
            string selectedItem = comboBox.SelectedItem as string;

            if (selectedItem == "O2")
            {
                // O2에 대한 작업 수행
                MessageBox.Show("O2가 선택되었습니다.");
            }
            else if (selectedItem == "SiH4")
            {
                // SiH4에 대한 작업 수행       이것보단 selectedItem을 바로 인자로 넘겨주는게 나을듯
            }
        }
    }
}
