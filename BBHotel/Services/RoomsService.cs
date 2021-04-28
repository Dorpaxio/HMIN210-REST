using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBHotel.Models;

namespace BBHotel.Services
{
    public static class RoomsService
    {
        private static Room[] Rooms = new Room[]
        {
            new Room() {Id = "R45", Beds = 4, Price = 89.99},
            new Room() {Id = "R46", Beds = 2, Price = 49.99},
            new Room() {Id = "R47", Beds = 6, Price = 119.69},
            new Room() {Id = "R48", Beds = 2, Price = 189.99},
            new Room() {Id = "R49", Beds = 4, Price = 89.98},
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
