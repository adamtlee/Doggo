using doggo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doggo.Controllers
{
    [ApiController]
    [Route("api/clients/{clientId}/dogs")]
    public class DogsController : ControllerBase
    {
        [HttpGet("{id}", Name = "GetDogs")]
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

        [HttpPost]
        public IActionResult CreateDog(int clientId, 
            [FromBody] NewDogForCreationDto dog)
        {
            if (dog.Name == dog.ShortName)
            {
                ModelState.AddModelError(
                    "ShortName",
                    "The Name and Short Name cannot be the same (please use less characters with short name field)");
            } 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var client = DoggoDataStore.DoggoData.Clients.FirstOrDefault(c => c.Id == clientId);
            if (client == null)
            {
                return NotFound();
            }

            var maxIndexDogId = DoggoDataStore.DoggoData.Clients.SelectMany(
                c => c.Dogs).Max(d => d.Id);

            var finalDog = new DogDto()
            {
                Id = ++maxIndexDogId,
                Name = dog.Name,
                Breed = dog.Breed,
                Birth = dog.Birth
            };

            client.Dogs.Add(finalDog);

            return CreatedAtRoute(
                "GetDogs",
                new { clientId = clientId, Id = finalDog.Id },
                finalDog);
        }
    }
}
