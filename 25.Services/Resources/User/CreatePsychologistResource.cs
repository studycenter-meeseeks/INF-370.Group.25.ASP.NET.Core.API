using System.Collections.Generic;

namespace _25.Services.Resources.User
{
    public class CreatePsychologistResource
    {
        public string FullName { get; set; }
        public string PracticeNo { get; set; }
        public string HPCSANo { get; set; }
        public string About { get; set; }
        public string PracticeTitle { get; set; }
        public string WorkContactNumber { get; set; }
        public string CellContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public int GenderId { get; set; }
        public int TitleId { get; set; }

        public List<int> Centres { get; set; }
        public List<string> Qualifications { get; set; }
        public List<string> Services { get; set; }

        public CreatePsychologistResource()
        {
            Centres =new List<int>();
            Qualifications = new List<string>();
            Services = new List<string>();
        }

    }
}