using System.Collections.Generic;
using _25.Services.Resources.Application;

namespace _25.Services.Services.Interfaces
{
    public interface IApplicationService
    {
         List<GetGenericNameAndIdResource> GetAllSubSystems();
         List<GetGenericNameAndIdResource> GetAllOperations();
    }
}