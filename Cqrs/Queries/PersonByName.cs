using AutoMapper;
using Cqrs.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cqrs.Queries
{
    public static class PersonByName
    {

        //Query / Command
        public record Query(string Name) : IRequest<List<Response>>;


        //Handler
        public class Handler : IRequestHandler<Query, List<Response>>
        {
            private readonly IMapper _mapper;

            private readonly IRepository _repository;
            public Handler(IRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<List<Response>> Handle(Query request, CancellationToken cancellationToken)
            {
                var people = _repository.GetPeople();
                    
                if(string.IsNullOrWhiteSpace(request.Name))
                    return await Task.FromResult(_mapper.Map<List<Response>>(people));

                var results = people.Where(x => x.Name.Contains(request.Name,
                    StringComparison.InvariantCultureIgnoreCase));

                return await Task.FromResult(
                      _mapper.Map<List<Response>>(results)
                    );
            }
        }

        //Response
        public record Response {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public int Age { get; set; }
        };
    }
}
