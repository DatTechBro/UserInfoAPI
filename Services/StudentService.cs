using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using UserInfoAPI.DataAccess;
using UserInfoAPI.Interfaces;
using UserInfoAPI.Models;
using UserInfoAPI.Services.DTO;
using UserInfoAPI.Services.ViewModels;
using UserInfoAPI.Shared.ViewModels;

namespace UserInfoAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly DataContext _dataContext;
        public StudentService(DataContext dataContext)
        {
            _dataContext = dataContext;  
        }
        public async Task<ResultModel<string>> CreateStudent(StudentDTO model)
        {
            var result = new ResultModel<string>();

            try
            {
                if (model == null)
                {
                    result.AddError("Model Cannot be Empty");
                    return result;
                }
                var isAgeValid = CalculateAge(model.DateOfBirth);
                if (!isAgeValid)
                {
                    result.AddError("Sorry only Teachers below 22 years of age can register.");
                    return result;
                }
                var checkIdNumber = _dataContext.Students.Where(x => x.NationalIDNumber.ToLower().Contains(model.NationalIDNumber.ToLower()));
                if (checkIdNumber.Any())
                {
                    result.AddError("National Id Number Already Exists");
                    return result;
                }

                var student = new Student()
                {
                    NationalIDNumber = model.NationalIDNumber,
                    Name = model.Name,
                    Surname = model.Surname,
                    DateOfBirth = model.DateOfBirth,
                    StudentNumber = model.StudentNumber
                };
                _dataContext.Students.Add(student);
                await _dataContext.SaveChangesAsync();
                result.Message = "Success";
                return result;
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        private static bool CalculateAge(DateTime birthDate)
        {
            DateTime currentDate = DateTime.Today;
            int age = currentDate.Year - birthDate.Year;

            // Check if the birthdate has occurred this year
            if (birthDate.Date > currentDate.AddYears(-age))
            {
                age--;
            }
            return age <= 22;
        }

        public async Task<ResultModel<List<StudentVM>>> GetAllStudents()
        {
            var result = new ResultModel<List<StudentVM>>();
            try
            {
                var students = await _dataContext.Students.ToListAsync();
                var data = students.Select(x => (StudentVM)x).ToList();
                result.Data = data;
                return result;
            }
            catch (Exception ex)
            {
            }
            return result;
        }

        public async Task<ResultModel<StudentVM>> GetStudent(int id)
        {
            var result = new ResultModel<StudentVM>();
            var student = _dataContext.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
            {
                result.AddError($"Teacher with {id} Does Not Exist");
                return result;
            }
            StudentVM studentVM = student;
            result.Message = "Successfully";
            result.Data = studentVM;
            return result;
        }
    }
}
