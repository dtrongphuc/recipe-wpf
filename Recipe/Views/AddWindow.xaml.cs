using Microsoft.Win32;
using Recipe.Model;
using System;
using System.Collections.Generic;
using System.IO;
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

        private List<TextBox> AllChildren(DependencyObject parent)
        {
            var list = new List<TextBox> { };
            for (int count = 0; count < VisualTreeHelper.GetChildrenCount(parent); count++)
            {
                var child = VisualTreeHelper.GetChild(parent, count);
                if (child is TextBox)
                {
                    list.Add(child as TextBox);
                }
                list.AddRange(AllChildren(child));
            }
            return list;
        }

        List<string> _ingredientList = new List<string>();
        private void BtnAddIngredientsField_Click(object sender, RoutedEventArgs e)
        {
            Style style = this.FindResource("ingredientBox") as Style;
            var newTextbox = new TextBox();
            newTextbox.Style = style;
            Ingredients.Children.Add(newTextbox);
        }

        private int _currentStep = 1;
        private void BtnAddStepField_Click(object sender, RoutedEventArgs e)
        {
            Style GridStyle = this.FindResource("leftCount") as Style;
            Style EllipseStyle = this.FindResource("circleIcon") as Style;
            Style CountStyle = this.FindResource("countNumber") as Style;
            Style stepBoxStyle = this.FindResource("stepBox") as Style;
            Style ImageAddStyle = this.FindResource("imageAddStep") as Style;

            var newGrid = new Grid();
            var newEllipse = new Ellipse();
            var newLabel = new Label();
            var newTextBox = new TextBox();
            var newDockPanel = new DockPanel();
            var newStackPanel = new StackPanel();
            var newBorderImage = new Border();

            newGrid.Style = GridStyle;
            newEllipse.Style = EllipseStyle;
            newLabel.Style = CountStyle;
            newTextBox.Style = stepBoxStyle;
            newBorderImage.Style = ImageAddStyle;

            newLabel.Content = ++_currentStep;
            newBorderImage.MouseLeftButtonDown += AddStepImage_Click;

            newGrid.Children.Add(newEllipse);
            newGrid.Children.Add(newLabel);
            newStackPanel.Children.Add(newTextBox);
            newStackPanel.Children.Add(newBorderImage);
            newDockPanel.Children.Add(newGrid);
            newDockPanel.Children.Add(newStackPanel);

            Steps.Children.Add(newDockPanel);
        }

        string _avatarFile = "";
        private void BtnAddAvatar(object sender, RoutedEventArgs e)
        {
            var screen = new OpenFileDialog();
            if (screen.ShowDialog() == true)
            {
                _avatarFile = screen.FileName;
                var bitmap = new BitmapImage(new Uri(_avatarFile, UriKind.Absolute));
                AvatarImage.Visibility = Visibility.Hidden;
                Header.Visibility = Visibility.Hidden;
                AddAvatar.ImageSource = bitmap;
            }
        }

        string _stepImage = "";
        List<string> _stepImageList = new List<string>();
        List<string> _stepList = new List<string>();
        private void AddStepImage_Click(object sender, MouseButtonEventArgs e)
        {
            var element = e.Source as FrameworkElement;
            var es = (Border)element;
            var screen = new OpenFileDialog();
            if (screen.ShowDialog() == true)
            {
                _stepImage = screen.FileName;
                var ib = new ImageBrush();
                ib.ImageSource = new BitmapImage(new Uri(_stepImage, UriKind.Absolute));
                es.Background = ib;
            }
            _stepImageList.Add(_stepImage);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            // Ảnh đại diện: _avatarFile
            // Tên món ăn: ProductName.Text
            // Mô tả: ProductIntro.Text
            // Danh mục: Categories.SelectedItem; (xem lại)
            // Thời gian nấu: Time.Text
            // Nguyên liệu được thêm vào _ingredientList
            List<TextBox> childrenOfIngredients = AllChildren(Ingredients);
            foreach(var element in childrenOfIngredients) {
                _ingredientList.Add(element.Text);
            }
            //Các bước làm được thêm vào _stepList
            List<TextBox> childrenOfSteps = AllChildren(Steps);
            foreach (var element in childrenOfSteps)
            {
                _stepList.Add(element.Text);
            }
            // List ảnh các bước làm _stepImageList
        }
    }
}
