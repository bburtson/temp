using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USTVA.Entities;
using USTVA.ViewModels;

namespace USTVA.Services
{
    public class SqlIncidentData : IIncidentData
    {
        private IncidentDbContext _context;
        private IConfigurationRoot _config;

        public SqlIncidentData(IncidentDbContext context, IConfigurationRoot config)
        {
            _config = config;
            _context = context;
        }

 
        public IQueryable<Incident> GetAll()
        {


            _context.Incidents.Include(x => x.Driver);
            return _context.Incidents.AsQueryable();
        }

        public async Task<IQueryable<Incident>> GetByUserFilterParams(FilterParams filterParams)
        {
            return await Task.Run(async() =>
            {

                var incidents = await GetByYearAsync(filterParams.Year).ConfigureAwait(false);

                if (filterParams.Alcohol != null && filterParams.Alcohol != "No Filter")
                {
                    incidents = incidents.Where(p => p.Alcohol == filterParams.Alcohol);
                }
                if (filterParams.Fatal != null && filterParams.Fatal != "No Filter")
                {
                    incidents = incidents.Where(p => p.Fatal == filterParams.Fatal);
                }
                if (filterParams.Race != null && filterParams.Race != "No Filter")
                {
                    incidents = incidents.Where(p => p.Driver.Race == filterParams.Race);
                }
                if (filterParams.Gender != null && filterParams.Gender != "No Filter")
                {
                    incidents = incidents.Where(p => p.Driver.Gender == filterParams.Gender.Substring(0, 1));
                }
                if (filterParams.ViolationType != ViolationType.NoFilter)
                {
                    incidents = incidents.Where(p => p.Violation.ViolationType == filterParams.ViolationType);
                }
                return incidents;

            }).ConfigureAwait(false);
        }


        public Incident GetById(int id)
        {
            return _context.Incidents.FirstOrDefault(i => i.IncidentId == id);
        }

        public async Task<Incident> GetByIdAsync(int id)
        {
            return await Task.Run(() => _context.Incidents.Include(x => x.Driver)
                                                          .Include(x=>x.Violation)
                                                          .Include(x=>x.Vehicle)
                                                          .FirstOrDefault(i => i.IncidentId == id));

        }


        public async Task<IQueryable<Incident>> GetByYearAsync(int year)
        {
            return await Task.Run(() => _context.Incidents.Where(i => i.DateTime.Year == year)).ConfigureAwait(false);
        }
    }
}
