using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Model
{
    public class SanPham
    {
        public string masp { get; set; }
        public string tensp { get; set; }
        public string video { get; set; }
        public int luotxem { get; set; }
        public bool yeuthich { get; set; }
        public string mota { get; set; }
        public string anhdaidien { get; set; }
        public string nguyenlieu { get; set; }
        public int sothanhphan { get; set; }
        public string thoigian { get; set; }
        public string TenDM { get; set; }
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
            sothanhphan = 0;
            thoigian = "";
            TenDM = "";
        }

        public SanPham(string _masp,string _tendm, string _tensp, string _video,int _luotxem,bool _yeuthich,string _mota, string _anhdaidien,string _nguyenlieu,int _spthanhphan,string _thoigian)
        {
            masp = _masp;
            tensp = _tensp;
            video = _video;
            luotxem = _luotxem;
            yeuthich = _yeuthich;
            mota = _mota;
            anhdaidien = _anhdaidien;
            nguyenlieu = _nguyenlieu;
            thoigian = thoigian;
            sothanhphan = _spthanhphan;
            TenDM = _tendm;
        }

        public void Find(string id)
        {

        }

        

    }
}
