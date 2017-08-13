namespace USTVA.Entities
{
    public enum VehicleType
    {
        Motorcycle = 1, Automobile, StationWagon, Limousine, LightDutyTruck, HeavyDutyTruck,
        RoadTractor, Recreational, Farm, TransitBus, CrossCountryBus,
        SchoolBus, AmbulanceEmergency, AmbulanceNonEmergency, FireEmergency, FireNonEmergency,
        PoliceEmergency, PoliceNonEmergency, Moped, CommercialRig, TandemTrailer,
        MobileHome, TravelHomeTrailer, Camper, UtilityTrailer, BoatTrailer,
        FarmEquipment, Other, Unknown
    }

    public class Vehicle
    {

        public int VehicleId { get; set; }
        public string CommercialVehicle { get; set; }
        public VehicleType Type { get; set; }
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
       // public int IncidentId { get; set; }
    }
}