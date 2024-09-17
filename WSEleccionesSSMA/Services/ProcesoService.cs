using WSEleccionesSSMA.Models;
using WSEleccionesSSMA.Repository;
using WSEleccionesSSMA.Utility;

namespace WSEleccionesSSMA.Services
{

    public interface IProcesoService
    {
       Proceso Add(Proceso _request, String connexion);
    }
    public  class ProcesoService : IProcesoService
    {
        public Proceso Add(Proceso _request, String connexion)
        {
            Proceso _Proceso = new Proceso();
            _Proceso = DbClientFactory<ProcesoDbClient>.Instance.Add(_request, connexion);
            return _Proceso;
        }
    }
}
