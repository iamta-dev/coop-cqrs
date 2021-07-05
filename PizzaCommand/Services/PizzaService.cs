using PizzaCommand.Models;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Text.Json;
using System;
using RabbitMQ.Client;


namespace PizzaCommand.Services
{
    public class PizzaService
    {
        List<Pizza> Pizzas { get; }
        int nextId = 3;
        public PizzaService()
        {
            Pizzas = new List<Pizza>
            {
                new Pizza { Id = 1, Name = "Classic Italian", IsGlutenFree = false },
                new Pizza { Id = 2, Name = "Veggie", IsGlutenFree = true }
            };
        }
        public void Add(Pizza pizza)
        {
            // pizza.Id = nextId++;
            Pizzas.Add(pizza);
        }

        async public void sender()
        {
            // var newPizza = JsonSerializer.Serialize(Pizzas[Pizzas.Count - 1]);
            // var data = new StringContent(newPizza, Encoding.UTF8, "application/json");

            // var url = "http://localhost:8003/Pizza";
            // using var client = new HttpClient();

            // var response = await client.PostAsync(url, data);
            // string result = response.Content.ReadAsStringAsync().Result;
            // Console.WriteLine(response);
            Send();
        }
        public void Send()
        {


            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = "Hello PAi!";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                     routingKey: "hello",
                                     basicProperties: null,
                                     body: body);
            }

        }

        public List<Pizza> GetAll() => Pizzas;
    }
}