﻿using System;
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
            get {
                return _currentPage;
            } set
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
            listsp = new BindingList<SanPham>();
        }

        public BindingList<SanPham> GetSPPagination(int _curr)
        {
            CurrentPage = _curr;
            Sum_record = Get_ListObject.Get_CountALLSP();
            CalculateTotalPage();
            int sotranghienhanh = (CurrentPage - 1) * PaginationObject.record1page;
            listsp = Get_ListObject.Get_AllSP(sotranghienhanh, record1page);
            return listsp;
        }
    }
}
