using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Application.Dtos.Request;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IStudentAppServices _studentAppServices;

        public StudentController(ILogger<StudentController> logger, IStudentAppServices studentAppServices)
        {
            _logger = logger;
            _studentAppServices = studentAppServices;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Student>>> Get()
        {
            var result = await _studentAppServices.OnGetAsync();
            return Ok(result);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetById([FromRoute]int id)
        {
            var result = await _studentAppServices.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult> Update(int id, StudentDto studentDto)
        {
            await _studentAppServices.UpdateAsync(id, studentDto);
            return Ok();
        }


        [HttpDelete]
        public async Task <ActionResult> Delete(int id)
        {
            await _studentAppServices.DeleteAsync(id);
            return Ok();
        }


        [HttpPost]
        public async Task<ActionResult> Create([FromBody] StudentDto studentDto)
        {
            try
            {
                await _studentAppServices.CreateAsync(studentDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }














    }
}
