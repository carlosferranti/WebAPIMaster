using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPIMaster.Models;

namespace WebAPIMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaController : ControllerBase
    {
        [HttpPost]

        public IActionResult Login([FromBody] LoginModel login)
        {
            if (login.Login == "admin" && login.Senha == "admin")
            {
                var token  = GerarTokenJWT();
                return Ok(new { token });
            }

            return BadRequest(new { mensagem = "Credencial inválida. Verifique nome e senha." });
        }

        private string GerarTokenJWT()
        {
            string keySecret = "b90d6201-2710-4741-bdd5-afabf3b91003";

            var chave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keySecret));
            var credencial = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim ("login", "admin"),
                new Claim ("nome", "Administrador do Sistema")
            };

            var token = new JwtSecurityToken
            (
                issuer: "bussiness",
                audience: "application",
                claims: null,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credencial

            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
