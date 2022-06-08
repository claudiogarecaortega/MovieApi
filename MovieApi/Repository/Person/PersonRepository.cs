using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Person
{
    public class PersonRepository : BaseRepository<Domain.Persons.Person>
    {

        public PersonRepository() : base()
        {

        }

        public IList<Domain.Persons.Person> GetAll()
        {
            return Persons;
        }

        public Domain.Persons.Person GetById(int id)
        {
            return Persons.FirstOrDefault(x => x.Id == id);
        }

        public Domain.Persons.Person Update(Domain.Persons.Person model)
        {
            return Persons.FirstOrDefault(x => x.Id == model.Id);
        }

        public Domain.Persons.Person Create(Domain.Persons.Person model)
        {
            Persons.Add(model);
            return model;
        }

        public void Delete(int id)
        {
            var item = Persons.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                Persons.Remove(item);
            }
        }
    }
}
