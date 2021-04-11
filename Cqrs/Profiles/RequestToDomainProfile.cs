using System;
using AutoMapper;
using Cqrs.Contracts.Contracts.Requests;
using Cqrs.Contracts.Contracts.Requests.Queries;
using Cqrs.Domain;

namespace Cqrs.Profiles
{
    public class RequestToDomainProfile : Profile
    {
        public RequestToDomainProfile()
        {
            CreateMap<PaginationQuery, PaginationFilter>();
            CreateMap<AddPersonRequest, Person>()
                .ConstructUsing(c=> Person.Create(Guid.NewGuid(), c.Name, c.Surname, c.DateOfBirth))
                ;
        }
    }
}
