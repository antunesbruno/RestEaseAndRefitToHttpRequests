using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestEaseAndRefitToHttpRequests
{
    public class ConsumerWithRestease : IConsumerWithRestEase
    {
        private readonly IRestEaseRequests _restEaseRequests;

        public ConsumerWithRestease(IRestEaseRequests restEaseRequests)
        {
            _restEaseRequests = restEaseRequests;
        }

        public async Task RunRestEaseAsync()
        {
            //GET
            var catFacts = await _restEaseRequests.GetCatFacts();

            //imprime
            Console.WriteLine("RestEase >>> Fact:{0} | Length: {1}", catFacts.fact, catFacts.length);
            Console.WriteLine("Informações da API RestEase consumidas com sucesso !");
            Console.ReadKey();
        }       
    }

    public interface IRestEaseRequests
    {
        [Get("/fact")]
        Task<CatFactsModel> GetCatFacts();
    }

    public interface IConsumerWithRestEase
    {
        Task RunRestEaseAsync();
    }    
}
