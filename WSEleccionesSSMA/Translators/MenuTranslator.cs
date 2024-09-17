
using System.Collections.Generic;
using System.Data.SqlClient;
using WSEleccionesSSMA.Models;
using WSEleccionesSSMA.Utility;

namespace WSEleccionesSSMA.Translators
{
    public static class MenuTranslator
    {
        public static List<Menu> TranslateAsMenuList(this SqlDataReader reader)
        {
            var list = new List<Menu>();
            while (reader.Read())
            {
                list.Add(TranslateAsMenu(reader, true));
            }
            return list;
        }
        public static Menu TranslateAsMenu(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new Menu();
            item.IdMenu   = SqlHelper.GetNullableInt32(reader, "IdMenu");
            item.NomVista = SqlHelper.GetNullableString(reader, "NomVista");
            item.NomUrl   = SqlHelper.GetNullableString(reader, "NomUrl");
            item.Icono    = SqlHelper.GetNullableString(reader, "Icono");
            item.Tipo     = SqlHelper.GetNullableString(reader, "Tipo");
            return item;
        }
        public static List<SubMenu> TranslateAsSubMenuList(this SqlDataReader reader)
        {
            var list = new List<SubMenu>();
            while (reader.Read())
            {
                list.Add(TranslateAsSubMenu(reader, true));
            }
            return list;
        }
        private static SubMenu TranslateAsSubMenu(SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }
            var item = new SubMenu();
            item.IdPerfil      = SqlHelper.GetNullableInt32(reader, "IdPerfil");
            item.Perfil        = SqlHelper.GetNullableString(reader, "Perfil");
            item.CodigoMenu    = SqlHelper.GetNullableInt32(reader, "CodigoMenu");
            item.Menu          = SqlHelper.GetNullableString(reader, "Menu");
            item.CodigoSubMenu = SqlHelper.GetNullableInt32(reader, "CodigoSubMenu");
            item.NomVista      = SqlHelper.GetNullableString(reader, "NomVista");
            item.NomUrl        = SqlHelper.GetNullableString(reader, "NomUrl");
            item.Icono         = SqlHelper.GetNullableString(reader, "Icono");
            return item;
        }
    }
}
