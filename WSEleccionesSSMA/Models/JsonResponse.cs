using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace WSEleccionesSSMA.Models
{
    public class JsonResponse
    {
        public object? data { get; set; }
        public int status  { get; set; }
        public string? msg  { get; set; }

        public static JsonResponse response(object D, int status = 0, string msg = "")
        {
            return new JsonResponse() { status = status, msg = msg, data = D };
        }
    }

    public class Response
    {
        public int Tipo { get; set; }
        public int Id { get; set; }
        public string? Mensaje { get; set; }
    }


}
