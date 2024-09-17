using System.Collections.Generic;
using WSEleccionesSSMA.Models;
using WSEleccionesSSMA.Repository;
using WSEleccionesSSMA.Utility;
using Microsoft.Extensions.Options;

namespace WSEleccionesSSMA.Services
{
    public interface IUserService
    {
        Usuario GetById(string cn,int id);
    }

    public class UsuarioService : IUserService
    {
        List<Usuario> _ListUsers = new List<Usuario>();
        private readonly IConfiguration Configuration;

        public UsuarioService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Usuario GetById(string cn, int id)
        {
            Usuario _usuario = new Usuario();
            return _usuario = DbClientFactory<UserDbClient>.Instance.GetById(id, cn);
        }

      
    };
             
}
