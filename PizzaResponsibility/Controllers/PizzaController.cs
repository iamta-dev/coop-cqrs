using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using PizzaResponsibility.Models;
using PizzaResponsibility.Services;
using System;

namespace PizzaResponsibility.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {
        }

        [HttpGet]
        public ActionResult<List<DotPizza>> GetAll() => PizzaService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<DotPizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza == null)
                return NotFound();

            return pizza;
        }
        [HttpPost]
        public IActionResult Received(Pizza newPizza)
        {
            PizzaService.Add(newPizza);
            return CreatedAtAction(nameof(Received), null);
        }
    }
}
