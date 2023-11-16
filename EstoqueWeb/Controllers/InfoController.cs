using Microsoft.AspNetCore.Mvc;

namespace EstoqueWeb.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
