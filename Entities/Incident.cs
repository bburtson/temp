using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace USTVA.Entities
{
    public class Incident 
    {
        public int IncidentId { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public string SeatBelts { get; set; }
        public string Fatal { get; set; }
        public string Alcohol { get; set; }
        
        public virtual Vehicle Vehicle { get; set; }
        public virtual Violation Violation { get; set; }
        public virtual Driver Driver { get; set; }
        
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public override string ToString()
        {

            StringBuilder str = new StringBuilder();
            str.Append("________Incident________\n");
            str.Append($"ID:  {IncidentId} \n");
            str.Append($"DateTime:  {DateTime}  \n");
            str.Append($"Fatal:  {Fatal}  \n");
            str.Append($"Seatbelts:  {SeatBelts}  \n");
            str.Append($"Alcohol:  {Alcohol}  \n");
            str.Append($"******Description******   \n");
            str.Append($"{Description}  \n");

            return str.ToString();
        }
    }
}