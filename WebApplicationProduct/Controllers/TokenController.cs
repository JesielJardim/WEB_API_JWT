using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using WebApplicationProduct.Models;
using WebApplicationProduct.Provider;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplicationProduct.Controllers
{
    public class TokenController : Controller
    {

        [Route("api/CreateToken")]
        [AllowAnonymous]
        [HttpPost]
        [Produces("application/json")]
        public IActionResult CreateToken([FromBody] ModelUser user)
        {
            if (user.name != "jesiel" || user.password != "1234")
                return Unauthorized();

            var token = new TokenJWTBuilder()
                .AddSecurityKey(Provider.JWTSecurityKey.Create("Secret_Key-12345678"))
                .AddSubject("Jesiel")
                .AddIssuer("Teste.Securiry.Bearer")
                .AddAudience("Teste.Securiry.Bearer")
                .AddClaim("UsuarioAPINumero", "1")
                .AddExpiry(3)
                .Builder();

            return Ok(token.value);
        }
    }
}
