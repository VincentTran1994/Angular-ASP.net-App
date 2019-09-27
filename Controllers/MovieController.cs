using angularASPApp.DataContext;
using angularASPApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace angularASPApp.Controllers
{
    public class MovieController : Controller
    {
        MovieInfoRepository movieRespository = new MovieInfoRepository();

        [HttpGet("api/movies")]
        public List<object> GetAllMovieInfo()
        {
            List<object> listAllMovies = movieRespository.GetAll();
            return listAllMovies;
        }
    }
}
