using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using changelib;
using Microsoft.AspNetCore.Mvc;

namespace changeapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values/5/9
        [HttpGet("{price}/{amount}")]
        public ActionResult<ChangeResult> Get(int price, int amount)
        {
            var change = new ChangeCalculator();
            return change.CalChange(price, amount);
        }
    }
}
