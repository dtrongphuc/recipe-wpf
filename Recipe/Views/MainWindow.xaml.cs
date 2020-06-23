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

namespace Recipe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<SanPham> _list = null;
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _list = PaginationObject.GetSPPagination(1);

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button sp = (Button)sender;
            var selected = sp.DataContext;
            SanPham a = (SanPham)selected;
            Console.WriteLine(a.masp);
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
                //this.Pagination.Visibility = Visibility.Hidden;
            }
        }

      

        private void DanhMuc_MouseEnter(object sender, MouseEventArgs e)
        {
            // trả về danh sách các danh mục.
            List<DanhMuc> listDM = Get_ListObject.Get_AllDM();
        }
    }
}