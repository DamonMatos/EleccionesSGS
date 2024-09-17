using System.Data.SqlClient;
using WSEleccionesSSMA.Models;
using WSEleccionesSSMA.Utility;

namespace WSEleccionesSSMA.Translators
{
    public static class CandidatosTranslator
    {
        public static List<Candidatos> TranslateAsCandidatosList(this SqlDataReader reader)
        {
            var list = new List<Candidatos>();
            while (reader.Read())
            {
                list.Add(TranslateAsCandidatos(reader, true));
            }
            return list;
        }

        public static Candidatos TranslateAsCandidatos(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                reader.Read();
            }

            var item = new Candidatos();
            item.Tipo = SqlHelper.GetNullableInt32(reader, "@Tipo");
            item.CodigoOrigen = SqlHelper.GettableString(reader, "CodigoOrigen");
            item.CodigoCliente = SqlHelper.GettableString(reader, "CodigoCliente");
            item.CodigoEleccion = SqlHelper.GettableString(reader, "CodigoEleccion");
            item.CodigoProceso = SqlHelper.GettableString(reader, "@codigoProceso");
            item.CodigoCandidato = SqlHelper.GettableString(reader, "@codigoCandidato");
            item.TipoDocumento = SqlHelper.GettableString(reader, "@TipoDocumento");
            item.NumeroDocumento = SqlHelper.GettableString(reader, "@NumeroDocumento");
            item.NombreCompleto = SqlHelper.GettableString(reader, "@NombreCompleto");
            item.Area = SqlHelper.GettableString(reader, "@Area");
            item.Localidad = SqlHelper.GettableString(reader, "@Localidad");
            item.UrlFile = SqlHelper.GettableString(reader, "@UrlFile");
            return item;
        }
    }
}
