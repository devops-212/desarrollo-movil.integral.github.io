using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using EcoDive_Integradora.Services;


namespace EcoDive_Integradora.Services
{
    public class FirebaseAuthService
    {
        private static readonly string apiKey = "AIzaSyCf0ZvRcTZSjXa0f-ywnl4ZSJ0nbvdyEB0";
        private static readonly HttpClient client = new();

        public class FirebaseAuthResponse
        {
            public string IdToken { get; set; }
            public string Email { get; set; }
            public string LocalId { get; set; }
        }

        public static async Task<FirebaseAuthResponse?> Register(string email, string password)
        {
            var data = new
            {
                email,
                password,
                returnSecureToken = true
            };

            var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(
                $"https://identitytoolkit.googleapis.com/v1/accounts:signUp?key={apiKey}", content);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<FirebaseAuthResponse>(json);
            }

            return null;
        }

        public static async Task<FirebaseAuthResponse?> Login(string email, string password)
        {
            var data = new
            {
                email,
                password,
                returnSecureToken = true
            };

            var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");

            var response = await client.PostAsync(
                $"https://identitytoolkit.googleapis.com/v1/accounts:signInWithPassword?key={apiKey}", content);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<FirebaseAuthResponse>(json);
            }

            return null;
        }
        // se se Deshabilita en  login la opcion de recuperar contraseña comentar toda la parte de ResetPassword 
        public static async Task<bool> ResetPassword(string email)
        {
            var client = new HttpClient();
            var request = new
            {
                requestType = "PASSWORD_RESET",
                email = email
            };

            var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key={apiKey}", content);

            return response.IsSuccessStatusCode;
        }

    }
}
