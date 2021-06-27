using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Pizzaquery.Models;
using Pizzaquery.Services;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("pizza/[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {
        }

        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza == null)
                return NotFound();

            return pizza;
        }
    }
}