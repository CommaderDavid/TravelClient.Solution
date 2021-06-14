using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TravelClient.Models
{
    public class Review
    {
        public string User_Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Details { get; set; }
        public int Rating { get; set; }

        public static List<Review> GetReviews()
        {
            Task<string> apiCallTask = ApiHelper.GetAll();
            string result = apiCallTask.Result;

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            List<Review> reviewList = JsonConvert.DeserializeObject<List<Review>>(jsonResponse.ToString());

            return reviewList;
        }
    }
}