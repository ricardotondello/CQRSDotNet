using System.Collections.Generic;
using Cqrs.Domain;

namespace Cqrs.Database
{
    public interface IRepository
    {
        List<Domain.Person> GetPeople(string name, PaginationFilter pagination = null);
        void AddPerson(Domain.Person person);
    }
}