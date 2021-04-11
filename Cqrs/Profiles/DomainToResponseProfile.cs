using AutoMapper;
using Cqrs.Domain;
using System;
using Contract = Cqrs.Contracts.Contracts.Responses;

namespace Cqrs.Profiles
{
    public class DomainToResponseProfile : Profile
    {
        public DomainToResponseProfile()
        {
            CreateMap<Person, Contract.PersonResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id.ToString()))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(x => DateTime.Now.Year - x.DateOfBirth.Year ));

        }
    }
}
