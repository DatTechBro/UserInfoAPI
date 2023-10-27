using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using UserInfoAPI.DataAccess;
using UserInfoAPI.Interfaces;
using UserInfoAPI.Models;
using UserInfoAPI.Services.DTO;
using UserInfoAPI.Services.ViewModels;
using UserInfoAPI.Shared.ViewModels;

namespace UserInfoAPI.Services
{
    public class TeacherService : ITeacherService
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<TeacherService> _logger;
        public TeacherService(DataContext dataContext, 
                                ILogger<TeacherService> logger
                                ) 
        {
            _dataContext = dataContext;
            _logger = logger;
        } 
        public async Task<ResultModel<string>> CreateTeacher(TeacherDTO model)
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
                var checkIdNumber = _dataContext.Teachers.Where(x => x.NationalIDNumber.ToLower().Contains(model.NationalIDNumber.ToLower()));
                if (checkIdNumber.Any())
                {
                    result.AddError("National Id Number Already Exists");
                    return result;
                }

                var teacher = new Teacher()
                {
                    NationalIDNumber = model.NationalIDNumber,
                    Title = model.Title,
                    Name = model.Name,
                    Surname = model.Surname,
                    DateOfBirth = model.DateOfBirth,
                    TeacherNumber = model.TeacherNumber,
                    Salary = model.Salary
                };
                _dataContext.Teachers.Add(teacher);
                await _dataContext.SaveChangesAsync();
                result.Message = "Success";
                return result;
            }
            catch (Exception ex) 
            {
                result.AddError("An error occurred: " + ex.Message);
            }
            return result;
        }

        public List<Teacher> GetAllTeachers()
        {
            var teachers = _dataContext.Teachers.ToList();
            return teachers;  
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
            return age <= 21;
        }

        public async Task<ResultModel<TeacherVM>> GetTeacher(int Id)
        {
            var result = new ResultModel<TeacherVM>();
            try 
            {
                var teacher = await _dataContext.Teachers.FirstOrDefaultAsync(x => x.Id == Id);
                if (teacher == null)
                {
                    result.AddError($"Teacher with {Id} Does Not Exist");
                    return result;
                }
                TeacherVM teacherVM = teacher;
                result.Message = "Successfully";
                result.Data = teacherVM;
                return result;
            }
            catch (Exception ex) 
            {
                result.AddError("An error occurred: " + ex.Message);
            }
            return result;
           
            
        }
    }
}
