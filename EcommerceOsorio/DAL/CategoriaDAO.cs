using EcommerceOsorio.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EcommerceOsorio.DAL
{
    public class CategoriaDAO
    {
        private static Context context = SingletonContext.GetInstance();

        public static List<Categoria> RetornarCategoria()
        {
            return context.Categorias.ToList();
        }

        public static bool CadastrarCategoria(Categoria categoria)
        {
            if (BuscarCategoriaPorNome(categoria) == null)
            {
                context.Categorias.Add(categoria);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static Categoria BuscarCategoriaPorId(int? id)
        {
            return context.Categorias.Find(id);
        }

        public static void RemoverCategoria(int id)
        {
            context.Categorias.Remove(BuscarCategoriaPorId(id));
            context.SaveChanges();
        }

        public static bool AlterarCategoria(Categoria categoria)
        {
            if (context.Categorias.FirstOrDefault(x => x.NomeCategoria.Equals(categoria.NomeCategoria) && x.CategoriaId != categoria.CategoriaId) == null)
            {
                context.Entry(categoria).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static Categoria BuscarCategoriaPorNome(Categoria categoria)
        {
            return context.Categorias.FirstOrDefault(x => x.NomeCategoria.Equals(categoria.NomeCategoria));
        }
    }
}