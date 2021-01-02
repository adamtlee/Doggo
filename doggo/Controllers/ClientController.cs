using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doggo.Controllers
{
    [ApiController]
    [Route("api/clients")]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        public IActionResult Index()
        {
            // TODO
            return Ok(DoggoDataStore.DoggoData.Clients);
        }
    }
}
