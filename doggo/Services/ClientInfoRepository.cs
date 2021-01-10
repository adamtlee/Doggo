using doggo.Contexts;
using doggo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doggo.Services
{
    public class ClientInfoRepository : IClientInfoRepository
    {
        private ClientInfoContext _context;
        public ClientInfoRepository(ClientInfoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public bool ClientExists(int clientId)
        {
            return _context.Clients.Any(c => c.Id == clientId);
        }

        public Client GetClient(int clientId, bool includeDogs)
        {
           if (includeDogs)
            {
                return _context.Clients.Include(c => c.Dogs)
                    .Where(c => c.Id == clientId).FirstOrDefault();
            }

            return _context.Clients
                 .Where(c => c.Id == clientId).FirstOrDefault();
        }

        public IEnumerable<Client> GetClients()
        {
            return _context.Clients.OrderBy(c => c.FirstName).ToList();
        }

        public Dog GetDogForClient(int clientId, int dogId)
        {
            return _context.Dogs
                .Where(d => d.ClientId == clientId && d.Id == dogId).FirstOrDefault();
        }

        public IEnumerable<Dog> GetDogsForClient(int clientId)
        {
            return _context.Dogs
                .Where(d => d.ClientId == clientId).ToList();
        }

        public void AddDogForClient(int clientId, Dog dog)
        {
            var client = GetClient(clientId, false);
            client.Dogs.Add(dog);
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
