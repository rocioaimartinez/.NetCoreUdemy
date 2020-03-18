using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module1.Models;

namespace Module1.Controllers
{
    ////[ApiVersion("2.0")]
    //[Produces("application/json")]
    ////[Route("api/movies")]
    ////[Route("api/v{version:apiVersion}/movies")]
    //[ApiController]
    //public class MovieV2Controller : ControllerBase
    //{
    //    static List<MovieV2> movies = new List<MovieV2>()
    //    {
    //        new MovieV2{ Id=0, MovieName="Lord Of The Rings", MovieDescription="an overrated movie", Type="Fantasy"},
    //        new MovieV2{ Id=1, MovieName="HSM", MovieDescription="high school movie", Type="teenagers"},
    //        new MovieV2{ Id=2, MovieName="zombieland", MovieDescription="lazy sunday movie", Type="zombies"}
    //    };
    //    // GET: api/MovieV2
    //    [HttpGet]
    //    public IEnumerable<MovieV2> Get()
    //    {
    //        return movies;
    //    }

    //    // GET: api/MovieV2/5
    //    //[HttpGet("{id}", Name = "Get")]
    //    //public string Get(int id)
    //    //{
    //    //    return "value";
    //    //}

    //    // POST: api/MovieV2
    //    [HttpPost]
    //    public void Post([FromBody] string value)
    //    {
    //    }

    //    // PUT: api/MovieV2/5
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
