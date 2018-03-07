using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Exchange.WebServices.Data;
using meetingRooms.backend.Models;

namespace meetingRooms.backend.Controllers
{
    public class GetMeetingsController : ApiController
    {
        private MeetingRoom[] rooms = new MeetingRoom[]
        {
            new MeetingRoom { Email = "large-meeting-room@sibedge.com", Name = "Большая переговорка"},
            new MeetingRoom { Email = "small-meeting-room@sibedge.com", Name = "Малая переговорка"}
        };

        private ExchangeService service;

        public GetMeetingsController()
        {
            service = new Services.ExchageService().GetExchange();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [Route("meetings/{id}")]
        public IEnumerable<Meeting> GetMeetings(int id)
        {
            FolderId folderIdFromCalendar;
            try
            {
                folderIdFromCalendar = new FolderId(WellKnownFolderName.Calendar, rooms[id].Email); //Get room calendar folder
            } catch(Exception)
            {
                throw new System.Web.HttpException(400, "Incorrect room id");
            }
            

            DateTime startDate = DateTime.Today;
            CalendarView cView = new CalendarView(startDate, startDate.AddDays(1), 200); //Set date

            FindItemsResults<Item> appointments = service.FindItems(folderIdFromCalendar, cView); //Get Appointments by room
            List<Meeting> meetings = new List<Meeting>();
            foreach(Appointment appointment in appointments)
                meetings.Add(new Meeting()
                    {
                        Subject = appointment.Subject,
                        StartTime = appointment.Start,
                        Duration = appointment.Duration
                    }
                );

            return meetings;
        }
    }
}
