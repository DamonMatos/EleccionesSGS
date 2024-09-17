using System.Data.SqlClient;
using WSEleccionesSSMA.Models;
using WSEleccionesSSMA.Utility;

namespace WSEleccionesSSMA.Translators
{
    public static class ProcesoTranslator
    {
        //public static List<Proceso> TranslateAs_Proceso_List(this SqlDataReader reader)
        //{
        //    var list = new List<Proceso>();
        //    while (reader.Read())
        //    {
        //        list.Add(TranslateAs_Proceso(reader, true));
        //    }
        //    return list;
        //}

        public static Proceso TranslateAs_Proceso(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                reader.Read();
            }

            var item = new Proceso();
            item.CodigoOrigen = SqlHelper.GettableString(reader, "CodigoOrigen");
            item.CodigoCliente = SqlHelper.GettableString(reader, "CodigoCliente");
            item.CodigoEleccion = SqlHelper.GettableString(reader, "CodigoEleccion");
            item.CodigoProceso = SqlHelper.GettableString(reader, "CodigoProceso");          
            item.NombreProceso = SqlHelper.GettableString(reader, "Nombre");
            item.NumeroCandidatos = SqlHelper.GetNullableInt32(reader, "NumeroCandidatos");
            item.VotacionObligatoria = SqlHelper.GetBoolean(reader, "VotacionObligatoria");
            return item;
        }

    }
}
