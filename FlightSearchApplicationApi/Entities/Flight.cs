using Newtonsoft.Json;

namespace FlightSearchApplicationApi.Entities
{
    public class Flight
    {
        [JsonProperty("id", Required = Required.Always)]
        public int Id { get; set; }

        [JsonProperty("from", Required = Required.Always)]
        public string From { get; set; }

        [JsonProperty("to", Required = Required.Always)]
        public string To { get; set; }

        [JsonProperty("date", Required = Required.Always)]
        public string Date { get; set; }

    }


}
