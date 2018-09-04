using EcommerceOsorio.DAL;
using EcommerceOsorio.Models;
using EcommerceOsorio.Utils;
using EcommerceOsorioManha.DAL;
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
                    CarrinhoId = Sessao.RetornarCarrinhoId()
                };
                ItemVendaDAO.CadastrarVenda(itemVenda);
                return RedirectToAction("CarrinhoCompras");
        }

        public ActionResult CarrinhoCompras()
        {
            ViewBag.Total = ItemVendaDAO.RetornarTotal();
            return View(ItemVendaDAO.BuscarItensVendaPorCarrinhoId());
        }

        public ActionResult RemoverCarrinho(int id)
        {
            ItemVendaDAO.RemoverProduto(id);
            return RedirectToAction("CarrinhoCompras", "Home");
        }

        public ActionResult AdicionarCarrinho(int id)
        {
            ItemVendaDAO.AumentarItem(id);
            return RedirectToAction("CarrinhoCompras", "Home");
        }

        public ActionResult DiminuirCarrinho(int id)
        {
            ItemVendaDAO.DiminuirItem(id);
            return RedirectToAction("CarrinhoCompras", "Home");
        }

        public ActionResult FinalizarCompra()
        {
            ViewBag.Itens = ItemVendaDAO.BuscarItensVendaPorCarrinhoId();
            return View();
        }

        [HttpPost]
        public ActionResult FinalizarCompra(Venda venda)
        {
            venda.CarrinhoId = Sessao.RetornarCarrinhoId();
            venda.ItensVenda = ItemVendaDAO.BuscarItensVendaPorCarrinhoId();
            Sessao.ZerarSessaoCarrinho();
            VendaDAO.CadastrarVenda(venda);
            return RedirectToAction("Index", "Home");
        }

    }
}