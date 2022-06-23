using PizzaDeliveryApi.Data.Models;
using PizzaDeliveryApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace PizzaDeliveryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        public ProductController()
        {
        }

        ///// <summary>
        ///// Return all pizza instanses
        ///// </summary>
        ///// <returns></returns>
        //// GET all action
        //[HttpGet]
        //public ActionResult<List<Product>> GetAll() =>
        //    PizzaService.GetAll();

        //// GET by Id action
        //[HttpGet("{id}")]
        //public ActionResult<Product> Get(int id)
        //{
        //    var pizza = PizzaService.Get(id);

        //    if (pizza == null)
        //        return NotFound();

        //    return pizza;
        //}

        //// POST action
        //[HttpPost]
        //public IActionResult Create(Product pizza)
        //{
        //    PizzaService.Add(pizza);
        //    return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
        //}

        //// PUT action
        //[HttpPut("{id}")]
        //public IActionResult Update(int id, Product pizza)
        //{
        //    if (id != pizza.Id)
        //        return BadRequest();

        //    var existingPizza = PizzaService.Get(id);
        //    if (existingPizza is null)
        //        return NotFound();

        //    PizzaService.Update(pizza);

        //    return NoContent();
        //}

        //// DELETE action
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var pizza = PizzaService.Get(id);

        //    if (pizza is null)
        //        return NotFound();

        //    PizzaService.Delete(id);

        //    return NoContent();
        //}

    }
}
