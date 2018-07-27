using EcommerceOsorio.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace EcommerceOsorio.Controllers
{
    public class ProdutoController : Controller
    {
        Context context = new Context();
        // GET: Produto
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            ViewBag.Produtos = context.Produtos.ToList();
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

            context.Produtos.Add(produto);
            context.SaveChanges();
            return RedirectToAction("Index", "Produto");
        }
    }
}