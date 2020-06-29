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
        public string masp { get; set; }
        List<StepDo> stepdo { get; set; }
        public List<string> hinhanh { get; set; }

        public DetailSP()
        {
            stepdo = new List<StepDo>();
            hinhanh = new List<string>();
        }

        //chưa làm
        //public DetailSP(List<string> _stt, List<string> _buoclam, List<string> _hinhanh)
        //{
        //    stepdo = new List<StepDo>();
        //    hinhanh = _hinhanh;
        //}

        public void Find(string id)
        {
            string sql = $"SELECT* FROM CTSP WHERE MaSP = {id} ORDER BY STT";
            DataTable dt = Connection.GetALL_Data(sql);
            foreach(DataRow row in dt.Rows)
            {
                StepDo stp = new StepDo();
                masp = row["MaSP"].ToString();               
                stp.step.Add(row["STT"].ToString());
                stp.Do.Add(row["Buoclam"].ToString());
                stepdo.Add(stp);
            }
            string sql2 = $"select* from HinhAnh where MaSP = {id}";
            DataTable dt2 = Connection.GetALL_Data(sql2);
            foreach(DataRow row2 in dt2.Rows)
            {
                this.hinhanh.Add(row2["HinhAnh"].ToString());
            }
        }

        //public void Add()
        //{
        //    string sql = "SELECT IDENT_CURRENT('{SanPham}') as LastID";
        //    masp = Connection.GetCount_Data(sql).ToString(); 
        //    for (int  i= 1; i <= STT.Count(); i++)
        //    {
        //        sql = $"INSERT INTO CTSP VALUES ({masp}, {i}, N'{buoclam[i-1]}')";
        //        Connection.Execute_SQL(sql);
        //        sql = $"INSERT INTO HinhAnh VALUES ({masp}, '{hinhanh[i-1]}')";
        //        Connection.Execute_SQL(sql);
        //    }

            
        //}
    }
}
