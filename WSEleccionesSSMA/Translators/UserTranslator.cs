
using WSEleccionesSSMA.Utility;
using System.Data.SqlClient;
using System.Collections.Generic;
using WSEleccionesSSMA.Models;
using WSEleccionesSSMA.Services;

namespace WSEleccionesSSMA.Translators
{
    public static class UserTranslator
    {
        public static List<Usuario> TranslateAsUsersList(this SqlDataReader reader)
        {
            var list = new List<Usuario>();
            while (reader.Read())
            {
                list.Add(TranslateAsUser(reader, true));
            }
            return list;
        }

        public static AuthenticateResponse TranslateAsUser(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                reader.Read();
            }

            var item = new AuthenticateResponse();
            if (reader.IsColumnExists("IdUsuario")) item.IdUsuario = SqlHelper.GetNullableInt32(reader, "IdUsuario");
            item.IdPersonal  = SqlHelper.GetNullableInt32(reader, "IdPersonal");
            item.ApePatPer   = SqlHelper.GetNullableString(reader, "ApePatPer");
            item.ApeMatPer   = SqlHelper.GetNullableString(reader, "ApeMatPer");
            item.NomPer      = SqlHelper.GetNullableString(reader, "NomPer");
            item.NumDocPer   = SqlHelper.GettableString(reader, "NumDocPer");
            item.FotPer      = SqlHelper.GettableString(reader, "FotPer");
            item.IdPerfil    = SqlHelper.GetNullableInt32(reader, "IdPerfil");
            item.Perfil      = SqlHelper.GettableString(reader, "Perfil");
            item.Correo      = SqlHelper.GetNullableString(reader, "Correo");
            item.Estado      = SqlHelper.GetNullableInt32(reader, "Estado");
            item.Token       = SqlHelper.GettableString(reader, "Token");

            reader.NextResult();
            item.ListMenu    = new GenericInstance<Menu>().readDataReaderList(reader);

            reader.NextResult();
            item.ListSubMenu = new GenericInstance<SubMenu>().readDataReaderList(reader);
            return item;
        }


        public static Usuario TranslateUser(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                reader.Read();
            }

            var item = new Usuario();
            item.IdUsuario = SqlHelper.GetNullableInt32(reader, "IdUsuario");
            item.IdPerfil  = SqlHelper.GetNullableInt32(reader, "IdPerfil");
            item.Perfil    = SqlHelper.GettableString(reader, "Perfil");
            item.Correo    = SqlHelper.GetNullableString(reader, "Correo");
            item.Estado    = SqlHelper.GetNullableInt32(reader, "Estado");
            return item;
        }
    }
}
