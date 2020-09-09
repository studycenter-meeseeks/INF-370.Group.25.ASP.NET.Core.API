using System.Collections.Generic;
using _25.Core.User;
using _25.Services.Resources.User;

namespace _25.Services.Services.Interfaces
{
    public interface IUserService
    {
        Psychologist AddPsychologist(CreatePsychologistResource resource, string generatedPassword);
        List<GetPsychologistResource> GetPsychologists();
    }
}