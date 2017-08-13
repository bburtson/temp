using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USTVA.Entities;

namespace USTVA.Services
{
    public class ArrangedInMemoryIncidentData 
    {
        public void Add(Incident incident)
        {
            throw new NotImplementedException();
        }

        public void BulkAdd(IEnumerable<Incident> incidents)
        {
            //...No-Op...
        }

        public void Delete(Incident incident)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void DeleteAll(string table)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Incident> Get()
        {
            return new List<Incident>()
            {
                new Incident
                {
                    IncidentId =1,
                    DateTime = DateTime.Now,
                    Description = "SOME MOCK DESCRIPTION",
                    SeatBelts ="Yes",
                    Fatal ="Yes",
                    Alcohol ="Yes",
                    Vehicle = new Vehicle{ Make="Volvo"},
                    Violation = new Violation { ViolationType = ViolationType.Warning},
                    Driver = new Driver
                    {
                       City ="Nowhere",
                       State = "MO", Gender =
                       "F",
                       Race = "WHITE",
                       CommercialLicense = "No"
                    },

                    Latitude = 0.00123124m,
                    Longitude = -70.33535662m

                },

                new Incident
                {
                    IncidentId =2,
                    DateTime = DateTime.Now,
                    Description = "SOME MOCK DESCRIPTION",
                    SeatBelts ="Yes",
                    Fatal ="Yes",
                    Alcohol ="Yes",
                    Vehicle = new Vehicle{ Make="Volvo"},
                    Violation = new Violation { ViolationType = ViolationType.Warning},
                    Driver = new Driver
                    {
                       City ="Nowhere",
                       State = "MO", Gender =
                       "F",
                       Race = "WHITE",
                       CommercialLicense = "No"
                    },

                    Latitude = 0.00123124m,
                    Longitude = -70.33535662m

                },

                new Incident
                {
                    IncidentId =3,
                    DateTime = DateTime.Now,
                    Description = "SOME MOCK DESCRIPTION",
                    SeatBelts ="Yes",
                    Fatal ="Yes",
                    Alcohol ="Yes",
                    Vehicle = new Vehicle{ Make="Volvo"},
                    Violation = new Violation { ViolationType = ViolationType.Warning},
                    Driver = new Driver
                    {
                       City ="Nowhere",
                       State = "MO", Gender =
                       "F",
                       Race = "WHITE",
                       CommercialLicense = "No"
                    },

                    Latitude = 0.00123124m,
                    Longitude = -70.33535662m

                }
            };
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
