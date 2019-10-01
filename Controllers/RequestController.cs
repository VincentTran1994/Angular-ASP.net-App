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
        public UserRepository UserRepository = new UserRepository();

        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="newUser"></param>
        [HttpPost("api/add-new-user")]
        public void AddNewUser([FromBody]object newUser)
        {
            UserRepository.Create(newUser);
            RequestRepository.Create(newUser);
        }

        /// <summary>
        /// Retrieve list of users
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/users")]
        public List<object> Users()
        {
            List<object> listAllMembers = UserRepository.GetAll();
            return listAllMembers;
        }

        /// <summary>
        /// Retrieve a specific user with userId
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("api/user/{userID}")]
        public User GetUser(string userId)
        {
            return UserRepository.Get(userId) as User;
        }

        /// <summary>
        /// Retrieve a specific user with all information
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("api/user-info/{userID}")]
        public User GetUserInfo(string userId)
        {
            return RequestRepository.Get(userId) as User;
        }

        /// <summary>
        /// Retrieve a specific user information
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/users-info")]
        public List<object> GetAllUserInfo()
        {
            List<object> listAllMembers = RequestRepository.GetAll();
            return listAllMembers;
        }

        /// <summary>
        /// Update user information
        /// </summary>       
        [HttpPut("api/update-user-info")]
        public void UpdatedUser([FromBody]object user)
        {
            RequestRepository.Update(user);
            UserRepository.Update(user);
        }

        /// <summary>
        /// Delete a user from DB
        /// </summary>
        [HttpDelete("api/delete-user-info")]
        public void DeletedUser([FromBody]object user)
        {
            RequestRepository.Delete(user);
            UserRepository.Delete(user);
        }
    }
}
