using System;
using System.Collections.Generic;
using System.Text;
using Application.Interfaces;
using Application.ViewModels;
using Domain.Models;
using Domain.Interfaces.Command;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class UsuariosService : ApplicationBase,IUsuariosService
    {
        public vmUsuario DoLogin(vmLogin login)
        {
            var rep = GetService<ILoginUser>();

            LoginDomain param = DataHelper.Read<LoginDomain>(login);

            UsuariosDomain loginUser = rep.Execute(param);

            if (loginUser == null)
            {
                return null;
            }

            loginUser.Token = CreateToken(loginUser);

            var result = ConvertToViewModel(loginUser);

            return result;
        }

        private vmUsuario ConvertToViewModel(UsuariosDomain d)
        {
            var item = new vmUsuario
            {
                UsuarioId = d.UsuarioId,
                UsuarioNome = d.UsuarioNome,    
                Email = d.Email,
                Senha = d.Senha,
                token = d.Token,
                

            };
            return item;
        }

        private string CreateToken(UsuariosDomain login)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("E9A975E3-F262-4DB2-8D8E-87DD644615CA"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, login.UsuarioNome),
                    new Claim(ClaimTypes.Email, login.Email)
                };

            var tokenOptions = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return tokenString;
        }

        
    }
}