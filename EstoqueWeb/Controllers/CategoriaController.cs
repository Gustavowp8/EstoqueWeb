using EstoqueWeb.Data;
using EstoqueWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstoqueWeb.Controllers
{
    [Authorize(AuthenticationSchemes = "CookieAuthentication")]
    public class CategoriaController : Controller
    {

        private readonly Context db;

        public CategoriaController(Context db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Categorias.OrderBy(x => x.Nome).AsNoTracking().ToListAsync());
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Adicionar(CategoriaModel categoria)
        {
            try
            {
                db.Categorias.Add(categoria);
                db.SaveChanges();
                TempData["mensagem"] = MensagemModel.Serializar("Categoria cadastrado com sucesso.");
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                TempData["mensagem"] = MensagemModel.Serializar("Erro ao cadastra categoria.", TipoMensagem.Erro);
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Apagar(int id)
        {
            db.Categorias.Remove(db.Categorias.Where(a => a.IdCategoria == id).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
