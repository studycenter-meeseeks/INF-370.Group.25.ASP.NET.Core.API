using System.Collections.Generic;
using System.Linq;
using _25.Core.System;
using _25.Core.User;
using _25.Data.Context;
using _25.Services.Extensions.System;
using _25.Services.Resources.User;
using _25.Services.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace _25.Services.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }


        public Psychologist AddPsychologist(CreatePsychologistResource resource, string generatedPassword)
        {
            var newPsychologist = new Psychologist
            {
                FullName = resource.FullName,
                PracticeNo = resource.PracticeNo,
                HPCSANo = resource.HPCSANo,
                About = resource.About,
                PracticeTitle = resource.PracticeTitle,
                WorkContactNumber = resource.WorkContactNumber,
                GenderId = resource.GenderId,
                TitleId = resource.TitleId,
                CellContactNumber = resource.CellContactNumber,
                EmailAddress = resource.EmailAddress,
                GeneratedPassword = generatedPassword
            };
            _context.Psychologists.Add(newPsychologist);
            _context.SaveChanges();

            foreach (var resourceCentre in resource.Centres)
            {
                var assignPsychologistToCenter = new PsychologistCentre
                {
                    CentreId = resourceCentre,
                    PsychologistId = newPsychologist.PsychologistId
                };
                _context.PsychologistCentres.Add(assignPsychologistToCenter);
                _context.SaveChanges();
            }

            foreach (var qualification in resource.Qualifications)
            {
                var newQualification = new PsychologistQualification
                {
                    Name = qualification,
                    PsychologistId = newPsychologist.PsychologistId
                };
                _context.PsychologistQualifications.Add(newQualification);
                _context.SaveChanges();

            }

            foreach (var service in resource.Services)
            {
                var newService = new PsychologistService
                {
                    Name = service,
                    PsychologistId = newPsychologist.PsychologistId
                };
                _context.PsychologistServices.Add(newService);
                _context.SaveChanges();
            }

            AuditLogExtenstion.LogActivity("Super Admin", SupportedLogOperation.Create, "Create a new Psychologist");
            return newPsychologist;
        }

        public List<GetPsychologistResource> GetPsychologists()
        {

            var psychologists = _context.Psychologists
                .Select(item => new GetPsychologistResource
                {
                    Id = item.PsychologistId,
                    FullName = item.FullName,
                    PracticeNo = item.PracticeNo,
                    HPCSANo = item.HPCSANo,
                    PracticeTitle = item.PracticeTitle

                }).AsNoTracking().ToList();
            return psychologists;
        }
    }
}