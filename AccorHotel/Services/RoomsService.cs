using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccorHotel.Models;

namespace AccorHotel.Services
{
    public static class RoomsService
    {
        private static Room[] Rooms = new Room[]
        {
            new Room() {Id = "West", Beds = 2, Price = 75.99},
            new Room() {Id = "North", Beds = 1, Price = 49.99},
            new Room() {Id = "Est", Beds = 3, Price = 98.99},
            new Room() {Id = "South", Beds = 2, Price = 144.44},
        };

        public static Room[] GetRooms(Agency agency)
        {
            if (agency == null) return Rooms;
            return Rooms.Select(room => new Room() { Id = room.Id, Beds = room.Beds, Price = (1 - agency.Reduction) * room.Price }).ToArray();
        }

        public static Room getRoom(string roomId)
        {
            return Rooms.FirstOrDefault(room => room.Id.ToLower() == roomId.ToLower());
        }
    }
}
