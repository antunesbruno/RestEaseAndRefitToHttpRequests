using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace RestEaseAndRefitToHttpRequests
{
    public static class ConsumerDefault
    {
        public static async Task RunDefaultAsync()
        {
            using (var client = new HttpClient())
            {
                //declara as informacoes
                client.BaseAddress = new Uri("https://catfact.ninja");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));                
                
                HttpResponseMessage response = await client.GetAsync("/fact");
                if (response.IsSuccessStatusCode)
                {  
                    //GET
                    var catFacts = await response.Content.ReadAsAsync<CatFactsModel>();

                    //imprime
                    Console.WriteLine("Default >>> Fact:{0} | Length: {1}", catFacts.fact, catFacts.length);
                    Console.WriteLine("Informações da API Default consumidas com sucesso !");
                    Console.ReadKey();
                }               
            }
        }
    }
}
