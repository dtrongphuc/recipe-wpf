using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Recipe.Modle;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Recipe.Model
{
     public class Get_ListObject : INotifyPropertyChanged
    {
        private BindingList<SanPham> _list { get; set; } = new BindingList<SanPham>();
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

        private BindingList<SanPham> _listlike { get; set; } = new BindingList<SanPham>();
        public BindingList<SanPham> ListLike
        {
            get
            {
                return _listlike;
            }
            set
            {
                _listlike = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("ListLike"));
            }
        }

        private BindingList<SanPham> _listdm { get; set; } = new BindingList<SanPham>();
        public BindingList<SanPham> ListDM
        {
            get
            {
                return _listdm;
            }
            set
            {
                _listdm = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("ListDM"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static int Get_CountALLSP()
        {          
            string sql = "SELECT COUNT(*) AS [SOLUONG] FROM SanPham";
            int id = Connection.GetCount_Data(sql);
            return id;
        }

        public BindingList<SanPham> Get_AllSP(int curr, int recode1trang)
        {
            List.Clear();
            string sql = $" SELECT sp.*,TenDM FROM SANPHAM AS SP join DanhMuc as dm on dm.MaDM = sp.MADM ORDER BY masp OFFSET  { curr}  ROWS FETCH NEXT  { recode1trang} ROWS ONLY";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach (DataRow row in dt.Rows)
            {
                SanPham sp = new SanPham();
                sp.MaSP = row["MaSP"].ToString();
                sp.TenSP = row["TenSp"].ToString();
                sp.Video = row["Video"].ToString();
                sp.LuotXem = (int)row["LuotXem"];
                sp.YeuThich = (int)row["yeuThich"];
                sp.MoTa = row["MoTa"].ToString();
                sp.AnhDaiDien = "/" + row["AnhDaiDien"].ToString();
                sp.NguyenLieu = row["NguyenLieu"].ToString();
                sp.SoThanhPhan = (int)row["SoThanhPhan"];
                sp.ThoiGian = row["ThoiGian"].ToString();
                sp.TenDM = row["TenDM"].ToString();
                List.Add(sp);
            }
            return List;
        }


        public BindingList<SanPham> Get_AllSPLike()
        {
            ListLike.Clear();
            string sql = "SELECT sp.*,TenDM  FROM SANPHAM AS SP join DanhMuc as dm on dm.MaDM = sp.MADM where yeuThich=1";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach (DataRow row in dt.Rows)
            {
                SanPham sp = new SanPham();
                sp.MaSP = row["MaSP"].ToString();
                sp.TenSP = row["TenSp"].ToString();
                sp.Video = row["Video"].ToString();
                sp.LuotXem = (int)row["LuotXem"];
                sp.YeuThich = (int)row["yeuThich"];
                sp.MoTa = row["MoTa"].ToString();
                sp.AnhDaiDien = "/" + row["AnhDaiDien"].ToString();
                sp.NguyenLieu = row["NguyenLieu"].ToString();
                sp.SoThanhPhan = (int)row["SoThanhPhan"];
                sp.ThoiGian = row["ThoiGian"].ToString();
                sp.TenDM = row["TenDM"].ToString();
                ListLike.Add(sp);
            }
            return ListLike;
        }

        public static List<DanhMuc> Get_AllDM()
        {
            List<DanhMuc> list = new List<DanhMuc>();
            string sql = "select * from danhMuc";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach(DataRow row in dt.Rows)
            {
                DanhMuc dm = new DanhMuc();
                dm.MaDM = row["MaDM"].ToString();
                dm.TenDM = row["TenDM"].ToString();
                list.Add(dm);
            }
            return list;
        }

        public BindingList<SanPham> Get_SPInDM(string id)
        {
            ListDM.Clear();
            string sql = $"select * from SanPham as sp join DanhMuc as dm on dm.MaDM = sp.MaDm  where dm.MADM={id}";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach(DataRow row in dt.Rows)
            {
                SanPham sp = new SanPham();
                sp.MaSP = row["MaSP"].ToString();
                sp.TenSP = row["TenSp"].ToString();
                sp.Video = row["Video"].ToString();
                sp.LuotXem = (int)row["LuotXem"];
                sp.YeuThich = (int)row["yeuThich"];
                sp.MoTa = row["MoTa"].ToString();
                sp.AnhDaiDien = "/" + row["AnhDaiDien"].ToString();
                sp.NguyenLieu = row["NguyenLieu"].ToString();
                sp.SoThanhPhan = (int)row["SoThanhPhan"];
                sp.ThoiGian = row["ThoiGian"].ToString();
                sp.TenDM = row["TenDM"].ToString();
                ListDM.Add(sp);
            }
            return ListDM;
        }
    }
}
