using Domain.Movies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Persons
{
    public class PersonDirector
    {
        public virtual Person Person { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
