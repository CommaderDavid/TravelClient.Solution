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
    }
}