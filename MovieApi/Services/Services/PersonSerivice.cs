using Domain.Persons;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class PersonSerivice : BaseServices
    {
        public PersonSerivice() : base() { }
        public IList<PersonModel> GetAll()
        {
            var items = _personRepository.GetAll();
            return MapItem(items);
        }

        public PersonModel GetById(int id)
        {
            var item = _personRepository.GetById(id);
            var list = new List<Domain.Persons.Person>();
            list.Add(item);
            return MapItem(list).First();

        }

        public PersonModel Update(PersonModel model)
        {
            _personRepository.Update(MapModelToDomain(model));
            return model;
        }

        public PersonModel Create(PersonModel model)
        {
            _personRepository.Create(MapModelToDomain(model));
            return model;
        }

        public void Delete(int id)
        {
            _movieRepository.Delete(id);
        }

        public IList<PersonModel> MapItem(IList<Domain.Persons.Person> input)
        {
            var personModelList = new List<PersonModel>();
            foreach (var item in input)
            {
                personModelList.Add(new PersonModel()
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    PersonDirectors = ConvertDirectors(item.PersonDirectors),
                    PersonMovies = ConvertMovies(item.PersonMovies),
                    PersonProducers = ConvertProducers(item.PersonProducers)
                });
            }
            return personModelList;
        }

        public Domain.Persons.Person MapModelToDomain(PersonModel model)
        {
            var personDirectors = new List<PersonDirector>();
            var personMovie = new List<PersonMovie>();
            var personProducer = new List<PersonProducer>();

            foreach (var item in model.PersonDirectors)
            {
                var person = _personRepository.GetById(Convert.ToInt32(item.Key));
                var movie = _movieRepository.GetById(Convert.ToInt32(item.Value));
                if (person != null && movie != null)
                {
                    personDirectors.Add(new PersonDirector() { Movie = movie, Person = person });
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

            var entity = new Domain.Persons.Person();
            entity.FirstName = model.FirstName;
            entity.LastName = model.LastName;
            entity.Aliases = model.Aliases;
            entity.PersonDirectors = personDirectors;
            entity.PersonProducers = personProducer;
            entity.PersonMovies = personMovie;
            return entity;
        }
    }
}
