using WSEleccionesSSMA.Models;
using WSEleccionesSSMA.Repository;
using WSEleccionesSSMA.Utility;

namespace WSEleccionesSSMA.Services
{

    public interface ICandidatosService
    {
        List<Candidatos> Add(Candidatos _request, String connexion);
        List<Candidatos> Get(Candidatos _request, String connexion);

    }

    public class CandidatosService: ICandidatosService
    {
        public List<Candidatos> Add(Candidatos _request, String connexion)
        {
            List<Candidatos> _ListCandidatos = new List<Candidatos>();
            _ListCandidatos = DbClientFactory<CandidatosDbClient>.Instance.Add(_request, connexion);

            return _ListCandidatos;
        }

        public List<Candidatos> Get(Candidatos candidatos, String connexion)
        {
            List<Candidatos> _ListCandidatos = new List<Candidatos>();
            _ListCandidatos = DbClientFactory<CandidatosDbClient>.Instance.Get(candidatos, connexion);
            return _ListCandidatos;
        }

    }
}
