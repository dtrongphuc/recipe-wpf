using Recipe.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public BindingList<SanPham> list;

        public string keyword { get; set; }
        private int _type = 0;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_keyword">từ khoá tìm kiếm</param>
        /// <param name="type">loại tìm kiếm ( 1-tên sản phẩm, 2-tên danh mục)</param>
        public SearchWindow(string _keyword, int type)
        {
            InitializeComponent();
            keyword = _keyword;
            _type = type;
        }

        Get_ListObject page = new Get_ListObject();
        public BindingList<SanPham> search_keyword(string keyword)
        {
            BindingList<SanPham> subnets = null;
            //lấy tất cả các sản phẩm
            BindingList<SanPham> sp = new BindingList<SanPham>();
            int lastindex = Get_ListObject.Get_CountALLSP();
            
            sp = page.Get_AllSP(1, lastindex);

            if (keyword == "")
            {
                ProductsSearch.ItemsSource = sp;
            }
            else
            {
                subnets = (BindingList<SanPham>)sp.Where(i => i.TenSP.ToLower() == keyword.ToLower());
            }
            return subnets;
        }
        List<DanhMuc> listDM;
        public BindingList<SanPham> SearchCategories(string tendm)
        {
            BindingList<SanPham> l = new BindingList<SanPham>();
            var DanhMuc = listDM.Single(x => x.TenDM == tendm);
            l = page.Get_SPInDM(DanhMuc.MaDM);
            return l;
        }

        private List<string> GetListCategoryName()
        {
            listDM = Get_ListObject.Get_AllDM();
            List<string> l = new List<string>();
            foreach (var item in listDM)
            {
                l.Add(item.TenDM);
            }
            return l;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            /// danh sách danh muc hiện tại chua dùng tới
            //List<SanPham> _listdm = Get_ListObject.Get_SPInDM("1");
            //soluong san pham được tìm thấy
            CategoryList.ItemsSource = GetListCategoryName();
            if(_type == 1)
            {
                list = search_keyword(keyword);
            } else
            {
                list = SearchCategories(keyword);
            }
            int soluong = list.Count();
            //binding 
            ProductsSearch.ItemsSource = list;
            Quantity.Text = soluong + " Công thức nấu ăn được tìm thấy";
        }
        private void BtnShowMenu_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbShowLeftMenu", BtnMenuHide, btnMenuShow, Menu);
        }

        private void BtnHideMenu_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbHideLeftMenu", BtnMenuHide, btnMenuShow, Menu);
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
            Quantity.Text = soluong + " Công thức nấu ăn được tìm thấy";
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

        private void OnChangeCategory(object sender, SelectionChangedEventArgs e)
        {
            string value = (sender as ComboBox).SelectedItem as string;
            list = SearchCategories(value);
        }

        private void Add_Click(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            var screen = new AddWindow();
            screen.ShowDialog();
            this.Show();
        }

        private void ReturnHome(object sender, MouseButtonEventArgs e)
        {

        }

        private void GopY_Click(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
