using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TruckerMicroservice.Domain
{
    public class TruckerModel
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public string Password { get; set; }
        public string TruckingCompany { get; private set; }

        public TruckerModel(string username, string password, string truckingCompany)
        {
            Username = username;
            Password = password;
            TruckingCompany = truckingCompany;
        }
    }
}
