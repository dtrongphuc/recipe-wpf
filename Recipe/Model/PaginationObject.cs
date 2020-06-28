using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe.Modle;

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
            int sotranghienhanh = (CurrentPage - 1) * PaginationObject.record1page;
            listsp = Get_ListObject.Get_AllSP(sotranghienhanh, record1page);
            return listsp;
        }
    }
}
