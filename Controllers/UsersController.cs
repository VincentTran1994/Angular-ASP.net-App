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

        [HttpPost("api/signup")]
        public void SignUp([FromBody]User newUser)
        {
            UserRepository.Create(newUser);
        }

        [HttpGet("api/users")]
        public List<object> Users()
        {
            List<object> listAllMembers = UserRepository.GetAll();
            return listAllMembers;
        }

        [HttpGet("api/user/{userID}")]
        public User GetUser(string userID)
        {
            return UserRepository.Get(userID) as User;
        }

        [HttpGet("api/users-info")]
        public List<object> GetAllUserInfo()
        {
            List<object> listAllMembers = UserInfoRepository.GetAll();
            return listAllMembers;
        }

        [HttpGet("api/user-info/{userID}")]
        public UserInfo GetUserInfo(string userID)
        {
            return UserInfoRepository.Get(userID) as UserInfo;
        }

        [HttpPost("api/add-user-info")]
        public void AddNewUserInfo([FromBody]UserInfo newUser)
        {
            UserInfoRepository.Create(newUser);
        }

        [HttpPut("api/update-user-info")]
        public void UpdatedUser(string email, [FromBody]UserInfo user)
        {
            UserInfoRepository.Update(user);
        }
    }
}
