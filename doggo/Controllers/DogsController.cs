using AutoMapper;
using doggo.Models;
using doggo.Services;
using Microsoft.AspNetCore.JsonPatch;
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
        private readonly IMapper _mapper; 

        public DogsController(IClientInfoRepository clientInfoRepository, IMapper mapper)
        {
            _clientInfoRepository = clientInfoRepository ??
                throw new ArgumentException(nameof(clientInfoRepository));
            _mapper = mapper ??
                throw new ArgumentException(nameof(mapper));
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

                return Ok(_mapper.Map<IEnumerable<DogDto>>(dogsOfClient));
            }
            catch(Exception e)
            {
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

            return Ok(_mapper.Map<DogDto>(dog));
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
           
            if (!_clientInfoRepository.ClientExists(clientId))
            {
                return NotFound();
            }

            var finalDog = _mapper.Map<Entities.Dog>(dog);

            _clientInfoRepository.AddDogForClient(clientId, finalDog);
            _clientInfoRepository.Save();

            var createdDogToReturn = _mapper
                .Map<Models.DogDto>(finalDog);

            return CreatedAtRoute(
                "GetDog",
                new { clientId = clientId, id = createdDogToReturn.Id },
                createdDogToReturn);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDogInformation(int clientId, int id,
            [FromBody] DogForUpdateDto dog)
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

            if (!_clientInfoRepository.ClientExists(clientId))
            {
                return NotFound();
            }

            var dogEntity = _clientInfoRepository
                .GetDogForClient(clientId, id);
            if (dogEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(dog, dogEntity);

            _clientInfoRepository.UpdateDogInformationForClient(clientId, dogEntity);

            _clientInfoRepository.Save();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateDog(int clientId, int id,
            [FromBody] JsonPatchDocument<DogForUpdateDto> patchDoc)
        {
            if (!_clientInfoRepository.ClientExists(clientId))
            {
                return NotFound();
            }

            var dogEntity = _clientInfoRepository
                .GetDogForClient(clientId, id); 
            if (dogEntity == null)
            {
                return NotFound();
            }

            var dogToPatch = _mapper
                .Map<DogForUpdateDto>(dogEntity);

            patchDoc.ApplyTo(dogToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (dogToPatch.Name == dogToPatch.ShortName)
            {
                ModelState.AddModelError(
                   "ShortName",
                   "The Name and Short Name cannot be the same (please use less characters with short name field)");
            }

            if (!TryValidateModel(dogToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(dogToPatch, dogEntity);

            _clientInfoRepository.UpdateDogInformationForClient(clientId, dogEntity);
            _clientInfoRepository.Save();

            return NoContent();
        }
    }
}
