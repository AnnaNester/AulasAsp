﻿using EcommerceOsorio.Models;
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

        public static void CadastrarProduto (Produto produto)
        {
            context.Produtos.Add(produto);
            context.SaveChanges();
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

        public static void AlterarProduto (Produto produto)
        {
            context.Entry(produto).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}