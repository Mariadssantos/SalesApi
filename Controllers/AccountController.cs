using MarcusDesafio.Data;
using MarcusDesafio.Helpers;
using MarcusDesafio.Models;
using MarcusDesafio.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MarcusDesafio.Controllers
{
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly dbContext _context;

        public AccountController(dbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("/api/v1/auth")]
        public async Task<IActionResult> Auth([FromBody] User user)
        {
            try
            {

                var userExists = _context.User.Where(x => x.Username.Contains(user.Username)).FirstOrDefault();

                if (userExists == null)
                    return BadRequest(new { Message = "Username e/ou senha está(ão) inválido(s)." });

                var matchPassword = _context.User.Where(x => x.Password.Contains(user.Password));

                if (matchPassword == null)
                {
                    return BadRequest(new { Message = "Email e/ou senha está(ão) inválido(s)." });
                }

                var token = JwtAuth.GenerateToken(userExists);

                return Ok(new
                {
                    Token = token,
                    Usuario = userExists
                });

            }
            catch (Exception)
            {
                return BadRequest(new { Message = "Ocorreu algum erro interno na aplicação, por favor tente novamente." });
            }
        }
    }
}
