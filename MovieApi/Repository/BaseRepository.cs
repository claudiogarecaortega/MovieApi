using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Movies;
using Domain.Persons;

namespace Repository
{
    public class BaseRepository<T> where T : class
    {
        public IList<Domain.Movies.Movie> Movies { get;  set; }

        public IList<Domain.Persons.Person> Persons { get;  set; }

        public BaseRepository()
        {
            Movies = new List<Domain.Movies.Movie>();
            Persons = new List<Domain.Persons.Person>();
            GenerateMovieData();
            GeneratePersonData();
            GenerateRelationships();
        }
        
        private void GenerateMovieData()
        {
            for (int i = 0; i < 100; i++)
            {
                Movies.Add(new Domain.Movies.Movie()
                {
                    Id=i,
                    Title=$"{GenerateRandomString()}",
                    ReleaseYear= GenerateRandomYear(),

                });
            }
        }

        private void GeneratePersonData()
        {
            for (int i = 0; i < 100; i++)
            {
                Persons.Add(new Domain.Persons.Person()
                {
                    Id = i,
                    FirstName= GenerateRandomString(),
                    LastName= GenerateRandomString(),
                    Aliases = GenerateRandomString(),

                });
            }
        }

        private void GenerateRelationships()
        {
            foreach (var movie in Movies)
            {
                if (movie.PersonDirectors == null)
                    movie.PersonDirectors = new List<PersonDirector>();

                if (movie.PersonProducers == null)
                    movie.PersonProducers = new List<PersonProducer>();

                if (movie.PersonMovies == null)
                    movie.PersonMovies = new List<PersonMovie>();

                for (int i = 0; i < 2; i++)
                {
                    var itemPerson = GenerateRandomItemFromList<Domain.Persons.Person>(Persons);
                    var itemMovie = GenerateRandomItemFromList<Domain.Movies.Movie>(Movies);
                    movie.PersonDirectors.Add(new PersonDirector() { Person = itemPerson, Movie = itemMovie });
                }

                for (int i = 0; i < 20; i++)
                {
                    var itemPerson = GenerateRandomItemFromList<Domain.Persons.Person>(Persons);
                    var itemMovie = GenerateRandomItemFromList<Domain.Movies.Movie>(Movies);
                    movie.PersonMovies.Add(new PersonMovie() { Person = itemPerson, Movie = itemMovie });

                }

                for (int i = 0; i < 10; i++)
                {
                    var itemPerson = GenerateRandomItemFromList<Domain.Persons.Person>(Persons);
                    var itemMovie = GenerateRandomItemFromList<Domain.Movies.Movie>(Movies);
                    movie.PersonProducers.Add(new PersonProducer() { Person = itemPerson, Movie = itemMovie });
                }
            }
            
        }
        private string GenerateRandomString()
        {
            Random rand = new Random();

            int stringlen = rand.Next(4, 10);
            int randValue;
            string str = "";
            char letter;
            for (int i = 0; i < stringlen; i++)
            {

                randValue = rand.Next(0, 26);
                letter = Convert.ToChar(randValue + 65);
                str = str + letter;
            }
            return str;
        }
        private int GenerateRandomYear()
        {
            Random rand = new Random();

            int year = rand.Next(1985, 2022);
           
            return year;
        }

        private TM GenerateRandomItemFromList<TM>(IList<TM> items)
        {
            Random rand = new Random();

            int index = rand.Next(items.Count);

            return items[index];
        }

        
    }
}
