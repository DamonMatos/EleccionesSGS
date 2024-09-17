using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Transactions;
using WSEleccionesSSMA.Helper;
using WSEleccionesSSMA.Models;
using WSEleccionesSSMA.Services;
namespace WSEleccionesSSMA.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class EleccionesController : Controller
    {
        private readonly IConfiguration _configuration;
        private IEleccionesService _ElecService;
        private IProcesoService _ProcService;

        public EleccionesController(IConfiguration configuration, IEleccionesService elecService, IProcesoService procService)
        {
            _configuration = configuration;
            _ElecService = elecService;
            _ProcService = procService;
        }

        [Authorize]
        [HttpGet("Get")]
        public IActionResult Get([FromQuery] Params _Parameters)
        {
            String _mensaje = String.Empty;
            int _estado = 0;
            String _CodigoOrigen = String.Empty;
            List<Elecciones> _ListElecciones = new List<Elecciones>();
            try
            {             
                _mensaje = "se Cargo correctamente";
                _estado = 1;
                _CodigoOrigen = "002";
                var cn = _configuration.GetConnectionString("DbConn");
                _ListElecciones = _ElecService.Get(_Parameters,_CodigoOrigen, cn);
            }
            catch (Exception ex)
            {
                _mensaje = ex.Message;
                _estado = 0;
            }
            return Ok(JsonResponse.response(_ListElecciones, _estado, _mensaje));
        }

        [Authorize]
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById([FromQuery] _Request _request)
        {
            String _mensaje = String.Empty;
            int _estado = 0;
            String _CodigoOrigen = String.Empty;

            List<Elecciones> _List = new List<Elecciones>();

            try
            {
                _mensaje = "se Cargo correctamente";
                _estado = 1;
                _request.CodigoOrigen = "002";
                var cn = _configuration.GetConnectionString("DbConn");
                _List = _ElecService.GetById(_request, cn);
            }
            catch (Exception ex)
            {
                _mensaje = ex.Message;
                _estado = 0;
            }
            return Ok(JsonResponse.response(_List, _estado, _mensaje));
        }

        [Authorize]
        [HttpPost]
        [Route("Add")]
        public IActionResult Add()
        {           
            int _estado = 0;
            int _tipo   = 1;
            String _mensaje = String.Empty;
            String _Ruta    = String.Empty;
            
            List<Elecciones> _ListElecciones = new List<Elecciones>();
            using (TransactionScope scope = new TransactionScope())
            {
                Elecciones _request = new Elecciones();
                List<Proceso> _ListProceso = new List<Proceso>();
                try
                {
                    var formCollection = Request.Form;
                    var file = formCollection.Files.First();
                    _Ruta    = Path.Combine("Resources", "Images");
                    var cn   = _configuration.GetConnectionString("DbConn");
                    _request = JsonConvert.DeserializeObject<Elecciones>(formCollection["Elecciones"]);
                    Helper.ArchivosIO _Convertidor = new ArchivosIO();
                    if (file.Length > 0)
                    {
                        _Ruta = String.Format("{0}/{1}/{2}.jpg", _Ruta,_request.Ruc,_request.Ruc);
                        _request.UrlLogo = Path.GetFileName(_Ruta);
                        _Convertidor.UploadFile(file,_Ruta);
                    }

                    _ListElecciones = _ElecService.Add(_tipo, _request, cn);
                    _request.CodigoEleccion = _ListElecciones[0].CodigoEleccion;
                    Proceso _proceso = null;

                    if (_ListElecciones.Count > 0)
                    {                       
                        _ListProceso = _request.List_proceso;
                        _proceso = new Proceso();
                        foreach (var x in _ListProceso)
                        {
                            _proceso.Tipo = 1;
                            _proceso.CodigoOrigen        = x.CodigoOrigen;
                            _proceso.CodigoCliente       = x.CodigoCliente;
                            _proceso.CodigoEleccion      = x.CodigoEleccion;
                            _proceso.NombreProceso       = x.NombreProceso;
                            _proceso.NumeroCandidatos    = x.NumeroCandidatos;
                            _proceso.VotacionObligatoria = x.VotacionObligatoria;
                            _ProcService.Add(_proceso,cn);
                        }

                        _Request _Objrequest = new _Request();
                        _Objrequest.CodigoOrigen = _request.CodigoOrigen;
                        _Objrequest.CodigoCliente = _request.CodigoCliente;
                        _Objrequest.CodigoEleccion = _request.CodigoEleccion.ToString();
                        _ListElecciones.Clear();
                        _ListElecciones = _ElecService.GetById(_Objrequest, cn);
                    }

                    _mensaje = "Se Registro Correctamente";
                    _estado = 1;
                    scope.Complete();
                    scope.Dispose();
                }
          
                catch (TransactionException ex)
                {
                    scope.Dispose();
                    return StatusCode(500, $"Internal server error: {ex}");
                }

                catch (Exception ex)
                {
                    _mensaje = ex.Message;
                    _estado = 0;
                }
            } 

            return Ok(JsonResponse.response(_ListElecciones, _estado, _mensaje));
        }


        [Authorize]
        [HttpPut]
        [Route("Put")]
        public IActionResult Put()
        {
            int _estado = 0;
            int _tipo   = 2;
            String _mensaje = String.Empty;
            String _Ruta    = String.Empty;
            String _Archivo = String.Empty;
            Elecciones _request = new Elecciones();
            List<Elecciones> _ListElecciones = new List<Elecciones>();
            List<Proceso> _ListProceso = new List<Proceso>();
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    var formCollection = Request.Form;
                    var file = formCollection.Files.First();
                    _Ruta = Path.Combine("Resources", "Images");
                    var cn = _configuration.GetConnectionString("DbConn");
                    _request = JsonConvert.DeserializeObject<Elecciones>(formCollection["Elecciones"]);
                    _Archivo = _request.Ruc.ToString();
                    Helper.ArchivosIO _Convertidor = new ArchivosIO();
                    if (file.Length > 0)
                    {
                        _Ruta = String.Format("{0}/{1}/{2}.jpg", _Ruta, _Archivo.Trim(), _Archivo);
                        _request.UrlLogo = Path.GetFileName(_Ruta);
                        _Convertidor.UploadFile(file, _Ruta);
                    }

                    _ListElecciones = _ElecService.Add(_tipo, _request, cn);
                    Proceso _proceso = null;
                    if (_ListElecciones.Count > 0)
                    {
                        _ListProceso = _request.List_proceso;
                        _proceso = new Proceso();
                        foreach (var x in _ListProceso)
                        {
                            _proceso.Tipo = 1;
                            _proceso.CodigoOrigen = x.CodigoOrigen;
                            _proceso.CodigoCliente = x.CodigoCliente;
                            _proceso.CodigoEleccion = x.CodigoEleccion;
                            _proceso.CodigoProceso = x.CodigoProceso;
                            _proceso.NombreProceso = x.NombreProceso;
                            _proceso.NumeroCandidatos = x.NumeroCandidatos;
                            _proceso.VotacionObligatoria = x.VotacionObligatoria;
                            _ProcService.Add(_proceso, cn);
                        }
                    }
                    _mensaje = "Se Modifico Correctamente";
                    _estado = 1;
                    scope.Complete();
                    scope.Dispose();

                }
                catch (TransactionException ex)
                {
                    scope.Dispose();
                    return StatusCode(500, $"Internal server error: {ex}");
                }

                catch (Exception ex)
                {
                    _mensaje = ex.Message;
                    _estado = 0;
                }

            } 

            return Ok(JsonResponse.response(_request, _estado, _mensaje));
        }

        [Authorize]
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete([FromQuery] Elecciones _request)
        {
            String _mensaje = String.Empty;
            int _estado = 0;
            String _CodigoEleccion = String.Empty;
            List<Elecciones> _ListElecciones = new List<Elecciones>();
            try
            {
                int _tipo = 3;
                var cn = _configuration.GetConnectionString("DbConn");
                _ListElecciones = _ElecService.Add(_tipo, _request, cn);

                _CodigoEleccion = _ListElecciones[0].CodigoEleccion;

                _Request _Objrequest = new _Request();
                _Objrequest.CodigoOrigen = _request.CodigoOrigen;
                _Objrequest.CodigoCliente = _request.CodigoCliente;
                _Objrequest.CodigoEleccion = _CodigoEleccion;

                _ListElecciones.Clear();
                _ListElecciones = _ElecService.GetById(_Objrequest, cn);

                _mensaje = "Se Elimino Correctamente";
                _estado = 1;
            }
            catch (Exception ex)
            {
                _mensaje = ex.Message;
                _estado = 0;
            }
            return Ok(JsonResponse.response(_ListElecciones, _estado, _mensaje));
        }


    }
}
