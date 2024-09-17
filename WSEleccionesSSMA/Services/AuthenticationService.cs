using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;
using WSEleccionesSSMA.Models;
using System.IdentityModel.Tokens.Jwt;
using System;
using WSEleccionesSSMA.Helper;
using Microsoft.Extensions.Options;
using WSEleccionesSSMA.Utility;
using WSEleccionesSSMA.Repository;
using System.Threading.Tasks;
using System.IO;
using System.Net.Mail;

namespace WSEleccionesSSMA.Services
{
    public interface IAuthenticationService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model,string connexion);
    }


    public class AuthenticationService : IAuthenticationService
    {
        private readonly IConfiguration _configuration;
        public AuthenticationService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest _request, string connexion)
        {
            AuthenticateResponse authenticateResponse = new AuthenticateResponse();
            authenticateResponse = DbClientFactory<UserDbClient>.Instance.Authenticate(_request, connexion);
            var _Token = GenerateJwtToken(authenticateResponse);
            authenticateResponse.Token = _Token;
            return authenticateResponse;
        }
        
        private string GenerateJwtToken(AuthenticateResponse authenticateResponse)
        {
            var _key    = _configuration.GetValue<string>("AppSettings:Key");
            var _Issuer = _configuration.GetValue<string>("AppSettings:Issuer");

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[] {
                new Claim("idUsuario", authenticateResponse.IdUsuario.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, "atul"),
                new Claim(JwtRegisteredClaimNames.Email, ""),
                new Claim("Role", authenticateResponse.Perfil.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var _Token = new JwtSecurityToken(_Issuer, _Issuer,claims,expires: DateTime.Now.AddMinutes(20),signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }
        
    }
}
