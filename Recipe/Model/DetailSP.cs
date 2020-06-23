using Recipe.Modle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Model
{
    public class DetailSP
    {
        public List<string> STT { get; set; }
        public List<string> buoclam { get; set; }
        public List<string> hinhanh { get; set; }

        public DetailSP()
        {
            STT = new List<string>();
            buoclam = new List<string>();
            hinhanh = new List<string>();
        }

        public DetailSP(List<string> _stt, List<string> _buoclam, List<string> _hinhanh)
        {
            STT = _stt;
            buoclam = _buoclam;
            hinhanh = _hinhanh;
        }

        public void Find(string id)
        {
            string sql = $"SELECT* FROM CTSP WHERE MaSP = {id} ORDER BY STT";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach(DataRow row in dt.Rows)
            {
                
                STT.Add(row["STT"].ToString());
                buoclam.Add(row["Buoclam"].ToString());
            }
            string sql2 = $"select* from HinhAnh where MaSP = {id}";
            DataTable dt2 = Connection.GetALL_Data(sql2);
            foreach(DataRow row2 in dt2.Rows)
            {
                this.hinhanh.Add(row2["HinhAnh"].ToString());
            }
        }
    }
}
