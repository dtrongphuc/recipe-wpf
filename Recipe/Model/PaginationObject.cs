using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipe.Modle;

namespace Recipe.Model
{
    public class PaginationObject
    {
        public static int Sum_record { get; set; }
        public static int currpage { get; set; }
        public static  int record1page = 8;
        public static  List<SanPham> listsp { get; set; }
        

        public PaginationObject()
        {
            Sum_record = 0;
            currpage = 1;
            listsp= new List<SanPham>();
        }

        public static List<SanPham> GetSPPagination(int _curr)
        {
            currpage = _curr;
            Sum_record = Get_ListObject.Get_CountALLSP();
            int sotranghienhanh = (currpage - 1) * PaginationObject.record1page;
            listsp = Get_ListObject.Get_AllSP(sotranghienhanh, record1page);
            return listsp;
        }
    }
}
