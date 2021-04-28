using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BBHotel.Models;
using Microsoft.AspNetCore.Mvc;

namespace BBHotel.Services
{
    public static class BookingsService
    {
        private static List<Booking> Bookings = new List<Booking>();

        public static Booking[] GetBookings(string roomId)
        {
            if (roomId == null) return Bookings.ToArray();
            return Bookings.FindAll(booking => booking.RoomId.ToLower() == roomId.ToLower()).ToArray();
        }

        public static Booking[] GetBookings()
        {
            return GetBookings(null);
        }

        public static bool isBooked(string roomId, DateTime arrival, DateTime departure)
        {
            return GetBookings(roomId).Any(booking => arrival >= booking.ArrivalDate && arrival <= booking.DepartureDate
                                            || departure >= booking.ArrivalDate && departure <= booking.DepartureDate);
        }

        public static string BookRoom(string roomId, string creditCard, string clientName, int nbClients, DateTime arrival, DateTime departure)
        {
            if (isBooked(roomId, arrival, departure)) return "409";
            Room room = RoomsService.getRoom(roomId);
            if (room == null) return "404";
            if (room.Beds < nbClients) return "4092";

            Bookings.Add(new Booking() { ClientName = clientName, RoomId = roomId, CreditCard = creditCard, ArrivalDate = arrival, DepartureDate = departure});
            return "201";
        }
    }
}
