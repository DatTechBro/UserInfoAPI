using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserInfoAPI.Interfaces;
using UserInfoAPI.Services;
using UserInfoAPI.Services.DTO;

namespace UserInfoAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;   

        public StudentController(IStudentService studentService) 
        {
            _studentService = studentService;
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateStudent(StudentDTO model)
        {
            var result = await _studentService.CreateStudent(model);
            return Ok(result);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var result = await _studentService.GetAllStudents();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var result = await _studentService.GetStudent(id);  
            return Ok(result);
        }


    }
}
