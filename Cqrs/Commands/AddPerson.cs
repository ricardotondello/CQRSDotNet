using AutoMapper;
using Cqrs.Database;
using Cqrs.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Cqrs.Commands
{
    public static class AddPerson
    {
        public record Command(PersonRequest personRequest) : IRequest<PersonResponse>;

        public class Handler : IRequestHandler<Command, PersonResponse>
        {
            private readonly Repository repository;
            private readonly IMapper mapper;

            public Handler(Repository repository, IMapper mapper)
            {
                this.repository = repository;
                this.mapper = mapper;
            }

            public async Task<PersonResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                var person = mapper.Map<Person>(request.personRequest);
                repository.People.Add(person);
                return await Task.FromResult(mapper.Map<PersonResponse>(person));
            }
        }

        public record PersonRequest
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime DateOfBirth { get; set; }
        }

        public record PersonResponse
        {
            public string Id { get; set; }
        }
    }
}
