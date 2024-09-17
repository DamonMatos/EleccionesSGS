using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WSEleccionesSSMA.Models;
using WSEleccionesSSMA.Services;
using Microsoft.AspNetCore.Authorization;

namespace WSEleccionesSSMA.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class AuthenticateController : Controller
    {
        private readonly IConfiguration _configuration;
        private IAuthenticationService _authService;

        public AuthenticateController(IConfiguration configuration, IAuthenticationService authService)
        {
            _configuration = configuration;
            _authService   = authService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult AuthenticateUser(AuthenticateRequest _request)
        {
            String _mensaje = String.Empty;
            int _estado = 0;
            AuthenticateResponse _response = new AuthenticateResponse(); ;
            try
            {                               
                if (ModelState.IsValid)
                {
                    var cn = _configuration.GetConnectionString("DbConn");
                    _response = _authService.Authenticate(_request, cn);
                    if (_response != null)
                    {
                        _mensaje = "!!Bienvenido al Sistema de EleccionesSSMA!!";
                        _estado = 1;
                    }
                    else
                    {
                        _mensaje = "Usuario Incorrecto Vuelva a Ingresar";
                        _estado = 0;
                    }
                }
                return Ok(JsonResponse.response(_response, _estado, _mensaje));
            }
            catch(Exception ex)
            {
                _estado = 0;
                return Ok(JsonResponse.response(null, _estado, ex.Message));
            }
        }

    }
}
