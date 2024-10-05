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

        public PremiumController(ILogger<PremiumController> logger, IPremiumAppServices premiumAppServices )
        {
            _logger = logger;
            _premiumAppServices = premiumAppServices;
        }

        //estudar verbos HTTP - post/get/delete/put
        //estudar IEnumerable
        //estudar flurl

        [HttpGet]
        //[HttpPost]
        public async Task<ActionResult<IEnumerable<Premium>>> Get()
        {
           var result =  await _premiumAppServices.OnGetAsync();
           return Ok(result);
        }






    }
}
