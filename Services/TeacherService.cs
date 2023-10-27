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

            }
            return result;
        }

        public async Task<ResultModel<List<TeacherVM>>>GetAllTeachers()
        {
            var result = new ResultModel<List<TeacherVM>>();
            try
            {
                var teachers = await _dataContext.Teachers.ToListAsync();
                var data = teachers.Select(x => (TeacherVM)x).ToList();
                result.Data = data;
                return result;
            }
            catch (Exception ex) 
            {
            }
            return result;
        }

        public async Task<ResultModel<TeacherVM>> GetTeacher(int Id)
        {
            var result = new ResultModel<TeacherVM>();  
            var teacher = _dataContext.Teachers.FirstOrDefault(x => x.Id == Id);  
            if(teacher == null)
            {
                result.AddError($"Teacher with {Id} Does Not Exist");
                return result;
            }
            TeacherVM teacherVM = teacher;
            result.Message = "Successfully";
            result.Data = teacherVM;    
            return result;
            
        }
    }
}
