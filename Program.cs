
//Novo console usando .NET 6
// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RestEaseAndRefitToHttpRequests;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) => DependencyResolver.AddDependencyResolver(services))
    .Build();      

//API padrão do .NET
await ConsumerDefault.RunDefaultAsync();

//API usando Refit
await host.Services.GetService<IConsumerWithRefit>().RunRefitAsync();

//API usando Restease
await host.Services.GetService<IConsumerWithRestEase>().RunRestEaseAsync();


