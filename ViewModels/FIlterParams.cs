using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USTVA.Entities;

namespace USTVA.ViewModels
{
    public class FilterParams
    {
        public int Year { get; set; }
        public string Alcohol { get; set; }
        public string Fatal { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }

        public ViolationType? ViolationType { get; set; }
    }

}
