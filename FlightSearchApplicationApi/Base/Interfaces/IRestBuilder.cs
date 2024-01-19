using RestSharp;

namespace FlightSearchApplicationApi.Base.Interfaces
{
    public interface IRestBuilder
    {
        IRestBuilder WithRequest();
        Task<RestResponse> WithGetResponse();
        Task<T?> WithGetResponse<T>();
        Task<RestResponse> Execute();
    }
}
