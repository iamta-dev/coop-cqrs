using PizzaResponsibility.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace PizzaResponsibility.Services
{
    public static class PizzaService
    {
        static List<Pizza> Pizzas { get; set; }
        static List<DotPizza> dotPizza { get; set; }
        static int nextId = 3;
        private static HttpClient client = new HttpClient();
        static PizzaService()
        {
            Pizzas = new List<Pizza>
            {
                new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
                new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true }
            };
            dotPizza = new List<DotPizza>
            {
                new DotPizza { Id = 1, Information = "Name = Classic Italian IsGlutenFree = false" },
                new DotPizza { Id = 2, Information = "Name = Veggie IsGlutenFree = true" }
            };
        }

        public static List<DotPizza> GetAll() => dotPizza;

        public static DotPizza Get(int id) => dotPizza.FirstOrDefault(p => p.Id == id);
        public static void SetDotPizza()
        {
            dotPizza.Clear();
            foreach (var value in Pizzas)
            {
                int id = value.Id;
                string content = "Name =" + value.Name + "IsGlutenFree =" + value.IsGlutenFree.ToString();
                dotPizza.Add(new DotPizza { Id = id, Information = content });
            }
        }
        public static void Add(Pizza pizza)
        {
            Pizzas.Add(pizza);
            SetDotPizza();
        }
    }
}