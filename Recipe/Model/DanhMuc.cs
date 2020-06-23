using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe.Model
{
    public class DanhMuc
    {
        public string MaDM { get; set; }
       
        public string TenDM { get; set; }

        public DanhMuc()
        {
            MaDM = "";
            TenDM = "";
        }
        
    }
}
