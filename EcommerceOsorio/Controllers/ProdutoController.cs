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
            return View(ProdutoDAO.RetornarProdutos());
        }

        public ActionResult CadastrarProduto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarProduto(Produto produto)
        {
            if (ModelState.IsValid)
            { 
                if (ProdutoDAO.CadastrarProduto(produto))
                {
                    return RedirectToAction("Index", "Produto");
                }
                else
                {
                    ModelState.AddModelError("", "Não é possível adicionar um produto com o mesmo nome!");
                    return View(produto);
                }
                
                
            }
            else
            {
                return View(produto);
            }
        }

        public ActionResult AlterarProduto(int id)
        {
            return View(ProdutoDAO.BuscarProdutoPorId(id));
        }

        [HttpPost]
        public ActionResult AlterarProduto(Produto produtoAlterado)
        {
            if (ModelState.IsValid)
            { 
                Produto produtoOriginal = ProdutoDAO.BuscarProdutoPorId(produtoAlterado.ProdutoId);
                produtoOriginal.NomeProduto = produtoAlterado.NomeProduto;
                produtoOriginal.DescricaoProduto = produtoAlterado.DescricaoProduto;
                produtoOriginal.PrecoProduto = produtoAlterado.PrecoProduto;
                produtoOriginal.CategoriaProduto = produtoAlterado.CategoriaProduto;


                if (ProdutoDAO.AlterarProduto(produtoAlterado))
                {
                    return RedirectToAction("Index", "Produto");
                }
                else
                {
                    ModelState.AddModelError("", "Não é possível alterar o produto com o mesmo nome!");
                    return View(produtoAlterado);
                }
            }
            else
            {
                return View(produtoAlterado);
            }
        }

        public ActionResult RemoverProduto(int id)
        {
            ProdutoDAO.RemoverProduto(id);
            return RedirectToAction("Index", "Produto");
        }
    }
}