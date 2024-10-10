using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PremiumController : ControllerBase
    {
        private readonly ILogger<PremiumController> _logger;
        private readonly IPremiumAppServices _premiumAppServices;

        public PremiumController(ILogger<PremiumController> logger, IPremiumAppServices premiumAppServices)
        {
            _logger = logger;
            _premiumAppServices = premiumAppServices;
        }

        //estudar verbos HTTP - post/get/delete/put
        //estudar IEnumerable -> Ele é mais leve que as listas puras, além de ser só readonly. Não permite que eu manipule a lista, só fazer consulta
        //estudar flurl  -> como fazer requisição e como capturar mensagem de erro
        //estudar DTO

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Premium>>> Get()
        {
            var result = await _premiumAppServices.OnGetAsync();
            return Ok(result);
        }


        [HttpGet("GetById")]
        public async Task<ActionResult<Premium>> GetById(int id)
        {
            var result = await _premiumAppServices.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpPut]
        public ActionResult Update(Premium premium)
        {
            _premiumAppServices.Update(premium);
            return Ok();
        }


        [HttpDelete]
        public ActionResult Delete(Premium premium)
        {
            _premiumAppServices.DeleteAsync(premium);
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
            
            var premium = new Premium();
            premium.Name = Name;
            premium.StartDate = StartDate;
            premium.EndtDate = EndDate;
            premium.StudentId = StudentId;

            _premiumAppServices.CreateAsync(premium);
            return Ok();
        }










    }
}
