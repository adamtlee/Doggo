using doggo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace doggo.Services
{
    public interface IClientInfoRepository
    {
        IEnumerable<Client> GetClients();
        Client GetClient(int clientId, bool includeDogs);
        IEnumerable<Dog> GetDogsForClient(int clientId);
        Dog GetDogForClient(int clientId, int dogId);
        bool ClientExists(int clientId);
        void AddDogForClient(int clientId, Dog dog);
        void UpdateDogInformationForClient(int clientId, Dog dog);
        void DeleteDogInformation(Dog dog);
        bool Save();


    }
}
