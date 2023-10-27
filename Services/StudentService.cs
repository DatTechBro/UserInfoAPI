using Microsoft.AspNetCore.Http.HttpResults;
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

        public Task<ResultModel<List<StudentVM>>> GetAllStudents()
        {
            throw new NotImplementedException();
        }

        public Task<ResultModel<StudentVM>> GetStudent(int id)
        {
            throw new NotImplementedException();
        }
    }
}
