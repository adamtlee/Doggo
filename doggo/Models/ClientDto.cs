﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doggo.Models
{
    public class ClientDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        
        public int NumberOfDogs
        {
            get
            {
                return Dogs.Count;
            }
        }
        public ICollection<DogDto> Dogs { get; set; }
             = new List<DogDto>();
    }
}
