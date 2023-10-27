using UserInfoAPI.Models;

namespace UserInfoAPI.Services.ViewModels
{
    public class StudentVM
    {
        public string? NationalIDNumber { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? StudentNumber { get; set; }

        public static implicit operator StudentVM(Student model)
            {
                return model == null ? null : new StudentVM
                {
                    NationalIDNumber = model.NationalIDNumber,
                    Name = model.Name,  
                    Surname = model.Surname,    
                    DateOfBirth = model.DateOfBirth,    
                    StudentNumber = model.StudentNumber,    
                };
            }
        }
}
