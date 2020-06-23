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
using System.Windows.Media.Animation;
using Recipe.Model;

namespace Recipe.Views
{
    /// <summary>
    /// Interaction logic for DetailsWindow.xaml
    /// </summary>
    public partial class DetailsWindow : Window
    {
        public DetailsWindow()
        {
            InitializeComponent();
        }

        private int _currentElement = 0;
        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            if (_currentElement < 10)
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DetailSP dtsp = new DetailSP();
            dtsp.Find("1");
            ImageCarousel.ItemsSource = dtsp.hinhanh;
        }
    }
}
