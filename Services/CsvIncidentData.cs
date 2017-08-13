using System;
using System.Collections.Generic;
using USTVA.Entities;

using USTVACommandLine;

namespace USTVA.Services
{

    public class CsvIncidentData 
    {
        private IEnumerable<Incident> _incidents;

        public CsvIncidentData(CsvParser parser)
        {
            _incidents = parser.ProcessFile();
        }

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
            return _incidents;
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
