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

        public string keyword { get; set; }

        public SearchWindow(string _keyword)
        {
            InitializeComponent();
            keyword = _keyword;
        }

        public IEnumerable<SanPham> search_keyword(string keyword)
        {
            IEnumerable<SanPham> subnets = null;
            //lấy tất cả các sản phẩm
            BindingList<SanPham> sp = new BindingList<SanPham>();
            int lastindex = Get_ListObject.Get_CountALLSP();
            Get_ListObject page = new Get_ListObject();
            sp = page.Get_AllSP(1, lastindex);

            if (keyword == "")
            {
                ProductsSearch.ItemsSource = sp;
            }
            else
            {
                subnets = sp.Where(i => i.TenSP.ToLower().Contains(keyword.ToLower()));
            }
            return subnets;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /// danh sách danh muc hiện tại chua dùng tới
            //List<SanPham> _listdm = Get_ListObject.Get_SPInDM("1");
            //soluong san pham được tìm thấy
            list = search_keyword(keyword);
            int soluong = list.Count();
            //binding 
            ProductsSearch.ItemsSource = list;
            Quality.Text = soluong + " Công Thức Nấu Ăn Được Tìm Thấy";
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

       

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            keyword = SearchBox.Text;
            list = search_keyword(keyword);
            int soluong = list.Count();
            // Tìm kiếm danh sách với keyword tương ứng
            ProductsSearch.ItemsSource = list;
            Quality.Text = soluong + " Công Thức Nấu Ăn Được Tìm Thấy";
        }

        private void BtnProduct_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            var selected = btn.DataContext;
            SanPham product = (SanPham)selected;
            var detailScreen = new DetailsWindow(product);
            this.Hide();
            detailScreen.ShowDialog();
            this.Show();
        }

        private void BtnFavorite_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            var btn = (Button)sender;
            var selected = btn.DataContext;
            SanPham product = (SanPham)selected;
            if (product.YeuThich == 1)
            {
                MainWindow._listLike.Remove(MainWindow._listLike.Where(i => i.MaSP == product.MaSP).Single());
                product.YeuThich = 0;
            }
            else
            {
                product.YeuThich = 1;
                MainWindow._listLike.Insert(0, product);
            }
            product.Edit();
            MainWindow.FavoriteCount = MainWindow._listLike.Count;
        }

        private void Lienhe_CLick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Chức Năng Đang Được Xây Dựng, Xin Lổi Về Sự Bất Tiện Này", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Home_CLick(object sender, MouseButtonEventArgs e)
        {
            DialogResult = true;
        }

        private void GopY_Click(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Chức Năng Đang Được Xây Dựng, Xin Lổi Về Sự Bất Tiện Này", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);

        }
    }
}
