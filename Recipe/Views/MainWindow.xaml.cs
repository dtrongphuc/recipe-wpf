using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;
using System.Configuration;
using Recipe.Model;
using Recipe.Views;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Recipe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BindingList<SanPham> _list = new BindingList<SanPham>();
        int FavoriteCount = 0;
        public MainWindow()
        {
            InitializeComponent();
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

        PaginationObject Pages = new PaginationObject();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _list = Pages.GetSPPagination(Pages.CurrentPage);
            List<DanhMuc> listDM = Get_ListObject.Get_AllDM();

            var config = ConfigurationManager.AppSettings["ShowSplash"];
            if (config.ToLower() == "true")
            {
                var screen = new Views.SplashWindow();
                screen.ShowDialog();
            }
            this.Show();

            //mon ăn yêu thich.
            List<SanPham> _listLike = Get_ListObject.Get_AllSPLike();
            FavoriteCount = _listLike.Count;
            FavoriteCarousel.ItemsSource = _listLike;
            Products.ItemsSource = _list;
            SetStylePagination();
            PaginationNumber.ItemsSource = PageStyleList;
        }

        List<PaginationStyle> PageStyleList;
        private void SetStylePagination()
        {
            List<int> PageNumbers = Pages.GetPaginaitonNumbers();
            PageStyleList = new List<PaginationStyle>();
            Style defaultStyle = this.FindResource("PaginationStyle") as Style;
            Style selectedStyle = this.FindResource("PaginationStyleSelected") as Style;
            foreach (var number in PageNumbers)
            {
                Style myStyle = defaultStyle;
                if (number == Pages.CurrentPage)
                {
                    myStyle = selectedStyle;
                }
                PageStyleList.Add(new PaginationStyle() { Number = number, PageBtnStyle = myStyle });
            }
        }

        private int _currentElement = 0;
        private void BtnNextFavorite_Click(object sender, RoutedEventArgs e)
        {
            if (_currentElement < FavoriteCount - 5)
            {
                _currentElement++;
                AnimateCarousel();
            }
        }

        private void BtnPrevFavorite_Click(object sender, RoutedEventArgs e)
        {
            if (_currentElement > 0)
            {
                _currentElement--;
                AnimateCarousel();
            }
        }

        private void AnimateCarousel()
        {
            var carousel = VisualTreeHelpers.FindChild<StackPanel>(FavoriteCarousel, "Carousel");
            Storyboard storyboard = (this.Resources["CarouselStoryboardFavorite"] as Storyboard);
            DoubleAnimation animation = storyboard.Children.First() as DoubleAnimation;
            Storyboard.SetTarget(animation, carousel);
            animation.To = -172 * _currentElement;
            storyboard.Begin();
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
            product.YeuThich = !product.YeuThich;
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string value = SearchBox.Text;
            // Khi rỗng trả về toàn bộ danh sách món ăn
            if(value == "")
            {
                Products.ItemsSource = _list;
            } 
            else
            {
                // Tìm kiếm danh sách với keyword tương ứng
                // Products.ItemsSource = null;
                // Nếu không có kết quả thì ẩn phân trang
                
                
                var keyword = SearchBox.Text;
                List<SanPham> sp = new List<SanPham>();
                int lastindex = Get_ListObject.Get_CountALLSP();
                //_list = Get_ListObject.Get_AllSP(1,lastindex);
                var subnet = _list.Where(i => i.TenSP.Contains(keyword));
                if (_list.Count < 8)
                {
                    this.Pagination.Visibility = Visibility.Hidden;
                }
                Products.ItemsSource = subnet;
            }
        }

        // Pagination
        private void UpdatePagination()
        {
            SetStylePagination();
            _list = Pages.GetSPPagination(Pages.CurrentPage);
            PaginationNumber.ItemsSource = PageStyleList;
        }

        private void OnPageNumber_Click(object sender, RoutedEventArgs e)
        {
            var Btn = (Button)sender;
            Pages.CurrentPage = (int)Btn.Content;
            UpdatePagination();
        }


        private void OnPrePage_Click(object sender, RoutedEventArgs e)
        {
            if(Pages.CurrentPage > 1)
            {
                Pages.CurrentPage--;
                UpdatePagination();
            }
        }

        private void OnNextPage_Click(object sender, RoutedEventArgs e)
        {
            if (Pages.CurrentPage < Pages.ToltalPage)
            {
                Pages.CurrentPage++;
                UpdatePagination();
            }
        }

        private void OnFirstPage_Click(object sender, RoutedEventArgs e)
        {
            Pages.CurrentPage = 1;
            UpdatePagination();
        }

        private void OnLastPage_Click(object sender, RoutedEventArgs e)
        {
            Pages.CurrentPage = Pages.ToltalPage;
            UpdatePagination();
        }


        private void ScrollViewer_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (sender is ListBox && !e.Handled)
            {
                e.Handled = true;
                var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
                eventArg.RoutedEvent = UIElement.MouseWheelEvent;
                eventArg.Source = sender;
                var parent = ((Control)sender).Parent as UIElement;
                parent.RaiseEvent(eventArg);
            }
        }
    }
}