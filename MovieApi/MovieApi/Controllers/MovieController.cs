using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Models;

namespace MovieApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MovieController : BaseController
    {

        [HttpGet(Name = "Get")]
        public IEnumerable<MovieModel> Get(int id)
        {
            if(id > 0)
            {
                var item = _movieService.GetById(id);
                return new List<MovieModel>() { item};
            }
            var items = _movieService.GetAll();
            return items.AsEnumerable();
        }

        [HttpPost(Name = "Create")]
        public MovieModel Create([FromBody] MovieModel model)
        {
            return _movieService.Create(model);
        }

        [HttpPut(Name = "Update")]
        public MovieModel Update([FromBody] MovieModel model)
        {
            return _movieService.Update(model);
        }


        [HttpDelete(Name = "Delete")]
        public ActionResult Delete(int id)
        {
            _movieService.Delete(id);
            return Ok();
        }

    }
}
