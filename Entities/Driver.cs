using System.Text;

namespace USTVA.Entities
{
    public class Driver
    {
        public int DriverId { get; set; }
        public string Race { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CommercialLicense { get; set; }

        // this was used for a command-line utility I was working on when scaffolding the incidents database
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append("_____Driver Details_____\n");
            str.Append($"ID:  {DriverId} \n");
            str.Append($"Race:  {Race}  \n");
            str.Append($"Gender:  {Gender}  \n");
            str.Append($"City:  {City}  \n");
            str.Append($"State:  {State}  \n");
            str.Append("________________________\n");
            return str.ToString();
        }
    }
}