using RestSharp;

namespace FlightSearchApplicationApi.Base.Interfaces
{
    public interface IRestLibrary {
        RestClient RestClient { get; }
    }
}
