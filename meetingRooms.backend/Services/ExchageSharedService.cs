using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Exchange.WebServices.Data;

namespace meetingRooms.backend.Services
{
    public class ExchageSharedService : IExchangeSharedService
    {
        private readonly ExchangeService _service;

        public ExchageSharedService()
        {
            _service = new ExchangeService(); //Auth
            _service.Credentials = new WebCredentials(PrivateVariables.Email, PrivateVariables.Password);
            _service.Url = new Uri("https://outlook.office365.com/EWS/Exchange.asmx");
        }
        public ExchangeService GetExchange()
        {
            return _service;
        }
    }
}