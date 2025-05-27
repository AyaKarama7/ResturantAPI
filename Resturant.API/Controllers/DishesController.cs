using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Resturant.Application.Dishes.Command.DishCreate;
using Resturant.Application.Dishes.Command.DishDelete;
using Resturant.Application.Dishes.Command.DishUpdate;
using Resturant.Application.Dishes.Query.GetAllDishesForResturant;
using Resturant.Application.Dishes.Query.GetDishForResturantById;


namespace Resturant.API.Controllers
{
    [Route("api/resturant/{resturantId}/dishes")]
    [Authorize]
    [ApiController]
    public class DishesController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateDish([FromRoute]int resturantId,[FromBody]DishCreateCommand command)
        {
            command.ResturantId = resturantId;
            var id=await mediator.Send(command);
            return CreatedAtAction(nameof(GetDishForResturantById), new {resturantId,id},null);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDishesForResturant([FromRoute]int resturantId)
        {
            var dishes = await mediator.Send(new GetAllDishesForResturantQuery(resturantId));
            if (dishes == null) return NotFound();
            return Ok(dishes);
        }
        [HttpGet("get-dish-by-id")]
        public async Task<IActionResult> GetDishForResturantById([FromRoute] int resturantId,
            int dishId)
        {
            var dish = await mediator.Send(new GetDishForResturantByIdQuery(resturantId,dishId));
            if (dish == null) return NotFound();
            return Ok(dish);
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateDishInResturant([FromRoute] int resturantId, 
            int dishId,[FromBody]DishUpdateCommand dish)
        {
            if (dish == null) return BadRequest("Dish  cannot be null");
            if (dish.ResturantId != resturantId||dish.DishId!=dishId) return BadRequest("MisMatch");
            var updatedId = await mediator.Send(dish);
            if (updatedId == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDishInResturant([FromRoute]int resturantId, int dishId)
        {
            var IsDeleted = await mediator.Send(new DishDeleteCommand(resturantId,dishId));
            if (IsDeleted) return NoContent();
            return NotFound();
        }
    }
}
