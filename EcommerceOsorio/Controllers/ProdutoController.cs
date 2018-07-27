using EcommerceOsorio.Models;
using System;
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
            return View();
        }
    }
}