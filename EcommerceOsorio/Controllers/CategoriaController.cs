using EcommerceOsorio.DAL;
using EcommerceOsorio.Models;
using System;
using System.Web.Mvc;

namespace EcommerceOsorio.Controllers
{
    public class CategoriaController : Controller
    {
        public ActionResult ListarCategoria()
        {
            CategoriaDAO.RetornarCategoria();
            return View();
        }


        // GET: Produto
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            return View(CategoriaDAO.RetornarCategoria());
        }

        public ActionResult CadastrarCategoria()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CadastrarCategoria(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                if (CategoriaDAO.CadastrarCategoria(categoria))
                {
                    return RedirectToAction("Index", "Categoria");
                }
                else
                {
                    ModelState.AddModelError("", "Não é possível adicionar uma categoria com o mesmo nome!");
                    return View(categoria);
                }


            }
            else
            {
                return View(categoria);
            }
        }

        public ActionResult AlterarCategoria(int id)
        {
            return View(ProdutoDAO.BuscarProdutoPorId(id));
        }

        [HttpPost]
        public ActionResult AlterarCategoria(Categoria categoriaAlterada)
        {
            if (ModelState.IsValid)
            {
                Categoria categoriaOriginal = CategoriaDAO.BuscarCategoriaPorId(categoriaAlterada.CategoriaId);
                categoriaOriginal.NomeCategoria = categoriaAlterada.NomeCategoria;
                categoriaOriginal.DescricaoCategoria = categoriaAlterada.DescricaoCategoria;

                if (CategoriaDAO.AlterarCategoria(categoriaAlterada))
                {
                    return RedirectToAction("Index", "Categoria");
                }
                else
                {
                    ModelState.AddModelError("", "Não é possível alterar a categoria com o mesmo nome!");
                    return View(categoriaAlterada);
                }
            }
            else
            {
                return View(categoriaAlterada);
            }
        }

        public ActionResult RemoverCategoria(int id)
        {
            CategoriaDAO.RemoverCategoria(id);
            return RedirectToAction("Index", "Categoria");
        }
    }
}