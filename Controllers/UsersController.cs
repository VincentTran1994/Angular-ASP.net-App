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

        [HttpPost("api/add-new-user")]
        public void AddNewUser([FromBody]object newUser)
        {
            UserRepository.Create(newUser);
            UserInfoRepository.Create(newUser);
        }

        [HttpGet("api/users")]
        public List<object> Users()
        {
            List<object> listAllMembers = UserRepository.GetAll();
            return listAllMembers;
        }

        [HttpGet("api/user/{userID}")]
        public User GetUser(string userId)
        {
            return UserRepository.Get(userId) as User;
        }

        [HttpGet("api/user-info/{userID}")]
        public UserInfo GetUserInfo(string userId)
        {
            return UserInfoRepository.Get(userId) as UserInfo;
        }

        [HttpGet("api/users-info")]
        public List<object> GetAllUserInfo()
        {
            List<object> listAllMembers = UserInfoRepository.GetAll();
            return listAllMembers;
        }
    
        [HttpPut("api/update-user")]
        public void UpdatedUser([FromBody]object user)
        {
            UserInfoRepository.Update(user);
            UserRepository.Update(user);
        }

        [HttpDelete("api/delete-user/{userId}")]
        public void DeletedUser(string userId)
        {
            UserInfoRepository.Delete(userId);
            UserRepository.Delete(userId);
        }
    }
}
