﻿using System;
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
using System.Windows.Media.Animation;
using Recipe.Model;
using MaterialDesignThemes.Wpf;
using System.Diagnostics;

namespace Recipe.Views
{
    /// <summary>
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        private SanPham _myproduct { get; set; }

        public int CarouselItemCount = 1;
        private int _currentElement = 0;

        public DetailsWindow(SanPham product)
        {
            InitializeComponent();
            _myproduct = product;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Detail.DataContext = _myproduct;
            DetailSP sp = new DetailSP();
            sp.Find(_myproduct.MaSP);
            CarouselItemCount = sp.hinhanh.Count;
            ImageCarousel.ItemsSource = sp.hinhanh;
            Ingredients.ItemsSource = GetIngredients();
            Steps.ItemsSource = sp.stepdo;
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (_currentElement < CarouselItemCount - 1)
            {
                _currentElement++;
                AnimateCarousel();
            }
        }

        private void btnPrev_Click(object sender, RoutedEventArgs e)
        {
            if (_currentElement > 0)
            {
                _currentElement--;
                AnimateCarousel();
            }
        }

        private void AnimateCarousel()
        {
            var carousel = VisualTreeHelpers.FindChild<StackPanel>(ImageCarousel, "Carousel");
            Storyboard storyboard = (this.Resources["CarouselStoryboard"] as Storyboard);
            DoubleAnimation animation = storyboard.Children.First() as DoubleAnimation;
            Storyboard.SetTarget(animation, carousel);
            animation.To = -550 * _currentElement;
            storyboard.Begin();
        }
        
        private List<string> GetIngredients()
        {
            List<string> list = new List<string>();
            string[] data = _myproduct.NguyenLieu.Split(new[] { "\\n" }, StringSplitOptions.None);
            foreach(var item in data)
            {
                if(item.Trim() != "")
                {
                    list.Add(item.Trim());
                }
            }
            return list;
        }

        private void BtnFavorite_Click(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            var btn = (Button)sender;
            var selected = btn.DataContext;
            SanPham product = (SanPham)selected;
            if(product.YeuThich == 0)
            {
                MainWindow._listLike.Insert(0, product);
                product.Edit();
            }
            product.YeuThich = 1;
            MessageBox.Show("Thêm thành công", "Thành công", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Hyperlink
        private void HandleRequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            string navigateUri = hl.NavigateUri.ToString();
            // if the URI somehow came from an untrusted source, make sure to
            // validate it before calling Process.Start(), e.g. check to see
            // the scheme is HTTP, etc.
            Process.Start(new ProcessStartInfo(navigateUri));
            e.Handled = true;
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
