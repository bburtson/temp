using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using USTVA.Entities;
using USTVA.ViewModels;

namespace USTVA.Services
{
    public interface IIncidentData
    {
        Incident GetById(int id);
        Task<Incident> GetByIdAsync(int id);
        IQueryable<Incident> GetAll();

        Task<IQueryable<Incident>> GetByUserFilterParams(FilterParams filterParams);
        Task<IQueryable<Incident>> GetByYearAsync(int year);
    }
}
