using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reciple.Model
{
    class SanPham
    {
        private string masp { get; set; }
        private string tensp { get; set; }
        private string video { get; set; }
        private int luotxem { get; set; }
        private bool yeuthich { get; set; }
        private string mota { get; set; }
        private string anhdaidien { get; set; }
        private string nguyenlieu { get; set; }

        public SanPham()
        {
            masp = "";
            tensp = "";
            video = "";
            luotxem = 0;
            yeuthich = false;
            mota = "";
            anhdaidien = "";
            nguyenlieu = "";
        }

        public SanPham(string _masp, string _tensp, string _video,int _luotxem,bool _yeuthich,string _mota, string _anhdaidien,string _nguyenlieu)
        {
            masp = _masp;
            tensp = _tensp;
            video = _video;
            luotxem = _luotxem;
            yeuthich = _yeuthich;
            mota = _mota;
            anhdaidien = _anhdaidien;
            nguyenlieu = _nguyenlieu;
        }


        

    }
}
