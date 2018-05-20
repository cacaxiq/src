using Base.Application.Interfaces;
using Base.Application.ViewModels;
using Base.WebApi.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace Base.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        [AllowAnonymous]
        [HttpPost]
        public object Post(
            [FromBody]UserViewModel user,
            [FromServices]IUserAppService userAppService,
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfigurations tokenConfigurations)
        {
            bool credenciaisValidas = false;
            var usuarioBase =new UserViewModel();
            if (user != null && !String.IsNullOrWhiteSpace(user.UserID))
            {
                usuarioBase = userAppService.GetByUserID(user.UserID);
                credenciaisValidas = (usuarioBase != null &&
                    user.UserID == usuarioBase.UserID &&
                    user.AccessKey == usuarioBase.AccessKey);
            }

            if (credenciaisValidas)
            {
                return GenerateToken(usuarioBase, signingConfigurations, tokenConfigurations);
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }

        private object GenerateToken(
            UserViewModel user,
            SigningConfigurations signingConfigurations,
            TokenConfigurations tokenConfigurations)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.UserID, "Login"),
                new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserID)
                }
            );

            DateTime dataCriacao = DateTime.Now;

            var timeForToken = new TimeSpan();

            switch (tokenConfigurations.Type)
            {
                case "Days":
                    timeForToken = TimeSpan.FromDays(tokenConfigurations.Time);
                    break;
                case "Minutes":
                    timeForToken = TimeSpan.FromMinutes(tokenConfigurations.Time);
                    break;
                case "Seconds":
                    timeForToken = TimeSpan.FromSeconds(tokenConfigurations.Time);
                    break;
                default:
                    break;
            }

            DateTime dataExpiracao = dataCriacao + timeForToken;

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });
            var token = handler.WriteToken(securityToken);

            return new
            {
                authenticated = true,
                created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                User = user
            };
        }

        private object GenerateTokenRefresh(
            string userID,
            SigningConfigurations signingConfigurations,
            TokenConfigurations tokenConfigurations,
            IDistributedCache cache)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(userID, "Login"),
                new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, userID)
                }
            );

            DateTime dataCriacao = DateTime.Now;

            var timeForToken = new TimeSpan();

            switch (tokenConfigurations.Type)
            {
                case "Days":
                    timeForToken = TimeSpan.FromDays(tokenConfigurations.Time);
                    break;
                case "Minutes":
                    timeForToken = TimeSpan.FromMinutes(tokenConfigurations.Time);
                    break;
                case "Seconds":
                    timeForToken = TimeSpan.FromSeconds(tokenConfigurations.Time);
                    break;
                default:
                    break;
            }

            DateTime dataExpiracao = dataCriacao + timeForToken;

            // Calcula o tempo máximo de validade do refresh token
            // (o mesmo será invalidado automaticamente pelo Redis)
            TimeSpan finalExpiration = TimeSpan.FromSeconds(tokenConfigurations.FinalExpiration);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });
            var token = handler.WriteToken(securityToken);

            var resultado = new
            {
                authenticated = true,
                created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                refreshToken = Guid.NewGuid().ToString().Replace("-", String.Empty),
                message = "OK"
            };

            // Armazena o refresh token em cache através do Redis 
            var refreshTokenData = new RefreshTokenData
            {
                RefreshToken = resultado.refreshToken,
                UserID = userID
            };

            DistributedCacheEntryOptions opcoesCache = new DistributedCacheEntryOptions();
            opcoesCache.SetAbsoluteExpiration(finalExpiration);
            cache.SetString(resultado.refreshToken, JsonConvert.SerializeObject(refreshTokenData), opcoesCache);

            return resultado;
        }

        //[AllowAnonymous]
        //[HttpPost]
        //public object Refresh(
        //    [FromBody]AccessCredentials credenciais,
        //    [FromServices]IUserAppService userAppService,
        //    [FromServices]SigningConfigurations signingConfigurations,
        //    [FromServices]TokenConfigurations tokenConfigurations,
        //    [FromServices]IDistributedCache cache)
        //{
        //    bool credenciaisValidas = false;
        //    if (credenciais != null && !String.IsNullOrWhiteSpace(credenciais.UserID))
        //    {
        //        var usuarioBase = userAppService.GetByUserID(credenciais.UserID);
        //        credenciaisValidas = (usuarioBase != null &&
        //            credenciais.UserID == usuarioBase.UserID &&
        //            credenciais.AccessKey == usuarioBase.AccessKey);
        //    }
        //    else if (credenciais.GrantType == "refresh_token")
        //    {
        //        if (!String.IsNullOrWhiteSpace(credenciais.RefreshToken))
        //        {
        //            RefreshTokenData refreshTokenBase = null;

        //            string strTokenArmazenado =
        //                cache.GetString(credenciais.RefreshToken);
        //            if (!String.IsNullOrWhiteSpace(strTokenArmazenado))
        //            {
        //                refreshTokenBase = JsonConvert
        //                    .DeserializeObject<RefreshTokenData>(strTokenArmazenado);
        //            }

        //            credenciaisValidas = (refreshTokenBase != null &&
        //                credenciais.UserID == refreshTokenBase.UserID &&
        //                credenciais.RefreshToken == refreshTokenBase.RefreshToken);

        //            // Elimina o token de refresh já que um novo será gerado
        //            if (credenciaisValidas)
        //                cache.Remove(credenciais.RefreshToken);
        //        }

        //    }

        //    if (credenciaisValidas)
        //    {
        //        return GenerateTokenRefresh(
        //            credenciais.UserID, 
        //            signingConfigurations, 
        //            tokenConfigurations, 
        //            cache);
        //    }
        //    else
        //    {
        //        return new
        //        {
        //            authenticated = false,
        //            message = "Falha ao autenticar"
        //        };
        //    }
        //}
    }
}