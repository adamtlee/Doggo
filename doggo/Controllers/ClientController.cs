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
            return Ok(DoggoDataStore.DoggoData.Clients);
        }

        [HttpGet("{id}")]
        public IActionResult GetClientById(int id)
        {
            var clientToReturn = DoggoDataStore.DoggoData.Clients
                                    .FirstOrDefault(c => c.Id == id);
            if (clientToReturn == null)
            {
                return NotFound();
            }

            return Ok(clientToReturn);
        }
    }
}
