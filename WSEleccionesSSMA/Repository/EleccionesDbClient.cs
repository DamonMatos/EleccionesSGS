using System.Data.SqlClient;
using WSEleccionesSSMA.Models;
using WSEleccionesSSMA.Translators;
using WSEleccionesSSMA.Utility;

namespace WSEleccionesSSMA.Repository
{
    public class EleccionesDbClient
    {
        public List<Models.Elecciones> Add(int _tipo,Elecciones _request, String _connString)
        {
            SqlParameter[] param = {
                new SqlParameter("@Tipo",_tipo),
                new SqlParameter("@CodigoOrigen",_request.CodigoOrigen),
                new SqlParameter("@CodigoCliente",_request.CodigoCliente),
                new SqlParameter("@CodigoEleccion",_request.CodigoEleccion),
                new SqlParameter("@Nombre",_request.Nombre),
                new SqlParameter("@RazonSocial",_request.RazonSocial),
                new SqlParameter("@Ruc",_request.Ruc),
                new SqlParameter("@ColorBase",_request.ColorBase),
                new SqlParameter("@UrlLogo",_request.UrlLogo),
                new SqlParameter("@FechaDifusion",DateTime.Parse(_request.FechaDifusion)),
                new SqlParameter("@FechaInicio",DateTime.Parse(_request.FechaInicio)),
                new SqlParameter("@FechaFin",DateTime.Parse(_request.FechaFin)),
                new SqlParameter("@PlanillaConfirmada",_request.PlanillaConfirmada),
                new SqlParameter("@DifusionEnviada",_request.DifusionEnviada)

            };
            return SqlHelper.ExecuteProcedureReturnData<List<Models.Elecciones>>(_connString, "up_Add_Elecciones", r => r.TranslateAsEleccionesList(), param);
        }

        public List<Models.Elecciones> Get(String _CodigoOrigen, String _connString)
        {
            SqlParameter[] param = {
                new SqlParameter("@CodigoOrigen",_CodigoOrigen)
            };
            return SqlHelper.ExecuteProcedureReturnData<List<Models.Elecciones>>(_connString, "up_Get_Elecciones", r => r.TranslateAsEleccionesList(), param);
        }


        public List<Elecciones> GetById(_Request _request, String _connString)
        {
            SqlParameter[] param = {
                new SqlParameter("@CodigoOrigen",_request.CodigoOrigen),
                new SqlParameter("@CodigoCliente",_request.CodigoCliente),
                new SqlParameter("@CodigoEleccion",_request.CodigoEleccion)
            };
            return SqlHelper.ExecuteProcedureReturnData<List<Elecciones>>(_connString, "up_GetById_Elecciones_Proceso", r => r.TranslateAs_Elecciones_Proceso_List(), param);
        }


    }
}
