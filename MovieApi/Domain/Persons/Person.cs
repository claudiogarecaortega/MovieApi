using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Persons
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Aliases { get; set; }

        #region Relationships
        public virtual IList<PersonMovie> PersonMovies { get; set; }
        public virtual IList<PersonDirector> PersonDirectors { get; set; }
        public virtual IList<PersonProducer> PersonProducers { get; set; }

        #endregion
    }
}
