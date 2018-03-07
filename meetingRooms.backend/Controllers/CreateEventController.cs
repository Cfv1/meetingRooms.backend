using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Microsoft.Exchange.WebServices.Data;
using meetingRooms.backend.Models;
using meetingRooms.backend.Services;

namespace meetingRooms.backend.Controllers
{
    public class CreateEventController : ApiController
    {
        private ExchangeService _service;

        public CreateEventController(IExchangeSharedService serviceGetter)
        {
            _service = serviceGetter.GetExchange();
        }
        /// <summary>
        /// Создает событие в календаре от лица test@sibedge.com в любой передаваемый email переговорки
        /// </summary>
        /// <param name="id">ID персонажа создающего событие</param>
        /// <param name="eventName">Название создаваемого события</param>
        /// <param name="roomEmail">EMAIL Переговорки</param>
        /// <param name="startTime">Время начала события в формате hh:mm</param>
        /// <param name="duration">Продолжительность события</param>
        [Route("addNewEvent")]
        public void createEvent(int id, string eventName, string roomEmail, string startTime, int duration)
        {
            // Работа со временем, допустим время приходит в формате hh:mm
            char[] separator = new char[1] { ':' };
            DateTime timeStart = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day,
                Int32.Parse(startTime.Split(separator)[0]), Int32.Parse(startTime.Split(separator)[1]), 0);
            DateTime timeEnd = DateTime.Parse(startTime).AddMinutes(duration);

            // Cоздание самого события
            var appointment = new Appointment(_service)
            {
                Subject = eventName, // изменить позже
                Body = UsersDataSource.getUsers().FirstOrDefault(user => user.Id == id).Surname,
                Location = eventName + " " + UsersDataSource.getUsers().FirstOrDefault(user => user.Id == id).Surname,
                Start = timeStart,
                End = timeEnd
            };
            appointment.Resources.Add(roomEmail);

            // Сохраняет событие в свой календарь
            appointment.Save(SendInvitationsMode.SendToAllAndSaveCopy);
        }

        private static bool RedirectionCallback(string url)
        {
            return url.ToLower().StartsWith("https://");
        }
    }
}