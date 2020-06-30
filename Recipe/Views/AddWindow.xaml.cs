﻿using Microsoft.Win32;
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

        private List<string> _categoryList = new List<string>();
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<DanhMuc> listDM = Get_ListObject.Get_AllDM();
            foreach(var element in listDM)
            {
                _categoryList.Add(element.TenDM);
            }
            Categories.ItemsSource = _categoryList;

            //SanPham sp = new SanPham();
            //////set dữ liệu liên quan den san pham vào đây.



            //////kết thúc set dữ liệu.
            //sp.Add();
            //DetailSP dtsp = new DetailSP();
            //////set dữ liệu liên quan den chi tiet san pham ( bao gom so thu tu, buoc lam, hinh anh tung buoc lam )
            //////tao ra 3 list 

            //////ket thuc set du lieu
            //dtsp.Add();

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
        FileInfo _stepFile;
        List<FileInfo> _stepImageList = new List<FileInfo>();
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

        string _fileAvatar;        
        private void BtnAddAvatar(object sender, RoutedEventArgs e)
        {
            var screen = new OpenFileDialog();
            if (screen.ShowDialog() == true)
            {
                _fileAvatar = screen.FileName;
                var bitmap = new BitmapImage(new Uri(_fileAvatar, UriKind.Absolute));
                AvatarImage.Visibility = Visibility.Hidden;
                Header.Visibility = Visibility.Hidden;
                AddAvatar.ImageSource = bitmap;
            }
        }

        private void AddStepImage_Click(object sender, MouseButtonEventArgs e)
        {
            var element = e.Source as FrameworkElement;
            var es = (Border)element;
            var screen = new OpenFileDialog();
            if (screen.ShowDialog() == true)
            {
                string file = screen.FileName;
                _stepFile = new FileInfo(file);
                var ib = new ImageBrush();
                ib.ImageSource = new BitmapImage(new Uri(file, UriKind.Absolute));
                es.Background = ib;
            }
            // Them anh cuoi cung duoc chon vao list
            if(_stepImageList.Count != _currentStep - 1)
            {
                _stepImageList.RemoveAt(_currentStep - 1);
            }
            _stepImageList.Add(_stepFile);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            FileInfo info = null;
            var folderfile = AppDomain.CurrentDomain.BaseDirectory;
            var newname="";
            // Ảnh đại diện: _avatarFile
            // Tên món ăn: ProductName.Text
            // Mô tả: ProductIntro.Text
            // Danh mục: Categories.SelectedItem; (xem lại)

            // Thời gian nấu: Time.Text
            // Nguyên liệu được thêm vào _ingredientList
            //tạo 1 file hình ảnh

            //kiem tra avatar nếu == null thì ko cho hoàn thành 
            if (_fileAvatar == null)
            {
                MessageBox.Show("Bạn chưa thêm ảnh đại diện cho món ăn!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                //DialogResult = false;            
            }
            else
            {
                info = new FileInfo(_fileAvatar);


                newname = $"{Guid.NewGuid()}{info.Extension}";
                //copy vào file           
                info.CopyTo($"{folderfile}Resource\\Images\\Product\\{newname}");

                //them vao chổ sp
                SanPham sp = new SanPham();
                sp.AnhDaiDien = "Resource/Images/Product/" + newname;
                if (ProductName.Text.Trim() != "")
                {
                    sp.TenSP = ProductName.Text.Trim();
                }
                if (ProductIntro.Text.Trim() != "")
                {
                    sp.MoTa = ProductIntro.Text.Trim();
                }
                sp.Video = ProductVideo.Text;
                sp.MaDM = (Categories.SelectedIndex + 1).ToString();
                sp.ThoiGian = Time.Text.Trim();
                List<TextBox> childrenOfIngredients = AllChildren(Ingredients);
                foreach (var element in childrenOfIngredients)
                {
                    sp.NguyenLieu += element.Text + "\n";
                }
                sp.SoThanhPhan = childrenOfIngredients.Count;
                ///thêm đối tượng sp vào database
                sp.Add();


                ///Các bước làm được thêm vào _stepList
                List<TextBox> childrenOfSteps = AllChildren(Steps);
                DetailSP ctsp = new DetailSP();


                for (int i = 1; i <= childrenOfSteps.Count; i++)
                {
                    StepDo stp = new StepDo();
                    stp.step = (i.ToString());
                    stp.Do = (childrenOfSteps[i - 1].Text);
                    ctsp.stepdo.Add(stp);
                }
                //// List ảnh các bước làm _stepImageList
                foreach (var av in _stepImageList)
                {
                    newname = $"{Guid.NewGuid()}{av.Extension}";
                    av.CopyTo($"{folderfile}Resource\\Images\\Product\\{newname}");
                    string path = $"Resource/Images/Product/{newname}";
                    ctsp.hinhanh.Add(path);
                }

                ////thêm ctsp vào database
                ctsp.Add();
                DialogResult = true;
            }
        }
    }
}
