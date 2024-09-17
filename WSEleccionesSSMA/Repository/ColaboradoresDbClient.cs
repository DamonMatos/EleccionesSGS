
using System.Data.SqlClient;
using WSEleccionesSSMA.Models;
using WSEleccionesSSMA.Translators;
using WSEleccionesSSMA.Utility;

namespace WSEleccionesSSMA.Repository
{
    public class ColaboradoresDbClient
    {
        public List<Colaboradores> Add(String _request, String _connString)
        {
            SqlParameter[] param = {
                new SqlParameter("@Data",_request)

            };
            return SqlHelper.ExecuteProcedureReturnData<List<Models.Colaboradores>>(_connString, "up_Add_ColaboradoresCsv", r => r.TranslateAsColaboradoresList(), param);
        }

    }
}
