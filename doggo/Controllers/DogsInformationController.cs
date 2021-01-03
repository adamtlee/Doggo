using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doggo.Controllers
{
    [ApiController]
    [Route("api/clients/{clientId}/dogs")]
    public class DogsInformationController : ControllerBase
    {
        [HttpGet("{id}", Name = "Index")]
        public IActionResult Index(int clientId, int id)
        {
            var client = DoggoDataStore.DoggoData.Clients
                .FirstOrDefault(c => c.Id == clientId);

            if (client == null)
            {
                return NotFound();
            }

            var dogs = client.Dogs
                .FirstOrDefault(c => c.Id == id);

            if(dogs == null)
            {
                return NotFound();
            }

            return Ok(dogs);
        }
    }
}
