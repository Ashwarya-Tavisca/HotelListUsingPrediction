using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Newtonsoft.Json;
using HotelList.Models;
using static HotelList.Models.Hotel;

namespace HotelList.Controllers
{
    public class HotelListController : ApiController
    {

        [HttpGet]

        public JsonResult<List<Result>> GET([FromUri]string inputString)

        {
            var result = new WebClient().DownloadString("https://maps.googleapis.com/maps/api/place/autocomplete/json?input=" + inputString + "&types=geocode&language=en&key=AIzaSyAFAfIYYn-j8qsBgk8j4f3RWXEvlJZIhvI");
            var Jsonobject = JsonConvert.DeserializeObject<Root1>(result);
            List<Prediction> autocomplete = Jsonobject.predictions;
            string place = autocomplete[0].description;
            var result2 = new WebClient().DownloadString("https://maps.googleapis.com/maps/api/place/textsearch/json?query=hotels+in+" + place + "&radius=10000&key=AIzaSyAFAfIYYn-j8qsBgk8j4f3RWXEvlJZIhvI");
            var Jsonobject1 = JsonConvert.DeserializeObject<Root2>(result2);
            List<Result> HotelList = Jsonobject1.Results;

            return Json(HotelList);
        }

    }
}
