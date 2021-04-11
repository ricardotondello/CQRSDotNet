using AutoMapper;
using Cqrs.Contracts.Resquests.Queries;
using Cqrs.Domain;

namespace Cqrs.Profiles
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<PaginationQuery, PaginationFilter>();
        }
    }
}
