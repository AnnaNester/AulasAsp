using EcommerceOsorio.DAL;
using System.Web.Mvc;

namespace EcommerceOsorio.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(CategoriaDAO.RetornarCategoria());
        }

        [HttpPost]
        public ActionResult ListarProduto(int id)
        {
            return View();
        }


    }
}