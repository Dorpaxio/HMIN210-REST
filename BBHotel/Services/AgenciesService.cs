using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBHotel.Models;

namespace BBHotel.Services
{
    public static class AgenciesService
    {
        private static Agency[] Agencies = new Agency[] { 
            new Agency() {Name = "MaximouAgency", Password = "test", Reduction = 0.2},
            new Agency() {Name = "QuentinouAgency", Password = "4567", Reduction = 0.21},
            new Agency() {Name = "ThominouAgency", Password = "7891", Reduction = 0.3},
            new Agency() {Name = "ZAgency", Password = "0000", Reduction = 0.4},
        };

        public static Agency Auth(string name, string password)
        {

            return Agencies.Where(agency => agency.Name.ToLower() == name.ToLower() && agency.Password == password).FirstOrDefault();
        }
    }
}
