using Application.Dtos;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<ActionResult<IEnumerable<StudentDtoResponse>>> Get()
        {
            try
            {
                var result = await _studentAppServices.OnGetAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDtoResponse>> GetById([FromRoute] int id)
        {
            try
            {
                var result = await _studentAppServices.GetByIdAsync(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update(StudentDto studentDto)
        {
            try
            {
                await _studentAppServices.UpdateAsync(studentDto);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _studentAppServices.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(StudentDto studentDto)
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
