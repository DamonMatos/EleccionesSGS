using System.ComponentModel.DataAnnotations;

namespace WSEleccionesSSMA.Models
{
    public class AuthenticateRequest
    {
        [Required]
        public string? Correo{get;set;}

        [Required]
        public string? Clave{get;set;}
        
    }

    public class Request {
        [Required]
        public string? Tipo { get; set; }

        [Required]
        public string? Input { get; set; }
    }
}
