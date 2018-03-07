using meetingRooms.backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace meetingRooms.backend.Controllers
{
    public class UserFilterController : ApiController
    {
        
        [Route("users/{userName}")]
        public IEnumerable<User> GetUsers(string userName)
        {
            userName = Char.ToUpper(userName[0])+userName.Substring(1);
            return UsersDataSource.getUsers().OfType<User>().Where(i => i.Surname.StartsWith(userName)|i.Email.StartsWith(userName));
        }
    }
}