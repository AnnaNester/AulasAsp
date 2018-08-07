using EcommerceOsorio.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EcommerceOsorio.DAL
{
    public class CategoriaDAO
    {
        private static Context context = new Context();

        public static List<Categoria> RetornarCategoria()
        {
            return context.Categoria.ToList();
        }

        public static bool CadastrarCategoria(Categoria categoria)
        {
            if (BuscarCategoriaPorNome(categoria) == null)
            {
                context.Categoria.Add(categoria);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static Categoria BuscarCategoriaPorId(int id)
        {
            return context.Categoria.Find(id);
        }

        public static void RemoverCategoria(int id)
        {
            context.Categoria.Remove(BuscarCategoriaPorId(id));
            context.SaveChanges();
        }

        public static bool AlterarCategoria(Categoria categoria)
        {
            if (context.Categoria.FirstOrDefault(x => x.NomeCategoria.Equals(categoria.NomeCategoria) && x.CategoriaId != categoria.CategoriaId) == null)
            {
                context.Entry(categoria).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static Categoria BuscarCategoriaPorNome(Categoria categoria)
        {
            return context.Categoria.FirstOrDefault(x => x.NomeCategoria.Equals(categoria.NomeCategoria));
        }
    }
}