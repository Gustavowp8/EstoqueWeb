using EstoqueWeb.Data;
using EstoqueWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstoqueWeb.Controllers
{
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
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
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
