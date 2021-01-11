using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doggo.Profiles
{
    public class DogProfile : Profile
    {
        public DogProfile()
        {
            CreateMap<Entities.Dog, Models.DogDto>();
            CreateMap<Models.DogForCreationDto, Entities.Dog>();
            CreateMap<Models.DogForUpdateDto, Entities.Dog>();
        }
    }
}
