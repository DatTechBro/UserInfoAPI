using UserInfoAPI.Models;

namespace UserInfoAPI.Services.ViewModels
{
    public class TeacherVM
    {
        public string? NationalIDNumber { get; set; }
        public string? Title { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? TeacherNumber { get; set; }
        public decimal Salary { get; set; }

        public static implicit operator TeacherVM(Teacher model)
        {
            return model == null ? null : new TeacherVM
            {
                NationalIDNumber = model.NationalIDNumber,
                Title = model.Title,
                Surname = model.Surname,
                DateOfBirth = model.DateOfBirth,
                TeacherNumber = model.TeacherNumber,
                Salary = model.Salary
            };
        }
    }
}
