using System.Text.Json.Serialization;

namespace WSEleccionesSSMA.Models
{
    public class Elecciones
    {
        public String CodigoOrigen { get; set; }
        public String CodigoCliente { get; set; }
        public String CodigoEleccion { get; set; }
        public String Nombre { get; set; }
        public String RazonSocial { get; set; }
        public String Ruc { get; set; }
        public String ColorBase { get; set; }
        public String UrlLogo { get; set; }
        public String FechaDifusion { get; set; }
        public String FechaInicio { get; set; }
        public String FechaFin { get; set; }
        public String FechaRegistro { get; set; }
        public Boolean PlanillaConfirmada { get; set; }
        public Boolean DifusionEnviada { get; set; }

        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<Proceso> List_proceso { get; set; }

    }

    public class _Request{
        public String CodigoOrigen { get; set; }
        public String CodigoCliente { get; set; }
        public String CodigoEleccion { get; set; }
}
}
