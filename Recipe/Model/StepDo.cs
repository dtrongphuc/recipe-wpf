using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe
{
    public class StepDo
    {
        public string  step{ get; set; }
        public string Do { get; set; }

        public StepDo()
        {
            step = "" ;
            Do = "";
        }
        public StepDo(string _stt, string _buoclam)
        {
            step = _stt;
            Do = _buoclam;           
        }
    }
}
