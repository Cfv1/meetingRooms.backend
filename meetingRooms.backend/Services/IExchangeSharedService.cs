using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Exchange.WebServices.Data;

namespace meetingRooms.backend.Services
{
    public interface IExchangeSharedService
    {
        ExchangeService GetExchange();
    }
}