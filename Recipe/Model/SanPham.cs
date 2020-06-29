using Recipe.Modle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Model
{
    public class SanPham:INotifyPropertyChanged
    {
        private string _masp;
        public string MaSP
        {
            get { return _masp; }
            set
            {
                _masp = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("MaSP"));
            }
        }

        private string _madm;
        public string MaDM
        {
            get { return _madm; }
            set
            {
                _madm = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("MaDM"));
            }
        }

        private string _tensp;
        public string TenSP
        {
            get { return _tensp; }
            set
            {
                _tensp = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("TenSP"));
            }
        }

        private string _video;
        public string Video
        {
            get { return _video; }
            set
            {
                _video = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("Video"));
            }
        }

        private int _luotxem;
        public int LuotXem
        {
            get { return _luotxem; }
            set
            {
                _luotxem = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("Luotxem"));
            }
        }

        private int _yeuthich;
        public int YeuThich
        {
            get { return _yeuthich; }
            set
            {
                _yeuthich = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("YeuThich"));
            }
        }

        private string _mota;
        public string MoTa
        {
            get { return _mota; }
            set
            {
                _mota = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("MoTa"));
            }
        }

        private string _anhdaidien;
        public string AnhDaiDien
        {
            get { return _anhdaidien; }
            set
            {
                _anhdaidien = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("AnhDaiDien"));
            }
        }

        private string _nguyenlieu;
        public string NguyenLieu
        {
            get { return _nguyenlieu; }
            set
            {
                _nguyenlieu = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("NguyenLieu"));
            }
        }

        private int _sothanhphan;
        public int SoThanhPhan
        {
            get { return _sothanhphan; }
            set
            {
                _sothanhphan = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("SoThanhPhan"));
            }
        }

        private string _thoigian;
        public string ThoiGian
        {
            get { return _thoigian; }
            set
            {
                _thoigian = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("ThoiGian"));
            }
        }

        private string _tendm;
        public string TenDM
        {
            get { return _tendm; }
            set
            {
                _tendm = value;
                PropertyChanged?.Invoke(
                    this, new PropertyChangedEventArgs("TenDM"));
            }
        }
        public SanPham()
        {
            MaSP = "";
            TenSP = "";
            Video = "";
            LuotXem = 0;
            YeuThich = 0;
            MoTa = "";
            AnhDaiDien = "";
            NguyenLieu = "";
            SoThanhPhan = 0;
            ThoiGian = "";
            TenDM = "";
        }

        public SanPham(string masp,string tendm, string tensp, string video,int luotxem,int yeuthich,string mota, string anhdaidien,string nguyenlieu,int sothanhphan,string thoigian)
        {
            MaSP = masp;
            TenSP = tensp;
            Video = video;
            LuotXem = luotxem;
            YeuThich = yeuthich;
            MoTa = mota;
            AnhDaiDien = anhdaidien;
            NguyenLieu = nguyenlieu;
            ThoiGian = thoigian;
            SoThanhPhan = sothanhphan;
            TenDM = _tendm;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Find(string id)
        {

        }

        public void Add ()
        {
            string sql;        
            sql = $"INSERT INTO SanPham VALUES ({MaDM}, N'{_tensp}', '{this._video}',{this._luotxem}, 0, N'{_mota}', '{_anhdaidien}',N'{_nguyenlieu}', {_sothanhphan}, '{_thoigian}')";
            Connection.Execute_SQL(sql);
        }

        public void Edit()
        {
            string sql = $"update Table SanPham set yeuthich={_yeuthich} where masp={_masp}";
            Connection.Execute_SQL(sql);
        }
    }
}
