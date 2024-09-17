using System.Data.SqlClient;
using WSEleccionesSSMA.Models;
using WSEleccionesSSMA.Utility;

namespace WSEleccionesSSMA.Translators
{
    public static class ColaboradoresTranslator
    {

        public static List<Colaboradores> TranslateAsColaboradoresList(this SqlDataReader reader)
        {
            var list = new List<Colaboradores>();
            while (reader.Read())
            {
                 list.Add(TranslateAsColaboradores(reader, true));
            }
            return list;
        }

        public static Colaboradores TranslateAsColaboradores(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                reader.Read();
            }

            var item = new Colaboradores();
            item.CodigoOrigen = SqlHelper.GettableString(reader, "CodigoOrigen");
            item.CodigoCliente = SqlHelper.GettableString(reader, "CodigoCliente");
            item.CodigoEleccion = SqlHelper.GettableString(reader, "CodigoEleccion");
            item.CodigoProceso = SqlHelper.GettableString(reader, "CodigoProceso");
            item.TipoDocumento = SqlHelper.GettableString(reader, "Tipodocumneto");
            item.NumeroDocumento = SqlHelper.GettableString(reader, "NumeroDocumento");
            item.Localidad = SqlHelper.GettableString(reader, "Localidad");
            item.Gerencia = SqlHelper.GettableString(reader, "Gerencia");
            item.Zona = SqlHelper.GettableString(reader, "Zona");
            item.Sucursal = SqlHelper.GettableString(reader, "Sucursal");
            item.Codigo = SqlHelper.GettableString(reader, "Codigo");
            item.Nombre = SqlHelper.GettableString(reader, "Nombre");
            item.ApellidoPaterno = SqlHelper.GettableString(reader, "Apellidopaterno");
            item.ApellidoMaterno = SqlHelper.GettableString(reader, "Apellidomaterno");
            item.EmailDifusion = SqlHelper.GettableString(reader, "Emaildifusion");
            item.CodigoOrigen = SqlHelper.GettableString(reader, "Orden");

            return item;
        }
    }
}
