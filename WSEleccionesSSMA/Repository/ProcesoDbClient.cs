using System.Data.SqlClient;
using WSEleccionesSSMA.Models;
using WSEleccionesSSMA.Translators;
using WSEleccionesSSMA.Utility;

namespace WSEleccionesSSMA.Repository
{
    public class ProcesoDbClient
    {
        public Proceso Add(Proceso _request, String _connString)
        {
            SqlParameter[] param = {
                new SqlParameter("@Tipo",_request.Tipo),
                new SqlParameter("@CodigoOrigen",_request.CodigoOrigen),
                new SqlParameter("@CodigoCliente",_request.CodigoCliente),
                new SqlParameter("@CodigoEleccion",_request.CodigoEleccion),
                new SqlParameter("@CodigoProceso",_request.CodigoProceso),
                new SqlParameter("@Nombre",_request.NombreProceso),
                new SqlParameter("@NumeroCandidatos",_request.NumeroCandidatos),
                new SqlParameter("@VotacionObligatoria",_request.VotacionObligatoria),

            };
            return SqlHelper.ExecuteProcedureReturnData<Proceso>(_connString, "up_Add_Proceso", r => r.TranslateAs_Proceso(), param);
        }

    }
}
