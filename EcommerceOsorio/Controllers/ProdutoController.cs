using System.Web.Mvc;

namespace EcommerceOsorio.Controllers
{
    public class ProdutoController : Controller
    {
        // GET: Produto
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CadastrarProduto()
        {
            return View();
        }

        public ActionResult CadastrarProduto(string txtNome, string txtDescricao, string txtPreco, string txtCategoria)
        {
            return View();
        }
    }
}