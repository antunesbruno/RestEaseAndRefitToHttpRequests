using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEaseAndRefitToHttpRequests
{
    public class ConsumerWithRefit : IConsumerWithRefit
    {
        private readonly IRefitRequests _refitRequests;

        public ConsumerWithRefit(IRefitRequests refitRequests)
        {
            _refitRequests = refitRequests;
        }

        public async Task RunRefitAsync()
        {
            //GET
            var catFacts = await _refitRequests.GetCatFacts();

            //imprime
            Console.WriteLine("Refit >>> Fact:{0} | Length: {1}", catFacts.fact, catFacts.length);
            Console.WriteLine("Informações da API Default consumidas com sucesso !");
            Console.ReadKey();
        }
    }

    public interface IRefitRequests
    {
        [Get("/fact")]
        Task<CatFactsModel> GetCatFacts();
    }

    public interface IConsumerWithRefit
    {       
        Task RunRefitAsync();
    }
}
