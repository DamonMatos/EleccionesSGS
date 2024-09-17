using System;
using System.Collections.Generic;

#nullable disable

namespace WSEleccionesSSMA.Models
{
    public partial class Menu
    {
        public int? IdMenu      { get; set; }
        public string NomVista  { get; set; }
        public string NomUrl    { get; set; }
        public string Icono     { get; set; }
        public string Tipo      { get; set; }
    }

    public partial class SubMenu : Menu
    {
        public int? IdPerfil      { get; set; }
        public string Perfil      { get; set; }
        public int? CodigoMenu    { get; set; }
        public string Menu        { get; set; }
        public int? CodigoSubMenu { get; set; }

        //public string NomVista    { get; set; }
        //public string NomUrl      { get; set; }
        //public string Icono       { get; set; }
    }
}
