using meetingRooms.backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using meetingRooms.backend.Services;
using Microsoft.Exchange.WebServices.Data;

namespace meetingRooms.backend.Controllers
{
    public class UserFilterController : ApiController
    {
        private ExchangeService _service;

        public UserFilterController(IExchangeSharedService serviceGetter)
        {
            _service = serviceGetter.GetExchange();
        }

        [Route("users")]
        public IEnumerable<User> GetUsers(string userName = "SMTP:")
        {
            var names = _service.ResolveName(userName);
            List<User> usersList = new List<User>();
            foreach (var contact in names)
            {
                usersList.Add(new User()
                {
                    Email = contact.Mailbox.Address,
                    Surname = contact.Mailbox.Name,
                });
            }
            return usersList;
        }
    }
}