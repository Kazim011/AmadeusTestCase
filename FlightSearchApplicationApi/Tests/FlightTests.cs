using FlightSearchApplicationApi.Base.Interfaces;
using FlightSearchApplicationApi.Base;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlightSearchApplicationApi.Entities;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace FlightSearchApplicationApi.Tests
{
    [TestFixture]
    public class FlightTests
    {
        private readonly IRestFactory _restFactory = new RestFactory(new RestBuilder(new RestLibrary()));

        [Test]
        public async Task GetFlightsTest()
        {
            var response = await _restFactory.Create()
                .WithRequest()
                .WithGetResponse();

            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
            Assert.That(response.Content, Is.Not.Null);            
            var json = JObject.Parse(response.Content!);
            var flights = JsonConvert.DeserializeObject<Flight[]>(json["data"]!.ToString());
            Assert.That(flights, Is.Not.Null);
            Assert.That(response.ContentType, Is.EqualTo("application/json"));
        }

    }
}
