using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using WSEleccionesSSMA.Helper;
using WSEleccionesSSMA.Models;
using WSEleccionesSSMA.Services;

namespace WSEleccionesSSMA.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class DashBoardController : Controller
    {
        private readonly IConfiguration _configuration;
        private IDashBoardService _DashBoardService;
        private readonly ExcelReportGenerator _generator;

        public DashBoardController(IConfiguration configuration, IDashBoardService dashBoardService)
        {
            _configuration = configuration;
            _DashBoardService = dashBoardService;
            _generator = new ExcelReportGenerator();
        }

        //[Authorize]
        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] JsonRequest _Parameters)
        {
            List<Difusion> _ListDifusion = new List<Difusion>();
            var cn = _configuration.GetConnectionString("DbConn");
            _ListDifusion = _DashBoardService.Get(_Parameters, cn);
            using (MemoryStream reportStream = _generator.GenerarReporteSimple(_ListDifusion, " Reporte Diario"))
            {
                var content = reportStream.ToArray();
                var fileName = "Reporte_Colaboradores.xlsx";
                var contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

                return File(content, contentType, fileName);
            }
        }


   
     
    }                       
}
