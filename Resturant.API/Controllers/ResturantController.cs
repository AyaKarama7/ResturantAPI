using MediatR;
using Microsoft.AspNetCore.Mvc;
using Resturant.Application.Resturants.Commands.ResturantCreate;
using Resturant.Application.Resturants.Commands.ResturantDelete;
using Resturant.Application.Resturants.Commands.ResturantUpdate;
using Resturant.Application.Resturants.Query.GetAllResturants;
using Resturant.Application.Resturants.Query.GetResturantById;


namespace Resturant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResturantController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var resturants = await mediator.Send(new GetAllResturantsQuery());
            return Ok(resturants);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var resturant = await mediator.Send(new GetResturantByIdQuery(id));
            if (resturant == null)
            {
                return NotFound();
            }
            return Ok(resturant);
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var IsDeleted = await mediator.Send(new ResturantDeleteCommand(id));
            if (IsDeleted) return NoContent();
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> AddResturant(ResturantCreateCommand resturant)
        {
            if (resturant == null)
            {
                return BadRequest("Resturant cannot be null");
            }
            int id = await mediator.Send(resturant);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }
        [HttpPatch("{id:int}")]
        public async Task<IActionResult> UpdateResturant([FromRoute] int id, ResturantUpdateCommand resturant)
        {
            if (resturant == null)
            {
                return BadRequest("Resturant cannot be null");
            }
            if (id != resturant.Id)
            {
                return BadRequest("Id mismatch");
            }
            var updatedId = await mediator.Send(resturant);
            if (updatedId == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
