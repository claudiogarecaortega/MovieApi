using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class PersonModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Aliases { get; set; }

        public virtual IDictionary<string, string> PersonMovies { get; set; }
        public virtual IDictionary<string, string> PersonDirectors { get; set; }
        public virtual IDictionary<string, string> PersonProducers { get; set; }
    }
}
