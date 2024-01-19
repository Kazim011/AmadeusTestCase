using FlightSearchApplicationApi.Base;
using FlightSearchApplicationApi.Base.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FlightSearchApplicationApi
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IRestLibrary, RestLibrary>();
            services.AddScoped<IRestBuilder, RestBuilder>();
            services.AddScoped<IRestFactory, RestFactory>();

        }
    }
}
