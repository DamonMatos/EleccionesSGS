using System.Data.SqlClient;
using WSEleccionesSSMA.Models;
using WSEleccionesSSMA.Translators;
using WSEleccionesSSMA.Utility;

namespace WSEleccionesSSMA.Repository
{
    public class DashBoardDbClient
    {

        public List<Difusion> Get(JsonRequest request, String _connString)
        {
            SqlParameter[] param = {
                new SqlParameter("@codigoOrigen",request.CodigoOrigen),
                new SqlParameter("@codigoCliente",request.CodigoCliente),
                new SqlParameter("@codigoEleccion",request.CodigoEleccion),
                new SqlParameter("@codigoProceso",request.CodigoProceso),
            };
            return SqlHelper.ExecuteProcedureReturnData<List<Difusion>>(_connString, "up_Get_DifusionSSMA", r => r.TranslateAsDifusionList(), param);
        }

    }
}
