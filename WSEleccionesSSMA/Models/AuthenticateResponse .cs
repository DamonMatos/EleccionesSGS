using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace WSEleccionesSSMA.Models
{
    public class AuthenticateResponse: Personal
    {
        public string Token { get; set; }

        public AuthenticateResponse()
        {

        }

    }

}
