using AutoMapper;
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
        private readonly IMapper _mapper;
        
        public ClientController(IClientInfoRepository clientInfoRepository, IMapper mapper)
        {
            _clientInfoRepository = clientInfoRepository ??
                throw new ArgumentException(nameof(clientInfoRepository));
            _mapper = mapper ??
                throw new ArgumentException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetClients()
        {
            var clientEntities = _clientInfoRepository.GetClients();
            
            return Ok(_mapper.Map<IEnumerable<ClientWithoutDogsDto>>(clientEntities));
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
                return Ok(_mapper.Map<ClientDto>(client));
            }

            return Ok(_mapper.Map<ClientWithoutDogsDto>(client));
        }    
    }
}
