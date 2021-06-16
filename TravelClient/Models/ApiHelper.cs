using RestSharp;
using System.Threading.Tasks;

namespace TravelClient.Models
{
    class ApiHelper
    {
        public static async Task<string> GetAll()
        {
            RestClient client = new RestClient("https://localhost:5001/api");
            RestRequest request = new RestRequest($"reviews", Method.GET);
            IRestResponse response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task<string> Get(int id)
        {
            RestClient client = new RestClient("https://localhost:5001/api");
            RestRequest request = new RestRequest($"reviews/{id}", Method.GET);
            IRestResponse response = await client.ExecuteTaskAsync(request);
            return response.Content;
        }

        public static async Task Post(string newReview)
        {
            RestClient client = new RestClient("http://localhost:5001/api");
            RestRequest request = new RestRequest($"reviews", Method.GET);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(newReview);
            IRestResponse response = await client.ExecuteTaskAsync(request);
        }

        public static async Task Put(int id, string newReview)
        {
            RestClient client = new RestClient("http://localhost:5001/api");
            RestRequest request = new RestRequest($"reviews/{id}", Method.PUT);
            request.AddHeader("Content-Type", "application/json");
            request.AddJsonBody(newReview);
            IRestResponse response = await client.ExecuteTaskAsync(request);
        }

        public static async Task Delete(int id)
        {
            RestClient client = new RestClient("http://localhost:5001/api");
            RestRequest request = new RestRequest($"reviews/{id}", Method.DELETE);
            request.AddHeader("Content-Type", "application/json");
            IRestResponse response = await client.ExecuteTaskAsync(request);
        }
    }
}