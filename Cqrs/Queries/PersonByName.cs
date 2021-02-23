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
            private readonly IMapper mapper;

            private Repository _repository { get; }
            public Handler(Repository repository, IMapper mapper)
            {
                _repository = repository;
                this.mapper = mapper;
            }

            public async Task<List<Response>> Handle(Query request, CancellationToken cancellationToken)
            {
                var results = _repository.People.Where(x => x.Name.Contains(request.Name, 
                    StringComparison.InvariantCultureIgnoreCase));

                if (results is null) return new List<Response>();

                return await Task.FromResult(
                      mapper.Map<List<Response>>(results)
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
