namespace USTVA.Entities
{
    public enum ArrestType
    {
        Unknown = 0, Marked_Patrol = 1, Unmarked_Patrol = 2, Marked_VASCAR = 3, Unmarked_VASCAR = 4,
        Marked_Stationary_Radar = 5, Unmarked_Stationary_Radar = 6, Marked_Moving_Radar_Stationary = 7,
        Unmarked_Moving_Radar_Stationary = 8, Marked_Moving_Radar_Moving = 9,
        Unmarked_Moving_Radar_Moving = 10, Aircraft_Assist = 11, Motorcycle = 12, Marked_Off_Duty = 13,
        Unmarked_Off_Duty = 14, Foot_Patrol = 15, Mounted_Patrol = 16, Marked_Laser = 17, Unmarked_Laser = 18,
        License_Plate_Recognition = 19
    }
    public enum ViolationType { Unknown = 0, Citation = 1, Warning = 2, NoFilter = 3}

    public class Violation
    {    
        public int ViolationId { get; set; }
        public ViolationType ViolationType { get; set; }
        public ArrestType ArrestType { get; set; }
        public string Charge { get; set; }
        public string Article { get; set; }
       // public int IncidentId { get; set; }
    }
}