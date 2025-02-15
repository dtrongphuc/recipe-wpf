﻿using System;
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
        public static BindingList<SanPham> _listLike;
        public static List<DanhMuc> listDM;
        List<PaginationStyle> PageStyleList;

        PaginationObject Pages = new PaginationObject();
        Get_ListObject GetControl = new Get_ListObject();

        private int _currentElement = 0;
        public static int FavoriteCount = 0;
        public static int selected = -1;

        public MainWindow()
        {
            InitializeComponent();
        }

        //LOADED
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Show();
            _list = Pages.GetSPPagination(Pages.CurrentPage);

            var config = ConfigurationManager.AppSettings["ShowSplash"];
            if (config.ToLower() == "true")
            {
                var screen = new Views.SplashWindow();
                screen.ShowDialog();
            }
            //mon ăn yêu thich.
            _listLike = GetControl.Get_AllSPLike();
            CategoryList.ItemsSource = GetListCategoryName();
            FavoriteCount = _listLike.Count;
            FavoriteCarousel.ItemsSource = _listLike;
            Products.ItemsSource = _list;
            SetStylePagination();
            PaginationNumber.ItemsSource = PageStyleList;
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
        //GET | SET
        private List<string> GetListCategoryName()
        {
            listDM = Get_ListObject.Get_AllDM();
            List<string> l = new List<string>();
            foreach(var item in listDM)
            {
                l.Add(item.TenDM);
            }
            return l;
        }

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

        //Event
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

        private void BtnShowMenu_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbShowLeftMenu", BtnMenuHide, BtnMenuShow, Menu);
        }

        private void BtnHideMenu_Click(object sender, RoutedEventArgs e)
        {
            ShowHideMenu("sbHideLeftMenu", BtnMenuHide, BtnMenuShow, Menu);
        }

        private void Modal_Click(object sender, MouseButtonEventArgs e)
        {
            ShowHideMenu("sbHideLeftMenu", BtnMenuHide, BtnMenuShow, Menu);
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

        private void BtnProduct_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            var selected = btn.DataContext;
            SanPham product = (SanPham)selected;
            var detailScreen = new DetailsWindow(product);
            this.Hide();
            detailScreen.ShowDialog();
            this.Show();
            product.LuotXem++;
            product.EditView();
        }

        private void BtnFavorite_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            var btn = (Button)sender;
            var selected = btn.DataContext;
            SanPham product = (SanPham)selected;
            if(product.YeuThich == 1)
            {
                _listLike.Remove(_listLike.Where(i => i.MaSP == product.MaSP).Single());
                product.YeuThich = 0;
            } else
            {
                product.YeuThich = 1;
                _listLike.Insert(0, product);
            }
            product.Edit();
            FavoriteCount = _listLike.Count;
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
            string value = SearchBox.Text;
            if(value.Trim() != "")
            {
                this.Hide();
                var screen = new SearchWindow(value, 1);
                screen.ShowDialog();
                SearchBox.Text = "";
                this.Show();
            }
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

        private void Add_Click(object sender, MouseButtonEventArgs e)
        {
            this.Hide();
            var screen = new AddWindow();
            screen.ShowDialog();
            if(screen.DialogResult == true)
            {
                _list.ResetBindings();
            }
            this.Show();
        }

        private void OnChangeCategory(object sender, SelectionChangedEventArgs e)
        {
            var cb = (sender as ComboBox);
            if(cb.SelectedIndex == -1)
            {
                e.Handled = true;
            } else
            {
                string value = cb.SelectedItem as string;
                selected = cb.SelectedIndex;
                this.Hide();
                var screen = new SearchWindow(value, 2);
                screen.ShowDialog();
                CategoryList.SelectedIndex = -1;
                this.Show();
            }
        }

        private void Favorite_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            StackPanel current = (StackPanel)sender;
            var selected = current.DataContext;
            SanPham product = (SanPham)selected;
            var detailScreen = new DetailsWindow(product);
            this.Hide();
            detailScreen.ShowDialog();
            this.Show();
            product.LuotXem++;
            product.EditView();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (this.ActualWidth >= 1310)
            {
                Pages.record1page = 10;
                FavoriteCarousel.Width = 860;
            }
            else if (this.ActualWidth >= 1100)
            {
                Pages.record1page = 8;
                FavoriteCarousel.Width = 860;
            }
            else if (this.ActualWidth >= 800)
            {
                Pages.record1page = 6;
                FavoriteCarousel.Width = 516;
            }
            UpdatePagination();
        }

        private void ReturnHome(object sender, MouseButtonEventArgs e)
        {

        }

        private void Infomation_Click(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("Chức năng đang được xây dựng, xin lỗi vì sự bất tiện này.", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Pagination
        private void UpdatePagination()
        {
            SetStylePagination();
            _list = Pages.GetSPPagination(Pages.CurrentPage);
            PaginationNumber.ItemsSource = PageStyleList;
            Products.ItemsSource = _list;
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
    }
}