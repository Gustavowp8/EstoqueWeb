using EstoqueWeb.Data;
using EstoqueWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstoqueWeb.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly Context db;

        public UsuarioController(Context db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Usuarios.OrderBy(x => x.Nome).AsNoTracking().ToListAsync());
        }

        public IActionResult CriarUsuario()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CriarUsuario(UsuarioModel usuario)
        {
            try
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //Apagar um usuario
        public ActionResult Apagar(int id)
        {
            db.Usuarios.Remove(db.Usuarios.Where(a => a.IdUsuario == id).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
