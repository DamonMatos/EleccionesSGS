using System.Data.SqlClient;
using WSEleccionesSSMA.Models;
using WSEleccionesSSMA.Translators;
using WSEleccionesSSMA.Utility;

namespace WSEleccionesSSMA.Repository
{
    public class CandidatosDbClient
    {
        public List<Candidatos> Add(Candidatos _request, String _connString)
        {
            SqlParameter[] param = {
                new SqlParameter("@Tipo",_request.Tipo),
                new SqlParameter("@CodigoOrigen",_request.CodigoOrigen),
                new SqlParameter("@CodigoCliente",_request.CodigoCliente),
                new SqlParameter("@CodigoEleccion",_request.CodigoEleccion),
                new SqlParameter("@codigoProceso",_request.CodigoProceso),
                new SqlParameter("@codigoCandidato",_request.CodigoCandidato),
                new SqlParameter("@TipoDocumento",_request.TipoDocumento),
                new SqlParameter("@NumeroDocumento",_request.NumeroDocumento),
                new SqlParameter("@NombreCompleto",_request.NombreCompleto),
                new SqlParameter("@Area",DateTime.Parse(_request.Area)),
                new SqlParameter("@Localidad",DateTime.Parse(_request.Localidad)),
                new SqlParameter("@UrlFile",DateTime.Parse(_request.UrlFile))
            };

            return SqlHelper.ExecuteProcedureReturnData<List<Candidatos>>(_connString, "up_Add_Candidatos", r => r.TranslateAsCandidatosList(), param);

        }

        public List<Candidatos> Get(Candidatos _request, String _connString)
        {
            SqlParameter[] param = {
                new SqlParameter("@Tipo",_request.Tipo),
                new SqlParameter("@CodigoOrigen",_request.CodigoOrigen),
                new SqlParameter("@CodigoCliente",_request.CodigoCliente),
                new SqlParameter("@CodigoEleccion",_request.CodigoEleccion),
                new SqlParameter("@codigoProceso",_request.CodigoProceso)
            };

            return SqlHelper.ExecuteProcedureReturnData<List<Candidatos>>(_connString, "up_Get_Candidatos", r => r.TranslateAsCandidatosList(), param);

        }


    }
}
