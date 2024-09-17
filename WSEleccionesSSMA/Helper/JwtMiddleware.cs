using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WSEleccionesSSMA.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace WSEleccionesSSMA.Helper
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configuration;
        public JwtMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            _next = next;
            _configuration = configuration;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
                attachUserToContext(context, userService, token);
            await _next(context);
        }

        private void attachUserToContext(HttpContext context, IUserService userService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var _key   = _configuration.GetValue<string>("AppSettings:Key");
                var Issuer = _configuration.GetValue<string>("AppSettings:Issuer");
                var cn     = _configuration.GetValue<string>("ConnectionStrings:DbConn");

                var key    = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = key,
                    ValidIssuer = Issuer,
                    ValidAudience = Issuer,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "idUsuario").Value);
                context.Items["Usuario"] = userService.GetById(cn,userId);
            }
            catch (Exception)
            {

            }
        }
    }
}
