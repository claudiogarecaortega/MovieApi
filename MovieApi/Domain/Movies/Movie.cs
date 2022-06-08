using Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Movies
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }

        #region Relationships
        public virtual IList<PersonMovie> PersonMovies { get; set; }
        public virtual IList<PersonDirector> PersonDirectors { get; set; }
        public virtual IList<PersonProducer> PersonProducers { get; set; }

        #endregion
    }
}
