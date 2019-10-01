using angularASPApp.DataContext;
using angularASPApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace angularASPApp.Controllers
{
    public class OrderController : Controller
    {
        private OrderRepository orderRepo= new OrderRepository();

        [HttpGet("api/orders")]
        public List<object> GetAllOrders()
        {
            return orderRepo.GetAll();
        }

        [HttpGet("api/orders/{userId}")]
        public List<object> GetOrder(string userId)
        {
            return orderRepo.GetAll(userId);
        }

        [HttpPost("api/create-new-order")]
        public HttpResponseMessage CreateNewOrder([FromBody]object order)
        {
            var response = new HttpResponseMessage();
            if (orderRepo.Create(order) == true)
            {
                response.StatusCode = System.Net.HttpStatusCode.OK;
                return response;
            }
            else
            {
                response.StatusCode = System.Net.HttpStatusCode.NotImplemented;
                return response;
            }
        }

        [HttpDelete("api/delete-order")]
        public HttpResponseMessage DeletedOrder([FromBody]object order)
        {
            var response = new HttpResponseMessage();
            if (orderRepo.Delete(order) == true)
            {
                response.StatusCode = System.Net.HttpStatusCode.OK;
                return response;
            }
            else
            {
                response.StatusCode = System.Net.HttpStatusCode.NotImplemented;
                return response;
            }
        }

        [HttpPut("api/update-order")]
        public HttpResponseMessage UpdateOrder([FromBody]object order)

        {
            var response = new HttpResponseMessage();
            if (orderRepo.Update(order) == true)
            {
                response.StatusCode = System.Net.HttpStatusCode.OK;
                return response;
            }
            else
            {
                response.StatusCode = System.Net.HttpStatusCode.NotImplemented;
                return response;
            }
        }
    }
}
