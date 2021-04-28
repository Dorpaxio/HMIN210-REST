using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccorHotel.Models;

namespace AccorHotel.Services
{
    public static class AgenciesService
    {
        private static Agency[] Agencies = new Agency[] { 
            new Agency() {Name = "MaximouAgency", Password = "1234", Reduction = 0.14},
            new Agency() {Name = "QuentinouAgency", Password = "4567", Reduction = 0.07},
            new Agency() {Name = "ThominouAgency", Password = "7891", Reduction = 0.14},
            new Agency() {Name = "ZAgency", Password = "0000", Reduction = 0.26},
        };

        public static Agency Auth(string name, string password)
        {

            return Agencies.Where(agency => agency.Name.ToLower() == name.ToLower() && agency.Password == password).FirstOrDefault();
        }
    }
}
