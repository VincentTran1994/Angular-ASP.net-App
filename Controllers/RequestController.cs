using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using angularASPApp.DataContext;
using angularASPApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace angularASPApp.Controllers
{
    public class RequestController : Controller
    {
        public RequestRepository RequestRepository = new RequestRepository();

        [HttpPost("api/add-new-request")]
        public void AddNewRequest([FromBody]object requestId)
        {
            RequestRepository.Create(requestId);
        }

        [HttpGet("api/requests")]
        public List<object> Requests()
        {
            List<object> listAllRequest = RequestRepository.GetAll();
            return listAllRequest;
        }

        [HttpGet("api/request/{requestId}")]
        public Request GetRequest(string requestId)
        {
            return RequestRepository.Get(requestId) as Request;
        }
                      
        [HttpPut("api/update-request")]
        public void UpdateRequest([FromBody]object request)
        {
            RequestRepository.Update(request);
        }

        [HttpDelete("api/delete-request")]
        public void DeleteRequest([FromBody]object request)
        {
            RequestRepository.Delete(request);
        }
    }
}
