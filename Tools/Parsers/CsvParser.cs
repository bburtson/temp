using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using USTVA.Tools.Extenstions.String;
using USTVA.Entities;


namespace USTVACommandLine
{
    public class CsvParser
    {
        
        private static string defaultPath = "Traffic_Violations.csv";
        private static string _path;
        private static IEnumerable<Incident> _incidentCollection;
        public static IEnumerable<Incident> incidentCollection
        {
            get
            {
                if (_incidentCollection == null)
                    _incidentCollection = new CsvParser().ProcessFile();

                return _incidentCollection;
            }
        }

        public static string Path
        {
            get
            {
                if (string.IsNullOrEmpty(_path)) _path = defaultPath;

                return _path;
            }
        }
        
        public IEnumerable<Incident> ProcessFile()
        {
            var lines = File.ReadAllLines(Path)
                                .Skip(1)
                                .Where(ln => HasValidCount(ln, 36))
                                .Select(ToIncident);
                                 

            return lines;
        }

        public Incident ToIncident(string line)
        {
            var omissions = new string[] {"Wheaton", "Silver Spring", "Gaithersburg / Montgomery Village",
                "Germantown", "Bethesda", "Rockville"};

            var invalidRaces = new string[] { "Transportation Article", "Maryland Rules" };

            var validColors = new string[] { "GRAY", "RED", "SILVER", "BLACK", "WHITE",
                "N/A", "GREEN", "GOLD", "ORANGE", "BLUE", "BEIGE", "CREAM", "TAN",  "PURPLE",
            "MAROON", "BROWN", "BRONZE", "YELLOW", "MULTICOLOR", "COPPER", "PINK" };

            var fields = line.Split(',', '"', false).ToArray();

            return new Incident
            {
                DateTime = DateTime.Parse($"{fields[0]},{fields[1]}"),
                Latitude = ParseLocation(line, 1),
                Longitude = ParseLocation(line, 2),
                Description = fields[4].RemoveAny(omissions),
                SeatBelts = fields[9],
                Fatal = fields[12],
                Alcohol = ParseAlcohol(fields),

                Driver = new Driver
                {
                    Race = fields[28].ReplaceAny("OTHER", invalidRaces),
                    Gender = fields[29].ReplaceAny("U", "Yes", "No"),
                    City = fields[30],
                    State = ValidateState(fields[31]),
                    CommercialLicense = fields[13]
                },

                Vehicle = new Vehicle
                {
                    CommercialVehicle = fields[15],
                    Type = ParseVehicleType(fields[19]),
                    Year = ParseVehicleYear(fields[20]),
                    Make = ParseVehicleMake(fields[21]),
                    Model = fields[22].Trim(),
                    Color = KeepAny(fields[23], validColors)
                },

                Violation = new Violation
                {
                    ViolationType = ParseViolationType(fields[24]),
                    ArrestType = ParseArrestType(fields[33]),
                    Charge = ParseCharge(fields[25]),
                    Article = ParseArticle(fields[26])
                }
            };
        }

        private string ParseAlcohol(string[] fields)
        {
            if (fields[4].Contains("ALCOHOL") ||
                fields[4].Contains("LCOHOL") ||
                fields[4].Contains("alcohol"))
            {
                fields[16] = "Yes";
            }
            return fields[16];
        }

        private bool HasValidCount(string line, int desired)
        {
            return line.Split(',', '"', false).ToArray().Length == 36;
        }

        private string ValidateState(string field)
        {
            if (string.IsNullOrWhiteSpace(field) || field.Length == 1)
            {
                field = "??";
            }

            else if (field.Length > 2) field = field.Trim().Substring(0, 2);

            return field;
        }

        private VehicleType ParseVehicleType(string field)
        {
            var sub = field.Substring(0, 2);

            if (sub.Contains("No")) return VehicleType.Unknown;

            return (VehicleType)int.Parse(sub);
        }

        private int ParseVehicleYear(string field)
        {
            if (field.Length > 3)
            {
                var result = int.Parse(field);

                if (result < 2017 && result > 1900) return result;
            }

            return 0;
        }

        private string ParseVehicleMake(string field)
        {
            if (field.Contains("VAL")) return field.Remove(field.IndexOf("VAL"));

            return field;
        }

        private string KeepAny(string field, string[] toKeep)
        {

            for (int i = 0; i < toKeep.Length; i++)
            {

                if (field.Contains("LUE")) return "BLUE";

                if (field.Contains("REEN")) return "GREEN";

                if (field.Contains(toKeep[i])) return toKeep[i];
            }

            return "N/A";
        }

        private decimal ParseLocation(string line, int oneortwo)
        {
            var location = new string[2];
            var latLon = new decimal[2];

            if (line.Contains('(') && line.Contains(')'))
            {
                location = line.Substring(line.LastIndexOf('(') + 1).Split(',');
                location[1] = location[1].Trim('"', ')');
            }

            decimal.TryParse(location[0], out latLon[0]);
            decimal.TryParse(location[1], out latLon[1]);

            var temp = latLon;
            if (latLon[0] < 0) latLon[0] = temp[1];

            if (latLon[1] > 0) latLon[1] = temp[0];

            if (latLon[1] > 0) { latLon[0] = 0; latLon[1] = 0; }

            //location[0] = latLon[0].ToString();
            //location[1] = latLon[1].ToString();
            if (oneortwo == 1) return latLon[0];
            if (oneortwo == 2) return latLon[1];

            return 0;
        }

        private ArrestType ParseArrestType(string field)
        {
            var result = ArrestType.Unknown;
            var letters = "0ABCDEFGHIJKLMNOPQRS";

            if (field.Length < 3) return result;

            for (int i = 0; i < letters.Length; i++)
            {
                if (field[0] == letters[i]) result = (ArrestType)i;
            }

            return result;
        }

        private ViolationType ParseViolationType(string field)
        {
            if (field.Contains("Citation")) return ViolationType.Citation;
            if (field.Contains("Warning")) return ViolationType.Warning;

            return ViolationType.Unknown;
        }

        private string ParseCharge(string field)
        {
            var result = 0;
            if (field.Length > 0)
            {
                if (int.TryParse(field.Substring(0, 1), out result) && !field.Contains('*'))
                {
                    return field;
                }
            }
            return "N/A";
        }

        private string ParseArticle(string field)
        {
            if (field.Contains("Transportation") || field.Contains("Maryland Rules")) return field;

            return "N/A";
        }
    }
}
