using Data;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MoviesController : ControllerBase
    {
        private AwardsDBContext dbContext;

        public MoviesController(AwardsDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public List<Movie> GetMovies()
        {
            return dbContext.Movies.ToList();
        }
    }
}
