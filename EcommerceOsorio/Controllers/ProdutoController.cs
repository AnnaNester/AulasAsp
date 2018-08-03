using EcommerceOsorio.DAL;
using EcommerceOsorio.Models;
using System;
using System.Web.Mvc;

namespace EcommerceOsorio.Controllers
{
    public class ProdutoController : Controller
    {
        public ActionResult ListarProduto()
        {
            ProdutoDAO.RetornarProdutos();
            return View();
        }


        // GET: Produto
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            ViewBag.Produtos = ProdutoDAO.RetornarProdutos();
            return View();
        }

        public ActionResult CadastrarProduto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarProduto(string txtNome, string txtDescricao, string txtPreco, string txtCategoria)
        {
            Produto produto = new Produto
            {
                NomeProduto = txtNome,
                DescricaoProduto = txtDescricao,
                PrecoProduto = Convert.ToDouble(txtPreco),
                CategoriaProduto = txtCategoria
            };
            ProdutoDAO.CadastrarProduto(produto);
            return RedirectToAction("Index", "Produto");
        }

        public ActionResult AlterarProduto(int id)
        {
            ViewBag.Produto = ProdutoDAO.BuscarProdutoPorId(id);
            return View();
        }

        [HttpPost]
        public ActionResult AlterarProduto(string txtNome, string txtDescricao, string txtPreco, string txtCategoria, int txtId)
        {
            Produto produto = ProdutoDAO.BuscarProdutoPorId(txtId);
            produto.NomeProduto = txtNome;
            produto.DescricaoProduto = txtDescricao;
            produto.PrecoProduto = Convert.ToDouble(txtPreco);
            produto.CategoriaProduto = txtCategoria;

            ProdutoDAO.AlterarProduto(produto);
            return RedirectToAction("Index", "Produto");
        }

        public ActionResult RemoverProduto(int id)
        {
            ProdutoDAO.RemoverProduto(id);
            return RedirectToAction("Index", "Produto");
        }
    }
}