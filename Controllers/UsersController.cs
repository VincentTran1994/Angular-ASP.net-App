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
        public UserInfoRepository DBcontext = new UserInfoRepository();

        [HttpGet("api/users")]
        public List<object> Info()
        {
            List<object> listAllMembers = DBcontext.GetAll();
            return listAllMembers;
        }

        [HttpGet("api/user/{userID}")]
        public UserInfo UserInfo(string userID)
        {
            return DBcontext.Get(userID) as UserInfo;
        }

        [HttpPost("api/addnewuser")]
        public void AddNewUser([FromBody]UserInfo newUser)
        {
            DBcontext.Create(newUser);
        }

        [HttpPut("api/updateduser")]
        public void UpdatedUser(string email, [FromBody]UserInfo user)
        {
            DBcontext.Update(user);
        }
    }
}
