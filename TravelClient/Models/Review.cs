using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TravelClient.Models
{
    public class Review
    {
        public int ReviewId { get; set; }
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

        public static Review GetDetails(int id)
        {
            Task<string> apiCallTask = ApiHelper.Get(id);
            string result = apiCallTask.Result;

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            Review review = JsonConvert.DeserializeObject<Review>(jsonResponse.ToString());

            return review;
        }

        public async static Task Post(Review review)
        {
            string jsonReview = JsonConvert.SerializeObject(review);
            await ApiHelper.Post(jsonReview);
        }

        public async static Task Put(Review review)
        {
            string jsonReview = JsonConvert.SerializeObject(review);
            await ApiHelper.Put(review.ReviewId, jsonReview);
        }

        public async static Task Delete(int id)
        {
            await ApiHelper.Delete(id);
        }
    }
}