using doggo.Models;
using doggo.Services;
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
        private readonly IClientInfoRepository _clientInfoRepository;

        public DogsController(IClientInfoRepository clientInfoRepository)
        {
            _clientInfoRepository = clientInfoRepository ??
                throw new ArgumentException(nameof(clientInfoRepository));
        }

        [HttpGet]
        public IActionResult GetDogs(int clientId)
        {
            try
            {
                if (!_clientInfoRepository.ClientExists(clientId))
                {
                    return NotFound();
                }

                var dogsOfClient = _clientInfoRepository.GetDogsForClient(clientId);

                var dogsOfClientResults = new List<DogDto>();
                foreach (var dog in dogsOfClient)
                {
                    dogsOfClientResults.Add(new DogDto()
                    {
                        Id = dog.Id,
                        Name = dog.Name,
                        ShortName = dog.ShortName,
                        Breed = dog.Breed,
                        Birth = dog.Birth
                    });
                }
                return Ok(dogsOfClientResults);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return StatusCode(500, "A problem occured when handling the request");
            }
        }

        [HttpGet("{id}", Name = "GetDog")]
        public IActionResult GetDogs(int clientId, int id)
        {
           if (!_clientInfoRepository.ClientExists(clientId))
            {
                return NotFound();
            }

            var dog = _clientInfoRepository.GetDogForClient(clientId, id);
            if (dog == null)
            {
                return NotFound();
            }
            var dogResult = new DogDto()
            {
                Id = dog.Id,
                Name = dog.Name,
                ShortName = dog.ShortName,
                Breed = dog.Breed,
                Birth = dog.Breed
            };

            return Ok(dogResult);
        }

        [HttpPost]
        public IActionResult CreateDog(int clientId, 
            [FromBody] DogForCreationDto dog)
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
