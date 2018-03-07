using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Exchange.WebServices.Data;

namespace meetingRooms.backend.Services
{
    public class ExchageService : IExchangeService
    {
        private readonly Microsoft.Exchange.WebServices.Data.ExchangeService _service;

        public ExchageService()
        {
            _service = new Microsoft.Exchange.WebServices.Data.ExchangeService(); //Auth
            _service.Credentials = new WebCredentials(PrivateVariables.Email, PrivateVariables.Passwrord);
            _service.Url = new Uri("https://outlook.office365.com/EWS/Exchange.asmx");
        }
        public Microsoft.Exchange.WebServices.Data.ExchangeService GetExchange()
        {
            return _service;
        }
    }
}