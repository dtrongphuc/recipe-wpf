﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Recipe.Modle;

namespace Recipe.Model
{
     public static class Get_ListObject
    {

        public static int Get_CountALLSP()
        {          
            string sql = "SELECT COUNT(*) AS [SOLUONG] FROM SanPham";
            int id = Connection.GetCount_Data(sql);
            return id;
        }

        public static List<SanPham> Get_AllSP(int curr, int recode1trang)
        {
           
            List<SanPham> _list = new List<SanPham>();

           
            string sql = $" SELECT sp.*,TenDM FROM SANPHAM AS SP join DanhMuc as dm on dm.MaDM = sp.MADM ORDER BY masp OFFSET  { curr}  ROWS FETCH NEXT  { recode1trang} ROWS ONLY";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach (DataRow row in dt.Rows)
            {
                SanPham sp = new SanPham();
                sp.masp = row["MaSP"].ToString();
                sp.tensp = row["TenSp"].ToString();
                sp.video = row["Video"].ToString();
                sp.luotxem = (int)row["LuotXem"];
                sp.yeuthich = (bool)row["yeuThich"];
                sp.mota = row["MoTa"].ToString();
                sp.anhdaidien = "/" + row["AnhDaiDien"].ToString();
                sp.nguyenlieu = row["NguyenLieu"].ToString();
                sp.sothanhphan = (int)row["SoThanhPhan"];
                sp.thoigian = row["ThoiGian"].ToString();
                //sp.TenDM = row["TenDM"].ToString();
                _list.Add(sp);
            }
            return _list;
        }


        public static List<SanPham> Get_AllSPLike()
        {

            List<SanPham> _list = new List<SanPham>();


            string sql = $" select * from SanPham where yeuThich=1";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach (DataRow row in dt.Rows)
            {
                SanPham sp = new SanPham();
                sp.masp = row["MaSP"].ToString();
                sp.tensp = row["TenSp"].ToString();
                sp.video = row["Video"].ToString();
                sp.luotxem = (int)row["LuotXem"];
                sp.yeuthich = (bool)row["yeuThich"];
                sp.mota = row["MoTa"].ToString();
                sp.anhdaidien = "/" + row["AnhDaiDien"].ToString();
                sp.nguyenlieu = row["NguyenLieu"].ToString();
                sp.sothanhphan = (int)row["SoThanhPhan"];
                sp.thoigian = row["ThoiGian"].ToString();
                sp.TenDM = row["TenDM"].ToString();
                _list.Add(sp);
            }
            return _list;
        }
    }
}
