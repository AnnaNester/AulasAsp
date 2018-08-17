using EcommerceOsorio.Models;
using System.Collections.Generic;
using System.Linq;

namespace EcommerceOsorio.DAL
{
    public class ItemVendaDAO
    {
        private static Context context = SingletonContext.GetInstance();

        public static List<ItemVenda> RetornarVenda()
        {
            return context.ItensVenda.ToList();
        }

        public static void CadastrarVenda(ItemVenda venda)
        {
            context.ItensVenda.Add(venda);
            context.SaveChanges();
        }
    }
}