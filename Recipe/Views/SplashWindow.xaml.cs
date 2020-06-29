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
using System.Windows.Shapes;
using System.Configuration;

namespace Recipe.Views
{
    /// <summary>
    /// Interaction logic for SplashWindow.xaml
    /// </summary>
    public partial class SplashWindow : Window
    {
        public SplashWindow()
        {
            InitializeComponent();
        }

        //var _content = new string[]
        //{

        //};

        List<string> _content = new List<string>()
        {
            "Mỗi ngày một món ăn cho gia đình thêm vui ^^",
            "Nhớ cẩn thận khi nấu nướng nhé các chị nhà ta ☺♥!!",
            "Gia đình là trên hết <3",
            "Thử làm nội trợ một ngày đi nào các anh -.-",
            "Nhớ đeo khẩu trang khi ra ngoài trong mùa Covid - 19 nhé!!",
            "Món của vợ là nhất 😋",
            "Vào chia sẻ món nhà mình với mọi người nào <3",
        };

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (checkboxdisplay.IsChecked == true)
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.AppSettings.Settings["ShowSplash"].Value = "false";
                config.Save(ConfigurationSaveMode.Modified);
            }
            DialogResult = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Random _rng = new Random();
            var content_wellcome = _content[(_rng.Next(0, _content.Count - 1))];
            ContentWellcome.DataContext = content_wellcome;
        }
    }
}
