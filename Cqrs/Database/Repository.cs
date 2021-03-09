using Bogus;
using System;
using System.Collections.Generic;

namespace Cqrs.Database
{
    public class Repository
    {
        public List<Domain.Person> People { get; } =
            new Faker<Domain.Person>().
            CustomInstantiator(f => new Domain.Person(Guid.NewGuid(), 
                                                        f.Person.FirstName, 
                                                        f.Person.LastName, 
                                                        f.Person.DateOfBirth))
                .Generate(100);
    }
}
