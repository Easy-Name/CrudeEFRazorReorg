using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
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
        public async Task<ActionResult<IEnumerable<Student>>> Get()
        {
            var result = await _studentAppServices.OnGetAsync();
            return Ok(result);
        }


        [HttpGet("GetById")]
        public async Task<ActionResult<Student>> GetById(int id)
        {
            var result = await _studentAppServices.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPut]
        public ActionResult Update(Student student)
        {
            _studentAppServices.Update(student);
            return Ok();
        }


        [HttpDelete]
        public ActionResult Delete(Student student)
        {
            _studentAppServices.DeleteAsync(student);
            return Ok();
        }



        /*[HttpPost]
        public ActionResult Create(Premium premium)
        {
            _premiumAppServices.CreateAsync(premium);
            return Ok();
        }*/

        [HttpPost]
        public ActionResult Create(string Name, DateTime StartDate, DateTime EndDate, int StudentId)
        {

            var student = new Student();
            student.Name = Name;


            _studentAppServices.CreateAsync(student);
            return Ok();
        }














    }
}
