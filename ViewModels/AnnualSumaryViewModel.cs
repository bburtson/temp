using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace USTVA.ViewModels
{
    
    public class AnnualSumaryViewModel
    {
        [Range(2012, 2017)]
        public int Year { get; set; }
        public int TotalIncidents { get; set; }
        public int Fatalities { get; set; }
    }
}
