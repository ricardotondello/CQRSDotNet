using AutoMapper;
using Cqrs.Database;
using Cqrs.Domain;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Cqrs.Contracts.Contracts.Requests;
using Cqrs.Contracts.Contracts.Responses;

namespace Cqrs.Commands
{
    public static class AddPerson
    {
        public record Command(AddPersonRequest PersonRequest) : IRequest<PersonResponse>;

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
                var person = _mapper.Map<Person>(request.PersonRequest);
                _repository.AddPerson(person);
                return await Task.FromResult(_mapper.Map<PersonResponse>(person));
            }
        }
    }
}
