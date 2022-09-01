using Microsoft.Extensions.DependencyInjection;
using Refit;
using RestEase.HttpClientFactory;

namespace RestEaseAndRefitToHttpRequests
{
    public static class DependencyResolver
    {
        public static IServiceCollection AddDependencyResolver(this IServiceCollection services)
        {
            services.AddScoped<IConsumerWithRefit, ConsumerWithRefit>();
            services.AddScoped<IConsumerWithRestEase, ConsumerWithRestease>();

            //Injeta o RestEase
            services.AddRestEaseClient<IRestEaseRequests>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://catfact.ninja");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            //Injeta o Refit
            services.AddRefitClient<IRefitRequests>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("https://catfact.ninja");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            return services;
        }
    }
}
