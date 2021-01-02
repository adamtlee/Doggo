﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doggo.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public ICollection<Dog> Dog { get; set; }
             = new List<Dog>();
    }
}