using System.Data.SqlClient;
using WSEleccionesSSMA.Models;
using WSEleccionesSSMA.Utility;

namespace WSEleccionesSSMA.Translators
{
    public static class JsonResponseTranslator
    {
        public static List<Response> TranslateAsJsonResponseList(this SqlDataReader reader)
        {
            var list = new List<Response>();
            while (reader.Read())
            {
                list.Add(TranslateAsJsonResponse(reader, true));
            }
            return list;
        }
        public static Response TranslateAsJsonResponse(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                if (!reader.HasRows)
                    return null;
                reader.Read();
            }

            var item = new Response();
            if (reader.IsColumnExists("IdEmpresa"))
                item.Id = SqlHelper.GetNullableInt32(reader, "IdEmpresa");

            return item;
        }
    }
}
