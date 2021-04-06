using System.Collections.Generic;

namespace Cqrs.Database
{
    public interface IRepository
    {
        List<Domain.Person> GetPeople();
        void AddPerson(Domain.Person person);
    }
}