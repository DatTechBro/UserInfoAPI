using UserInfoAPI.Services.DTO;
using UserInfoAPI.Services.ViewModels;
using UserInfoAPI.Shared.ViewModels;

namespace UserInfoAPI.Interfaces
{
    public interface IStudentService
    {
        Task<ResultModel<string>> CreateStudent(StudentDTO model);
        Task<ResultModel<List<StudentVM>>> GetAllStudents();
        Task<ResultModel<StudentVM>> GetStudent(int id);    
    }
}
