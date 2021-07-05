using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PizzaCommand.Models;
using PizzaCommand.Services;

namespace PizzaCommand.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        private PizzaService _pizzaService;
        public PizzaController()
        {
            _pizzaService = new PizzaService();
        }

        // POST action
        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            _pizzaService.Add(pizza);
            _pizzaService.sender();
            return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
        }

        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => _pizzaService.GetAll();
    }
}