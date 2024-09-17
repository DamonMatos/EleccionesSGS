using Microsoft.AspNetCore.Mvc;
using WSEleccionesSSMA.Services;
using WSEleccionesSSMA.Helper;
using WSEleccionesSSMA.Models;
using DocumentFormat.OpenXml.Packaging;

namespace WSEleccionesSSMA.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class ColaboradoresController : Controller
    {
        private readonly IConfiguration _configuration;
        private IColaboradoresService _ColabService;

        public ColaboradoresController(IConfiguration configuration, IColaboradoresService colabService)
        {
            _configuration = configuration;
            _ColabService = colabService;
        }

        [Authorize]
        [HttpPost]
        [Route("Add")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> Add(String _request)
        {
            String _mensaje = String.Empty;
            int _estado = 0;
            List<Colaboradores> _ListColaboradores = new List<Colaboradores>();
            try
            {
                var cn = _configuration.GetConnectionString("DbConn");
                _ListColaboradores = _ColabService.Add(_request, cn);

            }
            catch (Exception ex)
            {
                _mensaje = ex.Message;
                _estado = 0;
            }
            return Ok(JsonResponse.response(_ListColaboradores, _estado, _mensaje));

        }

    }
}






