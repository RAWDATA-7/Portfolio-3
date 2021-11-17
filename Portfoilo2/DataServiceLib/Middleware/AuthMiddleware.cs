using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Builder;

namespace DataServiceLib.Middleware
{
    public static class AuthMiddlewareExtension
    {
        public static IApplicationBuilder UseJwtAuth(this IApplicationBuilder builder)
        {
            Console.WriteLine("test fra middlewareEX...");
            return builder.UseMiddleware<AuthMiddleware>();
        }
    }
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IDataService _dataService;
        private readonly IConfiguration _configuration;

        public AuthMiddleware(RequestDelegate next, IDataService dataService, IConfiguration configuration)
        {
            _next = next;
            _dataService = dataService;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            try
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
                var key = Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value);
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(
                    token,
                    new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ClockSkew = TimeSpan.Zero
                    },
                    out var validatedToken);

                var jwtToken = validatedToken as JwtSecurityToken;

                var claim = jwtToken.Claims.FirstOrDefault(x => x.Type == "id");
                Console.WriteLine("har vi et claim?");
                if (claim != null)
                {
                    Console.WriteLine("test er her et ID?");
                    int.TryParse(claim.Value.ToString(), out var id);
                    context.Items["User"] = _dataService.GetUserFromId(id);
                }
            }
            catch
            {
            
            }
            Console.WriteLine("test pre await");
            await _next(context);
        }
    }
}
