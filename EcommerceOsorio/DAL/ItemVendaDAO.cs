using EcommerceOsorio.Models;
using System.Collections.Generic;
using System.Linq;

namespace EcommerceOsorio.DAL
{
    public class ItemVendaDAO
    {
        private static Context context = SingletonContext.GetInstance();

        public static List<ItemVenda> RetornarVendaCarrinhoId()
        {
            return context.ItensVenda.ToList();
        }

        public static void CadastrarVenda(ItemVenda venda)
        {
                context.ItensVenda.Add(venda);
                context.SaveChanges();
            
        }

        public static List<ItemVenda> BuscarCarrinhoId (string idCarrinho)
        {
            return context.ItensVenda.Include("ProdutoVenda").Where(x => x.CarrinhoId.Equals(idCarrinho)).ToList();
        }

        public static void RemoverProduto(int id)
        {
            ItemVenda venda = BuscarPorId(id);
            if (venda.QtdeVenda > 1)
            {
                venda.QtdeVenda--;
            }
            else
            {
                context.ItensVenda.Remove(venda);
                context.SaveChanges();
            }
        }

        public static ItemVenda BuscarPorId(int id)
        {
            return context.ItensVenda.Find(id);
        }
    }
}