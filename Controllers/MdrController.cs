using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace gatwayapi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MdrController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<MerchantDiscountRates>> Get()
        {
            try
            {
                MdrRepository repository = new MdrRepository();
                return Ok(repository.GetAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
