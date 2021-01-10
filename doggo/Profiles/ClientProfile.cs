using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doggo.Profiles
{
    public class ClientProfile : Profile
    {
        public ClientProfile()
        {
            CreateMap<Entities.Client, Models.ClientDto>();
            CreateMap<Entities.Client, Models.ClientWithoutDogsDto>();
        }
        
    }
}
