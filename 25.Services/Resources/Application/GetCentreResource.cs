namespace _25.Services.Resources.Application
{
    public class GetCentreResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int PsychologistsCount { get; set; }
        public int EmployeesCount { get; set; }


        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressCityOrTown { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
    }
}