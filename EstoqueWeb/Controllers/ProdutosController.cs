using EstoqueWeb.Data;
using EstoqueWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EstoqueWeb.Controllers
{
    public class ProdutosController : Controller
    {

        private readonly Context db;

        public ProdutosController(Context db)
        {
            this.db = db;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Produtos.OrderBy(x => x.Nome).Include(a => a.Categoria).AsNoTracking().ToListAsync());
        }

        public IActionResult Cadastrar()
        {
            ProdutosTela model = new ProdutosTela();
            model.ListaCategorias = db.Categorias.ToList();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastrar(ProdutoModel produto)
        {
            try
            {
                db.Produtos.Add(produto);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
