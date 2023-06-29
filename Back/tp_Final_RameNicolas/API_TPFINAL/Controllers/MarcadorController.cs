
using API_TPFINAL.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace API_TPFINAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcadorController : ControllerBase
    {

        private readonly IAuthService _authService;

        public MarcadorController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet("ObtenerMarcadores")]
        public async Task<IActionResult> ObtenerMarcadores()
        {
            string apiUrl = "https://prog3.nhorenstein.com/api/marcador/GetMarcadores";
            using (HttpClient client = new HttpClient())
            {
                string token = await _authService.GetAuthToken();

                if (!string.IsNullOrEmpty(token))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var marcadoresJson = await response.Content.ReadAsStringAsync();
                        return Ok(marcadoresJson);
                    }
                    else
                    {
                        return BadRequest("Error en la solicitud. Código de estado: " + response.StatusCode);
                    }
                }
                else
                {
                    return BadRequest("No se encontró un token válido en la caché de memoria.");
                }
            }

        }
    }
}
