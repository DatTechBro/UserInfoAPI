using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserInfoAPI.Interfaces;
using UserInfoAPI.Services.DTO;

namespace UserInfoAPI.Controllers
{
    [Route("api/[controller]/[action]")]
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
            if (!ModelState.IsValid)
            {
                // Return a Bad Request with ModelState errors
                return BadRequest(ModelState);
            }

            try
            {
                var result = await _teacherService.CreateTeacher(model);

                if (!result.ValidationErrors.Any()) // Check if the operation was successful
                {
                    return Ok(result);
                }
                else
                {
                    // Return a Bad Request with error message(s) from the result
                    return BadRequest(result.ValidationErrors);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }



        }

        [HttpGet]
        public async Task<IActionResult> GetAllTeachers()
        {
            try
            {
                var result = _teacherService.GetAllTeachers();
                return StatusCode(200,result);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);  
            }
            
        }


        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetTeacher(int id )
        {
            var result = await _teacherService.GetTeacher(id);
            return Ok(result);
        }

    }
}
