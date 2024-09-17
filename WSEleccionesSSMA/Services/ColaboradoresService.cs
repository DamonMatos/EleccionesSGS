using WSEleccionesSSMA.Models;
using WSEleccionesSSMA.Repository;
using WSEleccionesSSMA.Utility;

namespace WSEleccionesSSMA.Services
{
    public interface IColaboradoresService
    {
        List<Colaboradores> Add(String _request, String connexion);
        //List<Colaboradores> Get(Params _Parameters, String CodigoOrigen, String connexion);

    }

    public class ColaboradoresService : IColaboradoresService
    {
        public List<Colaboradores> Add(String _request, String connexion)
        {
            List<Colaboradores> _ListColaboradores = new List<Colaboradores>();
            _ListColaboradores = DbClientFactory<ColaboradoresDbClient>.Instance.Add(_request, connexion);

            return _ListColaboradores;

        }

    }
}
