using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserInfoAPI.Interfaces;
using UserInfoAPI.Services.DTO;

namespace UserInfoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatetTeacher([FromBody]TeacherDTO model)
        {
            var result = await _teacherService.CreateTeacher(model);
            return Ok(result);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            var result = await _teacherService.GetAllTeachers();
            return Ok(result);
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTeacher(int id )
        {
            var result = await _teacherService.GetTeacher(id);
            return Ok(result);
        }

    }
}
