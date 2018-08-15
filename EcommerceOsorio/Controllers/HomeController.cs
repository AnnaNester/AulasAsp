using EcommerceOsorio.DAL;
using System.Web.Mvc;

namespace EcommerceOsorio.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int? id)
        {
            ViewBag.Categorias = CategoriaDAO.RetornarCategoria();
            if (id ==null)
            {
                return View(ProdutoDAO.RetornarProdutos());
            }
            return View(ProdutoDAO.BuscarProdutoPorCategoria(id));
        }

        public ActionResult ProdutoDetalhe(int id)
        {
            return View(ProdutoDAO.BuscarProdutoPorId(id));
        }



    }
}