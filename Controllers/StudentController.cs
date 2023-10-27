using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserInfoAPI.Interfaces;
using UserInfoAPI.Services.DTO;

namespace UserInfoAPI.Controllers
{
    [Route("api/[controller]")]
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
            //var result = _studentService.CreateStudent(model);
            return Ok();

        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            //var result = _studentService.GetAllStudents();  
            return Ok();
        }


    }
}
