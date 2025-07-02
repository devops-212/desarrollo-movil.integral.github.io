using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EcoDive_Integradora.Models;
using Newtonsoft.Json;

namespace EcoDive_Integradora.Services
{
    public static class FirebaseService
    {
        static HttpClient client = new HttpClient();
        static string firebaseUrl = "https://integradora10a-f1ca9-default-rtdb.firebaseio.com/";

        public static async Task GuardarTrivia(TriviaModel trivia)
        {
            var json = JsonConvert.SerializeObject(trivia);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PostAsync($"{firebaseUrl}trivia.json", content);
        }

        public static async Task<List<TriviaModel>> ObtenerTrivia()
        {
            var response = await client.GetStringAsync($"{firebaseUrl}trivia.json");
            var data = JsonConvert.DeserializeObject<Dictionary<string, TriviaModel>>(response);
            return data?.Values.ToList() ?? new List<TriviaModel>();
        }
    }
}
