using EcommerceOsorio.Models;
using EcommerceOsorio.Utils;
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
            string carrinhoId = Sessao.RetornarCarrinhoId();
            ItemVenda item = context.ItensVenda.Include("ProdutoVenda").FirstOrDefault(x => x.ProdutoVenda.ProdutoId == venda.ProdutoVenda.ProdutoId && x.CarrinhoId.Equals(carrinhoId));
            if(item == null)
            {
                context.ItensVenda.Add(venda);
            }
            else
            {
                item.QtdeVenda++;
            }
            context.SaveChanges();
            
        }

        public static List<ItemVenda> BuscarCarrinhoId ()
        {
            string carrinhoId = Sessao.RetornarCarrinhoId();
            return context.ItensVenda.Include("ProdutoVenda").Where(x => x.CarrinhoId.Equals(idCarrinho)).ToList();
        }

        public static void RemoverProduto(int id)
        {
            ItemVenda venda = context.ItensVenda.Find(id);
            if (venda.QtdeVenda > 1)
            {
                venda.QtdeVenda--;
            }
            else
            {
                context.ItensVenda.Remove(venda);
            }
            context.SaveChanges();
        }

        public static void DiminuirItem(int id)
        {
            ItemVenda venda = context.ItensVenda.Find(id);
            if (venda.QtdeVenda > 1)
            {
                venda.QtdeVenda--;
                context.SaveChanges();
            }
        }

        public static void AumentarItem(int id)
        {
            ItemVenda venda = context.ItensVenda.Find(id);
            venda.QtdeVenda++;
            context.SaveChanges();
        }

        public static double RetornarTotal()
        {
            return BuscarCarrinhoId().Sum(x => x.QtdeVenda * x.PrecoVenda);
        }

        public static double RetornarQuantidade()
        {
            return BuscarCarrinhoId().Sum(x => x.QtdeVenda);
        }
    }
}