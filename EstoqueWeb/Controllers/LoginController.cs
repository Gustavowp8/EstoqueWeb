using EstoqueWeb.Data;
using EstoqueWeb.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EstoqueWeb.Controllers
{
    public class LoginController : Controller
    {

        private readonly Context db;

        public LoginController(Context db)
        {
            this.db = db;
        }

        public IActionResult Entrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Entrar(string login, string senha)
        {
            UsuarioModel usuariologado = db.Usuarios.Where(a => a.Login == login && a.Senha == senha).FirstOrDefault();

            if (usuariologado == null)
            {
                TempData["mensagem"] = MensagemModel.Serializar("Usuario ou senha errado tente novamente.", TipoMensagem.Erro);
                return View();
            }
            else
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, usuariologado.Nome));
                claims.Add(new Claim(ClaimTypes.Sid, usuariologado.IdUsuario.ToString()));

                var userIdentity = new ClaimsIdentity(claims, "Acesso");

                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync("CookieAuthentication", principal, new AuthenticationProperties());

                TempData["mensagem"] = MensagemModel.Serializar("Bem vindo.");

                return Redirect("/");
            }
        }

        public async Task<IActionResult> Logoff()
        {
            await HttpContext.SignOutAsync("CookieAuthentication");
            return Redirect("/Login/Entrar");
        }
    }
}
