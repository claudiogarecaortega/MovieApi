using Domain.Persons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class BaseServices
    {
        public Repository.Movie.MovieRepository _movieRepository;

        public Repository.Person.PersonRepository _personRepository;
        public BaseServices()
        {
            _movieRepository = new Repository.Movie.MovieRepository();
            _personRepository = new Repository.Person.PersonRepository();
        }

        public Dictionary<string, string> ConvertDirectors(IList<PersonDirector> items)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var item in items)
            {
                if (!dictionary.ContainsKey(item.Person.FirstName))
                {
                    dictionary.Add(item.Person.FirstName, item.Movie.Title);

                }
            }
            return dictionary;
        }

        public Dictionary<string, string> ConvertProducers(IList<PersonProducer> items)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var item in items)
            {
                if (!dictionary.ContainsKey(item.Person.FirstName))
                {
                    dictionary.Add(item.Person.FirstName, item.Movie.Title);

                }
            }
            return dictionary;
        }

        public Dictionary<string, string> ConvertMovies(IList<PersonMovie> items)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (var item in items)
            {
                if(!dictionary.ContainsKey(item.Person.FirstName))
                {
                    dictionary.Add(item.Person.FirstName, item.Movie.Title);

                }
            }
            return dictionary;
        }
    }
}
