using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using angularASPApp.DataContext;
using angularASPApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace angularASPApp.Controllers
{
    public class UsersController : Controller
    {
        public UserInfoRepository UserInfoRepository = new UserInfoRepository();
        public UserRepository UserRepository = new UserRepository();

        /// <summary>
        /// Add new user
        /// </summary>
        /// <param name="newUser"></param>
        [HttpPost("api/add-new-user")]
        public void AddNewUser([FromBody]object newUser)
        {
            UserRepository.Create(newUser);
            UserInfoRepository.Create(newUser);
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
        public Order GetUserInfo(string userId)
        {
            return UserInfoRepository.Get(userId) as Order;
        }

        /// <summary>
        /// Retrieve a specific user information
        /// </summary>
        /// <returns></returns>
        [HttpGet("api/users-info")]
        public List<object> GetAllUserInfo()
        {
            List<object> listAllMembers = UserInfoRepository.GetAll();
            return listAllMembers;
        }

        /// <summary>
        /// Update user information
        /// </summary>       
        [HttpPut("api/update-user-info")]
        public void UpdatedUser([FromBody]object user)
        {
            UserInfoRepository.Update(user);
            UserRepository.Update(user);
        }

        /// <summary>
        /// Delete a user from DB
        /// </summary>
        [HttpDelete("api/delete-user-info")]
        public void DeletedUser([FromBody]object user)
        {
            UserInfoRepository.Delete(user);
            UserRepository.Delete(user);
        }
    }
}
