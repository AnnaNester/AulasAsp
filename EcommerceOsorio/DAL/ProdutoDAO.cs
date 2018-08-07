using EcommerceOsorio.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace EcommerceOsorio.DAL
{
    public class ProdutoDAO
    {
        private static Context context = new Context();

        public static List<Produto> RetornarProdutos()
        {
            return context.Produtos.ToList();
        }

        public static bool CadastrarProduto (Produto produto)
        {
            if (BuscarProdutoPorNome(produto) == null)
            {
                context.Produtos.Add(produto);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public static Produto BuscarProdutoPorId(int id)
        {
            return context.Produtos.Find(id);
        }

        public static void RemoverProduto (int id)
        {
            context.Produtos.Remove(BuscarProdutoPorId(id));
            context.SaveChanges();
        }

        public static bool AlterarProduto (Produto produto)
        {
            if (context.Produtos.FirstOrDefault(x => x.NomeProduto.Equals(produto.NomeProduto) && x.ProdutoId != produto.ProdutoId) == null)
                { 
                    context.Entry(produto).State = EntityState.Modified;
                    context.SaveChanges();
                return true;
                }
            return false;
        }

        public static Produto BuscarProdutoPorNome(Produto produto)
        {
            return context.Produtos.FirstOrDefault(x => x.NomeProduto.Equals(produto.NomeProduto));
        }
    }
}