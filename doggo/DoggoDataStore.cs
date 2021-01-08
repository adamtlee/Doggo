using doggo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doggo
{
    public class DoggoDataStore
    {
        public static DoggoDataStore DoggoData { get; } = new DoggoDataStore();
        public List<ClientDto> Clients { get; set; }

        public DoggoDataStore()
        {
            Clients = new List<ClientDto>()
            {
                new ClientDto()
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Ross",
                    Email = "bob@mail.com",
                    Address = "Happy Trees Ct. 3004 Ave.",
                    Phone = "303-000-0000",
                    Dogs = new List<DogDto>()
                    {
                        new DogDto()
                        {
                            Id = 1, 
                            Name = "Tyco",
                            ShortName = "Tyc",
                            Breed = "Poodle", 
                            Birth = "July 10, 2018"
                        },
                         new DogDto()
                        {
                            Id = 2,
                            Name = "Maxxie",
                            ShortName = "Max",
                            Breed = "Huskie",
                            Birth = "July 11, 2019"
                        }
                    }
                },
                new ClientDto()
                {
                    Id = 2,
                    FirstName = "Harry",
                    LastName = "Potter",
                    Email = "harry@mail.com",
                    Address = "Hogwarts Wiz Ct. 3004 Ave.",
                    Phone = "303-111-0000",
                    Dogs = new List<DogDto>()
                    {
                        new DogDto()
                        {
                            Id = 1,
                            Name = "Gary",
                            ShortName = "Gar",
                            Breed = "Bulldog",
                            Birth = "November 10, 2018"
                        },
                         new DogDto()
                        {
                            Id = 2,
                            Name = "Haggie",
                            ShortName = "Hag",
                            Breed = "Pitbull",
                            Birth = "July 15, 2019"
                        }
                    }
                }
            };
        }
    }
}
