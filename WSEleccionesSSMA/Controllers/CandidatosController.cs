using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WSEleccionesSSMA.Helper;
using WSEleccionesSSMA.Models;
using WSEleccionesSSMA.Services;

namespace WSEleccionesSSMA.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class CandidatosController : Controller
    {
        private readonly IConfiguration _configuration;
        private ICandidatosService _CandService;

        public CandidatosController(IConfiguration configuration, ICandidatosService candService)
        {
            _configuration = configuration;
            _CandService   = candService;
        }

        [Authorize]
        [HttpPost]
        [Route("Add")]
        public IActionResult Add()
        {
            String _mensaje = String.Empty;
            int _estado = 0;
            String _Ruta = String.Empty;
            List<Candidatos> _ListCandidato = new List<Candidatos>(); 
            Candidatos _Candidato = null;  
            try
            {
                var formCollection = Request.Form;
                var file = formCollection.Files.First();
                _Ruta = Path.Combine("Resources", "Images");
                var cn = _configuration.GetConnectionString("DbConn");
                _Candidato = JsonConvert.DeserializeObject<Candidatos>(formCollection["Candidatos"]);
                Helper.ArchivosIO _Convertidor = new ArchivosIO();
                if (file.Length > 0)
                {
                    _Ruta = String.Format("{0}/{1}/{2}.jpg", _Ruta, _Candidato.NumeroDocumento, _Candidato.NumeroDocumento);

                    _Candidato.UrlFile = Path.GetFileName(_Ruta);
                    _Convertidor.UploadFile(file, _Ruta);
                }

                _ListCandidato = _CandService.Add(_Candidato,cn);
            }
            catch (Exception ex)
            {
                _mensaje = ex.Message;
                _estado = 0;
            }
            return Ok(JsonResponse.response(_ListCandidato, _estado, _mensaje));
        }
    }
}
