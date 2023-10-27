namespace UserInfoAPI.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string? NationalIDNumber { get; set; }    
        public string? Name { get; set; } 
        public string? Surname { get; set; }   
        public DateOnly DateOfBirth { get; set; }   
        public string? StudentNumber { get; set; }   
        public decimal Salary { get;}
    }
}
