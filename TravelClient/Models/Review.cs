using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TravelClient.Models
{
    public class Review
    {
        public string User_Name { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Details { get; set; }
        public int Rating { get; set; }

        public static List<Review> GetReviews(string apiKey)
        {
            Task<string> apiCallTask = ApiHelper.ApiCall(apiKey);
            string result = apiCallTask.Result;

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            List<Review> reviewList = JsonConvert.DeserializeObject<List<Review>>(jsonResponse["results"].ToString());

            return reviewList;
        }
    }
}