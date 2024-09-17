using WSEleccionesSSMA.Models;
using WSEleccionesSSMA.Repository;
using WSEleccionesSSMA.Utility;

namespace WSEleccionesSSMA.Services
{

    public interface IDashBoardService
    {
        List<Difusion> Get(JsonRequest request, String connexion);
    }
    public class DashBoardService: IDashBoardService
    {
        public List<Difusion> Get(JsonRequest request, String connexion)
        {
            List<Difusion> _List = new List<Difusion>();
            _List = DbClientFactory<DashBoardDbClient>.Instance.Get(request, connexion);
            return _List;
        }
    }
}
