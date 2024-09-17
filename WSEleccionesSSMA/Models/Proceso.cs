namespace WSEleccionesSSMA.Models
{
    public class Proceso
    {
        public int Tipo { get; set; }
        public String CodigoOrigen { get; set; }
        public String CodigoCliente { get; set; }
        public String CodigoEleccion { get; set; }
        public String CodigoProceso { get; set; }  
        public String NombreProceso { get; set; }
        public int NumeroCandidatos { get; set; }
        public Boolean VotacionObligatoria { get; set; }
        
    }

}
