using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EcommerceOsorio.Models;
using EcommerceOsorio.DAL;
using System.Web.Security;

namespace EcommerceOsorio.Controllers
{
    public class UsuarioController : Controller
    {
        private Context context = new Context();

        // GET: Usuario
        public ActionResult Index()
        {
            return View(UsuarioDAO.RetornarUsuarios());
        }


        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuarioId,Nome,Email,Senha, ConfirmacaoSenha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                if(UsuarioDAO.CadastrarUsuario(usuario))
                {
                    return RedirectToAction("Index", "Usuario");
                }
                ModelState.AddModelError("", "Esse usuário já existe!");
                return View(usuario);
            }

            return View(usuario);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "Email,Senha")] Usuario usuario)
        {
            usuario = UsuarioDAO.BuscarUsuarioPorEmailSenha(usuario);

            if (usuario != null)
            {
                FormsAuthentication.SetAuthCookie(usuario.Email, false);
                return RedirectToAction("Index", "Produto");
            }
            ModelState.AddModelError("", "O e-mail ou senha não coincidem!");
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

    }
}
