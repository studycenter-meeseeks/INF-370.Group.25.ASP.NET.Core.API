﻿using System.Collections.Generic;
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
                .Select(item => new GetCentreResource
                {
                    Id = item.CentreId,
                    AddressLine1 = item.Address.Line1,
                    AddressLine2 = item.Address.Line2,
                    AddressCityOrTown = item.Address.CityOrTown,
                    Province = item.Address.Province,
                    PostalCode = item.Address.ZipCode,
                })
                .AsNoTracking().ToList();

            return centres;

        }
    }
}