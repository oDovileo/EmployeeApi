namespace EmployeeApi.Dtos
{
    public class CreationEmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }        
        public int? CompanyId { get; set; }
        public string GenderType { get; set; }
    }
}
