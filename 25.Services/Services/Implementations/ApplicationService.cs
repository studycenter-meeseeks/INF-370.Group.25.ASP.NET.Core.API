using System.Collections.Generic;
using System.Linq;
using _25.Core.System;
using _25.Data.Context;
using _25.Services.Resources.Application;
using _25.Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _25.Services.Services.Implementations
{
    public class ApplicationService : IApplicationService
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

        public List<GetGenericNameAndIdResource> GetAllTitles()
        {
            var titles = _context.Titles.Select(item => new GetGenericNameAndIdResource
            {
                Id = item.TitleId,
                Name = item.Name
            }).AsNoTracking().ToList();

            return titles;
        }

        public List<GetGenericNameAndIdResource> GetAllGenders()
        {
            var genders = _context.Genders.Select(item => new GetGenericNameAndIdResource
            {
                Id = item.GenderId,
                Name = item.Name
            }).AsNoTracking().ToList();

            return genders;
        }

        public Centre AddCentre(CreateCentreResource resource)
        {

            var address = new CentreAddress
            {
                Line1 = resource.AddressLine1,
                Line2 = resource.AddressLine2,
                CityOrTown = resource.AddressCityOrTown,
                Province = resource.Province,
                ZipCode = resource.ZipCode
            };

            var newCenter = new Centre
            {
                Name = resource.Name,
                Address = address

            };
            _context.Centres.Add(newCenter);
            _context.SaveChanges();

            return newCenter;


        }

        public List<GetCentreResource> GetAlLCentres()
        {
            var centres = _context.Centres
                .Include(item=>item.Psychologists)
                .Include(item=>item.Employees)
                .Select(item => new GetCentreResource
                {
                    Id = item.CentreId,
                    Name = item.Name,
                    Location = item.Address.CityOrTown,
                    EmployeesCount = item.Employees.Count,
                    PsychologistsCount = item.Psychologists.Where(psychologistCentre=> psychologistCentre.CentreId == item.CentreId).ToList().Count,
                    AddressLine1 = item.Address.Line1,
                    AddressLine2 = item.Address.Line2,
                    AddressCityOrTown = item.Address.CityOrTown,
                    Province = item.Address.Province,
                    PostalCode = item.Address.ZipCode

                })
                .AsNoTracking().ToList();

            return centres;

        }
    }
}