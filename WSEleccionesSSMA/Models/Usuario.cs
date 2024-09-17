using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WSEleccionesSSMA.Models
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public int IdPerfil { get; set; }
        public string Perfil { get; set; }
        public string? Correo { get; set; }
        public int Estado { get; set; }

        [JsonIgnore]
        [DataMember(Name = "Clave")]
        public string? Clave { get; set; }


        public List<Menu>? ListMenu { get; set; }
        public List<SubMenu>? ListSubMenu { get; set; }
    }


   




}
