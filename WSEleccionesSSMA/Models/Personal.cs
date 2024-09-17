namespace WSEleccionesSSMA.Models
{
    public class Personal: Usuario
    {
        public int IdPersonal { get; set; } 
        public String? ApePatPer { get; set; }  
        public String? ApeMatPer { get; set; }
        public String? NomPer { get; set; }
        public String NumDocPer { get; set; }
        public String FotPer { get; set; }

    }
}
