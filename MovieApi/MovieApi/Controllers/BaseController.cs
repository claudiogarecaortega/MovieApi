using Microsoft.AspNetCore.Mvc;
using Services.Services;
namespace MovieApi.Controllers
{
    public class BaseController : Controller
    {
        public PersonSerivice _personService;
        public MovieService _movieService;

        public BaseController()
        {
            _personService = new PersonSerivice();
            _movieService = new MovieService();
        }
    }
}
