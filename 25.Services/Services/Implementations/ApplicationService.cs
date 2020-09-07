using System.Collections.Generic;
using System.Linq;
using _25.Data.Context;
using _25.Services.Resources.Application;
using _25.Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _25.Services.Services.Implementations
{
    public class ApplicationService:IApplicationService
    {
        private readonly ApplicationDbContext _context;

        public ApplicationService(ApplicationDbContext context)
        {
            _context = context;
        }


        public List<GetSubSystemResource> GetAllSubSystems()
        {
            var subSystems = _context.SubSystems.Select(item => new GetSubSystemResource
            {
                Id = item.SubSystemId,
                SubSystem = item.Name
            }).AsNoTracking().ToList();

            return subSystems;
        }
    }
}