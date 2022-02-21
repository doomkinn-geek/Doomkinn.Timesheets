using Doomkinn.Timesheets.Models;
using System.Collections.Generic;

namespace Doomkinn.Timesheets.Repository
{
    public interface IPersonRepository
    {
        public IReadOnlyCollection<Person> Get();
        public Person Get(int id);
        public IReadOnlyCollection<Person> Get(int skip, int take);
        public IReadOnlyCollection<Person> Get(string name);
        public Person Add(Person entity);
        public void Update(Person entity);
        public void Delete(int id);        
    }
}
