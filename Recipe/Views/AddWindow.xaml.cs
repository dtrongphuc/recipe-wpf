using Recipe.Model;
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

namespace Recipe.Views
{
    /// <summary>
    /// Interaction logic for AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SanPham sp = new SanPham();
            ////set dữ liệu liên quan den san pham vào đây.




            ////kết thúc set dữ liệu.
            sp.Add();
            DetailSP dtsp = new DetailSP();
            ////set dữ liệu liên quan den chi tiet san pham ( bao gom so thu tu, buoc lam, hinh anh tung buoc lam )
            ////tao ra 3 list 

            ////ket thuc set du lieu
            dtsp.Add();

        }
    }
}
