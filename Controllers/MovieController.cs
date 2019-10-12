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
        private IDataRepository movieRespository = new MovieInfoRepository();

        [HttpGet("api/movies")]
        public List<object> GetAllMovieInfo()
        {
            try
            {
                List<object> listAllMovies = movieRespository.GetAll();
                return listAllMovies;
            }
            catch
            {
                return null;
            }    
        }

        [HttpGet("api/movie/{movieId}")]
        public MovieInfo GetMovie(int movieId)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            List<object> listMovie = GetAllMovieInfo();
            MovieInfo temp = new MovieInfo();
            foreach (MovieInfo item in listMovie)
            {
                if(item.movieID == movieId)
                {
                    temp = item;
                    break;
                }
            }
            return temp;
        }

        [HttpPost("api/add-new-movie")]
        public HttpResponseMessage AddNewMovie([FromBody]object newMovie)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            if (movieRespository.Create(newMovie))
            {
                response.StatusCode = System.Net.HttpStatusCode.OK;
                return response;
            } 
            else
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return response;
            }
        }

        [HttpDelete("api/delete/{movieId}")]
        public HttpResponseMessage DeleteMovie([FromBody]object deletedMovie)
        {
            HttpResponseMessage response = new HttpResponseMessage();
            if (movieRespository.Create(deletedMovie))
            {
                response.StatusCode = System.Net.HttpStatusCode.OK;
                return response;
            }
            else
            {
                response.StatusCode = System.Net.HttpStatusCode.BadRequest;
                return response;
            }
        }
    }
}
