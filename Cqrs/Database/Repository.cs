using Bogus;
using System;
using System.Collections.Generic;

namespace Cqrs.Database
{
    public class Repository
    {
        public List<Domain.Person> People { get; } =
            new Faker<Domain.Person>()
                .RuleFor(x => x.Id, Guid.NewGuid())
                .RuleFor(x => x.Name, f => f.Person.FirstName)
                .RuleFor(x => x.Surname, f => f.Person.LastName)
                .RuleFor(x => x.DateOfBirth, f => f.Person.DateOfBirth).Generate(100);
    }
}
