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
        public List<Client> Clients { get; set; }

        public DoggoDataStore()
        {
            Clients = new List<Client>()
            {
                new Client()
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Ross",
                    Email = "bob@mail.com",
                    Address = "Happy Trees Ct. 3004 Ave.",
                    Phone = "303-000-0000",
                    Dog = new List<Dog>()
                    {
                        new Dog()
                        {
                            Id = 1, 
                            Name = "Tyco",
                            Breed = "Poodle", 
                            Birth = "July 10, 2018"
                        },
                         new Dog()
                        {
                            Id = 2,
                            Name = "Maxxie",
                            Breed = "Huskie",
                            Birth = "July 11, 2019"
                        }
                    }
                },
                new Client()
                {
                    Id = 2,
                    FirstName = "Harry",
                    LastName = "Potter",
                    Email = "harry@mail.com",
                    Address = "Hogwarts Wiz Ct. 3004 Ave.",
                    Phone = "303-111-0000",
                    Dog = new List<Dog>()
                    {
                        new Dog()
                        {
                            Id = 1,
                            Name = "Gary",
                            Breed = "Bulldog",
                            Birth = "November 10, 2018"
                        },
                         new Dog()
                        {
                            Id = 2,
                            Name = "Haggie",
                            Breed = "Pitbull",
                            Birth = "July 15, 2019"
                        }
                    }
                }
            };
        }
    }
}
