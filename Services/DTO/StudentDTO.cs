namespace UserInfoAPI.Services.DTO
{
    public class StudentDTO
    {
        public string? NationalIDNumber { get; set; } = string.Empty;
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? StudentNumber { get; set; }
        public decimal Salary { get; }
    }
}
