using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module1.Models;

namespace Module1.Controllers
{
    ////[ApiVersion("1.0")]
    //[Produces("application/json")]
    ////[Route("api/v{version:apiVersion}/movies")] //version by url path
    ////[Route("api/movies")]
    //[ApiController]
    //public class MoviesV1Controller : ControllerBase
    //{
    //    static List<MoviesV1> movies = new List<MoviesV1>()
    //    {
    //        new MoviesV1 { Id = 0, MovieName = "Mission Impossible" },
    //        new MoviesV1 { Id = 1, MovieName = "Jumanji" }

    //    };
    //    // GET: api/MoviesV1
    //    [HttpGet]
    //    public IEnumerable<MoviesV1> Get()
    //    {
    //        return movies;
    //    }

    //    // GET: api/MoviesV1/5
    //    //[HttpGet("{id}", Name = "Get")]
    //    //public string Get(int id)
    //    //{
    //    //    return "value";
    //    //}

    //    // POST: api/MoviesV1
    //    [HttpPost]
    //    public void Post([FromBody] string value)
    //    {
    //    }

    //    // PUT: api/MoviesV1/5
    //    [HttpPut("{id}")]
    //    public void Put(int id, [FromBody] string value)
    //    {
    //    }

    //    // DELETE: api/ApiWithActions/5
    //    [HttpDelete("{id}")]
    //    public void Delete(int id)
    //    {
    //    }
    //}
}
