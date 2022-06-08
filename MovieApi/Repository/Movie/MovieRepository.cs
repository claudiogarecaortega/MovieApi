using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Movie
{
    public class MovieRepository : BaseRepository<Domain.Movies.Movie>
    {

        public MovieRepository(): base()
        {

        }

        public IList<Domain.Movies.Movie> GetAll()
        {
            return Movies;
        }

        public Domain.Movies.Movie GetById(int id)
        {
            return Movies.FirstOrDefault(x=>x.Id == id);
        }

        public Domain.Movies.Movie Update(Domain.Movies.Movie model)
        {
            return Movies.FirstOrDefault(x => x.Id == model.Id);
        }

        public Domain.Movies.Movie Create(Domain.Movies.Movie model)
        {
            Movies.Add(model);
            return model;
        }

        public void Delete(int id)
        {
            var item = Movies.FirstOrDefault(x => x.Id == id);
            if(item != null)
            {
                Movies.Remove(item);
            }
        }
    }
}
