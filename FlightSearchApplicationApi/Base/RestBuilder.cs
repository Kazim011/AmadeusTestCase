using FlightSearchApplicationApi.Base.Interfaces;
using RestSharp;

namespace FlightSearchApplicationApi.Base
{
    public class RestBuilder : IRestBuilder
    {

        private readonly IRestLibrary _restLibrary;
        private RestRequest RestRequest { get; set; } = null!;

        public RestBuilder(IRestLibrary restLibrary) => _restLibrary = restLibrary;

        public IRestBuilder WithRequest()
        {
            RestRequest = new RestRequest();
            return this;
        }

        
        public async Task<RestResponse> WithGetResponse()
        {
            RestRequest.Method = Method.Get;
            return await _restLibrary.RestClient.GetAsync(RestRequest);
        }

        
        public async Task<T?> WithGetResponse<T>()
        {
            RestRequest.Method = Method.Get;
            return await _restLibrary.RestClient.GetAsync<T>(RestRequest);
        }
        

        public async Task<RestResponse> Execute()
        {
            return await _restLibrary.RestClient.ExecuteAsync(RestRequest);
        }

    }
}
