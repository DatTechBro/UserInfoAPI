namespace UserInfoAPI.Services.DTO
{
    public class TeacherDTO
    {
        public string? NationalIDNumber { get; set; }
        public string? Title { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? TeacherNumber { get; set; }
        public decimal Salary { get; set; }
    }
}
