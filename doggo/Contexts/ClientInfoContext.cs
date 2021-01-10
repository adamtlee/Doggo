using doggo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doggo.Contexts
{
    public class ClientInfoContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Dog> Dogs { get; set; }

        public ClientInfoContext(DbContextOptions<ClientInfoContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasData(
                new Client()
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Ross",
                    Email = "bobross@mail.com",
                    Address = "321 Nuna St. Denver Colorado",
                    Phone = "303-000-0001"
                },
                new Client()
                {
                    Id = 2,
                    FirstName = "Bat",
                    LastName = "Man",
                    Email = "batman@mail.com",
                    Address = "234 Nuna St. Arvada Colorado",
                    Phone = "303-000-0101"
                },
                new Client()
                {
                    Id = 3,
                    FirstName = "Super",
                    LastName = "Man",
                    Email = "superman@mail.com",
                    Address = "333 Nuna St. Arvada Colorado",
                    Phone = "303-100-0101"
                },
                new Client()
                {
                    Id = 4,
                    FirstName = "Cat",
                    LastName = "Woman",
                    Email = "catwoman@mail.com",
                    Address = "111 Nuna St. Arvada Colorado",
                    Phone = "303-101-0101"
                },
                new Client()
                {
                    Id = 5,
                    FirstName = "Wonder",
                    LastName = "Woman",
                    Email = "wonderwoman@mail.com",
                    Address = "112 Nuna St. Arvada Colorado",
                    Phone = "303-111-0101"
                });

            modelBuilder.Entity<Dog>()
                .HasData(
                new Dog()
                {
                    Id = 1,
                    ClientId = 1,
                    Name = "Tyco",
                    ShortName = "T",
                    Breed = "Pitbull",
                    Birth = "Jul 10th 2001"
                },
                 new Dog()
                 {
                     Id = 2,
                     ClientId = 3,
                     Name = "Maxxie",
                     ShortName = "M",
                     Breed = "Poodle",
                     Birth = "Jul 11th 2021"
                 },
                 new Dog()
                 {
                     Id = 3,
                     ClientId = 2,
                     Name = "Bo",
                     ShortName = "B",
                     Breed = "Pitbull",
                     Birth = "Jul 7th 2001"
                 },
                  new Dog()
                  {
                      Id = 4,
                      ClientId = 4,
                      Name = "Bennie",
                      ShortName = "B",
                      Breed = "Boxer",
                      Birth = "Aug 10th 2001"
                  },
                   new Dog()
                   {
                       Id = 5,
                       ClientId = 3,
                       Name = "Jax",
                       ShortName = "J",
                       Breed = "Mutt",
                       Birth = "Dec 11th 2001"
                   },
                   new Dog()
                   {
                       Id = 6,
                       ClientId = 1,
                       Name = "Dyco",
                       ShortName = "D",
                       Breed = "Husky",
                       Birth = "Nov 15th 2001"
                   },
                    new Dog()
                    {
                        Id = 7,
                        ClientId = 5,
                        Name = "Dunkin",
                        ShortName = "D",
                        Breed = "Pug",
                        Birth = "Aug 4th 2001"
                    });
            base.OnModelCreating(modelBuilder);
        }

    }
}
