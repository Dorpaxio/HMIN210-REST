using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MaximouAgency.Models;

namespace MaximouAgency.Services
{
    public class Reponse
    {
        public Hotel Hotel { get; set; }
        public HttpResponseMessage Response { get; set; }
    }

    public static class HotelsService
    {
        private static HttpClient Http = new HttpClient();
        private static Hotel[] Hotels = new Hotel[]
        {
            new Hotel() {Id = 1, Name = "AccorHotel", URL = "https://localhost:5003/api", Login = "MaximouAgency", Password = "1234", RoomsPath = "/rooms", BookingsPath = "/bookings"},
            new Hotel() {Id = 2, Name = "BBHotel", URL = "https://localhost:5001/api", Login = "MaximouAgency", Password = "test", RoomsPath = "/rooms", BookingsPath = "/bookings"}
        };

        public async static Task<Room[]> GetOffers()
        {
            return (await Task.WhenAll(Hotels.Select(hotel =>
                Http.GetAsync(hotel.URL + hotel.RoomsPath + "?agency=" + hotel.Login + "&password=" + hotel.Password)
                    .ContinueWith(response => new Reponse() { Hotel = hotel, Response = response.Result }))))
                    .Aggregate(new List<Room>(), (offers, response) =>
                    {
                        if (response.Response.StatusCode.ToString() == "OK")
                            offers.AddRange(response.Response.Content.ReadAsAsync<Room[]>()
                                .ContinueWith(rooms => rooms.Result.Select(room => new Room() { Beds = room.Beds, HotelId = response.Hotel.Id, Id = room.Id, Price = room.Price, ImgUrl = room.ImgUrl })).Result);
                        return offers;
                    }).ToArray();
        }

        public async static Task<string> BookOffer(int hotelId, string roomId, string arrivalDate, string departureDate, string clientname, string creditcard, int nbclients)
        {
            Hotel hotel = Hotels.FirstOrDefault(hotel => hotel.Id == hotelId);
            if (hotel == null) return "40401";

            MultipartFormDataContent formData = new MultipartFormDataContent();
            formData.Add(new StringContent(clientname), "customername");
            formData.Add(new StringContent(roomId), "roomid");
            formData.Add(new StringContent(creditcard), "creditcard");
            formData.Add(new StringContent(nbclients.ToString()), "nbcustomers");
            formData.Add(new StringContent(arrivalDate), "arrival");
            formData.Add(new StringContent(departureDate), "departure");

            HttpResponseMessage response = await Http.PostAsync(hotel.URL + hotel.BookingsPath + "?agency=" + hotel.Login + "&password=" + hotel.Password, formData);
            switch(response.StatusCode.ToString())
            {
                case "Created":
                    return "201";
                case "Conflict":
                    return "409";
                case "NotFound":
                    return "404";
                default:
                    return "500";
            }
        }
    }
}
