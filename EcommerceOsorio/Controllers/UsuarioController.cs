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
using System.Text;
using Newtonsoft.Json;

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
            if(TempData["Mensagem"] != null)
            {
                ModelState.AddModelError("", TempData["Mensagem"].ToString());
            }
            return View((Usuario)TempData["Usuario"]);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsuarioId, Nome, Email, Senha, ConfirmacaoSenha, Logradouro, Localidade, UF, Cep, Bairro")] Usuario usuario)
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

        [HttpPost]
        public ActionResult PesquisarCep(Usuario usuario)
        {
            try
            {
                //Download da string em JSON
                string url = "https://viacep.com.br/ws/" + usuario.Cep + "/json/";
                WebClient client = new WebClient();
                string json = client.DownloadString(url);

                //Converter a string para UTF-8
                byte[] bytes = Encoding.Default.GetBytes(json);
                json = Encoding.UTF8.GetString(bytes);

                //Converter o JSON para objeto
                usuario = JsonConvert.DeserializeObject<Usuario>(json);

                //passar informação para qualquer Action do Controller
                TempData["Usuario"] = usuario;
            }
            catch (Exception)
            {
                TempData["Mensagem"] = "CEP inválido!";
            }

            return RedirectToAction("Create", "Usuario");
        }

    }
}
