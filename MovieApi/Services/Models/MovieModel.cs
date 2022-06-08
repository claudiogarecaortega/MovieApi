using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ReleaseYear { get; set; }

        public virtual IDictionary<string, string> PersonMovies { get; set; }
        public virtual IDictionary<string, string> PersonDirectors { get; set; }
        public virtual IDictionary<string, string> PersonProducers { get; set; }
    }
}
