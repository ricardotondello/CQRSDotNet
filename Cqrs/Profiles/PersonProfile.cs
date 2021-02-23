using AutoMapper;
using Cqrs.Domain;
using Cqrs.Queries;
using System;
using static Cqrs.Commands.AddPerson;

namespace Cqrs.Profiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<Person, PersonByName.Response>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id.ToString()))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(x => DateTime.Now.Year - x.DateOfBirth.Year ));

            CreateMap<PersonRequest, Person>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => Guid.NewGuid()))
               ;

            CreateMap<Person, PersonResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(x => x.Id.ToString()));

        }
    }
}
