using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USTVA.Services;

namespace USTVA.Entities
{
    public class IncidentRepository
    {
        SqlIncidentData _incidents;

        public IncidentRepository(SqlIncidentData incidents)
        {
            _incidents = incidents;
        }
    }
}
