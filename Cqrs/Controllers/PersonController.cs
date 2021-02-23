using Cqrs.Commands;
using Cqrs.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cqrs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMediator mediator;

        public PersonController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetPersons(string Name)
        {
            var response = await mediator.Send(new PersonByName.Query(Name));
            return Ok(response);

        }

        [HttpPost]
        public async Task<IActionResult> SetPerson(AddPerson.Command command) => Ok(await mediator.Send(command));
       
    }
}
