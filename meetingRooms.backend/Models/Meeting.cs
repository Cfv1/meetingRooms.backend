using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace meetingRooms.backend.Models
{
    public class Meeting
    {
        public int Id { get; set; }

        public String Subject { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
    }
}