using EcommerceOsorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceOsorio.DAL
{
    public class UsuarioDAO
    {
        private static Context context = SingletonContext.GetInstance();

        public static List<Usuario> RetornarUsuarios()
        {
            return context.Usuarios.ToList();
        }

        public static Usuario BuscarUsuarioPorEmail(Usuario usuario)
        {
            return context.Usuarios.FirstOrDefault(x => x.Email.Equals(usuario.Email));
        }

        public static bool CadastrarUsuario(Usuario usuario)
        {
            if(BuscarUsuarioPorEmail(usuario) == null)
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static Usuario BuscarUsuarioPorEmailSenha (Usuario usuario)
        {
            return context.Usuarios.FirstOrDefault(x => x.Email.Equals(usuario.Email) && x.Senha.Equals(usuario.Senha));
        }
    }

}