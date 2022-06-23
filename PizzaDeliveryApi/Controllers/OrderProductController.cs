using Microsoft.AspNetCore.Mvc;
using PizzaDeliveryApi.Data.Models;
using PizzaDeliveryApi.Services;

namespace PizzaDeliveryApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderProductController : ControllerBase
    {
        public OrderProductController()
        {
        }

        ///// <summary>
        ///// Return all pizza instanses
        ///// </summary>
        ///// <returns></returns>
        //// GET all action
        //[HttpGet]
        //public ActionResult<List<OrderProduct>> GetAll() =>
        //    DrinkService.GetAll();

        //// GET by Id action
        //[HttpGet("{id}")]
        //public ActionResult<OrderProduct> Get(int id)
        //{
        //    var drink = DrinkService.Get(id);

        //    if (drink == null)
        //        return NotFound();

        //    return drink;
        //}

        //// POST action
        //[HttpPost]
        //public IActionResult Create(OrderProduct drink)
        //{
        //    DrinkService.Add(drink);
        //    return CreatedAtAction(nameof(Create), new { id = drink.Id }, drink);
        //}

        //// PUT action
        //[HttpPut("{id}")]
        //public IActionResult Update(int id, OrderProduct drink)
        //{
        //    if (id != drink.Id)
        //        return BadRequest();

        //    var existingDrink = DrinkService.Get(id);
        //    if (existingDrink is null)
        //        return NotFound();

        //    DrinkService.Update(drink);

        //    return NoContent();
        //}

        //// DELETE action
        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{
        //    var drink = DrinkService.Get(id);

        //    if (drink is null)
        //        return NotFound();

        //    DrinkService.Delete(id);

        //    return NoContent();
        //}

    }
}
