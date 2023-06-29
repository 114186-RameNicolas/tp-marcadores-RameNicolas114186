using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using API_TPFINAL.Service;

namespace API_TPFINAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticarController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AutenticarController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Authenticate()
        {
            string token = await _authService.GetAuthToken();
            return Ok(token);
        }
    }
}
