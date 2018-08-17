using EcommerceOsorio.DAL;
using EcommerceOsorio.Models;
using System;
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

        public ActionResult AdicionarAoCarrinho (int id)
        {
            Produto produto = ProdutoDAO.BuscarProdutoPorId(id);
            ItemVenda itemVenda = new ItemVenda
            {
                ProdutoVenda = produto,
                QtdeVenda = 1,
                PrecoVenda = produto.PrecoProduto,
                DataVenda = DateTime.Now,
            };
            ItemVendaDAO.CadastrarVenda(itemVenda);
            return RedirectToAction("CarrinhoCompras");
        }

        public ActionResult CarrinhoCompras()
        {
            return View(ItemVendaDAO.RetornarVenda());
        }

    }
}