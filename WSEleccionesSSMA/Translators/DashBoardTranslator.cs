using System.Data.SqlClient;
using WSEleccionesSSMA.Models;
using WSEleccionesSSMA.Utility;

namespace WSEleccionesSSMA.Translators
{
    public static class DashBoardTranslator
    {
        public static List<Difusion> TranslateAsDifusionList(this SqlDataReader reader)
        {
            var list = new List<Difusion>();
            while (reader.Read())
            {
                list.Add(TranslateAsDifusion(reader, true));
            }
            return list;
        }

        public static Difusion TranslateAsDifusion(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                reader.Read();
            }

            var item = new Difusion();
            item.CodigoOrigen = SqlHelper.GettableString(reader, "CodigoOrigen");
            item.CodigoCliente = SqlHelper.GettableString(reader, "CodigoCliente");
            item.NumeroDocumento = SqlHelper.GettableString(reader, "NumeroDocumento");
            item.NombreCompleto = SqlHelper.GettableString(reader, "NombreCompleto");
            item.FechaRegistroPadron = SqlHelper.GettableString(reader, "FechaRegistroPadron");
            return item;
        }

    }
}
