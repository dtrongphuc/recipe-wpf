using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipe
{
    public class StepDo
    {
        public List<string>  step{ get; set; }
        public List<string> Do { get; set; }

        public StepDo()
        {
            step = new List<string>() ;
            Do = new List<string>();
        }
        public StepDo(List<string> _stt, List<string> _buoclam)
        {
            step = _stt;
            Do = _buoclam;           
        }
    }
}
