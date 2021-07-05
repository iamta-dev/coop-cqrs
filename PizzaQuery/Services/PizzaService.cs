using PizzaQuery.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
namespace PizzaQuery.Services
{
    public static class PizzaService
    {
        static List<Pizza> Pizzas { get; set; }
        static List<Pizza> dotPizza { get; }
        static int nextId = 3;
        private static HttpClient client = new HttpClient();
        static PizzaService()
        {
            Pizzas = new List<Pizza>
            {
                new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
                new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true }
            };
        }


        public static async Task<string> ReceiveOne(int id)
        {
            string responseString = await client.GetStringAsync("http://localhost:8003/Pizza/" + id);
            string result = responseString.ToString();
            return result;
        }

        public static void Add(Pizza pizza)
        {
            Pizzas.Add(pizza);
        }
        public static async Task<string> Receive()
        {
            string responseString = await client.GetStringAsync("http://localhost:8003/Pizza");
            string result = responseString.ToString();
            return result;
        }
    }
}