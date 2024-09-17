using System.Data.SqlClient;
using WSEleccionesSSMA.Models;
using WSEleccionesSSMA.Utility;

namespace WSEleccionesSSMA.Translators
{
    public static class EleccionesTranslator
    {

        public static List<Elecciones> TranslateAsEleccionesList(this SqlDataReader reader)
        {
            var list = new List<Elecciones>();
            while (reader.Read())
            {
                list.Add(TranslateAsElecciones(reader, true));
            }
            return list;
        }

        public static Elecciones TranslateAsElecciones(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                reader.Read();
            }

            var item = new Elecciones();
            item.CodigoOrigen       = SqlHelper.GettableString(reader, "CodigoOrigen");
            item.CodigoCliente      = SqlHelper.GettableString(reader, "CodigoCliente");
            item.CodigoEleccion     = SqlHelper.GettableString(reader, "CodigoEleccion");
            item.Nombre             = SqlHelper.GettableString(reader, "Nombre");
            item.RazonSocial        = SqlHelper.GettableString(reader, "RazonSocial");
            item.Ruc                = SqlHelper.GettableString(reader, "Ruc");
            item.ColorBase          = SqlHelper.GettableString(reader, "ColorBase");
            item.UrlLogo            = SqlHelper.GettableString(reader, "UrlLogo");
            item.FechaDifusion      = SqlHelper.GettableString(reader, "FechaDifusion");
            item.FechaInicio        = SqlHelper.GettableString(reader, "FechaInicio");
            item.FechaFin           = SqlHelper.GettableString(reader, "FechaFin");
            item.FechaRegistro      = SqlHelper.GettableString(reader, "FechaRegistro");
            item.PlanillaConfirmada = SqlHelper.GetBoolean (reader, "PlanillaConfirmada");
            item.DifusionEnviada    = SqlHelper.GetBoolean(reader, "DifusionEnviada");

            return item;
        }



        public static List<Elecciones> TranslateAs_Elecciones_Proceso_List(this SqlDataReader reader)
        {
            var list = new List<Elecciones>();
            while (reader.Read())
            {
                list.Add(TranslateAs_Elecciones_Proceso(reader, true));
            }
            return list;
        }

        public static Elecciones TranslateAs_Elecciones_Proceso(this SqlDataReader reader, bool isList = false)
        {
            if (!isList)
            {
                reader.Read();
            }

            var item = new Elecciones();
            item.CodigoOrigen       = SqlHelper.GettableString(reader, "CodigoOrigen");
            item.CodigoCliente      = SqlHelper.GettableString(reader, "CodigoCliente");
            item.CodigoEleccion     = SqlHelper.GettableString(reader, "CodigoEleccion");
            item.Nombre             = SqlHelper.GettableString(reader, "Nombre");
            item.RazonSocial        = SqlHelper.GettableString(reader, "RazonSocial");
            item.Ruc                = SqlHelper.GettableString(reader, "Ruc");
            item.ColorBase          = SqlHelper.GettableString(reader, "ColorBase");
            item.UrlLogo            = SqlHelper.GettableString(reader, "UrlLogo");
            item.FechaDifusion      = SqlHelper.GettableString(reader, "FechaDifusion");
            item.FechaInicio        = SqlHelper.GettableString(reader, "FechaInicio");
            item.FechaFin           = SqlHelper.GettableString(reader, "FechaFin");
            item.FechaRegistro      = SqlHelper.GettableString(reader, "FechaRegistro");
            item.PlanillaConfirmada = SqlHelper.GetBoolean(reader, "PlanillaConfirmada");
            item.DifusionEnviada    = SqlHelper.GetBoolean(reader, "DifusionEnviada");
            
            reader.NextResult();
            item.List_proceso = new GenericInstance<Proceso>().readDataReaderList(reader);
            
            return item;
        }



    }
}
