using Recipe.Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Recipe.Views
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        public IEnumerable<SanPham> list;

        public SearchWindow(IEnumerable<SanPham> _list)
        {
            InitializeComponent();
            list = _list;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<SanPham> _listdm = Get_ListObject.Get_SPInDM("1");
            ProductsSearch_1.ItemsSource = list;
        }
        private void btnShowMenu_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbShowLeftMenu", btnMenuHide, btnMenuShow, Menu);
        }

        private void btnHideMenu_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbHideLeftMenu", btnMenuHide, btnMenuShow, Menu);
        }

        private void ShowHideMenu(string Storyboard, Button btnHide, Button btnShow, Grid pnl)
        {
            Storyboard sb = Resources[Storyboard] as Storyboard;
            sb.Begin(pnl);

            if (Storyboard.Contains("Show"))
            {
                btnHide.Visibility = System.Windows.Visibility.Visible;
                btnShow.Visibility = System.Windows.Visibility.Hidden;
            }
            else if (Storyboard.Contains("Hide"))
            {
                btnHide.Visibility = System.Windows.Visibility.Hidden;
                btnShow.Visibility = System.Windows.Visibility.Visible;
            }
        }

        BindingList<SanPham> _list = new BindingList<SanPham>();
        
        private void BtnSearch_Click_1(object sender, RoutedEventArgs e)
        {
            string value = SearchBox_1.Text;
            // Khi rỗng trả về toàn bộ danh sách món ăn
            if (value == "")
            {
                ProductsSearch_1.ItemsSource = _list;
            }
            else
            {
                // Tìm kiếm danh sách với keyword tương ứng
                // Products.ItemsSource = null;
                // Nếu không có kết quả thì ẩn phân trang
                var keyword = SearchBox_1.Text;
                BindingList<SanPham> sp = new BindingList<SanPham>();
                int lastindex = Get_ListObject.Get_CountALLSP();
                Get_ListObject page = new Get_ListObject();
                sp = page.Get_AllSP(1, lastindex);
                var subnet = sp.Where(i => i.TenSP.Contains(keyword));

                var screen = new SearchWindow(subnet);
                screen.ShowDialog();
            }
        }

       
    }
}
