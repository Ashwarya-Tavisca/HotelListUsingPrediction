using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelList.Models
{
    public class Hotel
    {
        public class Result
        {
            public string name { get; set; }
            public string formatted_address { get; set; }
            // public string geometry { get; set; }

        }
    }
}