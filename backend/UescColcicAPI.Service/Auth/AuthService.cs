using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using UescColcicAPI.Services.BD.Interfaces;
using UescColcicAPI.Core; // Para o modelo User

namespace UescColcicAPI.Services.Auth
{
    public class AuthService
    {
        private readonly IUserCRUD _userCRUD;

        public AuthService(IUserCRUD userCRUD)
        {
            _userCRUD = userCRUD;
        }

        public string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ChaveSecretaColcicComMaisDe16Caracteres"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "colcic.uesc.br",
                audience: "colcic.uesc.br",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public object GenerateJwtToken()
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, "admin"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ChaveSecretaColcicComMaisDe16Caracteres"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "colcic.uesc.br",
                audience: "colcic.uesc.br",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public bool ValidateUserCredentials(string username, string password, out User user)
        {
            user = _userCRUD.ReadByUsername(username);

            // Verifique se o usuário existe e se a senha está correta
            if (user != null && user.Password == password)
            {
                return true;
            }

            return false;
        }
    }
}