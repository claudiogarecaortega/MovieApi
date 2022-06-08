using Domain.Persons;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class MovieService:BaseServices
    {
        public MovieService():base()
        {

        }

        public IList<MovieModel> GetAll()
        {
            var items = _movieRepository.GetAll();
            return MapItem(items);
        }

        public MovieModel GetById(int id)
        {
            var item = _movieRepository.GetById(id);
            var list = new List<Domain.Movies.Movie>();
            list.Add(item);
            return MapItem(list).First();

        }

        public MovieModel Update(MovieModel model)
        {
            _movieRepository.Update(MapModelToDomain(model));
            return model;
        }

        public MovieModel Create(MovieModel model)
        {
            _movieRepository.Create(MapModelToDomain(model));
            return model;
        }

        public void Delete(int id)
        {
            _movieRepository.Delete(id);
        }

        public IList<MovieModel> MapItem(IList<Domain.Movies.Movie> input)
        {
            var moviesModelList = new List<MovieModel>();
            foreach (var item in input)
            {
                moviesModelList.Add(new MovieModel() { Id = item.Id, Title = item.Title, ReleaseYear = item.ReleaseYear, PersonDirectors = ConvertDirectors(item.PersonDirectors),
                PersonMovies = ConvertMovies(item.PersonMovies), PersonProducers = ConvertProducers(item.PersonProducers)});
            }
            return moviesModelList;
        }
        
        public Domain.Movies.Movie MapModelToDomain(MovieModel model)
        {
            var personDirectors = new List<PersonDirector>();
            var personMovie = new List<PersonMovie>();
            var personProducer = new List<PersonProducer>();

            foreach (var item in model.PersonDirectors)
            {
                var person = _personRepository.GetById(Convert.ToInt32(item.Key));
                var movie = _movieRepository.GetById(Convert.ToInt32(item.Value));
                if(person != null && movie != null)
                {
                    personDirectors.Add(new PersonDirector() { Movie=movie, Person=person });
                }

            }

            foreach (var item in model.PersonMovies)
            {
                var person = _personRepository.GetById(Convert.ToInt32(item.Key));
                var movie = _movieRepository.GetById(Convert.ToInt32(item.Value));
                if (person != null && movie != null)
                {
                    personMovie.Add(new PersonMovie() { Movie = movie, Person = person });
                }
            }

            foreach (var item in model.PersonProducers)
            {
                var person = _personRepository.GetById(Convert.ToInt32(item.Key));
                var movie = _movieRepository.GetById(Convert.ToInt32(item.Value));
                if (person != null && movie != null)
                {
                    personProducer.Add(new PersonProducer() { Movie = movie, Person = person });
                }
            }

            var entity = new Domain.Movies.Movie();
            entity.Title = model.Title;
            entity.ReleaseYear = model.ReleaseYear;
            entity.PersonDirectors = personDirectors;
            entity.PersonProducers = personProducer;
            entity.PersonMovies = personMovie;
            return entity;
        }

        
    }
}
