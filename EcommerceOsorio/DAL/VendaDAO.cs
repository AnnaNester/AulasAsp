using EcommerceOsorio.DAL;
using EcommerceOsorio.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EcommerceOsorioManha.DAL
{
    public class VendaDAO
    {
        private static Context context = SingletonContext.GetInstance();

        public static void CadastrarVenda(Venda venda)
        {
            context.Vendas.Add(venda);
            context.SaveChanges();
        }
    }
}
