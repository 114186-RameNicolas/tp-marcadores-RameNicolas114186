using Newtonsoft.Json;

namespace API_TPFINAL.Service
{
    public class AuthService : IAuthService
    {
        private string authToken;

        public async Task<string> GetAuthToken()
        {
            if (string.IsNullOrEmpty(authToken))
            {
                string apiUrl = "https://prog3.nhorenstein.com/api/usuario/LoginUsuarioWeb";
                using (HttpClient client = new HttpClient())
                {
                    var postData = new
                    {
                        nombreUsuario = "nicolas",
                        password = "rame"
                    };

                    HttpResponseMessage response = await client.PostAsJsonAsync(apiUrl, postData);

                    if (response.IsSuccessStatusCode)
                    {
                        var responseContent = await response.Content.ReadAsStringAsync();
                        var responseObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                        authToken = responseObject.token;
                    }
                }
            }

            return authToken;
        }
    }
}
