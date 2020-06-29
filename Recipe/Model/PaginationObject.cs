using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe.Model;

namespace Recipe.Model
{
    public class PaginationObject : INotifyPropertyChanged
    {
        public static int Sum_record { get; set; }
        private int _currentPage;
        public int CurrentPage
        {
            get { return _currentPage; } set
            {
                _currentPage = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("CurrentPage"));
            }
            }
        private int _record1page = 8;
        public int record1page
        {
            get { return _record1page; }
            set
            {
                _record1page = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("recod1page"));
            }
        }

        private int _totalpage = 0;
        public int ToltalPage
        {
            get { return _totalpage; }
            set
            {
                _totalpage = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("TotalPage"));
            }
        }
        private BindingList<SanPham> _listsp;

        public  BindingList<SanPham> listsp
        {
            get { return _listsp; }
            set
            {
                _listsp = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("listsp"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private BindingList<SanPham> _list { get; set; }

        public BindingList<SanPham> List
        {
            get
            {
                return _list;
            }
            set
            {
                _list = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("List"));
            }
        }

        public PaginationObject()
        {
            Sum_record = 0;
            CurrentPage = 1;
            List = new BindingList<SanPham>();
        }

        Get_ListObject GetCtrl = new Get_ListObject();
        public BindingList<SanPham> GetSPPagination(int _curr)
        {
            CurrentPage = _curr;
            Sum_record = Get_ListObject.Get_CountALLSP();
            CalculateTotalPage();
            int sotranghienhanh = (CurrentPage - 1) * record1page;
            List = GetCtrl.Get_AllSP(sotranghienhanh, record1page);
            //listsp = Get_ListObject.Get_AllSP(sotranghienhanh, record1page);
            return List;
        }

        public List<int> GetPaginaitonNumbers()
        {
            CalculateTotalPage();
            List<int> Numbers = new List<int>();
            int j = 2;
            if (ToltalPage - CurrentPage < 2)
            {
                j = 5 - (ToltalPage - CurrentPage) - 1;
            }
            for (int i = j; i > 0; --i)
            {
                if (CurrentPage > i)
                {
                    Numbers.Add(CurrentPage - i);
                }
            }
            j = (ToltalPage >= 5) ? 5 - Numbers.Count : ToltalPage - Numbers.Count;
            if (ToltalPage - CurrentPage <= 2)
            {
                j = (ToltalPage - CurrentPage) + 1;
            }
            for (int i = 0; i < j; ++i)
            {
                if (CurrentPage <= ToltalPage)
                {
                    Numbers.Add(CurrentPage + i);
                }
            }
            return Numbers;
        }

        public void CalculateTotalPage()
        {
            double num = (1.0 * Sum_record / record1page);
            double ToltalPageTemp = Math.Ceiling(num); // Tính tổng số trang và làm tròn lên
            ToltalPage = (int)ToltalPageTemp;
        }
    }
}
