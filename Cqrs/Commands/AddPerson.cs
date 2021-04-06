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
            private readonly IRepository _repository;
            private readonly IMapper _mapper;

            public Handler(IRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<PersonResponse> Handle(Command request, CancellationToken cancellationToken)
            {
                var person = _mapper.Map<Person>(request.personRequest);
                _repository.AddPerson(person);
                return await Task.FromResult(_mapper.Map<PersonResponse>(person));
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
