using Cqrs.Commands;
using Cqrs.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Cqrs.Contracts.Resquests.Queries;

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
        public async Task<IActionResult> GetPersons([FromQuery] PaginationQuery paginationQuery, string Name) => Ok(await mediator.Send(new PersonByName.Query(paginationQuery, Name)));

        [HttpPost]
        public async Task<IActionResult> SetPerson(AddPerson.Command command) => Ok(await mediator.Send(command));
       
    }
}
