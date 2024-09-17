using WSEleccionesSSMA.Models;
using System.Collections.Generic;
using WSEleccionesSSMA.Utility;
using WSEleccionesSSMA.Translators;
using System.Data.SqlClient;

namespace WSEleccionesSSMA.Repository
{
    public class UserDbClient
    {
        public AuthenticateResponse Authenticate(AuthenticateRequest _request, String _connString)
        {
            SqlParameter[] param = {
                new SqlParameter("@Correo",_request.Correo),
                new SqlParameter("@Clave" ,_request.Clave),
            };
            return SqlHelper.ExecuteProcedureReturnData<AuthenticateResponse>(_connString, "up_Iniciar_Sesion", r => r.TranslateAsUser(), param);
        }

        public Usuario GetById(int _id, string _connString)
        {
            SqlParameter[] param = {
                new SqlParameter("@Id",_id)
            };
            return SqlHelper.ExecuteProcedureReturnData<Usuario>(_connString, "up_GetById_Usuario", r => r.TranslateUser(), param);
        }




    }
}
