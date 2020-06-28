using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe.Model;

namespace Recipe.Model
{
    public class PaginationObject:INotifyPropertyChanged
    {
        public static int Sum_record { get; set; }
        private int _currentPage;
        public int CurrentPage
        {
            get => _currentPage; set
            {
                _currentPage = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("CurrentPage"));
            }
        }
        public static int record1page = 8;

        private int _totalpage = 0;
        public int ToltalPage { get { return _totalpage; } set {
                _totalpage = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("TotalPage"));
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static  List<SanPham> listsp { get; set; }
        

        public PaginationObject()
        {
            Sum_record = 0;
            CurrentPage = 1;
            listsp = new List<SanPham>();
        }

        public List<SanPham> GetSPPagination(int _curr)
        {
            CurrentPage = _curr;
            Sum_record = Get_ListObject.Get_CountALLSP();
            CalculateTotalPage();
            int sotranghienhanh = (CurrentPage - 1) * PaginationObject.record1page;
            listsp = Get_ListObject.Get_AllSP(sotranghienhanh, record1page);
            return listsp;
        }

        public List<int> GetPaginaitonNumbers()
        {
            List<int> Numbers = new List<int>();
            int j = 2;
            if (ToltalPage - CurrentPage < 2)
            {
                j = 5 - (ToltalPage - CurrentPage) - 1;
            }
            for (int i = j; i > 0; --i)
            {
                if(CurrentPage > i)
                {
                    Numbers.Add(CurrentPage - i);
                }
            }
            j = 5 - Numbers.Count;
            if(ToltalPage - CurrentPage <= 2)
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
            double num = (1.0*Sum_record / record1page);
            double ToltalPageTemp = Math.Ceiling(num);
            ToltalPage = (int)ToltalPageTemp; // Tính tổng số trang
        }
    }
}
