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
    [Route("api/clients")]
    public class ClientController : ControllerBase
    {
        private readonly IClientInfoRepository _clientInfoRepository;
        public ClientController(IClientInfoRepository clientInfoRepository)
        {
            _clientInfoRepository = clientInfoRepository ??
                throw new ArgumentException(nameof(clientInfoRepository));
        }

        [HttpGet]
        public IActionResult GetClients()
        {
            var clientEntities = _clientInfoRepository.GetClients();
            var results = new List<ClientWithoutDogsDto>();

            foreach (var clientEntity in clientEntities)
            {
                results.Add(new ClientWithoutDogsDto
                {
                    Id = clientEntity.Id,
                    FirstName = clientEntity.FirstName,
                    LastName = clientEntity.LastName,
                    Email = clientEntity.Email,
                    Address = clientEntity.Address,
                    Phone = clientEntity.Phone
                });
            }

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetClient(int id, bool includeDogs = false)
        {
            var client = _clientInfoRepository.GetClient(id, includeDogs);

            if (client == null)
            {
                return NotFound();
            }

            if (includeDogs)
            {
                var clientResult = new ClientDto()
                {
                    Id = client.Id,
                    FirstName = client.FirstName,
                    LastName = client.LastName,
                    Email = client.Email,
                    Address = client.Address,
                    Phone = client.Phone
                };

                foreach (var dog in client.Dogs)
                {
                    clientResult.Dogs.Add(
                        new DogDto()
                        {
                            Id = dog.Id,
                            Name = dog.Name,
                            ShortName = dog.ShortName,
                            Birth = dog.Birth,
                            Breed = dog.Breed
                        });
                }

                return Ok(clientResult);
            }

            var clientWithoutDogsResult = 
                new ClientWithoutDogsDto(){
                Id = client.Id,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Email = client.Email,
                Address = client.Address,
                Phone = client.Phone
            };

            return Ok(clientWithoutDogsResult);
        }    
    }
}
