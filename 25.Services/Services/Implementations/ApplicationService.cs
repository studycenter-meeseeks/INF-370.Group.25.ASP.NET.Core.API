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


        public List<GetGenericNameAndIdResource> GetAllSubSystems()
        {
            var subSystems = _context.SubSystems.Select(item => new GetGenericNameAndIdResource
            {
                Id = item.SubSystemId,
                Name = item.Name
            }).AsNoTracking().ToList();

            return subSystems;
        }

        public List<GetGenericNameAndIdResource> GetAllOperations()
        {
            var operations = _context.Operations.Select(item => new GetGenericNameAndIdResource
            {
                Id = item.OperationId,
                Name = item.Name
            }).AsNoTracking().ToList();

            return operations;
        }
    }
}