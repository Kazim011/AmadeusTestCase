using FlightSearchApplicationApi.Base.Interfaces;
using RestSharp;

namespace FlightSearchApplicationApi.Base {
    public class RestLibrary : IRestLibrary {
        public RestClient RestClient { get; }

        public RestLibrary() {
            var restClientOptions = new RestClientOptions {
                BaseUrl = new Uri("https://flights-api.buraky.workers.dev/"),
                RemoteCertificateValidationCallback = (sender, certificate, chain, errors) => true
            };

            RestClient = new RestClient(restClientOptions);
        }
    }
}
