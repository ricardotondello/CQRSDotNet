using AutoMapper;
using Cqrs.Database;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cqrs.Contracts.Contracts.Requests.Queries;
using Cqrs.Contracts.Contracts.Responses;
using Cqrs.Domain;

namespace Cqrs.Queries
{
    public static class PersonByName
    {

        //Query / Command
        public record Query(PaginationQuery paginationQuery, string Name) : IRequest<PageInfo<PersonResponse>>;


        //Handler
        public class Handler : IRequestHandler<Query, PageInfo<PersonResponse>>
        {
            private readonly IMapper _mapper;

            private readonly IRepository _repository;
            public Handler(IRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<PageInfo<PersonResponse>> Handle(Query request, CancellationToken cancellationToken)
            {

                var paginationFilter = _mapper.Map<PaginationFilter>(request.paginationQuery);

                var people = _repository.GetPeople(request.Name, paginationFilter);

                var peopleResponse = _mapper.Map<List<PersonResponse>>(people);

                var paginationResponse = new PageInfo<PersonResponse>
                {
                    Data = peopleResponse,
                    PageNumber = request.paginationQuery.GetPageNumber(),
                    PageSize = request.paginationQuery.GetPageSize()
                };

                return await Task.FromResult(paginationResponse);
            }
        }
    }
}
