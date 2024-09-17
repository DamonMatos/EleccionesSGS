using WSEleccionesSSMA.Models;
using WSEleccionesSSMA.Repository;
using WSEleccionesSSMA.Utility;

namespace WSEleccionesSSMA.Services
{
    public interface IEleccionesService
    {
        List<Elecciones> Add(int _tipo,Elecciones _request, String connexion);
        List<Elecciones> Get(Params _Parameters,String CodigoOrigen, String connexion);
        List<Elecciones> GetById(_Request _request, String connexion);
    }

    public class EleccionesService: IEleccionesService
    {
        public List<Elecciones> Add(int _tipo, Elecciones _request, String connexion)
        {
            List<Models.Elecciones> _ListElecciones = new List<Models.Elecciones>();
            _ListElecciones = DbClientFactory<EleccionesDbClient>.Instance.Add(_tipo,_request, connexion);

            return _ListElecciones;
        }

        public List<Elecciones> Get(Params _Parameters,String CodigoOrigen, String connexion)
        {
            List<Models.Elecciones> _ListElecciones = new List<Models.Elecciones>();
            _ListElecciones = DbClientFactory<EleccionesDbClient>.Instance.Get(CodigoOrigen, connexion);
            _ListElecciones  = _ListElecciones.OrderBy(on => on.RazonSocial).Skip((_Parameters.PageNumber - 1) * _Parameters.PageSize).Take(_Parameters.PageSize).ToList();
            
            return _ListElecciones;
        }

        public List<Elecciones> GetById(_Request _request, String connexion)
        {
            List<Models.Elecciones> _ListElecciones = new List<Models.Elecciones>();
            _ListElecciones = DbClientFactory<EleccionesDbClient>.Instance.GetById(_request, connexion);

            return _ListElecciones;
        }


    }
}
