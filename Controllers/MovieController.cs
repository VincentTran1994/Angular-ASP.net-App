using angularASPApp.DataContext;
using angularASPApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace angularASPApp.Controllers
{
    public class MovieController : Controller
    {
        MovieInfoRepository movieRespository = new MovieInfoRepository();

        [HttpGet("api/movies")]
        public HttpResponseMessage GetAllMovieInfo()
        {
            List<object> listAllMovies = movieRespository.GetAll();
            HttpResponseMessage response = new HttpResponseMessage();
            response.Content = new StringContent(listAllMovies.ToString());
            if(response.StatusCode== System.Net.HttpStatusCode.OK)
                return response;
            else
                return new HttpResponseMessage(System.Net.HttpStatusCode.NotImplemented);
        }

        [HttpPost("api/ad-new-movie")]
        public void AddNewMovie([FromBody]MovieInfo newMovie)
        {
            movieRespository.Create(newMovie);
        }
    }
}
