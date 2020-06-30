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
        private List<string> _categoryList = new List<string>();
        List<FileInfo> _stepImageList = new List<FileInfo>();

        FileInfo _stepFile;
        private int _currentStep = 1;
        string _fileAvatar;


        public AddWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            List<DanhMuc> listDM = Get_ListObject.Get_AllDM();
            foreach(var element in listDM)
            {
                _categoryList.Add(element.TenDM);
            }
            Categories.ItemsSource = _categoryList;
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

        private void BtnAddIngredientsField_Click(object sender, RoutedEventArgs e)
        {
            Style style = this.FindResource("ingredientBox") as Style;
            var newTextbox = new TextBox();
            newTextbox.Style = style;
            Ingredients.Children.Add(newTextbox);
        }

        
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
            var newStackPanelChild = new StackPanel();
            var newBorderImage = new Border();
            //var newBorderImage1 = new Border();
            //var newBorderImage2 = new Border();
            //var newBorderImage3 = new Border();

            newGrid.Style = GridStyle;
            newEllipse.Style = EllipseStyle;
            newLabel.Style = CountStyle;
            newTextBox.Style = stepBoxStyle;
            newBorderImage.Style = ImageAddStyle;
            //newborderimage1.style = imageaddstyle;
            //newBorderImage2.Style = ImageAddStyle;
            //newBorderImage3.Style = ImageAddStyle;

            newStackPanelChild.Orientation = Orientation.Horizontal;

            newLabel.Content = ++_currentStep;
            newBorderImage.MouseLeftButtonDown += AddStepImage_Click;
            //newBorderImage1.MouseLeftButtonDown += AddStepImage_Click;
            //newBorderImage2.MouseLeftButtonDown += AddStepImage_Click;
            //newBorderImage3.MouseLeftButtonDown += AddStepImage_Click;

            newGrid.Children.Add(newEllipse);
            newGrid.Children.Add(newLabel);
            newStackPanel.Children.Add(newTextBox);
            newStackPanelChild.Children.Add(newBorderImage);
            //newStackPanelChild.Children.Add(newBorderImage1);
            //newStackPanelChild.Children.Add(newBorderImage2);
            //newStackPanelChild.Children.Add(newBorderImage3);
            newStackPanel.Children.Add(newStackPanelChild);
            newDockPanel.Children.Add(newGrid);
            newDockPanel.Children.Add(newStackPanel);

            Steps.Children.Add(newDockPanel);
        }

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
            // Thêm ảnh cuối cùng được chọn
            if(_stepImageList.Count != _currentStep - 1)
            {
                _stepImageList.RemoveAt(_currentStep - 1);
            }
            _stepImageList.Add(_stepFile);
        }

        private bool ConditionCheck(List<TextBox> ingredients, List<TextBox> st)
        {
            if(_fileAvatar == null)
            {
                MessageBox.Show("Bạn chưa thêm ảnh đại diện cho món ăn!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            } else if (ProductName.Text.Trim() == "" | ProductName.Text.Trim() == "" | ProductVideo.Text.Trim() == "" |
                Time.Text.Trim() == "" | ingredients.Count < 1 | st.Count < 1 | _stepImageList.Count < 1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin cho món ăn!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            return true;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            List<TextBox> childrenOfIngredients = AllChildren(Ingredients);
            List<TextBox> childrenOfSteps = AllChildren(Steps);
            FileInfo info = null;
            var folderfile = AppDomain.CurrentDomain.BaseDirectory;
            var newname = "";
            // Ảnh đại diện: _fileAvatar
            // Tên món ăn: ProductName.Text
            // Mô tả: ProductIntro.Text
            // Danh mục: Categories.SelectedItem; (xem lại)

            // Thời gian nấu: Time.Text
            // Nguyên liệu được thêm vào childrenOfIngredients

            // Kiểm tra dữ liệu
            if (ConditionCheck(childrenOfIngredients, childrenOfSteps))
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
                
                foreach (var element in childrenOfIngredients)
                {
                    if(element.Text.Trim() != "")
                    {
                        sp.NguyenLieu += element.Text + "\\n";
                    }
                }
                sp.SoThanhPhan = childrenOfIngredients.Count;
                ///thêm đối tượng sp vào database
                sp.Add();

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
                    if(av.Name != null)
                    {
                        newname = $"{Guid.NewGuid()}{av.Extension}";
                        av.CopyTo($"{folderfile}Resource\\Images\\Product\\{newname}");
                        string path = $"Resource/Images/Product/{newname}";
                        ctsp.hinhanh.Add(path);
                    }
                }

                ////thêm ctsp vào database
                ctsp.Add();
                DialogResult = true;
            }
        }
    }
}
